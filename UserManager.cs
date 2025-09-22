using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace GfWLUtility
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    internal struct GamertagString
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x10)]
        public string Value;

        public static implicit operator string(GamertagString value)
        {
            return value.Value;
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct XamAccount
    {
        public uint Flags1;

        public uint Flags2;

        [MarshalAs(UnmanagedType.Struct)]
        public GamertagString Gamertag;

        public ulong OnlineXUID;

        public uint Flags3;

        public uint OnlineServiceID;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x4)]
        public byte[] Passcode; // unused in GfWL..?

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x14)]
        public string Domain; // unused in GfWL

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x18)]
        public string Realm; // unused in GfWL

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x10)]
        public byte[] OnlineKey; // unused in GfWL

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x72)]
        public string PassportEmail;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
        public string PassportPassword; // unused in GfWL

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x72)]
        public string OwnerPassportEmail; // unused in GfWL
    }

    internal class KnownUser
    {
        public ulong XUID;
        public Bitmap ProfilePicture;
        public bool HasFullInformation;

        public string Gamertag;
        public bool LiveEnabled;
        public bool Pnet;
        public ulong OnlineXUID;
        public string MsaEmail;

        public KnownUser(ulong xuid)
        {
            XUID = xuid;
        }

        public override string ToString()
        {
            if (Gamertag != null)
                return Gamertag;
            return $"{XUID:X} (Unknown)";
        }
    }

    internal class UserManager
    {
        public static Dictionary<ulong, KnownUser> KnownUsers = new Dictionary<ulong, KnownUser>();

        public static void FoundUserExists(ulong xuid)
        {
            if (!KnownUsers.ContainsKey(xuid))
                KnownUsers[xuid] = new KnownUser(xuid);
        }

        public static void FoundUserGamertag(ulong xuid, string name)
        {
            FoundUserExists(xuid);
            KnownUsers[xuid].Gamertag = name;
        }

        public static void PopulateUserInformation(ulong xuid, string accountFile = null)
        {
            FoundUserExists(xuid);
            byte[] accBytes = null;
            // if we're given one, attempt to decrypt profile information directly
            if (accountFile != null)
            {
                byte[] encBytes = File.ReadAllBytes(accountFile);
                accBytes = XeKeys.UnObfuscate(encBytes);
            }
            // otherwise check if we have decrypted profile information in the account cache
            if (accBytes == null)
            {
                string accCacheFilename = UtilityFuncs.GetLocalDirectory("ProfileCache") + xuid.ToString("x16") + ".bin";
                if (File.Exists(accCacheFilename))
                    accBytes = File.ReadAllBytes(accCacheFilename);
            }
            // if we have a byte stream of the right length of a decrypted account file, hooray
            if (accBytes != null && accBytes.Length == 0x17C)
            {
                XamAccount account = UtilityFuncs.BytesToStructure<XamAccount>(accBytes);
                KnownUsers[xuid].Gamertag = account.Gamertag;
                if ((account.Flags1 & 0x20000000) == 0x20000000)
                    KnownUsers[xuid].LiveEnabled = true;
                KnownUsers[xuid].OnlineXUID = account.OnlineXUID;
                KnownUsers[xuid].Pnet = account.OnlineServiceID == 0x54524150;
                KnownUsers[xuid].MsaEmail = account.PassportEmail;
                KnownUsers[xuid].HasFullInformation = true;
            }
        }
    }
}
