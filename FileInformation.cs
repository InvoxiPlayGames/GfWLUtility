using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GfWLUtility
{
    internal struct FileInformation
    {
        public string Filename;
        public string[] AltFilenames;
        public string[] DownloadURLs;
        public int Size;
        public byte[] Hash;
    }

    internal class StaticFileInformation
    {
        // tu10177600_35005f00.cab - the latest GfWL title update, contains XLiveUpdate.msi and wllogin_32/wllogin_64
        public static FileInformation titleupdate_3_5_95_cab = new FileInformation()
        {
            Filename = "tu10177600_35005f00.cab",
            AltFilenames = null,
            DownloadURLs = new string[]
            {
                // Official Microsoft URL
                "http://download.xbox.com/content/585207d1/tu10177600_35005f00.cab",
                // Legacy Update provided URL
                "http://content.legacyupdate.net/download.xbox.com/content/585207d1/tu10177600_35005f00.cab",
                // Internet Archive archived URL
                "http://web.archive.org/web/20191010213301id_/http://download.xbox.com/content/585207d1/tu10177600_35005f00.cab"
            },
            Size = 28021108,
            Hash = new byte[0x14]
            {
                0x71, 0xc7, 0xc7, 0xa0, 0x42, 0x47, 0x8d, 0x51, 0xf2, 0x5c, 0x47, 0x65, 0xac, 0xe7, 0xd0, 0x80, 0x8a, 0x9e, 0xe8, 0x4c
            }
        };

        // XLiveUpdate.msi - installs the XLive/GfWL redistributable used by applications
        public static FileInformation xliveupdate_3_5_95_msi = new FileInformation()
        {
            Filename = "XLiveUpdate.msi",
            AltFilenames = new string[] { "xliveredist.msi" },
            DownloadURLs = null, // only found in tu10177600_35005f00
            Size = 21594112,
            Hash = new byte[0x14]
            {
                0xad, 0x92, 0x4d, 0x74, 0x39, 0x47, 0x07, 0x3f, 0xe8, 0x27, 0x42, 0xe8, 0xf5, 0x29, 0xa3, 0x7e, 0xae, 0x07, 0x66, 0x2a
            }
        };

        // xliveredist.msi - a slightly older version of the xlive redistributable, latest available standalone
        public static FileInformation xliveredist_3_5_92_msi = new FileInformation()
        {
            Filename = "xliveredist.msi",
            AltFilenames = null,
            DownloadURLs = new string[]
            {
                // Official Microsoft URL
                "http://download.gfwl.xboxlive.com/content/gfwl-public/redists/production/xliveredist.msi",
                // Legacy Update provided URL
                "http://content.legacyupdate.net/download.gfwl.xboxlive.com/content/gfwl-public/redists/production/xliveredist.msi",
                // Internet Archive archived URL
                "http://web.archive.org/web/20141203142251id_/http://download.gfwl.xboxlive.com/content/gfwl-public/redists/production/xliveredist.msi"
            },
            Size = 21598208,
            Hash = new byte[0x14]
            {
                0xfc, 0x04, 0xd5, 0xc4, 0x95, 0x6f, 0xbf, 0x21, 0x36, 0xbd, 0xd4, 0xf2, 0xab, 0x15, 0x4e, 0xfb, 0xf5, 0xf6, 0xec, 0xa9
            }
        };

        // gfwlclient.msi - installs the Games for Windows Marketplace "dashboard" application
        public static FileInformation gfwlclient_msi = new FileInformation()
        {
            Filename = "gfwlclient.msi",
            AltFilenames = null,
            DownloadURLs = new string[]
            {
                // Official Microsoft URL
                "http://download.gfwl.xboxlive.com/content/gfwl-public/redists/production/gfwlclient.msi",
                // Legacy Update provided URL
                "http://content.legacyupdate.net/download.gfwl.xboxlive.com/content/gfwl-public/redists/production/gfwlclient.msi",
                // Internet Archive archived URL
                "http://web.archive.org/web/20141203142248id_/http://download.gfwl.xboxlive.com/content/gfwl-public/redists/production/gfwlclient.msi"
            },
            Size = 3375104,
            Hash = new byte[0x14]
            {
                0xdf, 0x6b, 0xe4, 0x41, 0xde, 0xed, 0x52, 0x54, 0x3c, 0xc1, 0xe8, 0xc7, 0x08, 0xa7, 0x2c, 0xa2, 0xca, 0x6b, 0xee, 0x92
            }
        };

        // wllogin_32.msi - x86 Windows Live Identity Client Runtime Library
        // !! DANGER: ONLY HAS 1 MIRROR !!
        public static FileInformation wllogin_32_msi = new FileInformation()
        {
            Filename = "wllogin_32.msi",
            AltFilenames = null,
            DownloadURLs = new string[]
            {
                // Internet Archive archived URL
                "http://web.archive.org/web/20200801000000id_/download.microsoft.com/download/7/4/0/740357D6-EFA8-43C1-A7DF-A8EEDD104638/wllogin_32.msi"
            },
            Size = 4649472,
            Hash = new byte[0x14]
            {
                0xf4, 0x77, 0xf8, 0xab, 0xc4, 0x51, 0x95, 0x32, 0xef, 0x29, 0x21, 0xb1, 0x34, 0x3a, 0x06, 0xf2, 0xac, 0x54, 0x6c, 0x2c
            }
        };

        // wllogin_64.msi - x64 Windows Live Identity Client Runtime Library. not used by GfWL but completeness
        // !! DANGER: ONLY HAS 1 MIRROR !!
        public static FileInformation wllogin_64_msi = new FileInformation()
        {
            Filename = "wllogin_64.msi",
            AltFilenames = null,
            DownloadURLs = new string[]
            {
                // Internet Archive archived URL
                "http://web.archive.org/web/20200801000000id_/download.microsoft.com/download/7/4/0/740357D6-EFA8-43C1-A7DF-A8EEDD104638/wllogin_64.msi"
            },
            Size = 6575616,
            Hash = new byte[0x14]
            {
                0x10, 0x78, 0xd3, 0x2c, 0xae, 0x64, 0xab, 0x1c, 0x5b, 0xce, 0x52, 0x63, 0x7e, 0xfa, 0xcb, 0xde, 0x70, 0xfa, 0x26, 0x70
            }
        };
    }
}
