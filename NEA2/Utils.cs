using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA2
{

    public static class Utils
    {
        private static Random rndm = new Random();
        public static void ShowForm(Form form, bool showdialog = true, bool hideborder = false)
        {
            if (showdialog && hideborder)
            {
                form.FormBorderStyle = FormBorderStyle.None;
                form.ShowDialog();
                return;
            }
            else if (!showdialog && hideborder)
            {
                form.FormBorderStyle = FormBorderStyle.None;
                form.Show();
                return;
            }
            else if (!showdialog)
            {
                form.Show();
                return;
            }
            form.ShowDialog();
            return;
        }
        public static Type[] CharacterTypes = {
                typeof(Wizard), // 6
                typeof(Rogue), //6
                typeof(Paladin), // 6
                typeof(Barbarian), // 4
                typeof(Monk), // 5
                typeof(Druid), // 3
                typeof(Bard), // 3
                typeof(Bloodhunter), // 2
                typeof(HighwayMan) // 4
        };
        public static Type[] AbilityTypes = {
                typeof(Fireball),
                typeof(Backstab),
                typeof(Smite),
                typeof(Berserk),
                typeof(Heal),
                typeof(PoisonArrow),
                typeof(Frostbolt),
                typeof(DivineIntervention),
                typeof(DrainLife),
                typeof(Teleport),
                typeof(ShurikenThrow),
                typeof(Shoot),
                typeof(SmokeBomb),
                typeof(Punch),
                typeof(Kick),
                typeof(SwordSlash),
                typeof(BloodSuck),
                typeof(BloodNova),
                typeof(DivineShield), 
                typeof(MindControl),  
                typeof(PerfectShot),  
                typeof(Whirlwind),    
                typeof(Earthquake),
                typeof(ThunderStrike),
                typeof(Weaken),
                typeof(DivineShield),
        };
        public static void ShowCharsControls(Character[] characters)
        {
            foreach (Character c in characters)
            {
                c.ShowControls();
            }
        }
        public static void RemoveTempControls(Form form)
        {
            for (int i = form.Controls.Count - 1; i >= 0; i--)
            {
                Control control = form.Controls[i];
                // Console.Write($"Type {control.GetType().ToString()} with text {control.Text}");
                
                if (control.Tag != null && control.Tag.ToString() == "Dynamic")
                {
                    form.Controls.Remove(control);  
                }
            }
            
        }
        private static List<string> RandomNameList = new List<string>
        {
            "Jeremy",
            "Kyan",
            "Yael",
            "Elian",
            "Braylen",
            "Esteban",
            "Brock",
            "Grant",
            "Alexzander",
            "Dashawn",
            "River",
            "Zechariah",
            "Gauge",
            "Jordon",
            "Arjun",
            "Alejandro",
            "Matthew",
            "Kolten",
            "Dario",
            "Samir",
            "Vance",
            "Bailey",
            "Mohammed",
            "Nelson",
            "Kody",
            "Wesley",
            "Boston",
            "Roy",
            "Eden",
            "Harold",
            "Ivan",
            "Roland",
            "Ari",
            "Alonzo",
            "Mario",
            "Trystan",
            "Morgan",
            "Addison",
            "Kadyn",
            "Steven",
            "Alfredo",
            "Camryn",
            "Braylon",
            "Adrien",
            "Gustavo",
            "Nicolas",
            "Cole",
            "Lamont",
            "Travis",
            "Kymani",
            "Antonio",
            "Demarcus",
            "Abdiel",
            "Bronson",
            "Octavio",
            "Reynaldo",
            "Darnell",
            "Jaron",
            "Brooks",
            "Kole",
            "Brendon",
            "Ty",
            "Cristopher",
            "Jayce",
            "Jamison",
            "Jadon",
            "Makhi",
            "Jermaine",
            "Everett",
            "Coby",
            "Rhys",
            "Nicholas",
            "Kai",
            "Kyle",
            "Randall",
            "Blaze",
            "Deacon",
            "Soren",
            "Julius",
            "Corbin",
            "Cristofer",
            "Edward",
            "Fisher",
            "Adriel",
            "Ali",
            "Byron",
            "Brodie",
            "Rey",
            "Charlie",
            "Xander",
            "Alden",
            "Jimmy",
            "Kael",
            "Johan",
            "Sheldon",
            "Raul",
            "Corey",
            "Odin",
            "Saul",
            "Bruce",
            "Clinton",
            "Antony",
            "Dereon",
            "Joel",
            "Elliot",
            "Krish",
            "Isaias",
            "Jeremiah",
            "Cayden",
            "Albert",
            "Dax",
            "Jaxson",
            "Ian",
            "Cory",
            "Omari",
            "Jadiel",
            "Marcus",
            "Davon",
            "Edgar",
            "Harper",
            "Andre",
            "Michael",
            "Ruben",
            "Luke",
            "Grayson",
            "Giovanni",
            "Reece",
            "Sam",
            "Keaton",
            "Shane",
            "Jaylen",
            "Nathen",
            "Jacoby",
            "Emmett",
            "Dalton",
            "Deandre",
            "Myles",
            "Judah",
            "Luis",
            "Douglas",
            "Peter",
            "Jeramiah",
            "Dawson",
            "Gael",
            "Jonathan",
            "Christian",
            "Tucker",
            "Jerome",
            "Alexis",
            "Steve",
            "Deon",
            "Oswaldo",
            "Trevor",
            "Kade",
            "Payton",
            "Jonas",
            "Elisha",
            "Jerry",
            "Cordell",
            "Weston",
            "Braden",
            "Vicente",
            "Talan",
            "Kamron",
            "Brett",
            "Trace",
            "Sidney",
            "Clayton",
            "Ronnie",
            "Aldo",
            "Tristan",
            "Jackson",
            "Paul",
            "Tristin",
            "Osvaldo",
            "Cassius",
            "Leonel",
            "Ramon",
            "Mohamed",
            "Reed",
            "Sonny",
            "Kale",
            "Kellen",
            "George",
            "Gianni",
            "Simeon",
            "Quincy",
            "Lee",
            "Graham",
            "Rene",
            "Dwayne",
            "Fernando",
            "Cale",
            "Easton",
            "Giovanny",
            "Blaine",
            "Hudson",
            "Aden",
            "Rodolfo",
            "Ezekiel",
            "Zackery",
            "Cade",
            "Mauricio",
            "Brennen",
            "Kelvin",
            "Justus",
            "Dayton",
            "Tyshawn",
            "Ray",
            "Israel",
            "Keagan",
            "Gavin",
            "Jairo",
            "Maxim",
            "Marvin",
            "Micah",
            "Nathanial",
            "Agustin",
            "Korbin",
            "Bernard",
            "Rylee",
            "Walker",
            "Jaylin",
            "Winston",
            "Donte",
            "Madden",
            "Misael",
            "Tanner",
            "Cody",
            "Reilly",
            "Miguel",
            "Kasen",
            "Willie",
            "Arturo",
            "Jakob",
            "Lucas",
            "Angel",
            "Justice",
            "Jordyn",
            "Kenneth",
            "Keith",
            "Jalen",
            "Pedro",
            "Allen",
            "Jaeden",
            "Jensen",
            "Brian",
            "Jon",
            "Bo",
            "Finnegan",
            "Milton",
            "Tristen",
            "Terrance",
            "Zain",
            "Lyric",
            "Nickolas",
            "Conor",
            "Elliott",
            "Asa",
            "Daniel",
            "Justin",
            "Jason",
            "Noel",
            "Quinton",
            "Kaleb",
            "Elias",
            "Konnor",
            "Baron",
            "Beckham",
            "Darrell",
            "Joe",
            "Ulises",
            "Andy",
            "Trent",
            "Dane",
            "Vaughn",
            "Moses",
            "Christopher",
            "Darian",
            "Kane",
            "Ellis",
            "Colt",
            "Jace",
            "Marlon",
            "London",
            "Leland",
            "Jonathon",
            "Salvatore",
            "Jovani",
            "Hunter",
            "Kamden",
            "Terrence",
            "Mekhi",
            "Drake",
            "Dangelo",
            "Francis",
            "Immanuel",
            "Darion",
            "Casey",
            "Uriel"
        };
        public static string GetRandomName()
        {
            string name = RandomNameList[rndm.Next(RandomNameList.Count)];
            RandomNameList.Remove(name);
            return name;
        }
        public static bool IsValidInteger(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            return Regex.IsMatch(input, @"^-?\d+$");
        }
        private static List<string> DungeonNames = new List<string>
        {
            "Crypt of the Raging Queen",
            "Grotto of the Storm Serpent",
            "Burrows of the Secret Witch",
            "Tombs of the Hidden Lion",
            "The Cold Cells",
            "The Burned Dungeon",
            "The Death Talon Quarters",
            "The Black Tombs",
            "The Rugged Grotto",
            "The Fire Mountain Crypt",
            "Cells of the Vanquished Ogre",
            "Dungeon of the Blooded Elf",
            "Cells of the Mad Arachnid",
            "Crypt of the Raging Monk",
            "The Twisting Maze",
            "The Isolated Cells",
            "The White Tunnels",
            "The Decayed Crypt",
            "The Roaring Point",
            "The Mocking Haunt",
            "Dungeon of the Brutal Forest",
            "Point of the Forgotten Priest",
            "Labyrinth of the Vanishing Spider",
            "Dungeon of the Hidden Scorpion",
            "The Northern Tunnels",
            "The Lower Tombs",
            "The Mesmerizing Grotto",
            "The Iron Vault",
            "The Shrieking Delves",
            "The Lifeless Tunnels"
        };
        public static string GetRandomDungeonName()
        {
            string choice = DungeonNames[rndm.Next(DungeonNames.Count)];
            DungeonNames.Remove(choice);
            return choice;
        }

        public static Ability[] RemoveSupportAbilities(Ability[] abilities)
        {
            return abilities.Where(a =>
                a.GetType() != typeof(Heal) ||
                a.GetType() != typeof(DivineIntervention) ||
                a.GetType() != typeof(DivineShield) ||
                a.GetType() != typeof(SmokeBomb)).ToArray();
        }
        public static Ability[] RemoveCombatAbilities(Ability[] abilities)
        {
            return abilities.Where(a =>
                a.GetType() == typeof(Heal) ||
                a.GetType() == typeof(DivineIntervention) ||
                a.GetType() == typeof(DivineShield) ||
                a.GetType() == typeof(SmokeBomb)).ToArray();
        }
    }
    
}
