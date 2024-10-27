using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GfWLUtility
{
    internal class KnownUser
    {
        public ulong XUID;
        public string Gamertag;
        public bool LiveEnabled;
        public ulong OnlineXUID;
        public Bitmap ProfilePicture;

        public KnownUser(ulong xuid)
        {
            XUID = xuid;
        }

        public override string ToString()
        {
            if (Gamertag != null)
                return Gamertag;
            return $"{XUID:X}";
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
    }
}
