using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace GfWLUtility
{
    internal class KnownTitle
    {
        public uint TitleID;
        public string Name;
        public string ProductKey;
        public byte[] ConfigData;
        public Bitmap Icon;

        public KnownTitle(uint titleID)
        {
            TitleID = titleID;
        }

        public override string ToString()
        {
            if (Name != null)
                return Name;
            return $"{TitleID:X8} (Unknown)";
        }
    }

    internal class TitleManager
    {
        public static Dictionary<uint, KnownTitle> KnownTitles = new Dictionary<uint, KnownTitle>();

        public static void FoundTitleExists(uint titleID)
        {
            if (!KnownTitles.ContainsKey(titleID))
                KnownTitles[titleID] = new KnownTitle(titleID);
        }

        public static void FoundTitleName(uint titleID, string name)
        {
            FoundTitleExists(titleID);
            KnownTitles[titleID].Name = name;
        }

        public static string GetTitleProductKey(uint titleID)
        {
            if (KnownTitles.ContainsKey(titleID))
            {
                // if we already fetched the product key, don't try to fetch it again
                if (KnownTitles[titleID].ProductKey != null)
                    return KnownTitles[titleID].ProductKey;

                string rawTokenPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    $"Microsoft\\Xlive\\Titles\\{titleID:X8}\\Token.bin");
                if (File.Exists(rawTokenPath)) {
                    byte[] tokenBytes = File.ReadAllBytes(rawTokenPath);
                    // first 32-bits are a size, we can ignore that
                    byte[] rawTokenBytes = tokenBytes.Skip(4).ToArray();
                    // try to decrypt it, if we fail just assume the key is a dud
                    try
                    {
                        byte[] unprotectedBytes = ProtectedData.Unprotect(rawTokenBytes, null, DataProtectionScope.CurrentUser);
                        string productKey = Encoding.UTF8.GetString(unprotectedBytes);
                        KnownTitles[titleID].ProductKey = productKey;
                        return productKey;
                    } catch (Exception e)
                    {
                        return null;
                    }
                }
            }
            return null;
        }

        public static byte[] GetConfigSector(uint titleID, int sectorID)
        {
            if (KnownTitles.ContainsKey(titleID))
            {
                string configPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    $"Microsoft\\Xlive\\Titles\\{titleID:X8}\\config.bin");
                byte[] configData = null;
                if (KnownTitles[titleID].ConfigData == null)
                {
                    if (File.Exists(configPath))
                        KnownTitles[titleID].ConfigData = File.ReadAllBytes(configPath);
                    else
                        return null;
                }
                configData = KnownTitles[titleID].ConfigData;

                int sectorStart = sectorID * 0x400;
                // make sure the sector isn't empty
                if (configData[sectorStart] != 0x00)
                {
                    // copy it into a buffer and unprotect it
                    byte[] sector = new byte[0x400];
                    Buffer.BlockCopy(configData, sectorStart, sector, 0, 0x400);
                    // try to decrypt it, if we fail just assume the sector doesn't exist
                    try
                    {
                        byte[] unprotectedSector = ProtectedData.Unprotect(sector, null, DataProtectionScope.CurrentUser);
                        return unprotectedSector;
                    } catch (Exception e)
                    {
                        return null;
                    }
                } else
                {
                    return null;
                }
            }
            return null;
        }
    }
}
