using NEA2.Gameplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NEA2.Ability;

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

    public static class AbilityFactory
    {
        private static Random rndm = new Random();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="c">The character for which this ability will be for</param>
        /// <returns></returns>
        public static Ability GenerateAbility(Character c)
        {
            var ValidTypes = Utils.AbilityTypes.Where(type =>
            {
                if (type == typeof(Punch))
                {
                    return false;
                }

                Ability abilityObj = (Ability)Activator.CreateInstance(type);
                return abilityObj.ValidCharacterTypes.Contains(c.GetType());
            }).ToArray();

            if (ValidTypes.Length == 0)
            {
                // Handle this case
                return null;
            }

            var abilityType = ValidTypes[rndm.Next(ValidTypes.Length)];
            return (Ability)Activator.CreateInstance(abilityType);
        }

    }
    public class AbilityCost
    {
        public int Mana = 0;
        public int Health = 0;

        public AbilityCost(int mana, int health)
        {
            Mana = mana;
            Health = health;
        }
    }
    
    public abstract class Ability
    {
        public enum SpecialEffect
        {
            None,
            DrainMana, // removes mana from target
            Bullseye, // 0% miss chance
            ConfirmCrit, // 100% crit chance
            Piercing, // ignores armour
            Frost, // (Slow)
            SplashR, SplashL, SplashLR, SplashAll,

            // all below apply status effect
            Burn,
            Poison,
            Weaken,
            Strengthen,
            HPRegen,
            ManaRegen,
        }

        public SpecialEffect effect;
        public List<int> TargetablePositions; // if contains -1, can target allies
        public bool TargetsAllies 
        { get
            {
                return TargetablePositions.Contains(-1);
            } 
        }
        public int Damage; // max health of a very strong enemy is 400
        public float MissChance; // between 0-1, 1 = 100% miss chance
        public int CritChanceMult; // between 1-3 inclusive
        public AbilityCost Costs;
        public Type[] ValidCharacterTypes; // the valid types of characters that can use an ability
        public CharacterType TargetType; // whether an ability targets allies (heals), or enemies (damage)
        public string Name { get
            {
                return this.GetType().ToString().Split('.')[1];
            } }
        Random rndm = new Random();

        public Ability()
        {

        }

        public override string ToString()
        {
            return this.Name;
        }
        public abstract void Execute(Character source, Character target, CombatInstance CI);

    }

    public class Fireball : Ability
    {
        public Fireball()
        {
            effect = SpecialEffect.Burn;
            TargetablePositions = new List<int> { 1, 2, 3, 4 };
            Damage = 50;
            MissChance = 0.1f;
            CritChanceMult = 2;
            Costs = new AbilityCost(10, 0);
            ValidCharacterTypes = new Type[] { typeof(Wizard), typeof(Druid), typeof(Bard) };
        }

        public override void Execute(Character source, Character target, CombatInstance CI)
        {
            CombatTurnHandler.HandleCombatInteraction(source, target, this, CI);
        }
    }

    public class Backstab : Ability
    {
        public Backstab()
        {
            effect = SpecialEffect.None;
            TargetablePositions = new List<int> { 4 };
            Damage = 100;
            MissChance = 0.2f;
            CritChanceMult = 3;
            Costs = new AbilityCost(0, 0);
            ValidCharacterTypes = new Type[] { typeof(Rogue), typeof(HighwayMan) };
        }

        public override void Execute(Character source, Character target, CombatInstance CI)
        {
            CombatTurnHandler.HandleCombatInteraction(source, target, this, CI);
        }
    }

    public class Smite : Ability
    {
        public Smite()
        {
            effect = SpecialEffect.Strengthen;
            TargetablePositions = new List<int> { 1, 2 };
            Damage = 70;
            MissChance = 0.05f;
            CritChanceMult = 1;
            Costs = new AbilityCost(20, 0);
            ValidCharacterTypes = new Type[] { typeof(Paladin), typeof(Monk) };
        }

        public override void Execute(Character source, Character target, CombatInstance CI)
        {
            CombatTurnHandler.HandleCombatInteraction(source, target, this, CI);
        }
    }
    public class Berserk : Ability
    {
        public Berserk()
        {
            effect = SpecialEffect.Strengthen;
            TargetablePositions = new List<int> { -1 };
            Damage = 0;
            MissChance = 0.0f;
            CritChanceMult = 1;
            Costs = new AbilityCost(0, 50);
            ValidCharacterTypes = new Type[] { typeof(Barbarian) };
        }

        public override void Execute(Character source, Character target, CombatInstance CI)
        {
            CombatTurnHandler.HandleCombatInteraction(source, target, this, CI);
        }
    }

    public class Heal : Ability
    {
        public Heal()
        {
            effect = SpecialEffect.HPRegen;
            TargetablePositions = new List<int> { -1 }; // Targets allies
            Damage = -30; // Negative for healing
            MissChance = 0.0f;
            CritChanceMult = 1;
            Costs = new AbilityCost(20, 0);
            ValidCharacterTypes = new Type[] { typeof(Paladin), typeof(Druid), typeof(Monk) };
        }

        public override void Execute(Character source, Character target, CombatInstance CI)
        {
            CombatTurnHandler.HandleCombatInteraction(source, target, this, CI);
        }
    }

    public class PoisonArrow : Ability
    {
        public PoisonArrow()
        {
            effect = SpecialEffect.Poison;
            TargetablePositions = new List<int> { 3, 4 };
            Damage = 20;
            MissChance = 0.1f;
            CritChanceMult = 1;
            Costs = new AbilityCost(10, 0);
            ValidCharacterTypes = new Type[] { typeof(Rogue), typeof(HighwayMan) };
        }

        public override void Execute(Character source, Character target, CombatInstance CI)
        {
            CombatTurnHandler.HandleCombatInteraction(source, target, this, CI);
        }
    }

    public class Frostbolt : Ability
    {
        public Frostbolt()
        {
            effect = SpecialEffect.Frost;
            TargetablePositions = new List<int> { 3, 4 };
            Damage = 30;
            MissChance = 0.2f;
            CritChanceMult = 2;
            Costs = new AbilityCost(15, 0);
            ValidCharacterTypes = new Type[] { typeof(Wizard), typeof(Druid) };
        }

        public override void Execute(Character source, Character target, CombatInstance CI)
        {
            CombatTurnHandler.HandleCombatInteraction(source, target, this, CI);
        }
    }

    public class DivineIntervention : Ability
    {
        public DivineIntervention()
        {
            effect = SpecialEffect.None;
            TargetablePositions = new List<int> { -1 };
            Damage = -100;
            MissChance = 0.0f;
            CritChanceMult = 1;
            Costs = new AbilityCost(50, 0);
            ValidCharacterTypes = new Type[] { typeof(Paladin), typeof(Monk) };
        }

        public override void Execute(Character source, Character target, CombatInstance CI)
        {
            CombatTurnHandler.ApplyStatusEffect(source, target, StatusEffects.Invincible, 1);
            CombatTurnHandler.HandleCombatInteraction(source, target, this, CI);
        }
    }

    public class DrainLife : Ability
    {
        public DrainLife()
        {
            effect = SpecialEffect.DrainMana;
            TargetablePositions = new List<int> { 2, 3 };
            Damage = 20;
            MissChance = 0.2f;
            CritChanceMult = 1;
            Costs = new AbilityCost(20, 0);
            ValidCharacterTypes = new Type[] { typeof(Bard), typeof(Bloodhunter) };
        }

        public override void Execute(Character source, Character target, CombatInstance CI)
        {
            CombatTurnHandler.HandleCombatInteraction(source, target, this, CI);
        }
    }

    public class Teleport : Ability
    {
        public Teleport()
        {
            effect = SpecialEffect.None;
            TargetablePositions = new List<int> { -1 };
            Damage = 0;
            MissChance = 0.0f;
            CritChanceMult = 1;
            Costs = new AbilityCost(20, 0);
            ValidCharacterTypes = new Type[] { typeof(Wizard) };
        }

        public override void Execute(Character source, Character target, CombatInstance CI)
        {
            CombatTurnHandler.HandleCombatInteraction(source, target, this, CI);
        }
    }

    public class ShurikenThrow : Ability
    {
        public ShurikenThrow()
        {
            effect = SpecialEffect.None;
            TargetablePositions = new List<int> { 3, 4 };
            Damage = 30;
            MissChance = 0.1f;
            CritChanceMult = 2;
            Costs = new AbilityCost(10, 0);
            ValidCharacterTypes = new Type[] { typeof(Rogue), typeof(Monk) };
        }

        public override void Execute(Character source, Character target, CombatInstance CI)
        {
            CombatTurnHandler.HandleCombatInteraction(source, target, this, CI);
        }
    }

    public class Shoot : Ability
    {
        public Shoot()
        {
            effect = SpecialEffect.None;
            TargetablePositions = new List<int> { 2, 3, 4 };
            Damage = 25;
            MissChance = 0.05f;
            CritChanceMult = 1;
            Costs = new AbilityCost(5, 0);
            ValidCharacterTypes = new Type[] { typeof(HighwayMan), typeof(Rogue) };
        }

        public override void Execute(Character source, Character target, CombatInstance CI)
        {
            CombatTurnHandler.HandleCombatInteraction(source, target, this, CI);
        }
    }
    public class SmokeBomb : Ability
    {
        public SmokeBomb()
        {
            effect = SpecialEffect.None;
            TargetablePositions = new List<int> { -1 };
            Damage = 0;
            MissChance = 0;
            CritChanceMult = 1;
            Costs = new AbilityCost(5, 0);
            ValidCharacterTypes = new Type[] { typeof(Rogue) };
        }

        public override void Execute(Character source, Character target, CombatInstance CI)
        {
            CombatTurnHandler.ApplyStatusEffect(source, target, StatusEffects.Invincible, 1);
            CombatTurnHandler.HandleCombatInteraction(source, target, this, CI);
        }
    }
    public class Punch : Ability
    {
        public Punch()
        {
            effect = SpecialEffect.None;
            TargetablePositions = new List<int> { 1,2,3,4 };
            Damage = 35;
            MissChance = 0.3f;
            CritChanceMult = 1;
            Costs = new AbilityCost(0, 0);
            ValidCharacterTypes = Utils.CharacterTypes;
        }

        public override void Execute(Character source, Character target, CombatInstance CI)
        {
            CombatTurnHandler.HandleCombatInteraction(source, target, this, CI);
        }
    }
    public class Kick : Ability
    {
        public Kick()
        {
            effect = SpecialEffect.None;
            TargetablePositions = new List<int> { 1, 2, 3, 4 };
            Damage = 35;
            MissChance = 0.3f;
            CritChanceMult = 1;
            Costs = new AbilityCost(0, 0);
            ValidCharacterTypes = Utils.CharacterTypes;
        }

        public override void Execute(Character source, Character target, CombatInstance CI)
        {
            CombatTurnHandler.HandleCombatInteraction(source, target, this, CI);
        }
    }
    public class SwordSlash : Ability
    {
        public SwordSlash()
        {
            effect = SpecialEffect.None;
            TargetablePositions = new List<int> { 1, 2, 3 };
            Damage = 70;
            MissChance = 0.1f;
            CritChanceMult = 1;
            Costs = new AbilityCost(5, 0);
            ValidCharacterTypes = new Type[] { typeof(Paladin), typeof(Barbarian) };
        }

        public override void Execute(Character source, Character target, CombatInstance CI)
        {
            CombatTurnHandler.HandleCombatInteraction(source, target, this, CI);
        }
    }
    public class BloodSuck : Ability
    {
        public BloodSuck()
        {
            effect = SpecialEffect.None;
            TargetablePositions = new List<int> { 1, 2, 3, 4 };
            Damage = 65;
            MissChance = 0.1f;
            CritChanceMult = 1;
            Costs = new AbilityCost(5, 20);
            ValidCharacterTypes = new Type[] { typeof(Bloodhunter) };
        }

        public override void Execute(Character source, Character target, CombatInstance CI)
        {
            CombatTurnHandler.HandleCombatInteraction(source, target, this, CI);
        }
    }
    public class BloodNova : Ability
    {
        public BloodNova()
        {
            effect = SpecialEffect.SplashAll;
            TargetablePositions = new List<int> { 1, 2, 3, 4 };
            Damage = 90;
            MissChance = 0f;
            CritChanceMult = 1;
            Costs = new AbilityCost(15, 80);
            ValidCharacterTypes = new Type[] { typeof(Bloodhunter) };
        }

        public override void Execute(Character source, Character target, CombatInstance CI)
        {
            CombatTurnHandler.HandleCombatInteraction(source, target, this, CI);
        }
    }
    public class Earthquake : Ability
    {
        public Earthquake()
        {
            effect = SpecialEffect.SplashAll;
            TargetablePositions = new List<int> { 1, 2, 3, 4 };
            Damage = 40;
            MissChance = 0.15f;
            CritChanceMult = 1;
            Costs = new AbilityCost(12, 0);
            ValidCharacterTypes = new Type[] { typeof(Wizard), typeof(Druid) };
        }

        public override void Execute(Character source, Character target, CombatInstance CI)
        {
            CombatTurnHandler.HandleCombatInteraction(source, target, this, CI);
        }
    }
    public class Parry : Ability
    {
        public Parry()
        {
            effect = SpecialEffect.None;
            TargetablePositions = new List<int> { -1 };
            Damage = 0;
            MissChance = 0;
            CritChanceMult = 1;
            Costs = new AbilityCost(0, 0);
            ValidCharacterTypes = new Type[] { typeof(Rogue), typeof(Monk), typeof(HighwayMan) };
        }

        public override void Execute(Character source, Character target, CombatInstance CI)
        {
            CombatTurnHandler.ApplyStatusEffect(source, target, StatusEffects.Invincible, 1);
            CombatTurnHandler.HandleCombatInteraction(source, target, this, CI);
        }
    }
    public class ThunderStrike : Ability
    {
        public ThunderStrike()
        {
            effect = SpecialEffect.ConfirmCrit;
            TargetablePositions = new List<int> { 1, 2 };
            Damage = 35;
            MissChance = 0.1f;
            CritChanceMult = 2;
            Costs = new AbilityCost(8, 0);
            ValidCharacterTypes = new Type[] { typeof(Paladin), typeof(Barbarian), typeof(Wizard) };
        }

        public override void Execute(Character source, Character target, CombatInstance CI)
        {
            CombatTurnHandler.HandleCombatInteraction(source, target, this, CI);
        }
    }
    public class Weaken : Ability
    {
        public Weaken()
        {
            effect = SpecialEffect.Weaken;
            TargetablePositions = new List<int> { 1, 2, 3, 4 };
            Damage = 0;
            MissChance = 0.1f;
            CritChanceMult = 1;
            Costs = new AbilityCost(5, 0);
            ValidCharacterTypes = new Type[] { typeof(Bard) };
        }

        public override void Execute(Character source, Character target, CombatInstance CI)
        {
            CombatTurnHandler.ApplyStatusEffect(source, target, StatusEffects.Weak, 1);
            CombatTurnHandler.HandleCombatInteraction(source, target, this, CI);
        }
    }
    public class DivineShield : Ability
    {
        public DivineShield()
        {
            effect = SpecialEffect.None;
            TargetablePositions = new List<int> { -1 };
            Damage = 0;
            MissChance = 0;
            CritChanceMult = 1;
            Costs = new AbilityCost(10, 0);
            ValidCharacterTypes = new Type[] { typeof(Paladin) };
        }

        public override void Execute(Character source, Character target, CombatInstance CI)
        {
            CombatTurnHandler.ApplyStatusEffect(source, target, StatusEffects.Invincible, 1);
            CombatTurnHandler.HandleCombatInteraction(source, target, this, CI);
        }
    }
    public class MindControl : Ability
    {
        public MindControl()
        {
            effect = SpecialEffect.Weaken;
            TargetablePositions = new List<int> { 1, 2, 3, 4 };
            Damage = 0;
            MissChance = 0.2f;
            CritChanceMult = 1;
            Costs = new AbilityCost(15, 0);
            ValidCharacterTypes = new Type[] { typeof(Wizard), typeof(Bard) };
        }

        public override void Execute(Character source, Character target, CombatInstance CI)
        {
            CombatTurnHandler.ApplyStatusEffect(source, target, StatusEffects.Weak, 2);
            CombatTurnHandler.HandleCombatInteraction(source, target, this, CI);
        }
    }
    public class PerfectShot : Ability
    {
        public PerfectShot()
        {
            effect = SpecialEffect.Bullseye;
            TargetablePositions = new List<int> { 1, 2, 3, 4 };
            Damage = 40;
            MissChance = 0f;
            CritChanceMult = 2;
            Costs = new AbilityCost(15, 0);
            ValidCharacterTypes = new Type[] { typeof(HighwayMan) };
        }

        public override void Execute(Character source, Character target, CombatInstance CI)
        {
            CombatTurnHandler.HandleCombatInteraction(source, target, this, CI);
        }
    }
    public class Whirlwind : Ability
    {
        public Whirlwind()
        {
            effect = SpecialEffect.SplashAll;
            TargetablePositions = new List<int> { 1, 2, 3, 4 };
            Damage = 30;
            MissChance = 0.25f;
            CritChanceMult = 1;
            Costs = new AbilityCost(10, 0);
            ValidCharacterTypes = new Type[] { typeof(Barbarian) };
        }

        public override void Execute(Character source, Character target, CombatInstance CI)
        {
            CombatTurnHandler.HandleCombatInteraction(source, target, this, CI);
        }
    }

}
