# GfWL Utility

Work-in-progress highly incomplete utility for working with Games for Windows - LIVE.

This is incomplete. There will be bugs.

**Requires .NET Framework 3.5:**

* On Windows 8 and newer, you will get a prompt to install this if you do not have this.
* On Windows 7 when fully up-to-date, it should be included.
* On Windows XP and Vista, you will need to install [.NET Framework 3.5 SP1](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net35-sp1) manually.

## Current Features:

- View saved product keys
- View some profile metadata (not everything, see TODO)
- View some game information (not everything, see TODO)
- Create a backup of all GfWL data including product keys and config sectors
- Adding/removing GfWL domains from hosts for speedups, or to block LIVE
- Install the latest or mostly-latest versions of GfWL components
    - Xlive Runtime (3.5.92, *mildly outdated*)
	- Latest Games for Windows Marketplace Client (3.5.67.0, latest)
	- Windows Live ID Sign-In Assistant (6.500.3165.0, latest, on Windows XP, Vista and 7)

## TODO

Ordered roughly in order of what would be best to do first

- CAB extractor for installing 3.5.95.0 runtime
- Verify size/checksums after downloading
- Figure out AES-CBC encryption key (used by XeKeysUnObfuscate) for profile metadata
    - I do not think this is the Xbox 360 Roamable Obfuscation Key but there is a small chance it is
- Error handling everywhere
- Parsing for getting the game name and icon
- Ability to manage/clear per-game configs
- Downloading from other mirrors if a file is unavailable
- Support data importing from the data backups
- Other useful stuff
    - Key/PCID trick?

## Shoutouts

* [Legacy Update](https://legacyupdate.net) for providing mirrors for some assets
* [Free60 Wiki](https://free60.org/)
* [NeKzor's Xlive reversing from Tron Evolution](https://github.com/NeKzor/tem/blob/master/doc/src/reversed/xlive.md)
