using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace NEA2
{
    public class Game
    {
        public int Experience { get; private set; } // changes
        public int Level 
        { 
            get
            {
                return (int)Math.Floor(Experience / 1000.0);
            }
        }
        public int Gold { get; set; } // Changes
        public Character[] Party { get; set; } = new Character[4]; // Changes
        public List<Character> OwnedCharacters  { get; set; } = new List<Character>(); // Changes
        public Dungeon[] Dungeons { get; private set; } // Changes
        public HamletForm MainHamlet { get; set; } // No changes
        public EstateMapForm MainEstateMap { get; set; } // No changes
        public string SavePath; // make so if saving when already loaded from a save it doesnt need name input

        public Game()
        { 
            this.Gold = 500;
            this.Experience = 1000;
            Dungeons = new Dungeon[5] { new Dungeon(this, 0.5f, 6), 
                                        new Dungeon(this, 0.8f, 8), 
                                        new Dungeon(this, 1, 10), 
                                        new Dungeon(this, 1.2f, 12), 
                                        new Dungeon(this, 1.5f, 14) };
            MainHamlet = new HamletForm(this);
            MainEstateMap = new EstateMapForm(this);
            for (int i = 0; i < 4;)
            {
                Character charCandidate = CharacterFactory.CreateRandomCharacter(CharacterType.Hero, 4);

                
                if (!Party.Where(c => c != null).Any(c => c.ClassName == charCandidate.ClassName))
                {
                    Party[i] = charCandidate;
                    i++; 
                }
            }
        }
        public Game(string SaveKey, string path)
        {
            this.SavePath = path;
            MainHamlet = new HamletForm(this);
            MainEstateMap = new EstateMapForm(this);

            string[] splitKey = SaveKey.Split(new string[] { "\n\n" }, StringSplitOptions.None);

            Gold = Convert.ToInt32(splitKey[0].Split(':')[1]);
            Experience = Convert.ToInt32(splitKey[1].Split(':')[1]);

            string[] PartyKeys = splitKey[2].Split(new string[] { ":\n" }, StringSplitOptions.None)[1].Split('\n');

            int counter = 0;
            foreach(string key in PartyKeys)
            {
                Party[counter] = CharacterFactory.CreateCharacterFromKey(key);
                counter++;
            }
            if (splitKey[3].Split(new string[] { ":\n" }, StringSplitOptions.None)[1] != "N/A")
            {
                List<string> OwnedKeys = splitKey[3].Split(new string[] { ":\n" }, StringSplitOptions.None)[1].Split('\n').ToList();
                foreach (string key in OwnedKeys)
                {
                    OwnedCharacters.Add(CharacterFactory.CreateCharacterFromKey(key));
                }
            }
            // make character key parser

            string[] DungeonKeys = splitKey[4].Split(new string[] { ":\n" }, StringSplitOptions.None)[1].Split('\n');
            Dungeons = new Dungeon[5];
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(DungeonKeys[i].Substring(DungeonKeys[i].IndexOf('|', 0) + 1));
                Dungeon d = KeyParser.DGN_ParseFromKey(DungeonKeys[i].Substring(DungeonKeys[i].IndexOf('|', 0) + 1), this);
                string tempString = DungeonKeys[i].Split(new char[] { '|' })[0];
                d.Attempted = Convert.ToBoolean(tempString);
                Dungeons[i] = d;
                if (d.Attempted)
                {
                    MainEstateMap.DisableDungeonButton(i + 1);
                }
            }
        }

        public Dungeon GetDungeon(int index)
        {
            if (index >= 0 && index < Dungeons.Length)
            {
                return Dungeons[index];
            }
            else { return null; }
        }

        public void AddXp(int amount)
        {
            this.Experience += (int)(amount * (1 + (this.Level * 0.4)));
        }
        public void AddXp(double amount)
        {
            this.Experience += (int)(amount * (1 + (this.Level * 0.4)));
        }
        public string Save()
        {
            string output = "";

            output += $"Gold:{Gold}\n\n";
            output += $"Experience:{Experience}\n\n";

            output += "Party:\n";
            foreach (Character c in Party)
            {
                if (c != null)
                {
                    output += c.Get_Save_Key() + "\n";
                }
            }

            output += "\nOwnedChars:\n";
            bool hasAdded = false;
            foreach (Character c in OwnedCharacters)
            {
                if (c != null && !Party.Contains(c))
                {
                    output += c.Get_Save_Key() + "\n";
                    hasAdded = true;
                }
            }
            if (!hasAdded)
            {
                output += "N/A\n";
            }


            output += "\nDungeons:\n";
            foreach (Dungeon dgn in this.Dungeons)
            {
                output += dgn.Get_Save_Key() + "\n";
            }
            Console.WriteLine(output);
            return output;
        }
    }

}
