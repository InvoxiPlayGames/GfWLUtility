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
        // list from XLiveLessNess
        // https://gitlab.com/GlitchyScripts/xlln-data/-/blob/main/XLiveLessNess/hub/titles.json?ref_type=heads
        public static Dictionary<uint, string> TitleNameDatabase = new Dictionary<uint, string>()
        {
            { 0x33390FA0, "7 Wonders 3" },
            { 0x33390FA1, "Chainz 2: Relinked" },
            { 0x35530FA0, "Cubis Gold" },
            { 0x35530FA1, "Cubis Gold 2" },
            { 0x35530FA2, "Ranch Rush 2" },
            { 0x355A0FA0, "Mahjongg Dimensions" },
            { 0x36590FA0, "TextTwist 2" },
            { 0x36590FA1, "Super TextTwist" },
            { 0x41560829, "007: Quantum of Solace" },
            { 0x41560FA0, "Call of Duty 4" },
            { 0x41560FA1, "Call of Duty: WaW" },
            { 0x41560FA2, "Singularity" },
            { 0x41560FA3, "Transformers: WFC" },
            { 0x41560FA4, "Blur" },
            { 0x41560FA5, "[PROTOTYPE]" },
            { 0x41560FA6, "007: Blood Stone" },
            { 0x415807D5, "BlazBlue: Calamity Trigger" },
            { 0x425307D6, "Fallout 3" },
            { 0x42530FA0, "Hunted Demon's Forge" },
            { 0x425607F3, "TRON: Evolution" },
            { 0x42560FA0, "LEGO Pirates of the Caribbean: The Video Game" },
            { 0x434307DE, "Lost Planet: Extreme Condition: Colonies Edition" },
            { 0x434307F4, "Street Fighter IV" },
            { 0x434307F7, "Resident Evil 5" },
            { 0x43430803, "Dark Void" },
            { 0x43430808, "Lost Planet 2" },
            { 0x4343080E, "Dead Rising 2" },
            { 0x43430FA0, "Super Street Fighter IV: Arcade Edition" },
            { 0x43430FA1, "Resident Evil: Operation Raccoon City" },
            { 0x43430FA2, "Dead Rising 2: Off the Record" },
            { 0x43430FA5, "Street Fighter X Tekken" },
            { 0x434D0820, "DiRT 2" },
            { 0x434D082F, "FUEL" },
            { 0x434D0831, "F1 2010" },
            { 0x434D083E, "Operation Flashpoint: Red River" },
            { 0x434D0FA0, "DiRT 3" },
            { 0x434D0FA1, "F1 2011" },
            { 0x44540FA0, "Crash Time 4: The Syndicate" },
            { 0x44540FA1, "Crash Time 4 Demo" },
            { 0x4541091C, "Dragon Age: Awakening" },
            { 0x4541091F, "Battlefield: Bad Co. 2" },
            { 0x45410920, "Mass Effect 2" },
            { 0x45410921, "Dragon Age: Origins" },
            { 0x45410935, "Bulletstorm" },
            { 0x45410FA1, "Medal of Honor" },
            { 0x45410FA2, "Need for Speed SHIFT" },
            { 0x45410FA3, "Dead Space 2" },
            { 0x45410FA4, "Bulletstrom DEMO" },
            { 0x45410FA5, "Dragon Age 2" },
            { 0x45410FA8, "Crysis 2" },
            { 0x45410FAB, "The Sims 3" },
            { 0x45410FAC, "The Sims 3 Late Night" },
            { 0x45410FAD, "The Sims 3 Ambitions" },
            { 0x45410FAE, "World Adventures" },
            { 0x45410FAF, "The Sims Medieval" },
            { 0x45410FB1, "Darkspore" },
            { 0x45410FB2, "NFS SHIFT 2 Unleashed" },
            { 0x45410FB3, "Spore" },
            { 0x45410FB4, "The Sims 3 Generations" },
            { 0x45410FB5, "Alice: Madness Returns" },
            { 0x45410FB6, "Harry Potter (DH2)" },
            { 0x45410FB7, "The Sims Medieval Pirates & Nobles" },
            { 0x45410FB8, "Tiger Woods PGA TOUR 12: The Masters" },
            { 0x454D07D4, "Flatout Ultimate Carnage" },
            { 0x46450FA0, "Divinity II - DKS" },
            { 0x46450FA1, "Cities XL 2011" },
            { 0x46450FA2, "The Next Big Thing" },
            { 0x46450FA3, "Faery" },
            { 0x46450FA4, "Pro Cycling Manager" },
            { 0x46550FA0, "Jewel Quest 5" },
            { 0x46550FA1, "Family Feud Dream Home" },
            { 0x48450FA0, "AFL Live" },
            { 0x48450FA1, "Rugby League Live 2" },
            { 0x49470FA1, "Test Drive Ferrari Racing Legend" },
            { 0x4B590FA0, "Tropico 3 Gold Edition" },
            { 0x4B590FA1, "Patrician IV" },
            { 0x4B590FA3, "Commandos Complete" },
            { 0x4B590FA5, "Dungeons" },
            { 0x4B590FA8, "Patrician: RoaD" },
            { 0x4B590FA9, "Elements of War" },
            { 0x4B590FAA, "The First Templar" },
            { 0x4C4107EB, "Star Wars: The Clone Wars - Republic Heroes" },
            { 0x4D5307D6, "Shadowrun" },
            { 0x4D53080F, "Halo 2 Vista" },
            { 0x4D530841, "Viva Piñata" },
            { 0x4D530842, "Gears of War" },
            { 0x4D5308D2, "Microsoft Flight" },
            { 0x4D5308D3, "Firebird Project" },
            { 0x4D530901, "Game Room" },
            { 0x4D53090A, "Fable 3" },
            { 0x4D530935, "Flight Simulator X" },
            { 0x4D530936, "Age of Empires III" },
            { 0x4D530937, "Fable: TLC" },
            { 0x4D530942, "AoE Online - Beta" },
            { 0x4D530FA0, "Zoo Tycoon 2" },
            { 0x4D530FA2, "Toy Soldiers" },
            { 0x4D530FA3, "Age of Empires Online" },
            { 0x4D530FA4, "Toy Soldiers: Cold War" },
            { 0x4D530FA5, "Ms. Splosion Man" },
            { 0x4D530FA6, "Skulls of the Shogun" },
            { 0x4D530FA7, "Insanely Twisted Shadow Planet" },
            { 0x4D530FA8, "Iron Brigade" },
            { 0x4D530FA9, "MGS Pinball FX2 GFWL Games For Windows Live" },
            { 0x4D530FAA, "MGS Vodka PC" },
            { 0x4D5388B0, "BugBash 2" },
            { 0x4E4D0FA1, "Dark Souls: Prepare to Die Edition" },
            { 0x4E4D0FA2, "ACE COMBAT ASSAULT HORIZON: Enhanced Edition" },
            { 0x4E4E0FA0, "Trainz Simulator 2010" },
            { 0x4E4E0FA1, "Settle and Carlisle" },
            { 0x4E4E0FA2, "Classic Cabon City" },
            { 0x4E4E0FA3, "TS 2010: Blue Comet" },
            { 0x4E4E0FA4, "Trainz Simulator 12" },
            { 0x4F420FA0, "BubbleTown" },
            { 0x4F430FA0, "King's Bounty Platinum" },
            { 0x50470FA1, "Bejeweled 2" },
            { 0x50470FA3, "Bookworm" },
            { 0x50470FA4, "Plants vs. Zombies" },
            { 0x50470FA5, "Zuma's Revenge" },
            { 0x50470FA6, "Bejeweled 3" },
            { 0x50580FA0, "Europa Universalis III" },
            { 0x50580FA1, "Hearts of Iron III" },
            { 0x50580FA2, "King Arthur" },
            { 0x50580FA3, "Mount & Blade Warband" },
            { 0x50580FA4, "Victoria 2" },
            { 0x50580FA6, "EU 3: Divine Wind" },
            { 0x50580FA7, "EU3:Heir to the Throne" },
            { 0x50580FA8, "King Arthur The Druids" },
            { 0x50580FA9, "King Arthur The Saxons" },
            { 0x50580FAB, "Cities in Motion" },
            { 0x50580FAC, "Cities in Motion" },
            { 0x50580FAD, "EU 3: Chronicles" },
            { 0x50580FAE, "Darkest Hour" },
            { 0x50580FAF, "MnB: With Fire & Sword" },
            { 0x50580FB0, "King Arthur Collection" },
            { 0x50580FB1, "Supreme Ruler Cold War" },
            { 0x50580FB2, "Pirates of Black Cove" },
            { 0x51320FA0, "Poker Superstars III" },
            { 0x51320FA1, "Slingo Deluxe" },
            { 0x534307EB, "Kane & Lynch: Dead Men" },
            { 0x534307FA, "Battlestations: Pacific" },
            { 0x534307FF, "Batman: Arkham Asylum" },
            { 0x53430800, "Battlestations: Pacific" },
            { 0x5343080C, "Batman: AA GOTY" },
            { 0x53430813, "ChampionshipManager 10" },
            { 0x53430814, "Tomb Raider Underworld" },
            { 0x534507F0, "Universe at War: Earth Assault" },
            { 0x534507F6, "The Club" },
            { 0x53450826, "Stormrise" },
            { 0x5345082C, "Vancouver 2010" },
            { 0x53450849, "Alpha Protocol" },
            { 0x5345084E, "Football Manager 2010" },
            { 0x53450854, "Rome: Total War" },
            { 0x53450FA0, "Football Manager 2011" },
            { 0x53450FA1, "Dreamcast Collection" },
            { 0x53450FA2, "Virtua Tennis 4" },
            { 0x53460FA0, "A Vampyre Story" },
            { 0x53460FA1, "Ankh 2" },
            { 0x53460FA2, "Ankh 3" },
            { 0x53460FA3, "Rise of Flight: ICE" },
            { 0x535007E3, "Section 8" },
            { 0x53510FA0, "Deus Ex: GotY" },
            { 0x53510FA1, "Deus Ex: Invisible War" },
            { 0x53510FA2, "Hitman: Blood Money" },
            { 0x53510FA3, "Thief: Deadly Shadows" },
            { 0x53510FA4, "Hitman 2: SA" },
            { 0x53510FA5, "MINI NINJAS" },
            { 0x53510FA6, "Tomb Raider:Legend" },
            { 0x53510FA7, "Tomb Raider: Anniv." },
            { 0x53510FA8, "Battlestations: Midway" },
            { 0x53510FA9, "Conflict: Denied Ops" },
            { 0x53510FAA, "Project: Snowblind" },
            { 0x544707D4, "Section 8: Prejudice" },
            { 0x5451081F, "Juiced 2: Hot Import Nights" },
            { 0x5451082D, "Warhammer 40,000: Dawn of War 2: Chaos Rising" },
            { 0x54510837, "Red Faction: Guerrilla" },
            { 0x54510868, "DoW II: Chaos Rising" },
            { 0x54510871, "Saints Row 2" },
            { 0x54510872, "S.T.A.L.K.E.R." },
            { 0x5451087F, "Dawn of War" },
            { 0x54510880, "DoW - Dark Crusade" },
            { 0x54510881, "Supreme Commander" },
            { 0x54510882, "Supreme Commander: Forged Alliance" },
            { 0x5454083B, "Grand Theft Auto IV" },
            { 0x5454085C, "BioShock 2" },
            { 0x5454086E, "GTA IV: EFLC" },
            { 0x54540873, "Borderlands" },
            { 0x54540874, "Civ IV: Complete" },
            { 0x54540876, "GTA San Andreas" },
            { 0x54540877, "GTA: Vice City" },
            { 0x54540878, "Max Payne 2" },
            { 0x54540879, "Max Payne" },
            { 0x5454087B, "BioShock" },
            { 0x54540880, "Bully Scholarship Ed." },
            { 0x54540881, "Grand Theft Auto III" },
            { 0x54590FA0, "RIFT" },
            { 0x54590FA1, "RIFT CE" },
            { 0x54590FA2, "RIFT AoH CE" },
            { 0x554C0FA0, "4 Elements" },
            { 0x554C0FA1, "Gardenscapes" },
            { 0x554C0FA2, "Call of Atlantis" },
            { 0x554C0FA3, "Around the World in 80" },
            { 0x554C0FA4, "Fishdom: Spooky Splash" },
            { 0x55530855, "Prince of Persia: TFS" },
            { 0x55530856, "Assassin's Creed II" },
            { 0x55530857, "SplinterCellConviction" },
            { 0x55530859, "Prince of Persia: WW" },
            { 0x5553085A, "Prince of Persia: SoT" },
            { 0x5553085B, "The Settlers 7" },
            { 0x5553085E, "Assassin's Creed" },
            { 0x5553085F, "World In Conflict" },
            { 0x55530860, "Dawn of Discovery Gold" },
            { 0x55530861, "Prince of Persia" },
            { 0x55530862, "TC's RainbowSix Vegas2" },
            { 0x55530864, "GRAW 2" },
            { 0x55530865, "Far Cry 2" },
            { 0x55530866, "Silent Hunter 5" },
            { 0x55530FA0, "Prince of Persia: TT" },
            { 0x55530FA1, "Tom Clancy's H.A.W.X.2" },
            { 0x55530FA2, "Shaun White Skate" },
            { 0x55530FA3, "AC Brotherhood" },
            { 0x55530FA4, "AC Brotherhood Deluxe" },
            { 0x55530FA6, "From Dust" },
            { 0x57520806, "F.E.A.R. 2" },
            { 0x57520808, "LEGO Batman" },
            { 0x57520809, "LEGO Harry Potter: Years 1-4" },
            { 0x57520FA0, "Batman: Arkham City" },
            { 0x57520FA1, "LEGO Universe" },
            { 0x57520FA2, "Mortal Kombat Arcade Kollection" },
            { 0x57520FA3, "Gotham City Impostors" },
            { 0x584109EB, "Tinker" },
            { 0x584109F0, "World of Goo" },
            { 0x584109F1, "Mahjong Wisdom" },
            { 0x58410A01, "Where's Waldo" },
            { 0x58410A10, "Osmos" },
            { 0x58410A1C, "Carneyvale Showtime" },
            { 0x58410A6D, "Blacklight: Tango Down" },
            { 0x585207D1, "XLive" },
            { 0x5A450FA0, "Battle vs. Chess" },
            { 0x5A450FA1, "Two Worlds II" },
            { 0x5A500FA1, "Kona's Crate" }
        };

        public static Dictionary<uint, KnownTitle> KnownTitles = new Dictionary<uint, KnownTitle>();

        public static void FoundTitleExists(uint titleID)
        {
            if (!KnownTitles.ContainsKey(titleID))
                KnownTitles[titleID] = new KnownTitle(titleID);
            if (TitleNameDatabase.ContainsKey(titleID))
                KnownTitles[titleID].Name = TitleNameDatabase[titleID];
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

        public static void WriteConfigSector(uint titleID, int sectorID, byte[] data)
        {
            byte[] sector = new byte[0x1EC];
            Buffer.BlockCopy(data, 0, sector, 0, data.Length);

            byte[] protectedSector = new byte[0x400];
            byte[] protectedSectorBytes = ProtectedData.Protect(sector, null, DataProtectionScope.CurrentUser);
            Buffer.BlockCopy(protectedSectorBytes, 0, protectedSector, 0, protectedSectorBytes.Length);

            string configPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                $"Microsoft\\Xlive\\Titles\\{titleID:X8}\\config.bin");
            byte[] configData = null;
            if (File.Exists(configPath))
                configData = File.ReadAllBytes(configPath);
            else
                configData = new byte[0x5000];
            Buffer.BlockCopy(protectedSector, 0, configData, sectorID * 0x400, protectedSector.Length);
            File.WriteAllBytes(configPath, configData);
        }
    }
}
