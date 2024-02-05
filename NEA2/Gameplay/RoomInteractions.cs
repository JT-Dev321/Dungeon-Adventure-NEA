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
        protected int XPadding = 0;
        protected int YPadding = 110;
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

                    pb.Size = new Size(200, 400);

                    pb.Location = new Point(x, y);
                    pb.BackColor = Color.Black;

                    cc.NameLabel.Text = c.Name;


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

                    cc.StatusEffectsBox.Location = new Point(x + (pb.Width / 2) - (cc.StatusEffectsBox.Width / 2), cc.LBL_Dodge.Location.Y + cc.LBL_Dodge.Height + 5);


                    cc.NameLabel.BackColor = Color.Transparent;
                    cc.LBL_Crit.BackColor = Color.Transparent;
                    cc.LBL_Armour.BackColor = Color.Transparent;
                    cc.LBL_Dodge.BackColor = Color.Transparent;
                    cc.LBL_Speed.BackColor = Color.Transparent;

                    cc.NameLabel.Parent = form;
                    cc.HealthBar.Parent = form;
                    cc.ManaBar.Parent = form;
                    cc.LBL_Crit.Parent = form;
                    cc.LBL_Armour.Parent = form;
                    cc.LBL_Dodge.Parent = form;
                    cc.LBL_Speed.Parent = form;
                    cc.LBL_HPFraction.Parent = form;
                    cc.LBL_ManaFraction.Parent = form;
                    cc.StatusEffectsBox.Parent = form;

                    cc.Picture.Location = new Point(cc.Picture.Location.X + XPadding, cc.Picture.Location.Y + YPadding);
                    cc.ClassLabel.Location = new Point(cc.ClassLabel.Location.X + XPadding, cc.ClassLabel.Location.Y + YPadding);
                    cc.NameLabel.Location = new Point(cc.NameLabel.Location.X + XPadding, cc.NameLabel.Location.Y + YPadding);
                    cc.HealthBar.Location = new Point(cc.HealthBar.Location.X + XPadding, cc.HealthBar.Location.Y + YPadding);
                    cc.ManaBar.Location = new Point(cc.ManaBar.Location.X + XPadding, cc.ManaBar.Location.Y + YPadding);
                    cc.LBL_Crit.Location = new Point(cc.LBL_Crit.Location.X + XPadding, cc.LBL_Crit.Location.Y + YPadding);
                    cc.LBL_Armour.Location = new Point(cc.LBL_Armour.Location.X + XPadding, cc.LBL_Armour.Location.Y + YPadding);
                    cc.LBL_Dodge.Location = new Point(cc.LBL_Dodge.Location.X + XPadding, cc.LBL_Dodge.Location.Y + YPadding);
                    cc.LBL_Speed.Location = new Point(cc.LBL_Speed.Location.X + XPadding, cc.LBL_Speed.Location.Y + YPadding);
                    cc.LBL_HPFraction.Location = new Point(cc.LBL_HPFraction.Location.X + XPadding, cc.LBL_HPFraction.Location.Y + YPadding);
                    cc.LBL_ManaFraction.Location = new Point(cc.LBL_ManaFraction.Location.X + XPadding, cc.LBL_ManaFraction.Location.Y + YPadding);
                    cc.StatusEffectsBox.Location = new Point(cc.StatusEffectsBox.Location.X + XPadding, cc.StatusEffectsBox.Location.Y + YPadding);


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
                    form.Controls.Add(cc.StatusEffectsBox);
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
        public List<Character> OrderedChars;
        private int counter = 0;
        private int maxCount;
        public Button NextTurnBTN;
        public Label TurnInfoLBL;
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
                    pb.Size = new Size(200, 400);

                    cc.NameLabel.Text = c.Name;

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

                    cc.StatusEffectsBox.Location = new Point(x + (pb.Width / 2) - (cc.StatusEffectsBox.Width / 2), cc.LBL_Dodge.Location.Y + cc.LBL_Dodge.Height + 5);
                    
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
                    cc.StatusEffectsBox.Parent = form;

                    cc.Picture.Location = new Point(cc.Picture.Location.X + XPadding, cc.Picture.Location.Y + YPadding);
                    cc.ClassLabel.Location = new Point(cc.ClassLabel.Location.X + XPadding, cc.ClassLabel.Location.Y + YPadding);
                    cc.NameLabel.Location = new Point(cc.NameLabel.Location.X + XPadding, cc.NameLabel.Location.Y + YPadding);
                    cc.HealthBar.Location = new Point(cc.HealthBar.Location.X + XPadding, cc.HealthBar.Location.Y + YPadding);
                    cc.ManaBar.Location = new Point(cc.ManaBar.Location.X + XPadding, cc.ManaBar.Location.Y + YPadding);
                    cc.LBL_Crit.Location = new Point(cc.LBL_Crit.Location.X + XPadding, cc.LBL_Crit.Location.Y + YPadding);
                    cc.LBL_Armour.Location = new Point(cc.LBL_Armour.Location.X + XPadding, cc.LBL_Armour.Location.Y + YPadding);
                    cc.LBL_Dodge.Location = new Point(cc.LBL_Dodge.Location.X + XPadding, cc.LBL_Dodge.Location.Y + YPadding);
                    cc.LBL_Speed.Location = new Point(cc.LBL_Speed.Location.X + XPadding, cc.LBL_Speed.Location.Y + YPadding);
                    cc.LBL_HPFraction.Location = new Point(cc.LBL_HPFraction.Location.X + XPadding, cc.LBL_HPFraction.Location.Y + YPadding);
                    cc.LBL_ManaFraction.Location = new Point(cc.LBL_ManaFraction.Location.X + XPadding, cc.LBL_ManaFraction.Location.Y + YPadding);
                    cc.StatusEffectsBox.Location = new Point(cc.StatusEffectsBox.Location.X + XPadding, cc.StatusEffectsBox.Location.Y + YPadding);


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
                    form.Controls.Add(cc.StatusEffectsBox);
                    cc.LBL_HPFraction.BringToFront();
                    cc.LBL_ManaFraction.BringToFront();
                    form.Invalidate();
                    c.HideControls();
                }
            }
        }
        public void GenSpeedOrderChars()
        {

            OrderedChars = base.Allies.Where(c => !c.isDead)
                         .Concat(Enemies.Where(e => !e.isDead))
                         .OrderByDescending(c => c.Speed)
                         .ToList(); maxCount = OrderedChars.Count;
            // ADD PROPER SORTING ALGORITHM
        }
        public void RefreshAllStatLBLs()
        {
            foreach (Character c in base.Allies.Concat(Enemies))
            {
                c.Controls.RefreshStatLabels();
            }
        }
        
        public CombatInstance(EnemyRoom room, Character[] allies, Character[] enemies) : base(room, allies)
        {
            this.room = room;
            this.Enemies = enemies;
        }
        public void CombatStart()
        {

            GenSpeedOrderChars();

            Form form = this.room.Dungeon.DungeonForm;

            NextTurnBTN = new Button();
            NextTurnBTN.Size = new Size(90, 35);
            NextTurnBTN.Location = new Point((form.Width / 2) - (NextTurnBTN.Width / 2), (form.Height / 10) * 2 + 35);
            NextTurnBTN.Text = "Increment turn";
            NextTurnBTN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            NextTurnBTN.BackColor = Color.White;

            form.Controls.Add(NextTurnBTN);
            NextTurnBTN.Show();
            NextTurnBTN.Click += new EventHandler(ExecuteNextTurn);

            TurnInfoLBL = new Label();
            TurnInfoLBL.AutoSize = true;
            TurnInfoLBL.Location = new Point(500,65);
            TurnInfoLBL.Font = new Font(FontFamily.GenericSansSerif, 12);
            TurnInfoLBL.Text = "";
            TurnInfoLBL.Tag = "Dynamic";
            TurnInfoLBL.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            TurnInfoLBL.BackColor = Color.Transparent;

            form.Controls.Add(TurnInfoLBL);
            TurnInfoLBL.Show();

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
                /*
                foreach(Character character in this.OrderedChars)
                {
                    CombatTurnHandler.TickSpecialFX(character);
                }
                */
                if (!c.isDead)
                {
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
                        Character LowestEN, HighestEN, LowestAL, HighestAL, ChosenTarget = null;
                        Ability ChosenAbility = null;

                        LowestEN = Allies.OrderBy(x => x.Health).First();
                        HighestEN = Allies.OrderBy(x => x.Health).Last();
                        LowestAL = Enemies.OrderBy(x => x.Health).First();
                        HighestAL = Enemies.OrderBy(x => x.Health).Last();


                        if (LowestAL.Health < LowestAL.MaxHealth * 0.33)
                        { // tries to do a support move if there is a weak ally
                            // heal,divine,smoke,divineshield
                            List<Ability> intersect = new List<Ability>();
                            foreach (Ability ability in c.Abilities)
                            {
                                if (ability.GetType() == typeof(SmokeBomb) && LowestAL == c)
                                {
                                    intersect.Add(ability);
                                }
                                if (ability.GetType() == typeof(Heal) ||
                                    ability.GetType() == typeof(DivineIntervention) ||
                                    ability.GetType() == typeof(DivineShield))
                                {
                                    intersect.Add(ability);
                                }
                            }
                            if (intersect.Count > 0)
                            {
                                ChosenAbility = intersect[rndm.Next(0, intersect.Count)];
                                ChosenTarget = LowestAL;
                            }
                        }
                        else if (LowestEN.Health < LowestEN.MaxHealth * 0.6)
                        {
                            // tries to damage a finish off weak enemies
                            ChosenTarget = LowestEN;

                            ChosenAbility = Utils.RemoveSupportAbilities(c.Abilities).OrderBy(a => a.Damage).Last();
                        }
                        else
                        {
                            // if nobody is weak, try to deal splash damage, alternatively kill the weakest enemy
                            bool found = false;
                            foreach (Ability ability in c.Abilities)
                            {
                                if (ability.effect == Ability.SpecialEffect.SplashAll ||
                                    ability.effect == Ability.SpecialEffect.SplashL ||
                                    ability.effect == Ability.SpecialEffect.SplashR ||
                                    ability.effect == Ability.SpecialEffect.SplashLR)
                                {
                                    ChosenAbility = ability;
                                    ChosenTarget = Allies[rndm.Next(0,Allies.Length)];
                                    found = true;
                                }
                            }
                            if (!found)
                            {
                                ChosenAbility = c.Abilities.OrderBy(a => a.Damage).Last();
                                ChosenTarget = LowestEN;
                            }
                        }
                        
                        CombatTurnHandler.HandleCombatInteraction(c, ChosenTarget, ChosenAbility, this);
                    }
                }
                if (Allies.All(x => x.Health <= 0) || Enemies.All(x => x.Health <= 0))
                {
                    HasConcluded = true;
                }
                foreach (Character character in Allies.Concat(Enemies))
                {
                    character.AddMana(5);
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
            // OrderedChars = OrderedChars.Where(x => x.isDead != true).ToList();
        }
    }
    // combat: 
    // still left off making the combat system - How to select a char, then a move, then a target etc...

}
