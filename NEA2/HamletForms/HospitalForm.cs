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
    public partial class HospitalForm : Form
    {
        private Game game;
        private int Cost;
        public HospitalForm(Game game)
        {
            InitializeComponent();
            this.game = game;
        }

        private void HospitalForm_Load(object sender, EventArgs e)
        {
            HealButton.Enabled = false;

            CurrentGoldLBL.Text = "Current gold: " + Convert.ToString(game.Gold);

            for (int i = 0; i < this.game.Party.Length; i++)
            {
                Character hero = this.game.Party[i];
                if (hero.Health != hero.MaxHealth)
                {
                    SelectHero_CMB.Items.Add(hero);
                }
            }

            SelectHero_CMB.ValueMember = "Character";
            SelectHero_CMB.DisplayMember = "FullTitle";

            this.Controls.Add(SelectHero_CMB);

            SelectHero_CMB.SelectedItem = null;
        }

        private void HeroCMBBox_SelectChange(object sender, EventArgs e)
        {
            if (SelectHero_CMB.SelectedItem != null)
            {
                Character c = (Character)SelectHero_CMB.SelectedItem;
                HealButton.Text = "Heal";
                HealButton.Enabled = true;

                this.Cost = (int)(150 + ((c.MaxHealth - c.Health) * 0.5) + (c.Level * 50));

                HealButton.Text = $"Heal ({this.Cost} gold)";

                SelectedHeroHealthLBL.Text = $"Health: {c.Health}/{c.MaxHealth}";
                SelectedHeroHealthLBL.Location = new Point((SelectHero_CMB.Location.X) + (SelectHero_CMB.Width / 2) - (SelectedHeroHealthLBL.Width / 2), SelectedHeroHealthLBL.Location.Y);
                SelectedHeroHealthLBL.Refresh();
            }
        }

        private void OnClose(object sender, FormClosedEventArgs e)
        {
            SelectHero_CMB.SelectedItem = null;
            SelectHero_CMB.Items.Clear();
        }

        private void HealButton_Click(object sender, EventArgs e)
        {
            Character SelectedHero = null;
            if (this.game.Gold > this.Cost)
            {
                game.Gold -= this.Cost;
                SelectedHero = (Character)SelectHero_CMB.SelectedItem;
                SelectedHero.SetHealth(SelectedHero.MaxHealth);
            }
            SelectedHeroHealthLBL.Text = $"Health: {SelectedHero.Health}/{SelectedHero.MaxHealth}";
            CurrentGoldLBL.Text = "Current gold: " + Convert.ToString(game.Gold);
            SelectedHeroHealthLBL.Refresh();
            CurrentGoldLBL.Refresh();
        }
    }
}
