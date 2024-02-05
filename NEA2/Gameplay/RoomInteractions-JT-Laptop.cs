using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;

namespace NEA2.Gameplay
{
    public class RoomInteractions
    {
        private DungeonRoom room;
        protected Random rndm = new Random();
        public Character[] Allies = new Character[4]; // need to treat as reveresed
        // A[3],A[2],A[1],A[0] | E[0],E[1],E[2],E[3]
        public RoomInteractions(DungeonRoom room, Character[] allies)
        {
            this.room = room;
            this.Allies = allies;
        }
        public void LoadAllyControls()
        {
            for (int i = 0; i < 4; i++)
            {
                if (Allies[i] != null)
                {
                    // A[3],A[2],A[1],A[0] | E[0],E[1],E[2],E[3]

                    Character c = Allies[i];
                    PictureBox pb = c.Controls.Picture;
                    Form form = this.room.Dungeon.DungeonForm;
                    CharacterControls cc = c.Controls;
                    // 20 padding between each, 
                    int x = (form.Width / 2) - ((i + 1) * 220);
                    int y = (form.Height / 4);


                    pb.Location = new Point(x, y);
                    pb.BackColor = Color.Black;

                    


                    cc.ClassLabel.Location = new Point(x + (pb.Width / 2) - (cc.ClassLabel.Width / 2), y - cc.ClassLabel.Height);
                    cc.ClassLabel.ForeColor = Color.Green;

                    cc.NameLabel.Location = new Point(x + (pb.Width / 2) - (cc.NameLabel.Width / 2), cc.ClassLabel.Location.Y - cc.NameLabel.Height - 5);
                    cc.NameLabel.ForeColor = Color.Green;

                    cc.HealthBar.Location = new Point(x + (pb.Width / 2) - (cc.HealthBar.Width / 2), y + pb.Height + 5);
                    cc.LBL_HPFraction.AutoSize = true;
                    cc.LBL_HPFraction.Parent = cc.HealthBar;
                    cc.LBL_HPFraction.Location = new Point((cc.HealthBar.Location.X) + (cc.HealthBar.Width / 2) - (cc.LBL_HPFraction.Width / 2), (cc.HealthBar.Location.Y) + (cc.HealthBar.Height / 2) - (cc.LBL_HPFraction.Height / 2));
                    cc.LBL_HPFraction.BackColor = Color.White;

                    cc.ManaBar.Location = new Point(x + (pb.Width / 2) - (cc.ManaBar.Width / 2), cc.HealthBar.Location.Y + cc.HealthBar.Height + 5);
                    cc.LBL_ManaFraction.AutoSize = true;
                    cc.LBL_ManaFraction.Parent = cc.ManaBar;
                    cc.LBL_ManaFraction.Location = new Point((cc.ManaBar.Location.X) + (cc.ManaBar.Width / 2) - (cc.LBL_ManaFraction.Width / 2), (cc.ManaBar.Location.Y) + (cc.ManaBar.Height / 2) - (cc.LBL_ManaFraction.Height / 2));
                    cc.LBL_ManaFraction.BackColor = Color.White;

                    cc.LBL_Crit.Location = new Point(x + 5, cc.ManaBar.Location.Y + cc.ManaBar.Height + 5);
                    cc.LBL_Armour.Location = new Point(x + 5 + cc.LBL_Crit.Width + 5, cc.ManaBar.Location.Y + cc.ManaBar.Height + 5);
                    cc.LBL_Dodge.Location = new Point(x + 5, cc.LBL_Crit.Location.Y + cc.LBL_Crit.Height + 5);
                    cc.LBL_Speed.Location = new Point(x + 5 + cc.LBL_Dodge.Width + 5, cc.LBL_Dodge.Location.Y);


                    cc.ClassLabel.BackColor = Color.Transparent;
                    cc.NameLabel.BackColor = Color.Transparent;
                    cc.LBL_Crit.BackColor = Color.Transparent;
                    cc.LBL_Armour.BackColor = Color.Transparent;
                    cc.LBL_Dodge.BackColor = Color.Transparent;
                    cc.LBL_Speed.BackColor = Color.Transparent;

                    cc.ClassLabel.Parent = form;
                    cc.NameLabel.Parent = form;
                    cc.HealthBar.Parent = form;
                    cc.ManaBar.Parent = form;
                    cc.LBL_Crit.Parent = form;
                    cc.LBL_Armour.Parent = form;
                    cc.LBL_Dodge.Parent = form;
                    cc.LBL_Speed.Parent = form;
                    cc.LBL_HPFraction.Parent = form;
                    cc.LBL_ManaFraction.Parent = form;


                    form.Controls.Add(pb);
                    form.Controls.Add(cc.ClassLabel);
                    form.Controls.Add(cc.NameLabel);
                    form.Controls.Add(cc.HealthBar);
                    form.Controls.Add(cc.ManaBar);
                    form.Controls.Add(cc.LBL_Crit);
                    form.Controls.Add(cc.LBL_Armour);
                    form.Controls.Add(cc.LBL_Dodge);
                    form.Controls.Add(cc.LBL_Speed);
                    form.Controls.Add(cc.LBL_HPFraction);
                    form.Controls.Add(cc.LBL_ManaFraction);
                    cc.LBL_HPFraction.BringToFront();
                    cc.LBL_ManaFraction.BringToFront();
                    form.Invalidate();
                    // c.HideControls();
                }
            }
        }

        
    }
    public class CombatInstance : RoomInteractions
    {
        private EnemyRoom room;
        public Character[] Enemies = new Character[4];
        public Character[] OrderedChars;
        private int counter = 0;
        private int maxCount;
        public Button NextTurnBTN;
        private List<string> TurnHistory = new List<string>();
        public bool HasConcluded = false;
        public void LoadEnemyControls()
        {
            for (int i = 0; i < 4; i++)
            {

                if (this.Enemies[i] != null)
                {
                    // A[3],A[2],A[1],A[0] | E[0],E[1],E[2],E[3]

                    Character c = this.Enemies[i];
                    PictureBox pb = c.Controls.Picture;
                    Form form = this.room.Dungeon.DungeonForm;
                    CharacterControls cc = c.Controls;
                    // 20 padding between each, 
                    int x = (form.Width / 2) + 20 + (i * 220);
                    int y = (form.Height / 4);

                    pb.Location = new Point(x, y);
                    pb.BackColor = Color.Black;


                    cc.ClassLabel.Location = new Point(x + (pb.Width / 2) - (cc.ClassLabel.Width / 2), y - cc.ClassLabel.Height);
                    cc.ClassLabel.ForeColor = Color.Red;

                    cc.NameLabel.Location = new Point(x + (pb.Width / 2) - (cc.NameLabel.Width / 2), cc.ClassLabel.Location.Y - cc.NameLabel.Height - 5);
                    cc.NameLabel.ForeColor = Color.Red;

                    cc.HealthBar.Location = new Point(x + (pb.Width / 2) - (cc.HealthBar.Width / 2), y + pb.Height + 5);
                    cc.LBL_HPFraction.AutoSize = true;
                    cc.LBL_HPFraction.Parent = cc.HealthBar;
                    cc.LBL_HPFraction.Location = new Point((cc.HealthBar.Location.X) + (cc.HealthBar.Width / 2) - (cc.LBL_HPFraction.Width / 2), (cc.HealthBar.Location.Y) + (cc.HealthBar.Height / 2) - (cc.LBL_HPFraction.Height / 2));
                    cc.LBL_HPFraction.BackColor = Color.White;

                    cc.ManaBar.Location = new Point(x + (pb.Width / 2) - (cc.ManaBar.Width / 2), cc.HealthBar.Location.Y + cc.HealthBar.Height + 5);
                    cc.LBL_ManaFraction.AutoSize = true;
                    cc.LBL_ManaFraction.Parent = cc.ManaBar;
                    cc.LBL_ManaFraction.Location = new Point((cc.ManaBar.Location.X) + (cc.ManaBar.Width / 2) - (cc.LBL_ManaFraction.Width / 2), (cc.ManaBar.Location.Y) + (cc.ManaBar.Height / 2) - (cc.LBL_ManaFraction.Height / 2));
                    cc.LBL_ManaFraction.BackColor = Color.White;

                    cc.LBL_Crit.Location = new Point(x + 5, cc.ManaBar.Location.Y + cc.ManaBar.Height + 5);
                    cc.LBL_Armour.Location = new Point(x + 5 + cc.LBL_Crit.Width + 5, cc.ManaBar.Location.Y + cc.ManaBar.Height + 5);
                    cc.LBL_Dodge.Location = new Point(x + 5, cc.LBL_Crit.Location.Y + cc.LBL_Crit.Height + 5);
                    cc.LBL_Speed.Location = new Point(x + 5 + cc.LBL_Dodge.Width + 5, cc.LBL_Dodge.Location.Y);

                    cc.ClassLabel.BackColor = Color.Transparent;
                    cc.NameLabel.BackColor = Color.Transparent;
                    cc.LBL_Crit.BackColor = Color.Transparent;
                    cc.LBL_Armour.BackColor = Color.Transparent;
                    cc.LBL_Dodge.BackColor = Color.Transparent;
                    cc.LBL_Speed.BackColor = Color.Transparent;

                    cc.ClassLabel.Parent = form;
                    cc.NameLabel.Parent = form;
                    cc.HealthBar.Parent = form;
                    cc.ManaBar.Parent = form;
                    cc.LBL_Crit.Parent = form;
                    cc.LBL_Armour.Parent = form;
                    cc.LBL_Dodge.Parent = form;
                    cc.LBL_Speed.Parent = form;
                    cc.LBL_HPFraction.Parent = form;
                    cc.LBL_ManaFraction.Parent = form;

                    form.Controls.Add(pb);
                    form.Controls.Add(cc.ClassLabel);
                    form.Controls.Add(cc.NameLabel);
                    form.Controls.Add(cc.HealthBar);
                    form.Controls.Add(cc.ManaBar);
                    form.Controls.Add(cc.LBL_Crit);
                    form.Controls.Add(cc.LBL_Armour);
                    form.Controls.Add(cc.LBL_Dodge);
                    form.Controls.Add(cc.LBL_Speed);
                    form.Controls.Add(cc.LBL_HPFraction);
                    form.Controls.Add(cc.LBL_ManaFraction);
                    cc.LBL_HPFraction.BringToFront();
                    cc.LBL_ManaFraction.BringToFront();
                    form.Invalidate();
                    c.HideControls();
                }
            }
        }
        public void GenSpeedOrderChars()
        {

            OrderedChars = base.Allies.Concat(Enemies).OrderByDescending(c => c.Speed).ToArray();
            maxCount = OrderedChars.Length;
            // ADD PROPER SORTING ALGORITHM
        }

        public CombatInstance(EnemyRoom room, Character[] allies, Character[] enemies) : base(room, allies)
        {
            this.room = room;
            this.Enemies = enemies;
        }
        public void CombatStart()
        {
            // completely broken, doesnt wait for you to choose a move
            bool cont = true;
            GenSpeedOrderChars();

            Form form = this.room.Dungeon.DungeonForm;

            NextTurnBTN = new Button();
            NextTurnBTN.Size = new Size(200, 100);
            NextTurnBTN.Location = new Point((form.Width / 2) - (NextTurnBTN.Width / 2), (form.Height / 10) * 8);
            NextTurnBTN.Text = "Increment turn";
            NextTurnBTN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            NextTurnBTN.BackColor = Color.White;
            
            form.Controls.Add(NextTurnBTN);
            NextTurnBTN.Show();
            NextTurnBTN.Click += new EventHandler(ExecuteNextTurn);

            this.room.Dungeon.DungeonForm.ViewMap.Enabled = false;
            this.room.Dungeon.DungeonForm.BTN_GoBack.Enabled = false;

        }

        public void ExecuteNextTurn(object sender, EventArgs e)
        {
            int i = this.counter;
            if (Allies.All(x => x.Health <= 0) || Enemies.All(x => x.Health <= 0))
            {
                HasConcluded = true;
            }
            if (i < maxCount && !HasConcluded)
            {
                Character c = this.OrderedChars[i];
                foreach(Character character in this.OrderedChars)
                {
                    // CombatTurnHandler.TickSpecialFX(character);
                }
                if (c.CharType == CharacterType.Hero)
                {
                    this.NextTurnBTN.Enabled = false;
                    this.NextTurnBTN.Refresh();

                    AbilityInputForm inputform = new AbilityInputForm(this, c);
                    inputform.TopLevel = false;
                    inputform.Parent = this.room.Dungeon.DungeonForm;
                    Utils.ShowForm(inputform, false, true);
                }
                else
                {
                    CombatTurnHandler.HandleCombatInteraction(c, Allies[rndm.Next(0, 4)], c.Abilities[rndm.Next(0, 4)]);
                }
                if (Allies.All(x => x.Health <= 0) || Enemies.All(x => x.Health <= 0))
                {
                    HasConcluded = true;
                }
                this.counter++;
            }
            else
            {
                if (HasConcluded)
                {
                    this.NextTurnBTN.Enabled = false;
                    this.NextTurnBTN.Refresh();
                    this.room.ConcludeRoom(Enemies.All(x => x.Health <= 0));
                }
                else
                {
                    if (i >= maxCount)
                    {
                        this.counter = 0;
                        GenSpeedOrderChars();
                    }
                }
            }

        }
    }
    // combat: 
    // still left off making the combat system - How to select a char, then a move, then a target etc...

}
