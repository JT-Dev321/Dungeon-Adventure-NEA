using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA2
{
    public partial class EstateMapForm : Form
    {
        private Game game;
        private Button[] btnarr;
        public EstateMapForm(Game game)
        {
            InitializeComponent();
            this.game = game;
            this.btnarr = new Button[5] {BTN_estate_dungeon1,
                                             BTN_estate_dungeon2,
                                             BTN_estate_dungeon3,
                                             BTN_estate_dungeon4,
                                             BTN_estate_dungeon5};
        }




        private void BTN_estate_tohamlet_Click(object sender, EventArgs e)
        {
            Utils.ShowForm(this.game.MainHamlet, false);
            this.Hide();
        }



        private void EstateMapForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                btnarr[i].Text = this.game.GetDungeon(i).Name;
            }
            this.Invalidate();
        }
        public void DisableDungeonButton(int number)
        {
            this.btnarr[number - 1].Enabled = false;
        }
        private void BTN_estate_dungeon1_Click(object sender, EventArgs e)
        {
            Dungeon d = this.game.GetDungeon(0);
            Utils.ShowForm(d.DungeonForm, false);
            d.UpdateMap(this.game.GetDungeon(0).MapForm.pbArr);
            Utils.ShowForm(d.MapForm, true, true);
            this.Hide();
        }

        private void BTN_estate_dungeon2_Click(object sender, EventArgs e)
        {
            Dungeon d = this.game.GetDungeon(1);
            Utils.ShowForm(d.DungeonForm, false);
            d.UpdateMap(this.game.GetDungeon(1).MapForm.pbArr);
            Utils.ShowForm(d.MapForm, true, true);
            this.Hide();
        }

        private void BTN_estate_dungeon3_Click(object sender, EventArgs e)
        {
            Dungeon d = this.game.GetDungeon(2);
            Utils.ShowForm(d.DungeonForm, false);
            d.UpdateMap(this.game.GetDungeon(2).MapForm.pbArr);
            Utils.ShowForm(d.MapForm, true, true);
            this.Hide();
        }
        private void BTN_estate_dungeon4_Click(object sender, EventArgs e)
        {
            Dungeon d = this.game.GetDungeon(3);
            Utils.ShowForm(d.DungeonForm, false);
            d.UpdateMap(this.game.GetDungeon(3).MapForm.pbArr);
            Utils.ShowForm(d.MapForm, true, true);
            this.Hide();
        }

        private void BTN_estate_dungeon5_Click(object sender, EventArgs e)
        {
            Dungeon d = this.game.GetDungeon(4);
            Utils.ShowForm(d.DungeonForm, false);
            d.UpdateMap(this.game.GetDungeon(4).MapForm.pbArr);
            Utils.ShowForm(d.MapForm, true, true);
            this.Hide();
        }
    }
}
