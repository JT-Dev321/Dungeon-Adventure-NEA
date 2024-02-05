using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace NEA2.CustomDungeons
{
    public partial class CustomDungeonSelect : Form
    {
        Game game;
        public CustomDungeonSelect(Game game)
        {
            InitializeComponent();
            this.game = game;
            LoadDGN_Button.Enabled = false;
        }

        private void CreateDGN_Button_Click(object sender, EventArgs e)
        {
            Utils.ShowForm(new CustomDungeonMapForm());
        }

        private void LoadDGN_Button_Click(object sender, EventArgs e)
        {
            Dungeon d = KeyParser.DGN_ParseFromKey(DGN_Key_TXT.Text, game);
            Utils.ShowForm(d.DungeonForm, false);
            d.UpdateMap(this.game.GetDungeon(1).MapForm.pbArr);
            Utils.ShowForm(d.MapForm, true, true);
            this.Hide();
            this.game.MainHamlet.Hide();
        }

        private void KeyTXT_Changed(object sender, EventArgs e)
        {
            if (Regex.Match($"{DGN_Key_TXT.Text}", @"^[a-zA-Z ]+\|[0,1,2](\.[0-9])?\|([0-5]{1}:([0-9]){1,2},)+([0-5]{1}:([0-9]){1,2}){1}$").Success)
            {
                LoadDGN_Button.Enabled = true;
            }
            else
            {
                LoadDGN_Button.Enabled = false;
            }
        }
    }
}
