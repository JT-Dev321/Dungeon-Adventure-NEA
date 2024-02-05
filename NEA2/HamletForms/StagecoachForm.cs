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
    
    public partial class StagecoachForm : Form
    {
        private int CalculateCost(Character character)
        {
            Character c = character;
            int cost = 0;

            cost += c.MaxHealth * 10;
            cost += c.MaxMana * 10;
            cost += (int)c.CritChance * 100 * 5;
            cost += (int)c.DodgeChance * 100 * 5;
            cost += c.Armour * 5;
            cost += (int)c.Speed * 5;
            cost += c.Level * 500;
            cost += c.Abilities.Length * 100;

            return cost;

        }
        private Game game;
        private Random rndm = new Random();
        private List<Character> SaleList = new List<Character>();
        public StagecoachForm(Game game)
        {
            InitializeComponent();
            this.game = game;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        // add cost for finding new character, random character, class stats, etcc.....
        // purchase price calculated from stats & level etc
        // add separate function where player can swap out members of their party
        private void StagecoachForm_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1000, 900);
        }
        private void UpdateSaleList()
        {
            List<Control> controlstoremove = new List<Control>();
            foreach (Control c in this.Controls)
            {
                try
                {
                    if ((string)c.Tag != "protected")
                    {
                        controlstoremove.Add(c);
                    }
                }
                catch
                {
                    controlstoremove.Add(c);
                }
            }
            foreach (Control c in controlstoremove)
            {
                this.Controls.Remove(c);
            }
            for (int i = 0; i < SaleList.Count; i++)
            {
                Character c = SaleList[i];
                //Console.WriteLine($"{i}: " + c.FullTitle);
                // somethings wrong
                PictureBox pb = c.Controls.Picture;
                Form form = this;
                CharacterControls cc = c.Controls;
                // 20 padding between each, 
                

                int x = 10;
                int y = 10 + (i * 205);


                pb.Location = new Point(x, y);
                pb.Size = new Size(100, 200);
                pb.BackColor = Color.Black;


                cc.ClassLabel.Location = new Point(pb.Location.X + pb.Width + 5, pb.Location.Y + 10);
                cc.ClassLabel.ForeColor = Color.Green;

                
                cc.NameLabel.Location = new Point(cc.ClassLabel.Location.X, cc.ClassLabel.Location.Y + cc.ClassLabel.Height + 5);
                cc.NameLabel.Text = "Name";
                cc.NameLabel.ForeColor = Color.Green;
                
                cc.LBL_HPFraction.Location = new Point(cc.ClassLabel.Location.X + cc.ClassLabel.Width + 5, pb.Location.Y + 20);
                cc.LBL_ManaFraction.Location = new Point(cc.LBL_HPFraction.Location.X, cc.LBL_HPFraction.Location.Y + cc.LBL_HPFraction.Height + 5);

                if (!cc.LBL_HPFraction.Text.Contains("Health: "))
                {
                    cc.LBL_HPFraction.Text = $"Health: {cc.LBL_HPFraction.Text}";
                    cc.LBL_ManaFraction.Text = $"Mana: {cc.LBL_ManaFraction.Text}";
                }
                cc.LBL_Crit.Location = new Point(cc.LBL_HPFraction.Location.X + cc.LBL_HPFraction.Width + 5, pb.Location.Y + 20);
                cc.LBL_Armour.Location = new Point(cc.LBL_Crit.Location.X, cc.LBL_Crit.Location.Y + cc.LBL_Crit.Height + 5);
                cc.LBL_Dodge.Location = new Point(cc.LBL_Crit.Location.X + cc.LBL_Crit.Width + 5, pb.Location.Y + 20);
                cc.LBL_Speed.Location = new Point(cc.LBL_Crit.Location.X + cc.LBL_Crit.Width + 5, cc.LBL_Crit.Location.Y + cc.LBL_Crit.Height + 5);

                cc.ClassLabel.BackColor = Color.Transparent;
                cc.NameLabel.BackColor = Color.Transparent;
                cc.LBL_Crit.BackColor = Color.Transparent;
                cc.LBL_Armour.BackColor = Color.Transparent;
                cc.LBL_Dodge.BackColor = Color.Transparent;
                cc.LBL_Speed.BackColor = Color.Transparent;

                cc.ClassLabel.Parent = form;
                cc.NameLabel.Parent = form;
                cc.LBL_Crit.Parent = form;
                cc.LBL_Armour.Parent = form;
                cc.LBL_Dodge.Parent = form;
                cc.LBL_Speed.Parent = form;
                cc.LBL_HPFraction.Parent = form;
                cc.LBL_ManaFraction.Parent = form;

                Button purchaseBTN = new Button
                {
                    Size = new Size(120,120),
                    Location = new Point(cc.LBL_Dodge.Location.X + cc.LBL_Dodge.Width + 5, cc.LBL_Dodge.Location.Y),
                    Text = $"Purchase ({CalculateCost(c)} gold)",
                    Tag = c,
                };
                purchaseBTN.Click += (sender, e) => PurchaseChar(sender, e, (Character)purchaseBTN.Tag);

                form.Controls.Add(pb);
                form.Controls.Add(purchaseBTN);
                form.Controls.Add(cc.ClassLabel);
                form.Controls.Add(cc.NameLabel);
                form.Controls.Add(cc.LBL_Crit);
                form.Controls.Add(cc.LBL_Armour);
                form.Controls.Add(cc.LBL_Dodge);
                form.Controls.Add(cc.LBL_Speed);
                form.Controls.Add(cc.LBL_HPFraction);
                form.Controls.Add(cc.LBL_ManaFraction);
                cc.LBL_HPFraction.BringToFront();
                cc.LBL_ManaFraction.BringToFront();
                
            }
            this.Invalidate();
        }

        private void PurchaseChar(object sender, EventArgs e, Character character)
        {
            if (this.game.Gold > CalculateCost(character))
            {
                this.game.Gold -= CalculateCost(character);
                this.game.OwnedCharacters.Add(character);
                character.SetName();
                this.SaleList.Remove(character);
                UpdateSaleList();
            }
        }

        private void BuyNewChar_Click(object sender, EventArgs e)
        {
            if (this.game.Gold > Convert.ToInt32(BuyNewChar.Text.Split('(')[1].Split('g')[0]))
            {
                AddChar(1);
                this.game.Gold -= Convert.ToInt32(BuyNewChar.Text.Split('(')[1].Split('g')[0]);
                BuyNewChar.Text = "Buy New Character (" + Convert.ToString(Convert.ToInt32(BuyNewChar.Text.Split('(')[1].Split('g')[0]) + (30 * this.game.Level)) + "g)";
            }
        }
        private void AddChar(int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (SaleList.Count == 4)
                {
                    SaleList[rndm.Next(SaleList.Count)] = CharacterFactory.CreateRandomCharacter(CharacterType.Hero, rndm.Next(game.Level - 1, game.Level + 2), false);
                }
                else
                {
                    SaleList.Add(CharacterFactory.CreateRandomCharacter(CharacterType.Hero, rndm.Next(game.Level - 1, game.Level + 2), false));
                }
            }
            UpdateSaleList();
        }
        
    }
}
