# GfWL Utility

Work-in-progress utility for working with Games for Windows - LIVE.

This is incomplete. There will be bugs.

**Requires .NET Framework 3.5:**

* On Windows 8 and newer, you will get a prompt to install this if you do not have this.
* On Windows 7 when fully up-to-date, it should be included.
* On Windows XP and Vista, you will need to install [.NET Framework 3.5 SP1](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net35-sp1) manually.

## [Downloads](https://github.com/InvoxiPlayGames/GfWLUtility/releases)

It is recommended that you have the latest Windows Updates installed (if neccessary, use [Legacy Update](https://legacyupdate.net)!)

## Current Features:

- Install the latest or mostly-latest versions of GfWL components
    - Games for Windows - LIVE Runtime (3.5.95, latest)
	- Latest Games for Windows Marketplace Client (3.5.67.0, latest)
	- Windows Live ID Sign-In Assistant (6.500.3165.0, *mostly latest*, on Windows XP, Vista and 7)
- View and export saved product keys
- View profile/gamertag metadata (XUID, email)
- View game information
- Create a backup of all GfWL data including product keys and config sectors
- Adding/removing GfWL domains from hosts for speedups, or to block LIVE

## TODO

Ordered roughly in order of what would be best to do first

- Support data importing from the data backups
- Error handling everywhere
- Parsing for getting the game name and icon from GPD files
- Ability to manage/clear per-game configs
- Downloading from other mirrors if a file is unavailable
- Other useful stuff
- Figure out AES encryption (used by XeKeysUnObfuscate) for profile metadata
    - Currently, a Title Update for Shadowrun is used alongside a sideloaded DLL to dump profile metadata.

## Shoutouts

* [Legacy Update](https://legacyupdate.net) for providing mirrors for some assets
* [Free60 Wiki](https://free60.org/)
* [NeKzor's Xlive reversing from Tron Evolution](https://github.com/NeKzor/tem/blob/master/doc/src/reversed/xlive.md)
* [XLiveLessNess](https://gitlab.com/GlitchyScripts/xlivelessness)
