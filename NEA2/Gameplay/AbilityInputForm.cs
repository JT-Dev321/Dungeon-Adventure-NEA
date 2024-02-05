using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NEA2.Gameplay;

namespace NEA2
{

    public partial class AbilityInputForm : Form
    {
        // private ComboBox allyComboBox;
        private ComboBox abilityComboBox;
        private ComboBox targetComboBox;
        private Button submitButton;

        private Label AbilityDesc;

        private Character[] allies;
        private Character[] enemies;
        private CombatInstance combatInstance;

        private Character SelectedChar;



        public AbilityInputForm(CombatInstance combatInstance, Character character)
        {
            this.combatInstance = combatInstance;
            this.allies = combatInstance.Allies;
            this.enemies = combatInstance.Enemies;
            this.SelectedChar = character;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            int padding = 15;
            Label HeroLabel = new Label();
            HeroLabel.Location = new Point(padding, padding);
            HeroLabel.Font = new Font(FontFamily.GenericSansSerif, 12);
            HeroLabel.Width = 180;
            HeroLabel.Text = $"{SelectedChar.ClassName} - {SelectedChar.Name}";

            abilityComboBox = new ComboBox();
            abilityComboBox.Location = new Point(HeroLabel.Location.X + HeroLabel.Width, padding);
            abilityComboBox.Enabled = false;
            abilityComboBox.SelectedIndexChanged += new EventHandler(AbilityComboBox_SelectedIndexChanged);
            abilityComboBox.Font = new Font(FontFamily.GenericSansSerif, 12);
            //abilityComboBox.Width = 150;

            targetComboBox = new ComboBox();
            targetComboBox.Location = new Point(abilityComboBox.Location.X + abilityComboBox.Width + 5, padding);
            targetComboBox.Enabled = false;
            targetComboBox.SelectedIndexChanged += new EventHandler(TargetComboBox_SelectedIndexChanged);
            targetComboBox.Font = new Font(FontFamily.GenericSansSerif, 12);
            //targetComboBox.Width = 150;



            this.Size = new Size(targetComboBox.Location.X + targetComboBox.Width + padding, 170);


            AbilityDesc = new Label();
            AbilityDesc.Location = new Point(HeroLabel.Location.X, HeroLabel.Location.Y + HeroLabel.Height + 5);
            AbilityDesc.Size = new Size(200, 150);
            AbilityDesc.Font = new Font(FontFamily.GenericSansSerif, 9);

            submitButton = new Button();
            submitButton.Text = "Submit";
            submitButton.Location = new Point(AbilityDesc.Location.X + AbilityDesc.Width + 5, 60);
            submitButton.Enabled = false;
            submitButton.Click += new EventHandler(SubmitButton_Click);

            /*
            List<IndexedCharacter> indexedAllies = new List<IndexedCharacter>();

            for (int i = 0; i < allies.Length; i++)
            {
                if (!allies[i].isDead) // this doesnt work
                {
                    indexedAllies.Add(new IndexedCharacter(allies[i], i + 1));
                }
            }

            allyComboBox.DataSource = indexedAllies;
            // allyComboBox.DisplayMember = "Character.Name";
            allyComboBox.ValueMember = "Character";


            allyComboBox.DisplayMember = "Name";
            */
            abilityComboBox.DisplayMember = "Name";
            targetComboBox.DisplayMember = "FullTitle";

            // this.Controls.Add(allyComboBox);
            this.Controls.Add(HeroLabel);
            this.Controls.Add(abilityComboBox);
            this.Controls.Add(targetComboBox);
            this.Controls.Add(submitButton);
            this.Controls.Add(AbilityDesc);
            AbilityDesc.BringToFront();
            // allyComboBox.SelectedItem = null;

            abilityComboBox.Items.Clear();
            abilityComboBox.SelectedItem = null;
            abilityComboBox.Enabled = true;

            Character selectedAlly = SelectedChar;

            selectedAlly.HighlightSelected();

            foreach (var ability in selectedAlly.Abilities)
            {
                if (ability.Costs.Mana <= selectedAlly.Mana && ability.Costs.Health < selectedAlly.Health)
                {
                    abilityComboBox.Items.Add(ability);
                }
            }

        }

        private void AbilityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            targetComboBox.Items.Clear();
            targetComboBox.SelectedItem = null;
            targetComboBox.Enabled = true;

            Ability selectedAbility = (Ability)abilityComboBox.SelectedItem;

            Ability a = selectedAbility;

            string temp = $"Base Damage: {a.Damage}\nMiss Chance: {a.MissChance * 100}%\nCrit Chance Mult: {a.CritChanceMult}";
            if (a.Costs.Health > 0)
            {
                temp += $"\nHP Cost: {a.Costs.Health}";
            }
            if (a.Costs.Mana > 0)
            {
                temp += $"\nMana Cost: {a.Costs.Mana}";
            }
            temp += "\nTargets: ";
            List<string> templist = new List<string>();
            foreach (int i in a.TargetablePositions)
            {
                switch (i)
                {
                    case 1:
                        templist.Add("Front");
                        break;
                    case 2:
                        templist.Add("Middle Left");
                        break;
                    case 3:
                        templist.Add("Middle Right");
                        break;
                    case 4:
                        templist.Add("Back");
                        break;
                    case -1:
                        templist.Add("Allies");
                        break;

                }
            }
            temp += string.Join(", ", templist);
            temp += $"\nEffects: {a.effect.ToString()}";
            
            AbilityDesc.Text = temp;
            AbilityDesc.Show();

            foreach (int i in selectedAbility.TargetablePositions)
            {
                if (i == -1)
                {
                    foreach (var v in allies)
                    {
                        if (!v.isDead)
                        {
                            targetComboBox.Items.Add(v);
                        }
                    }
                }
                else
                {
                    if (!enemies[i - 1].isDead)
                    {
                        targetComboBox.Items.Add(enemies[i - 1]);
                    }
                }
            }
            if (selectedAbility.effect == Ability.SpecialEffect.SplashAll || targetComboBox.Items.Count == 1)
            {
                targetComboBox.SelectedIndex = 0;
            }
        }

        private void TargetComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            submitButton.Enabled = true;
            
            foreach(Character c in this.enemies)
            {
                c.UnHighlight();
            }
            
            Character selectedTarget = (Character)targetComboBox.SelectedItem;
            selectedTarget.HighlightTargeted();

        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            // Here you handle the selected items
            // Character selectedCharacter = (Character)((IndexedCharacter)allyComboBox.SelectedValue).Char;
            Ability selectedAbility = (Ability)abilityComboBox.SelectedItem;
            Character selectedTarget = (Character)targetComboBox.SelectedItem;

            this.Invalidate();
            this.Hide();
            selectedAbility.Execute(SelectedChar, selectedTarget, this.combatInstance);
            // Do something with selectedCharacter and selectedAbility
            this.combatInstance.NextTurnBTN.Enabled = true;

            foreach (Character c in this.allies.Concat(this.enemies))
            {
                c.UnHighlight();
            }
        }

        private void AbilityInputForm_Load(object sender, EventArgs e)
        {

        }
    }

}
