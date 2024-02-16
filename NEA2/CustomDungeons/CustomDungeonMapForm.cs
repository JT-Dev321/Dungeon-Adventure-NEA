using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NEA2.Dungeon;

namespace NEA2.CustomDungeons
{
    public partial class CustomDungeonMapForm : Form
    {
        public Button[,] pbArr;
        private int[,] Grid = new int[5, 5];
        private int roomCount { get
            {
                var flatpbArr = pbArr.Cast<Button>();
                return flatpbArr.Count(x => x.Tag != null && int.TryParse(x.Tag.ToString(), out int tagValue) && tagValue > 0);
            }
        }
        private int exitCount
        {
            get
            {
                var flatpbArr = pbArr.Cast<Button>();
                return flatpbArr.Count(x => x.Tag != null && int.TryParse(x.Tag.ToString(), out int tagValue) && tagValue == 5);
            }
        }
        private Dictionary<int, Image> BackImgDict = new Dictionary<int, Image>
            {
                { 0, Image.FromFile("roomicons/Nulled.png") },
                { 1, Image.FromFile("roomicons/empty.png") },
                { 2, Image.FromFile("roomicons/Easy.png") },
                { 3, Image.FromFile("roomicons/Hard.png") },
                { 4, Image.FromFile("roomicons/Reward.png") },
                { 5, Image.FromFile("roomicons/Exit.png") }
            };
        public CustomDungeonMapForm()
        {
            InitializeComponent();
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
                    pbArr[x, y].Tag = 0;
                    pbArr[x, y].Click += (sender, e) => PictureBox_Click(sender, e, tempX, tempY);
                }
            }
            pbArr[2, 2].BackColor = Color.White;
            pbArr[2, 2].Tag = 1;
            pbArr[2, 2].Enabled = false;
            BTN_Save.Enabled = false;
        }
        private void PictureBox_Click(object sender, EventArgs e, int x, int y)
        {
            pbArr[x, y].Tag = Convert.ToInt16(pbArr[x, y].Tag) + 1;

            if (Convert.ToInt16(pbArr[x, y].Tag) > 5)
            {
                pbArr[x, y].Tag = 0;
            }


            isValidLBL.Text = CheckValidGrid() && exitCount == 1 ? "Valid Format" : "Invalid Format";
            UpdatePBImgs();
            CheckForValidSaveState();
        }
        private void CheckForValidSaveState()
        {
            if (CheckValidGrid() && DNGN_Name_TXT.Text.Length > 0 && DNGN_Name_TXT.Text.Length < 24 && roomCount > 1 && exitCount == 1) 
            {
                BTN_Save.Enabled = true;
                return;
            }
            BTN_Save.Enabled = false;
        }
        private void NameTextChanged(object sender, EventArgs e)
        {
            CheckForValidSaveState();
        }
        private void UpdatePBImgs()
        {
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    pbArr[x, y].BackgroundImage = BackImgDict[Convert.ToInt16(pbArr[x, y].Tag)];
                    pbArr[x, y].Refresh();
                }
            }
            // this.Invalidate();
        }

        private bool CheckValidGrid()
        {
            bool[,] visited = new bool[5, 5];
            
            DepthFirstSearch(2,2, visited);

            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (Convert.ToInt16(pbArr[x, y].Tag) >= 1 && !visited[x, y])
                    {
                        return false;
                    }
                }
            }

            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    Grid[x, y] = Convert.ToInt16(pbArr[x, y].Tag);
                }
            }

            return true;
        }

        private void DepthFirstSearch(int x, int y, bool[,] visited)
        {
            if (x < 0 || x >= 5 || y < 0 || y >= 5) return;
            if (visited[x, y]) return;
            if (Convert.ToInt16(pbArr[x, y].Tag) < 1) return; 

            visited[x, y] = true;

            DepthFirstSearch(x - 1, y, visited);
            DepthFirstSearch(x + 1, y, visited);
            DepthFirstSearch(x, y - 1, visited);
            DepthFirstSearch(x, y + 1, visited);
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            KeyParser.ToFile(Grid, (float)Decimal.Divide(DifficultyTrackBar.Value, 10), DNGN_Name_TXT.Text);
            this.Close();
        }

        private void DIffBarChange(object sender, EventArgs e)
        {
            DifficultyLBL.Text = $"Difficulty: x{Decimal.Divide(DifficultyTrackBar.Value, 10)}";
        }


    }
}
