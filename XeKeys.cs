using System;
using System.Linq;

namespace GfWLUtility
{
    /*
     * For Xbox 360 researchers among us who might've stumbled upon this code,
     * this is not what you're looking for, at all.
     * 
     * I recommend checking out emoose's ExCrypt library for a reference of
     * Xbox 360 XeKeys, which will be much more useful for you:
     * https://github.com/emoose/ExCrypt
     */

    internal class XeKeys
    {
        public static byte[] UnObfuscate(byte[] input)
        {
            // skip over the header - this is populated on xenon but not xlive
            byte[] buffer = input.Skip(0x18).ToArray();
            try
            {
                return PanoramaCrypto.Obfuscation.DecryptBuffer(buffer);
            } catch (Exception)
            {
                return null;
            }
        }
    }
}
