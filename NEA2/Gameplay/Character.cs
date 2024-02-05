using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;

namespace NEA2
{
    /*
     * Heros have level --> Dictates stats
     * Stats: Health, Crit chance, Dodge chance, Speed (1-9), (mana) | do a bit of randomness for each to make them seem unique
     * every hero has set base number based on class --> classes = inheritance opportunity
     * Each class has fixed abilities, could potentially make swappable and so not fixed
     * SKills will need to be a separate class, each skill can inherit a "Skill" class and just have unique stuff
     * skills will have: Positions hitting, damage, miss chance, crit chance (multiplies), mana cost
     */
    // Ver 2:
    /*
     * Skills will be class specific some suitable to just 1 class, or a few
     * When a new random character is regenerated in the stagecoach, 
     *  it will be given a random set of 4 abilities for which it is valid to use
     */

    

    public class CharacterControls
    {
        private Character character;
        public PictureBox Picture;
        public Label ClassLabel, NameLabel;
        public ProgressBar HealthBar, ManaBar;
        // public Button AbilityBTN1, AbilityBTN2, AbilityBTN3, AbilityBTN4;
        public Label LBL_Crit, LBL_Dodge, LBL_Speed, LBL_Armour,
                                            LBL_ManaFraction, LBL_HPFraction;
        public ListBox StatusEffectsBox;
        
        // public Button SelectButton;
        public CharacterControls(Character character, Ability[] abilities, int MaxHealth, int MaxMana)
        {
            this.character = character;
            string Name = character.Name;
            string className = character.GetType().Name;
            string tag = null;
            Font BigLBLFont = new Font(FontFamily.GenericSansSerif, 30);
            Font SmallLBLFont = new Font(FontFamily.GenericSansSerif, 8);
            if (character.CharType == CharacterType.Enemy)
            {
                tag = "Dynamic";
            }

            /*
                public float CritChance; // 0-1
                public float DodgeChance; // 0-1
                public float Speed; // really anything, for normal chars 0-10
                public int Mana, MaxMana;
                public int Health, MaxHealth;
                public int Armour; // 1-100 (% reduction)
            */


            Picture = new PictureBox();
            Picture.Size = new Size(200, 400);
            Picture.ImageLocation = $"charicons/{className.ToLower()}icon.png";
            Picture.Tag = tag;
            Picture.SizeMode = PictureBoxSizeMode.StretchImage;

            LBL_Crit = new Label
            {
                Text = $"Crit: {this.character.CritChance * 100}%",
                Font = SmallLBLFont,
                Tag = tag,
            };
            LBL_Armour = new Label
            {
                Text = $"Armour: {this.character.Armour}%",
                Font = SmallLBLFont,
                Tag = tag,
            };
            LBL_Dodge = new Label
            {
                Text = $"Dodge: {this.character.DodgeChance * 100}%",
                Font = SmallLBLFont,
                Tag = tag,
            };
            LBL_Speed = new Label
            {
                Text = $"Speed: {this.character.Speed}",
                Font = SmallLBLFont,
                Tag = tag,
            };
            LBL_HPFraction = new Label
            {
                Text = $"{character.Health}/{character.MaxHealth}",
                Font = SmallLBLFont,
                Tag = tag,
            };
            LBL_ManaFraction = new Label
            {
                Text = $"{character.Mana}/{character.MaxMana}",
                Font = SmallLBLFont,
                Tag = tag,
            };

            NameLabel = new Label();
            NameLabel.Text = Name;
            NameLabel.Tag = tag;
            NameLabel.TextAlign = ContentAlignment.MiddleCenter;
            NameLabel.Font = BigLBLFont;
            NameLabel.Size = new Size(200, 40);

            ClassLabel = new Label(); 
            ClassLabel.Text = className;
            ClassLabel.Tag = tag;
            ClassLabel.TextAlign = ContentAlignment.MiddleCenter;
            ClassLabel.Font = new Font(FontFamily.GenericSansSerif, 20);
            ClassLabel.Size = new Size(200, 40);

            HealthBar = new ProgressBar();
            HealthBar.Minimum = 0;
            HealthBar.Tag = tag;
            HealthBar.Maximum = MaxHealth;
            HealthBar.Value = this.character.Health;
            HealthBar.ForeColor = Color.Red;
            HealthBar.Style = ProgressBarStyle.Continuous;
            HealthBar.Size = new Size(200, 40);

            ManaBar = new ProgressBar();
            ManaBar.Minimum = 0;
            ManaBar.Tag = tag;
            ManaBar.Maximum = MaxMana;
            ManaBar.Value = this.character.Mana;
            ManaBar.ForeColor = Color.Blue;
            ManaBar.Style = ProgressBarStyle.Continuous;
            ManaBar.Size = new Size(200, 40);

            Size buttonsize = new Size(90, 90);

            StatusEffectsBox = new ListBox
            {
                Size = new Size(200, 40),
                Tag = tag,
            };
            List<string> temp = new List<string>();
            foreach (KeyValuePair<StatusEffects, int> kvp in this.character.ActiveStatusEffects)
            {
                StatusEffectsBox.Items.Add($"{kvp.Key.ToString()} | {kvp.Value} turns");
            }
            

            

        }
        public void RefreshStatListBox()
        {
            StatusEffectsBox.Items.Clear();
            foreach (KeyValuePair<StatusEffects, int> kvp in this.character.ActiveStatusEffects)
            {
                StatusEffectsBox.Items.Add($"{kvp.Key.ToString()} | {kvp.Value} turns");
            }
        }
        public void RefreshStatLabels()
        {
            LBL_Crit.Text = $"Crit: {this.character.CritChance * 100}%";

            LBL_Armour.Text = $"Armour: {this.character.Armour}%";

            LBL_Dodge.Text = $"Dodge: {this.character.DodgeChance * 100}%";

            LBL_Speed.Text = $"Speed: {this.character.Speed}";

            if (this.character.Health > this.character.MaxHealth)
            {
                this.character.MaxHealth = this.character.Health;
            }

            if (this.character.Mana > this.character.MaxMana)
            {
                this.character.MaxMana = this.character.Mana;
            }

            LBL_HPFraction.Text = $"{character.Health}/{character.MaxHealth}";

            LBL_ManaFraction.Text = $"{character.Mana}/{character.MaxMana}";

            LBL_Crit.Refresh();
            LBL_Armour.Refresh();
            LBL_Dodge.Refresh();
            LBL_Speed.Refresh();
            LBL_HPFraction.Refresh();
            LBL_ManaFraction.Refresh();
            RefreshStatListBox();
        }
    
        public void UpdateValues()
        {
            if (this.character.Health > this.HealthBar.Maximum)
            {
                this.HealthBar.Maximum = this.character.Health;
            }
            this.HealthBar.Value = this.character.Health;

            if (this.character.Mana > this.ManaBar.Maximum)
            {
                this.ManaBar.Maximum = this.character.Mana;
            }
            this.ManaBar.Value = this.character.Mana;
            

            RefreshStatLabels();
            this.HealthBar.Refresh();
            this.ManaBar.Refresh();
            StatusEffectsBox.Update();
            RefreshStatListBox();
        }
    }
    public enum CharacterType
    {
        Hero,
        Enemy
    }
    public enum StatusEffects
    {
        Poison,
        Burn,
        Weak,
        Strength,
        HPRegeneration,
        ManaRegenetation,
        Invisible,
        Invincible
    }
    public static class CharacterFactory
    {
        private static Random rndm = new Random();

        public static Character CreateRandomCharacter(CharacterType type, int level, bool setname = true)
        {
            var characterType = Utils.CharacterTypes[rndm.Next(Utils.CharacterTypes.Length)];
            Character c = (Character)Activator.CreateInstance(characterType, type, level);

            // hashset didnt work since duplicate objects are seen
            // as separate instances 
            List<Ability> abilities = new List<Ability>();


            while (abilities.Count != 4)
            {
                Ability newAbility = AbilityFactory.GenerateAbility(c);
                if (!abilities.Any(a => a.GetType() == newAbility.GetType()))
                {
                    abilities.Add(newAbility);
                }
            }
            abilities.Add(new Punch());

            c.Abilities = abilities.ToArray();
            if (setname)
            {
                c.SetName();
            }
            c.Controls = new CharacterControls(c, c.Abilities, c.MaxHealth, c.MaxMana);
            return c;
        }
        public static Character CreateCharacterFromKey(string key)
        {
            string[] splitkey = key.Split('|');

            string name = splitkey[0];
            string classname = splitkey[1];
            int level = Convert.ToInt32(splitkey[2]);
            int currenthealth = Convert.ToInt32(splitkey[4]);
            int maxhealth = Convert.ToInt32(splitkey[5]);
            int currentmana = Convert.ToInt32(splitkey[6]);
            int maxmana = Convert.ToInt32(splitkey[7]);
            float critchance = Convert.ToSingle(splitkey[8]);
            float dodgechance = Convert.ToSingle(splitkey[9]);
            int armour = Convert.ToInt32(splitkey[10]);
            int speed = Convert.ToInt32(splitkey[11]);

            string[] abilityNames = new string[] { splitkey[12], splitkey[13], splitkey[14], splitkey[15], splitkey[16] };
            var characterType = Type.GetType($"NEA2.{classname}");
            
            Character c = (Character)Activator.CreateInstance(characterType, CharacterType.Hero, level);

            c.Name = name;
            // Blaze|Druid|4|Hero|223|223|115|115|0|0|19|20|Frostbolt|Heal|Earthquake|Kick|Punch|

            c.MaxHealth = maxhealth;
            c.Health = currenthealth;
            c.MaxHealth = maxhealth;
            c.Mana = currentmana;
            c.MaxMana = maxmana;
            c.CritChance = critchance;
            c.DodgeChance = dodgechance;
            c.Armour = armour;
            c.Speed = speed;

            for (int i = 0; i < 5; i++)
            {
                string ability_name = abilityNames[i];
                Ability a = (Ability)Activator.CreateInstance(Type.GetType($"NEA2.{ability_name}"));
                c.Abilities[i] = a;
            }

            c.Controls = new CharacterControls(c, c.Abilities, c.MaxHealth, c.MaxMana);

            return c;
        }
    }
    public class Character
    {
        public CharacterType CharType;
        public string Name = "";
        public int Level;
        public string ClassName { get
            {
                return this.GetType().ToString().Split('.')[1];
            } }
        public bool isDead { get
            {
                return this.Health <= 0;
            } }
        public string FullTitle { get
            {
                return $"{ClassName} - {Name}";
            } }
        public float CritChance; // 0-1
        public float DodgeChance; // 0-1
        public float Speed; // really anything, for normal chars 0-10
        public int Mana { get; set; } 
        public int Health { get; set; }
        public int MaxHealth, MaxMana;
        public int Armour; // 1-100 (% reduction)
        public Ability[] Abilities = new Ability[5];
        public Dictionary<StatusEffects, int> ActiveStatusEffects = new Dictionary<StatusEffects, int>();
        public CharacterControls Controls;
        // when making abilities for characters,
        // use hashset to prevent duplicates,
        protected Random rndm = new Random();
        /// <summary>
        /// Using this constructor will create a random profession of character
        /// </summary>
        /// <param name="type"></param>
        /// <param name="level">Pass in the player's level</param>
        public Character(CharacterType type, int level)
        {
            this.CharType = type;
            this.Level = level;
        }
        public virtual void InitializeStats()
        {
            this.MaxHealth = rndm.Next(15, 21) * Level + 100;
            this.CritChance = (Level * 0.025f) + 0.01f;
            this.DodgeChance = (Level * 0.025f) + 0.01f;
            this.Speed = (Level * 0.25f) + 3f;
            this.MaxMana = rndm.Next(2, 5) * Level + 30;
            this.Armour = rndm.Next(2,5) * Level + 2;
        }
        public void MultiplyStats(float mult)
        {
            this.MaxHealth = (int)(this.MaxHealth * mult);
            this.MaxMana = (int)(this.MaxMana * mult);
            this.CritChance = this.CritChance * mult;
            this.DodgeChance = this.DodgeChance * mult;
            this.Armour = (int)(this.Armour * mult);
            this.Speed = this.Speed * mult;
            this.ValidateStats();

        }
        public void DrainMana(int mana)
        {
            this.SetMana(this.Mana - mana);
        }
        public void DrainHealth(int damage)
        {
            this.SetHealth(this.Health - damage);
        }
        public void AddMana(int mana)
        {
            this.SetMana(this.Mana + mana);
        }
        public void AddHealth(int health)
        {
            this.SetHealth(this.Health + health);
        }
        public void SetHealth(int health)
        {
            health = Math.Max(health, 0);
            this.Health = Math.Min(health, MaxHealth);

            if (this.Health > this.Controls.HealthBar.Maximum)
            {
                this.Controls.HealthBar.Maximum = this.Health;
            }
            this.Controls.HealthBar.Value = this.Health;
            this.Controls.HealthBar.Refresh();
        }
        public void SetMana(int mana)
        {
            mana = Math.Max(mana, 0);
            this.Mana = Math.Min(mana, MaxMana);
            
            if (this.Mana > this.Controls.ManaBar.Maximum)
            {
                this.Controls.ManaBar.Maximum = this.Mana;
            }
            this.Controls.ManaBar.Value = this.Mana;
            this.Controls.ManaBar.Refresh();
        }
        public void LevelUp()
        {
            this.Level += 1;
            this.InitializeStats();
            this.ValidateStats();
        }
        public void SetName()
        {
            this.Name = Utils.GetRandomName();
        }
        public void ValidateStats()
        {
            // enforce max values
            this.Armour = Math.Min(this.Armour, 70);
            this.Speed = Math.Min(this.Speed, 20);
            this.CritChance = Math.Min(this.CritChance, 0.7f);
            this.DodgeChance = Math.Min(this.DodgeChance, 0.5f);

            //enforce min values
            this.Armour = Math.Max(this.Armour, 0);
            this.Speed = Math.Max(this.Speed, 1);
            this.CritChance = Math.Max(this.CritChance, 0);
            this.DodgeChance = Math.Max(this.DodgeChance, 0);
            this.MaxMana = Math.Max(this.MaxMana, 0);

            this.Health = this.MaxHealth;
            this.Mana = this.MaxMana;

            if (this.Controls != null)
            {
                if (this.Controls.HealthBar != null && this.Controls.ManaBar != null)
                {
                    this.Controls.HealthBar.Maximum = this.MaxHealth;
                    this.Controls.ManaBar.Maximum = this.MaxMana;

                    this.Controls.HealthBar.Value = this.Health;
                    this.Controls.ManaBar.Value = this.Mana;
                }
            }
        }
        public void ValidateStatsCombat()
        {
            if (this.Health < 0)
            {
                this.Health = 0;
                this.Kill();
                // to do (Death)
            }

            if (this.Health > this.MaxHealth)
            {
                this.MaxHealth = this.Health;
            }

            if (this.Mana > this.MaxMana)
            {
                this.MaxMana = this.Mana;
            }

            this.Armour = Math.Max(this.Armour, 0);
            this.Speed = Math.Max(this.Speed, 0);
            this.CritChance = Math.Max(this.CritChance, 0);
            this.DodgeChance = Math.Max(this.DodgeChance, 0);
            this.Mana = Math.Max(this.Mana, 0);
        }
        public void Kill()
        {
            this.ActiveStatusEffects.Clear();
            this.Controls.RefreshStatListBox();
        }
        public void HighlightSelected()
        {
            this.Controls.NameLabel.ForeColor = Color.Yellow;
            this.Controls.ClassLabel.ForeColor = Color.Yellow;
        }
        public void HighlightTargeted()
        {
            this.Controls.NameLabel.ForeColor = Color.DarkRed;
            this.Controls.ClassLabel.ForeColor = Color.DarkRed;
        }
        public void UnHighlight()
        {
            if (this.CharType == CharacterType.Hero)
            {
                this.Controls.NameLabel.ForeColor = Color.Green;
                this.Controls.ClassLabel.ForeColor = Color.Green;
            }
            else
            {
                this.Controls.NameLabel.ForeColor = Color.Red;
                this.Controls.ClassLabel.ForeColor = Color.Red;
            }
        }
        public void ShowControls()
        {
            this.Controls.Picture.Show();

            this.Controls.ClassLabel.Show(); this.Controls.NameLabel.Show();

            this.Controls.HealthBar.Show(); this.Controls.ManaBar.Show();

            
        }
        public void HideControls()
        {
            this.Controls.Picture.Hide();

            this.Controls.ClassLabel.Hide(); this.Controls.NameLabel.Hide();

            this.Controls.HealthBar.Hide(); this.Controls.ManaBar.Hide();

            
        }
        public string Get_Save_Key()
        {
            // name, class, level, type, Health, Maxhealth, Mana, Maxmana, Critchance, Dodgechance, Armour, Speed, Abilities (names), status effects
            string output = $"{Name}|{ClassName}|{Level}|{CharType}|{Health}|{MaxHealth}|{Mana}|{MaxMana}|{CritChance}|{DodgeChance}|{Armour}|{Speed}|";
            foreach (Ability a in Abilities)
            {
                output += a.ToString() + "|";
            }
            foreach (KeyValuePair<StatusEffects, int> kvp in this.ActiveStatusEffects)
            {
                output += $"{(int)kvp.Key}:{kvp.Value}|";
                if (kvp.Value == null)
                {
                    output += "-1:-1";
                }
            }
            return output;
        }
        public void UpdateControlValues()
        {
            this.ValidateStatsCombat();
            this.Controls.UpdateValues();
        }
    }

    public class Wizard : Character
    {
        public Wizard(CharacterType type, int level) : base(type, level)
        {
            InitializeStats();
        }
        public override void InitializeStats()
        {
            base.InitializeStats();
            this.CritChance += 0.1f;
            this.MaxHealth = (int)(this.MaxHealth * 0.7);
            this.Armour = (int)(this.Armour * 0.8);
            this.Speed = (int)(this.Speed * 1.2);
            this.MaxMana = (int)(this.MaxMana * 3);
            base.ValidateStats();
        }
    }

    public class Rogue : Character
    {
        public Rogue(CharacterType type, int level) : base(type, level)
        {
            InitializeStats();
        }

        public override void InitializeStats()
        {
            base.InitializeStats();
            this.CritChance += 0.15f;
            this.MaxHealth = (int)(this.MaxHealth * 0.7);
            this.DodgeChance += 0.15f;
            this.Armour = 0;
            this.Speed *= 2;
            base.ValidateStats();
        }
    }

    public class Paladin : Character
    {
        public Paladin(CharacterType type, int level) : base(type, level)
        {
            InitializeStats();
        }

        public override void InitializeStats()
        {
            base.InitializeStats();
            this.MaxHealth = (int)(this.MaxHealth * 2);
            this.Armour = (int)(this.Armour * 1.7);
            this.Speed = (int)(this.Speed * 0.8);
            this.CritChance = 0;
            this.MaxMana = (int)(this.MaxMana * 1.35);
            this.DodgeChance = (int)(this.DodgeChance * 0.5);
            base.ValidateStats();
        }
    }

    public class Barbarian : Character
    {
        public Barbarian(CharacterType type, int level) : base(type, level)
        {
            InitializeStats();
        }

        public override void InitializeStats()
        {
            base.InitializeStats();
            this.MaxHealth = (int)(this.MaxHealth * 1.3);
            this.Armour = (int)(this.Armour * 0.85);
            this.Speed = (int)(this.Speed * 0.95);
            this.CritChance = 0.1f;
            this.DodgeChance = (int)(this.DodgeChance * 0.5);
            base.ValidateStats();
        }
    }

    public class Monk : Character
    {
        public Monk(CharacterType type, int level) : base(type, level)
        {
            InitializeStats();
        }

        public override void InitializeStats()
        {
            base.InitializeStats();
            this.MaxHealth = (int)(this.MaxHealth * 0.9);
            this.Armour = (int)(this.Armour * 0.9);
            this.Speed = (int)(this.Speed * 3);
            this.DodgeChance = (int)(this.DodgeChance * 2.5);
            base.ValidateStats();
        }
    }

    public class Druid : Character
    {
        public Druid(CharacterType type, int level) : base(type, level)
        {
            InitializeStats();
        }

        public override void InitializeStats()
        {
            base.InitializeStats();
            this.MaxHealth = (int)(this.MaxHealth * 1.3);
            this.Armour = (int)(this.Armour * 1.1);
            this.Speed = 20;
            this.CritChance = 0;
            this.MaxMana = (int)(this.MaxMana * 2.5);
            this.DodgeChance = (int)(this.DodgeChance * 0.3);
            base.ValidateStats();
            // completely healing focused
        }
    }

    public class Bard : Character
    {
        public Bard(CharacterType type, int level) : base(type, level)
        {
            InitializeStats();
        }

        public override void InitializeStats()
        {
            base.InitializeStats();
            this.MaxHealth = (int)(this.MaxHealth * 0.8);
            this.Armour = (int)(this.Armour * 0.4);
            this.Speed = (int)(this.Speed * 2);
            this.CritChance = 0;
            this.MaxMana = (int)(this.MaxMana * 2.5);
            this.DodgeChance = (int)(this.DodgeChance * 0.3);
            base.ValidateStats();
        }
    }

    public class Bloodhunter : Character
    {
        public Bloodhunter(CharacterType type, int level) : base(type, level)
        {
            InitializeStats();
        }

        public override void InitializeStats()
        {
            base.InitializeStats();
            this.MaxHealth = (int)(this.MaxHealth * 1.5);
            this.Armour = (int)(this.Armour * 1.15);
            this.Speed = (int)(this.Speed * 1.15);
            this.CritChance = 0;
            base.ValidateStats();
        }
    }

    public class HighwayMan : Character
    {
        public HighwayMan(CharacterType type, int level) : base(type, level)
        {
            InitializeStats();
        }

        public override void InitializeStats()
        {
            base.InitializeStats();
            this.MaxHealth = (int)(this.MaxHealth * 0.8);
            this.Armour = (int)(this.Armour * 0.7);
            this.Speed = (int)(this.Speed * 2.3);
            this.CritChance *= 1.5f;
            base.ValidateStats();
        }
    }
}
