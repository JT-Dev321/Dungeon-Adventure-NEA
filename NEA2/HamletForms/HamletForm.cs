using NEA2.CustomDungeons;
using NEA2.HamletForms;
using NEA2.Save_Handling;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA2
{
    public partial class HamletForm : Form
    {
        Game game;

        public BarracksForm BlacksmithForm { get; set; }
        public HospitalForm HospitalForm { get; set; }
        public StagecoachForm StagecoachForm { get; set; }
        public WagonForm WagonForm { get; set; }

        public HamletForm(Game game)
        {
            InitializeComponent();
            this.BlacksmithForm = new BarracksForm(game);
            this.HospitalForm = new HospitalForm(game);
            this.StagecoachForm = new StagecoachForm(game);
            this.WagonForm = new WagonForm(game);
            this.game = game;
        }


        private void BTN_hamlet_stagecoach_Click(object sender, EventArgs e)
        {
            Utils.ShowForm(this.StagecoachForm);
        }

        private void BTN_hamlet_hospital_Click(object sender, EventArgs e)
        {
            Utils.ShowForm(this.HospitalForm);
        }

        private void BTN_hamlet_blacksmith_Click(object sender, EventArgs e)
        {
            Utils.ShowForm(this.BlacksmithForm);
        }

        private void BTN_hamlet_tradermarket_Click(object sender, EventArgs e)
        {
            Utils.ShowForm(this.WagonForm);
        }

        private void btn_hamlet_ready_Click(object sender, EventArgs e)
        {
            Utils.ShowForm(this.game.MainEstateMap, false);
            this.Hide();
        }

        private void HamletForm_Load(object sender, EventArgs e)
        {

        }

        private void CustomDungeon_BTN(object sender, EventArgs e)
        {
            Utils.ShowForm(new CustomDungeonSelect(game));
        }

        private void BTN_SaveGame_Click(object sender, EventArgs e)
        {
            if (this.game.SavePath == null)
            {
                Utils.ShowForm(new SaveFileNameInput(game, null));
            }
            else
            {
                string path = this.game.SavePath;
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(this.game.Save());
                    }
                }
            }
        }
    }
    /*
    static class State
    {
        public static PictureBox MainMenu()
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(1200, 750);
            pictureBox.BackgroundImage = Image.FromFile("TownImg.png");
            pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox.Name = "MenuBackground";
            pictureBox.Show();
            return pictureBox;
        }


        private static void LoadShopButtons()
        {
            List<PictureBox> pbs = new List<PictureBox>();

             people: 313,725
            Blacksmith: 1007,778
            Graveyard: 741,621
            Hospital: 605,592

            for (int i = 1; i <= 4; i++)
            {
                PictureBox pb = new PictureBox();
                pb.Size = new Size(1200, 750);
                pb.BackgroundImage = Image.FromFile("TownImg.png");
                pb.BackgroundImageLayout = ImageLayout.Stretch;
                pb.Show();
            }
            foreach (PictureBox pb in pbs)
            {
                pb.Show();
            }
        }
    }*/
}
