using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NEA2.Dungeon;

namespace NEA2
{
    // light mechanic, xml, improve map generation significantly
    // (exit be actually furthest away,
    // add 1 reward per dungeon on opposite side to exit.
    public partial class MapForm : Form
    {
        public Dungeon dungeon;
        public Button[,] pbArr;
        private int Light;
        private bool HasLoaded = false;
        public MapForm(Dungeon dungeon, int roomcount)
        {
            InitializeComponent();
            this.dungeon = dungeon;
            pbArr = new Button[5, 5]
            {
                { MapBox1, MapBox2,MapBox3,MapBox4,MapBox5 },
                { MapBox6, MapBox7,MapBox8,MapBox9,MapBox10 },
                { MapBox11,MapBox12,MapBox13,MapBox14,MapBox15 },
                { MapBox16,MapBox17,MapBox18,MapBox19,MapBox20 },
                { MapBox21,MapBox22,MapBox23,MapBox24,MapBox25 },
            };
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    int tempX = x;
                    int tempY = y;
                    pbArr[x, y].Click += (sender, e) => PictureBox_Click(sender, e, tempX, tempY);
                }
            }
            Light = 17; // calculate in future
            UpdateLightLabel();
        }
        private void UpdateLightLabel()
        {
            Light_LBL.Text = $"Light: {Light}";
        }
        private void PictureBox_Click(object sender, EventArgs e, int x, int y)
        {
            if (this.dungeon.RoomMap[x, y].RoomType == RoomContent.Exit)
            {
                Utils.ShowForm(this.dungeon.game.MainEstateMap, false);
                this.dungeon.DungeonForm.Invalidate();
                this.dungeon.DungeonForm.Hide();
                if (!this.dungeon.IsCustom)
                {
                    this.dungeon.game.MainEstateMap.DisableDungeonButton(this.dungeon.ID);
                    this.dungeon.Attempted = true;
                }
                this.dungeon.MapForm.Hide();
            }
            else
            {
                if (Light == 1)
                {
                    Utils.ShowForm(this.dungeon.game.MainEstateMap, false);
                    this.dungeon.DungeonForm.Invalidate();
                    this.dungeon.DungeonForm.Hide();
                    if (!this.dungeon.IsCustom)
                    {
                        this.dungeon.game.MainEstateMap.DisableDungeonButton(this.dungeon.ID);
                        this.dungeon.Attempted = true;
                    }
                    this.dungeon.MapForm.Hide();
                } // DIE
                else
                {
                    for (int i = 0; i < pbArr.GetLength(0); i++)
                    {
                        for (int j = 0; j < pbArr.GetLength(1); j++)
                        {
                            pbArr[i, j].Enabled = false;
                        }
                    }

                    Utils.RemoveTempControls(this.dungeon.DungeonForm);
                    Coordinate currentCoord = new Coordinate(x, y);
                    this.dungeon.CurrentPosition = currentCoord;
                    this.dungeon.ActiveRoom = this.dungeon.RoomMap[x, y];

                    this.Invalidate();
                    this.Hide();

                    this.dungeon.RoomMap[x, y].Initialise();
                    UpdateVisibility(currentCoord);

                    List<Coordinate> adjacentPoints = this.dungeon.MapAdjMatrix[currentCoord];

                    for (int i = 0; i < pbArr.GetLength(0); i++)
                    {
                        for (int j = 0; j < pbArr.GetLength(1); j++)
                        {
                            Coordinate buttonCoord = new Coordinate(i, j);

                            if (!adjacentPoints.Any(adj => adj.X == buttonCoord.X && adj.Y == buttonCoord.Y))
                            {
                                pbArr[i, j].Enabled = false;
                            }
                            else
                            {
                                pbArr[i, j].Enabled = true;
                            }
                        }
                    }
                    pbArr[x, y].Enabled = false;
                    Light--;
                    UpdateLightLabel();
                }
            }
        }
        

        private void MapForm_Load(object sender, EventArgs e)
        {
            if (!HasLoaded)
            {
                var coord = new Dungeon.Coordinate(2, 2);

                this.dungeon.CurrentPosition = coord;

                int x = coord.X; int y = coord.Y;

                for (int i = 0; i < pbArr.GetLength(0); i++)
                {
                    for (int j = 0; j < pbArr.GetLength(1); j++)
                    {
                        pbArr[i, j].Enabled = false;
                    }
                }

                Utils.RemoveTempControls(this.dungeon.DungeonForm);
                Coordinate currentCoord = new Coordinate(x, y);
                this.dungeon.ActiveRoom = this.dungeon.RoomMap[x, y];

                this.Invalidate();
                this.Hide();
                
                this.dungeon.RoomMap[x, y].Initialise();
                UpdateVisibility(currentCoord);

                List<Coordinate> adjacentPoints = this.dungeon.MapAdjMatrix[currentCoord];

                for (int i = 0; i < pbArr.GetLength(0); i++)
                {
                    for (int j = 0; j < pbArr.GetLength(1); j++)
                    {
                        Coordinate buttonCoord = new Coordinate(i, j);

                        if (!adjacentPoints.Any(adj => adj.X == buttonCoord.X && adj.Y == buttonCoord.Y))
                        {
                            pbArr[i, j].Enabled = false;
                        }
                        else
                        {
                            pbArr[i, j].Enabled = true;
                        }
                    }
                }
                pbArr[x, y].Enabled = false;
                HasLoaded = true;
            }
        }
        private void UpdateVisibility(Dungeon.Coordinate coordinate)
        {
            int x = coordinate.X;
            int y = coordinate.Y;

            this.dungeon.RoomMap[x,y].IsExplored = true;
            this.dungeon.RoomMap[x,y].UpdateVisiblity();
            foreach (Dungeon.Coordinate coord in this.dungeon.MapAdjMatrix[new Dungeon.Coordinate(x, y)])
            {
                this.dungeon.RoomMap[coord.X, coord.Y].IsExplored = true;
                this.dungeon.RoomMap[coord.X, coord.Y].UpdateVisiblity();
            }
            this.dungeon.UpdateMap(pbArr);
            
        }

    }
    
}
