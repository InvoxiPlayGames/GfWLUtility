using System;
using System.Linq;
using System.Security.Cryptography;

namespace GfWLUtility
{
    internal class DecryptionFailedException : Exception
    {
        public DecryptionFailedException(string message) : base(message) { }
    }
    internal class InvalidKeysetException : Exception
    {
        public InvalidKeysetException(string message) : base(message) { }
    }

    internal class PanoramaCrypto
    {
        private int _keySet;
        private ICryptoTransform _encryptor;
        private ICryptoTransform _decryptor;

        //public static PanoramaCrypto Stub = new PanoramaCrypto(0); // for testing CBC mode, not in xlive.dll

        public static PanoramaCrypto Obfuscation = new PanoramaCrypto(1); // obfuscation
        public static PanoramaCrypto SysLink = new PanoramaCrypto(2); // system link

        private void SetUpAes(byte[] key)
        {
            Aes aes = Aes.Create();
            aes.Key = key;
            aes.Mode = CipherMode.ECB;
            _encryptor = aes.CreateEncryptor();
            _decryptor = aes.CreateDecryptor();
        }

        public PanoramaCrypto(int keySet)
        {
            _keySet = keySet;
            // we have the system link key available thanks to x360
            // TODO(Emma): get the GfWL obfuscation keyset!
            if (_keySet == 2)
                SetUpAes(new byte[0x10] { 0x64, 0xFA, 0x1A, 0xC2, 0x0F, 0xD7, 0x58, 0x07, 0xCA, 0xE6, 0x74, 0xBA, 0xA3, 0xB4, 0x78, 0x7F });
        }

        private void XorWithIv(byte[] block, byte[] iv)
        {
            for (int i = 0; i < 0x10; i++)
                block[i] ^= iv[i];
        }

        private static byte[] StubDecrypt(byte[] input_block)
        {
            byte[] output_block = new byte[0x10];
            for (int i = 0; i < 0x10; i++)
                output_block[i] = (byte)~input_block[i];
            return output_block;
        }

        private byte[] AesDecrypt(byte[] input_block)
        {
            byte[] output_block = new byte[0x10];
            _decryptor.TransformBlock(input_block, 0, 0x10, output_block, 0);
            return output_block;
        }

        private byte[] AesEncrypt(byte[] input_block)
        {
            byte[] output_block = new byte[0x10];
            _encryptor.TransformBlock(input_block, 0, 0x10, output_block, 0);
            return output_block;
        }

        private byte[] Decrypt(byte[] block)
        {
            if (_keySet == 0)
                return StubDecrypt(block);
            else if (_keySet == 2)
                return AesDecrypt(block);
            throw new InvalidKeysetException("PanoramaCrypto doesn't support this key set for decryption");
        }

        private byte[] Encrypt(byte[] block)
        {
            if (_keySet == 0)
                return StubDecrypt(block);
            else if (_keySet == 2)
                return AesEncrypt(block);
            throw new InvalidKeysetException("PanoramaCrypto doesn't support this key set for encryption");
        }

        public byte[] DecryptBuffer(byte[] buffer, bool padding = true)
        {
            byte[] iv = new byte[0x10];
            byte[] currBlock = new byte[0x10];
            byte[] output = new byte[buffer.Length];
            // sanity check
            if (buffer.Length % 0x10 != 0)
                throw new DecryptionFailedException("Invalid length");
            // decrypt each block of the input data
            for (int i = 0; i < buffer.Length; i += 0x10)
            {
                Buffer.BlockCopy(buffer, i, currBlock, 0, 0x10);
                byte[] newBlock = Decrypt(currBlock);
                XorWithIv(newBlock, iv);
                Buffer.BlockCopy(currBlock, 0, iv, 0, 0x10);
                Buffer.BlockCopy(newBlock, 0, output, i, 0x10);
            }
            // hacky (and slow, inefficient) handling for PKCS#5 padding
            if (padding)
            {
                byte padByte = output[output.Length - 1];
                if (padByte <= 0x10)
                {
                    int num_pad_bytes = (int)padByte;
                    byte[] padding_bytes = output.Skip(output.Length - num_pad_bytes).ToArray();
                    if (padding_bytes.Length == padByte)
                    {
                        for (int i = 0; i < padding_bytes.Length; i++)
                            if (padding_bytes[i] != padByte)
                                throw new DecryptionFailedException("Invalid padding");
                    } else
                    {
                        throw new DecryptionFailedException("Invalid padding");
                    }
                    return output.Take(output.Length - num_pad_bytes).ToArray();
                }
                else
                {
                    throw new DecryptionFailedException("Invalid padding");
                }
            }
            return output;
        }
    }
}
