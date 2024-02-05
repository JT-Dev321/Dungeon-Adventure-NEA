using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Authentication.ExtendedProtection.Configuration;

namespace NEA2
{
    public static class KeyParser
    {
        // format example:
        // testname|0.8|4:1,0:2,2:1,0:1,2:1,1:1,0:1,2:1,0:1,3:2,1:1,2:1,1:1,0:1,4:1,2:1,0:4,5:1,2:2

        // dungeon input regex /([0-5]{5}\n){5}/gm

        public static void ToFile(int[,] grid, float difficulty, string name)
        {
            string output = $"{name}|{difficulty}|";

            string flatGrid = "";

            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    flatGrid += grid[y, x];
                }
            }


            int counter = 1;

            List<string> RLEList = new List<string>();  

            for (int i = 0; i < flatGrid.Length - 1; i++)
            {
                if (flatGrid[i] == flatGrid[i + 1])
                {
                    counter++;
                }
                else
                {
                    RLEList.Add($"{flatGrid[i]}:{counter}");
                    counter = 1;
                }
            }
            RLEList.Add($"{flatGrid[flatGrid.Length - 1]}:{counter}");

            Console.Write("[");
            foreach (string s in RLEList)
            {
                output += $"{s},";
                Console.Write($"{s},");
            }
            Console.Write("]");

            output = output.Remove(output.Length - 1, 1);

            Console.WriteLine("\n\n");
            Console.WriteLine(output);

            StreamWriter sw = new StreamWriter($"savedDungeons/{name}.txt");

            Clipboard.SetText(output);

            sw.WriteLine(output); sw.Close();

        }
        public static string To_Key(int[,] grid, float difficulty, string name)
        {
            string output = $"{name}|{difficulty}|";

            string flatGrid = "";

            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    flatGrid += grid[y, x];
                }
            }

            int counter = 1;

            List<string> RLEList = new List<string>();

            for (int i = 0; i < flatGrid.Length - 1; i++)
            {
                if (flatGrid[i] == flatGrid[i + 1])
                {
                    counter++;
                }
                else
                {
                    RLEList.Add($"{flatGrid[i]}:{counter}");
                    counter = 1;
                }
            }
            RLEList.Add($"{flatGrid[flatGrid.Length - 1]}:{counter}");

            foreach (string s in RLEList)
            {
                output += $"{s},";
            }

            output = output.Remove(output.Length - 1, 1);

            return output;
        }
        public static Dungeon ParseFromFile(string filepath, Game game)
        {
            StreamReader sr = new StreamReader(filepath);

            string data = sr.ReadLine();

            string output = "";

            float diff = (float)Convert.ToDouble(data.Split('|')[1]);

            foreach (string pair in data.Split('|')[2].Split(','))
            {
                string[] splitpair = pair.Split(':');
                string character = splitpair[0];
                int freq = Convert.ToInt16(splitpair[1].ToString());

                for (int i = 0; i < freq; i++)
                {
                    output += character;
                }

            }

            int[,] map = new int[5, 5];

            int k = 0;

            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    map[y, x] = Convert.ToInt16(Convert.ToString(output[k]));
                    k++;
                }
            }

            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    Console.Write(map[y, x] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("----------");

            return new Dungeon(game, diff, map, data.Split('|')[0]);
        }
        public static Dungeon DGN_ParseFromKey(string key, Game game)
        {
            string data = key;

            string output = "";

            float diff = (float)Convert.ToDouble(data.Split('|')[1]);
            Console.WriteLine(diff);
            foreach (string pair in data.Split('|')[2].Split(','))
            {
                string[] splitpair = pair.Split(':');
                string character = splitpair[0];
                int freq = Convert.ToInt16(splitpair[1].ToString());

                for (int i = 0; i < freq; i++)
                {
                    output += character;
                }

            }

            int[,] map = new int[5, 5];

            int k = 0;

            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    map[y, x] = Convert.ToInt16(Convert.ToString(output[k]));
                    k++;
                }
            }

            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    Console.Write(map[y, x] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("----------");
            Console.WriteLine($"Name: {data.Split('|')[0]}");
            Dungeon test = new Dungeon(game, diff, map, data.Split('|')[0], true);
            Console.WriteLine(test);
            return new Dungeon(game, diff, map, data.Split('|')[0], true);
        }

        
    }
}
