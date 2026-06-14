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
        private ManualAES128 _manualAes;

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

        private void SetUpCustomAes(byte[][] roundKeys)
        {
            _manualAes = new ManualAES128(roundKeys);
        }

        public PanoramaCrypto(int keySet)
        {
            _keySet = keySet;
            // we have the system link key available thanks to x360
            // thank you to widberg for reversing the round keys for obfuscation
            if (_keySet == 1)
                SetUpCustomAes(new byte[12][] {
                    new byte[0x10] { 0xc3,0x95,0xf2,0x3c,0x0d,0x14,0xb8,0x7f,0xe2,0xa5,0x69,0xc2,0xdb,0x81,0x58,0xba },
                    new byte[0x10] { 0xa4,0x27,0xb2,0x96,0x0e,0xa2,0x62,0x75,0x03,0xb6,0xda,0x0a,0xe1,0x13,0xb3,0xc8 },
                    new byte[0x10] { 0x3a,0x92,0xeb,0x72,0x9e,0xb5,0x59,0xe4,0xd9,0x69,0x0b,0x7e,0xda,0xdf,0xd1,0x74 },
                    new byte[0x10] { 0x3b,0xcc,0x62,0xbc,0x01,0x5e,0x89,0xce,0x9f,0xeb,0xd0,0x2a,0x34,0x19,0xee,0xa5 },
                    new byte[0x10] { 0xee,0xc6,0x3f,0xd1,0xd5,0x0a,0x5d,0x6d,0xd4,0x54,0xd4,0xa3,0x4b,0xbf,0x04,0x89 },
                    new byte[0x10] { 0x34,0xeb,0x49,0x16,0xda,0x2d,0x76,0xc7,0x0f,0x27,0x2b,0xaa,0xdb,0x73,0xff,0x09 },
                    new byte[0x10] { 0x90,0xcc,0xfb,0x80,0x6f,0xe4,0x84,0x76,0xb5,0xc9,0xf2,0xb1,0xba,0xee,0xd9,0x1b },
                    new byte[0x10] { 0x61,0x9d,0x26,0x12,0xf1,0x51,0xdd,0x92,0x9e,0x25,0xcb,0xd7,0x2b,0xec,0x39,0x66 },
                    new byte[0x10] { 0x91,0x02,0xe0,0x7d,0xf0,0x9f,0xc6,0x6f,0x01,0xce,0x1b,0xfd,0x55,0x8a,0x9f,0xab },
                    new byte[0x10] { 0x7e,0x66,0xa6,0xcd,0xef,0x64,0x46,0xb0,0x1f,0xfb,0x80,0xdf,0x1e,0x35,0x9b,0x22 },
                    new byte[0x10] { 0x43,0x9e,0x0c,0xd9,0x3d,0xf8,0xaa,0x14,0xd2,0x9c,0xec,0xa4,0xcd,0x67,0x6c,0x7b },
                    new byte[0x10] { 0xd3,0x52,0xf7,0x59,0x58,0xf6,0xc7,0xbf,0x65,0x0e,0x6d,0xab,0xb7,0x92,0x81,0x0f },
                });
            else if (_keySet == 2)
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

        private byte[] ManualAesDecrypt(byte[] input_block)
        {
            byte[] output_block = new byte[0x10];
            Buffer.BlockCopy(input_block, 0, output_block, 0, 0x10);
            _manualAes.DecryptBlock(output_block);
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
            else if (_keySet == 1)
                return ManualAesDecrypt(block);
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
