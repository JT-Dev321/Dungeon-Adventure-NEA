using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace NEA2
{
    public partial class BarracksForm : Form
    {
        private Game game;
        private int CurrentCost = -1;
        public BarracksForm(Game game)
        {
            InitializeComponent();
            this.game = game;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            Character SelectedHero = (Character)SelectHero_CMB.SelectedItem;

            if (CurrentCost != -1)
            {
                if (game.Gold > CurrentCost)
                {
                    game.Gold -= CurrentCost;
                    SelectedHero.MaxHealth = CandidateCharacter.MaxHealth;
                    SelectedHero.MaxMana = CandidateCharacter.MaxMana;
                    SelectedHero.CritChance = CandidateCharacter.CritChance;
                    SelectedHero.DodgeChance = CandidateCharacter.DodgeChance;
                    SelectedHero.Armour = CandidateCharacter.Armour;
                    SelectedHero.Speed = CandidateCharacter.Speed;
                    SelectedHero.Level++;
                    SelectedHero.ValidateStats();
                    this.Close();
                }
            }

        }
        private void HideArrows()
        {
            foreach (Label l in ArrowLabels)
            {
                l.Hide();
            }
        }
        private void ShowArrows()
        {
            foreach (Label l in ArrowLabels)
            {
                l.Show();
            }
        }

        private List<Label> ArrowLabels = new List<Label>();

        private void BarracksForm_Load(object sender, EventArgs e)
        {
            HPLabel.Text = "";
            ManaLabel.Text = "";
            CritLabel.Text = "";
            DodgeLabel.Text = "";
            SpeedLabel.Text = "";
            ArmourLabel.Text = "";

            ArrowLabels.Add(ArrowLabel1);
            ArrowLabels.Add(ArrowLabel2);
            ArrowLabels.Add(ArrowLabel3); 
            ArrowLabels.Add(ArrowLabel4);
            ArrowLabels.Add(ArrowLabel5);
            ArrowLabels.Add(ArrowLabel6);
            
            HideArrows();

            HPLabelAfter.Text = "";
            ManaLabelAfter.Text = "";
            CritLabelAfter.Text = "";
            DodgeLabelAfter.Text = "";
            SpeedLabelAfter.Text = "";
            ArmourLabelAfter.Text = "";

            ConfirmButton.Enabled = false;

            CurrentGoldLBL.Text = "Current gold: " + Convert.ToString(game.Gold);

            for (int i = 0; i < this.game.Party.Length; i++)
            {
                SelectHero_CMB.Items.Add(this.game.Party[i]);
            }
            
            SelectHero_CMB.ValueMember = "Character";
            SelectHero_CMB.DisplayMember = "FullTitle";

            this.Controls.Add(SelectHero_CMB);

            SelectHero_CMB.SelectedItem = null;
        }
        private Character prevSelection;
        private Character CandidateCharacter;
        private void HeroCMBBox_SelectChange(object sender, EventArgs e)
        {
            if (SelectHero_CMB.SelectedItem != null && SelectHero_CMB.SelectedItem != prevSelection)
            {
                Character c = (Character)SelectHero_CMB.SelectedItem;
                prevSelection = c;

                int BaseX;
                int BaseY;
                CharacterControls cc = c.Controls;
                cc.RefreshStatLabels();

                this.Invalidate();

                string CritText = cc.LBL_Crit.Text;
                string ArmourText = cc.LBL_Armour.Text;
                string DodgeText = cc.LBL_Dodge.Text;
                string SpeedText = cc.LBL_Speed.Text;
                string HPText = cc.LBL_HPFraction.Text;
                string ManaText = cc.LBL_ManaFraction.Text;

                HPLabel.Text = "Health: " + HPText;
                ManaLabel.Text = "Mana: " + ManaText;
                CritLabel.Text = CritText;
                DodgeLabel.Text = DodgeText;
                SpeedLabel.Text = SpeedText;
                ArmourLabel.Text = ArmourText;

                BaseX = HPLabel.Location.X; BaseY = HPLabel.Location.Y;

                CurrentCost = 2000;

                ConfirmButton.Text = $"Level up | Cost: {CurrentCost}";
                
                var className = c.GetType();

                Character tempChar = (Character)Activator.CreateInstance(className, new object[] { CharacterType.Hero, c.Level + 1 }); // CHANGE 5 to 1
                Character SelectedHero = (Character)SelectHero_CMB.SelectedItem;


                tempChar.MaxHealth = SelectedHero.MaxHealth < tempChar.MaxHealth ? tempChar.MaxHealth : (int)Math.Ceiling(SelectedHero.MaxHealth * 1.15f);
                tempChar.MaxMana = SelectedHero.MaxMana < tempChar.MaxMana ? tempChar.MaxMana : (int)Math.Ceiling(SelectedHero.MaxMana * 1.15f);
                tempChar.CritChance = SelectedHero.CritChance < tempChar.CritChance ? tempChar.CritChance : (float)Math.Round(SelectedHero.CritChance * 1.15f, 2);
                tempChar.DodgeChance = SelectedHero.DodgeChance < tempChar.DodgeChance ? tempChar.DodgeChance : (float)Math.Round(SelectedHero.DodgeChance * 1.15f, 2);
                tempChar.Armour = SelectedHero.Armour < tempChar.Armour ? tempChar.Armour : (int)Math.Ceiling(SelectedHero.Armour * 1.15f);
                tempChar.Speed = SelectedHero.Speed < tempChar.Speed ? tempChar.Speed : (int)Math.Round(SelectedHero.Speed * 1.15f, 2);
                
                tempChar.Controls = new CharacterControls(tempChar, tempChar.Abilities, tempChar.MaxHealth, tempChar.MaxMana);
                var tempCC = tempChar.Controls;

                CritText = tempCC.LBL_Crit.Text;
                ArmourText = tempCC.LBL_Armour.Text;
                DodgeText = tempCC.LBL_Dodge.Text;
                SpeedText = tempCC.LBL_Speed.Text;
                HPText = tempCC.LBL_HPFraction.Text;
                ManaText = tempCC.LBL_ManaFraction.Text;

                HPLabelAfter.Text = "Health: " + HPText;
                ManaLabelAfter.Text = "Mana: " + ManaText;
                CritLabelAfter.Text = CritText;
                DodgeLabelAfter.Text = DodgeText;
                SpeedLabelAfter.Text = SpeedText;
                ArmourLabelAfter.Text = ArmourText;

                CandidateCharacter = tempChar;

                ShowArrows();

                if (CurrentCost < game.Gold)
                {
                    ConfirmButton.Enabled = true;
                }

                this.Invalidate();

            }
        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            SelectHero_CMB.SelectedItem = null;
            SelectHero_CMB.Items.Clear();
            prevSelection = null;
            HideArrows();
        }
    }
}
