using NEA2;
using NEA2.Gameplay;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA2
{
    public enum RoomContent
    {
        nulled = 0,
        Empty = 1,
        EasyEnemy = 2,
        HardEnemy = 3,
        Reward = 4,
        Exit = 5,
    }
    public class Dungeon
    {
        public int ID
        {
            get
            {
                try
                {
                    return Array.IndexOf(this.game.Dungeons, this) + 1; // DOING ID TO DISABLE BUTTON
                }
                catch
                {
                    return -1;
                }
            }
        } // Saving
        public MapForm MapForm;
        public string Name; // Saving
        public float DifficultyMult; // Saving
        public bool IsCustom;
        public Coordinate CurrentPosition;
        public DungeonRoom ActiveRoom;
        public DungeonRoom[,] RoomMap { get; set; }
        public int[,] IntMap { get
            {
                int[,] intmap = new int[size, size];
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        intmap[i, j] = (int)this.RoomMap[i, j].RoomType;
                    }
                }
                return intmap;
            } 
        } // Saving
        public bool Attempted = false; // Saving
        public Dictionary<Coordinate, List<Coordinate>> MapAdjMatrix = new Dictionary<Coordinate, List<Coordinate>>();
        public DungeonForm DungeonForm { get; set; }
        public Game game { get; set; }

        // public Dictionary<List<int>, List<List<int>>> MapAdjMatrix;
        public Dungeon(Game game, float dungeonLevel, int roomcount)
        {
            DifficultyMult = dungeonLevel;
            this.game = game;
            this.MapForm = new MapForm(this, roomcount);
            this.RoomMap = new DungeonRoom[5, 5];
            this.Generate(roomcount);
            this.DungeonForm = new DungeonForm(this);
            this.Name = Utils.GetRandomDungeonName();
            this.IsCustom = false;
        }
        // For loading a saved dungeon
        public Dungeon(Game game, float dungeonLevel, int[,] Map, string name, bool IsFromSave = false)
        {
            DifficultyMult = dungeonLevel;
            this.game = game;
            this.MapForm = new MapForm(this, Map.Cast<int>().Count(x => x > 0));
            this.RoomMap = new DungeonRoom[5, 5];
            this.ProcessDungeonGrid(Map);
            this.DungeonForm = new DungeonForm(this);
            this.Name = name;
            this.IsCustom = !IsFromSave;
        }


        public class Coordinate
        {
            public int X { get; set; }
            public int Y { get; set; }
            public Coordinate(int x, int y)
            {
                X = x;
                Y = y;
            }
            public override bool Equals(object obj)
            {
                if (obj is Coordinate other)
                {
                    return X == other.X && Y == other.Y;
                }
                return false;
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int hash = 17;
                    hash = hash * 23 + X.GetHashCode();
                    hash = hash * 23 + Y.GetHashCode();
                    return hash;
                }
            }
        }

        private const int size = 5;
        public void Generate(int roomcount)
        {

            // DO PATHFINDING TO MAKE BETTER MAPS

            if (roomcount < 2) { roomcount = 2; }
            roomcount -= 1;
            int[,] Map = new int[size, size];
            Map[size / 2, size / 2] = 1;

            Random rndm = new Random();
            // loop generates a temporary list of "candidates"
            // (adjacent points in the array) for a new room to be created on.
            for (int i = roomcount; i > 0; i--) 
            {
                List<Coordinate> candidateCoords = new List<Coordinate>();
                for (int y = 0; y < size; y++)
                {
                    for (int x = 0; x < size; x++)
                    {
                        Coordinate coord = new Coordinate(x, y);
                        if (Map[x, y] == 0 && IsAdjacentToValue(coord, Map))
                        {
                            candidateCoords.Add(coord);
                        }
                    }
                }
                Coordinate chosenCoord = candidateCoords[rndm.Next(0, candidateCoords.Count)];
                Map[chosenCoord.X, chosenCoord.Y] = rndm.Next(1, 5);
            }

            // following chunk of loops/ifs sets the "exit" room to a random existing room that is the furthest from the center as possible.
            List<List<int>> OutsideRooms = new List<List<int>>();
            for (int i = 0; i < size; i++)
            {
                if (Map[i, 0] > 0)
                {
                    OutsideRooms.Add(new List<int>() { i, 0 });
                }
                if (Map[0, i] > 0)
                {
                    OutsideRooms.Add(new List<int>() { 0, i });
                }
            }
            for (int i = 0; i < size; i++)
            {
                if (Map[i, 4] > 0)
                {
                    OutsideRooms.Add(new List<int>() { i, 4 });
                }
                if (Map[4, i] > 0)
                {
                    OutsideRooms.Add(new List<int>() { 4, i });
                }
            }
            if (OutsideRooms.Count < 1)
            {
                for (int i = 1; i < size - 1; i++)
                {
                    if (Map[i, 1] > 0)
                    {
                        OutsideRooms.Add(new List<int>() { i, 1 });
                    }
                    if (Map[1, i] > 0)
                    {
                        OutsideRooms.Add(new List<int>() { 1, i });
                    }
                }
                for (int i = 1; i < size - 1; i++)
                {
                    if (Map[i, 3] > 0)
                    {
                        OutsideRooms.Add(new List<int>() { i, 3 });
                    }
                    if (Map[3, i] > 0)
                    {
                        OutsideRooms.Add(new List<int>() { 3, i });
                    }
                }
            }
            int OutsideChoice = rndm.Next(0, OutsideRooms.Count);
            Map[OutsideRooms[OutsideChoice][0], OutsideRooms[OutsideChoice][1]] = 5; // 5 means the room is the exit
            for (int y = 0; y < size; y++) // formats it nicely
            {
                for (int x = 0; x < size; x++)
                {
                    Console.Write(Map[y, x] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("----------");

            ProcessDungeonGrid(Map);
        }

        public void ProcessDungeonGrid(int[,] Map)
        {
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (Map[x, y] >= 1)
                    {
                        Coordinate currentCoord = new Coordinate(x, y);

                        MapAdjMatrix.Add(currentCoord, new List<Coordinate>());
                        int[,] AdjCoordArr = new int[4, 2] { { x - 1, y }, { x + 1, y }, { x, y - 1 }, { x, y + 1 } };

                        for (int i = 0; i < 4; i++)
                        {
                            if (!(AdjCoordArr[i, 0] < 0 || AdjCoordArr[i, 0] > 4 || AdjCoordArr[i, 1] < 0 || AdjCoordArr[i, 1] > 4))
                            {
                                MapAdjMatrix[currentCoord].Add(new Coordinate(AdjCoordArr[i, 0], AdjCoordArr[i, 1]));
                            }
                        }
                    }
                }
            }

            for (int y = 0; y < size; y++)// applying the enum roomcontent types depending on the number in the grid
            {
                for (int x = 0; x < size; x++)
                {
                    RoomContent rt = RoomContent.Empty;
                    switch (Map[y, x])
                    {
                        case 0:
                            rt = RoomContent.nulled;
                            break;
                        case 1:
                            rt = RoomContent.Empty;
                            break;
                        case 2:
                            rt = RoomContent.EasyEnemy;
                            break;
                        case 3:
                            rt = RoomContent.HardEnemy;
                            break;
                        case 4:
                            rt = RoomContent.Reward;
                            break;
                        case 5:
                            rt = RoomContent.Exit;
                            break;
                    }
                    if (rt == RoomContent.EasyEnemy || rt == RoomContent.HardEnemy)
                    {
                        RoomMap[y, x] = new EnemyRoom(rt, this);
                    }
                    else if (rt == RoomContent.Reward)
                    {
                        RoomMap[y, x] = new RewardRoom(rt, this);
                    }
                    else
                    {
                        RoomMap[y, x] = new DungeonRoom(rt, this);
                    }
                }
            }
        }

        private bool IsAdjacentToValue(Coordinate coord, int[,] Map) // self explanatory
        {
            Coordinate[] adjCoords = new Coordinate[]
            {
                new Coordinate(coord.X - 1, coord.Y),
                new Coordinate(coord.X + 1, coord.Y),
                new Coordinate(coord.X, coord.Y - 1),
                new Coordinate(coord.X, coord.Y + 1)
            };

            foreach (var adjCoord in adjCoords)
            {
                if (IsInBounds(adjCoord) && Map[adjCoord.X, adjCoord.Y] >= 1)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsInBounds(Coordinate coord) // within bounds of array's size
        {
            return coord.X >= 0 && coord.X < 5 && coord.Y >= 0 && coord.Y < 5;
        }

        public string Get_Save_Key()
        {
            string output = KeyParser.To_Key(this.IntMap, this.DifficultyMult, this.Name);
            if (Attempted)
            {
                output = "True|" + output;
            }
            else
            {
                output = "False|" + output;
            }
            return output;
            // True|testname|0.8|4:1,0:2,2:1,0:1,2:1,1:1,0:1,2:1,0:1,3:2,1:1,2:1,1:1,0:1,4:1,2:1,0:4,5:1,2:2
        }

        public void UpdateMap(Button[,] pbArr) // re-analyses the colours of each element in the room map grid
        {
            Console.WriteLine("UpdateMap called");
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    if (RoomMap[y, x].IsVisible)
                    {
                        RoomContent content = RoomMap[y, x].RoomType;  // Assuming RoomMap contains the DungeonRoom objects and RoomType is accessible
                        switch (content)
                        {
                            case RoomContent.nulled:
                                pbArr[y, x].Hide();
                                break;
                            case RoomContent.Empty:
                                //pbArr[y, x].BackColor = Color.Gray;
                                pbArr[y, x].BackgroundImage = Image.FromFile("roomicons/empty.png");
                                break;
                            case RoomContent.EasyEnemy:
                                //pbArr[y, x].BackColor = Color.Orange;
                                pbArr[y, x].BackgroundImage = Image.FromFile("roomicons/Easy.png");
                                break;
                            case RoomContent.HardEnemy:
                                //pbArr[y, x].BackColor = Color.Red;
                                pbArr[y, x].BackgroundImage = Image.FromFile("roomicons/Hard.png");
                                break;
                            case RoomContent.Reward:
                                //pbArr[y, x].BackColor = Color.Gold;
                                pbArr[y, x].BackgroundImage = Image.FromFile("roomicons/Reward.png");
                                break;
                            case RoomContent.Exit:
                                //pbArr[y, x].BackColor = Color.LimeGreen;
                                pbArr[y, x].BackgroundImage = Image.FromFile("roomicons/Exit.png");
                                break;
                        }
                    }
                    else
                    {
                        if (RoomMap[y, x].RoomType == RoomContent.nulled)
                        {
                            this.MapForm.pbArr[y, x].Hide();
                        }
                        else
                        {
                            // pbArr[y, x].BackColor = Color.DarkGray;
                            pbArr[y, x].BackgroundImage = Image.FromFile("roomicons/Locked.png");
                        }
                    }
                }
            }
            if (CurrentPosition != null)
            {
                int newx = this.CurrentPosition.X;
                int newy = this.CurrentPosition.Y;

                pbArr[newx, newy].BackgroundImage = Image.FromFile("roomicons/CurrentRoom.png");
            }
            this.MapForm.Invalidate();
        }
    }
    public class DungeonRoom
    {
        // private DungeonRoom[] AdjacenctRooms = new DungeonRoom[3];
        public Dungeon Dungeon;
        public RoomContent RoomType;
        public bool IsExplored = false;
        public bool IsVisible = false;
        protected RoomInteractions RI;
        protected string backdropFilePath;
        protected Random rndm = new Random();

        public DungeonRoom(RoomContent roomCont, Dungeon dungeon)
        {
            RoomType = roomCont;
            this.Dungeon = dungeon;
            this.backdropFilePath = $"roombackdrops/room{rndm.Next(0, 5)}.png";
        }

        public void SetContent(RoomContent roomCont)
        {
            this.RoomType = roomCont;
        }

        public virtual void Initialise()
        {
            SharedInitialise();

            // Code unique to BaseClass
            this.RI = new RoomInteractions(this, this.Dungeon.game.Party);
            RI.LoadAllyControls();
        }
        public void UpdateVisiblity()
        {
            IsVisible = IsExplored || IsVisible;
        }
        protected void SharedInitialise()
        {
            this.IsExplored = true;
            //this.Dungeon.DungeonForm.BackgroundImage = Image.FromFile(this.backdropFilePath);

            Label InfoLabel = this.Dungeon.DungeonForm.GeneralInfoLabel;
            InfoLabel.Text = $"{this.RoomType.ToString()} room | Level {this.Dungeon.game.Level} | Gold: {this.Dungeon.game.Gold}";
            InfoLabel.Location = new Point((this.Dungeon.DungeonForm.Width / 2) - (InfoLabel.Width / 2), 10);
            InfoLabel.Refresh();

            this.Dungeon.DungeonForm.Text = $"{this.Dungeon.Name}";
            this.Dungeon.DungeonForm.Invalidate();
        }

    }
    public class EnemyRoom : DungeonRoom
    {
        public Character[] enemies = new Character[4];
        private CombatInstance CI;
        public EnemyRoom(RoomContent roomCont, Dungeon dungeon) : base(roomCont, dungeon)
        {
            RoomType = roomCont;
            this.Dungeon = dungeon;
            this.enemies = GenerateEnemyArr();
            this.backdropFilePath = $"roombackdrops/room{rndm.Next(0, 5)}.png";
        }
        private Character[] GenerateEnemyArr()
        {
            Character[] characterArr = new Character[4];
            for (int i = 0; i < 4; i++)
            {
                characterArr[i] = CharacterFactory.CreateRandomCharacter(CharacterType.Enemy, this.Dungeon.game.Level);
                characterArr[i].MultiplyStats(this.Dungeon.DifficultyMult);
            }
            return characterArr;
        }
        public override void Initialise()
        {
            base.SharedInitialise();

            this.CI = new CombatInstance(this, this.Dungeon.game.Party, this.enemies);
            CI.RefreshAllStatLBLs();
            CI.LoadAllyControls();
            CI.LoadEnemyControls();
            ShowEnemyControls();
            CI.CombatStart();
        }
        public void ShowEnemyControls()
        {
            foreach (Character c in enemies)
            {
                c.ShowControls();
            }
        }
        public void HideEnemyControls()
        {
            foreach (Character c in enemies)
            {
                c.HideControls();
            }
        }
        public void ConcludeRoom(bool Victory)
        {
            this.Dungeon.DungeonForm.ViewMap.Enabled = true;
            this.Dungeon.DungeonForm.BTN_GoBack.Enabled = true;
        }
    }
    public class RewardRoom : DungeonRoom
    {
        private int GoldReward;
        private bool Claimed = false;
        public RewardRoom(RoomContent roomCont, Dungeon dungeon) : base(roomCont, dungeon)
        {
            RoomType = roomCont;
            this.Dungeon = dungeon;
            this.backdropFilePath = $"roombackdrops/room{rndm.Next(0, 5)}.png";
            this.GoldReward = (int)(rndm.Next(800, 1501) * this.Dungeon.game.Level * this.Dungeon.DifficultyMult);
        }
        public override void Initialise()
        {
            base.Initialise();
            Character[] allies = this.RI.Allies;
            Button btn = new Button();
            btn.Size = new Size(200, 200);
            btn.Tag = "Dynamic";
            btn.Text = $"Claim {this.GoldReward} Gold";
            int totwidth = allies[0].Controls.Picture.Location.X + allies[0].Controls.Picture.Width;
            btn.Location = new Point(((this.Dungeon.DungeonForm.Width - (totwidth)) / 2) + totwidth - btn.Width / 2, allies[0].Controls.Picture.Location.Y + (allies[0].Controls.Picture.Height / 2) - (btn.Height / 2));
            this.Dungeon.DungeonForm.Controls.Add(btn);
            btn.Visible = true;
            btn.Click += (sender, e) => RewardCollect_Click(sender, e);
            if (Claimed)
            {
                btn.Enabled = false;
            }
        }
        private void RewardCollect_Click(object sender, EventArgs e)
        {
            this.Dungeon.game.Gold += this.GoldReward;
            ((Button)sender).Enabled = false;
            this.Claimed = true;
        }
    }
}

    