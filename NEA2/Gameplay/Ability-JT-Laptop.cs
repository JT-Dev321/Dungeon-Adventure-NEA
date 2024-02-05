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
                Ability abilityObj = (Ability)Activator.CreateInstance(type);
                return abilityObj.ValidTypes.Contains(c.GetType());
            }); // gets every ability that is valid for the given character
            // then choose a random one and returns it
            var abilityType = Utils.AbilityTypes[rndm.Next(Utils.AbilityTypes.Length)];
            return (Ability)Activator.CreateInstance(abilityType);
            
        }
    }
    public class AbilityCost
    {
        public int Mana;
        public int Health;

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
            DrainMana,
            Bullseye,
            ConfirmCrit,
            Piercing,
            Frost, // (Slow)
            SplashR, SplashLR, SplashAll,
            Burn,
            Poison,
            Weaken,
            Strengthen,
            HPRegen,
            ManaRegen,
        }

        public SpecialEffect effect;
        public List<int> TargetablePositions; // if contains -1, can target allies
        bool TargetsAllies 
        { get
            {
                return TargetablePositions.Contains(-1);
            } 
        }
        public int Damage;
        public int MissChance;
        public int CritChanceMult;
        public AbilityCost Costs;
        public Type[] ValidTypes;
        public CharacterType TargetType;
        Random rndm = new Random();

        public abstract void Execute(Character source, Character target, RoomInteractions room);

    }

    public class Fireball : Ability
    {
        public Fireball()
        {
            this.effect = SpecialEffect.None;
            this.Damage = 30;
            this.ValidTypes = new Type[] { typeof(Wizard), typeof(Druid), typeof(Bard) };
        }

        public override void Execute(Character source, Character target, RoomInteractions room)
        {
            // Implementation
        }
    }

    public class Smite : Ability
    {
        public Smite()
        {
            this.effect = SpecialEffect.ConfirmCrit;
            this.Damage = 40;
            this.ValidTypes = new Type[] { typeof(Paladin), typeof(Barbarian), typeof(Monk) };
        }

        public override void Execute(Character source, Character target, RoomInteractions room)
        {
            // Implementation
        }
    }

    public class Backstab : Ability
    {
        public Backstab()
        {
            this.effect = SpecialEffect.ConfirmCrit;
            this.Damage = 25;
            this.ValidTypes = new Type[] { typeof(Rogue), typeof(Monk), typeof(Barbarian) };
        }

        public override void Execute(Character source, Character target, RoomInteractions room)
        {
            // Implementation
        }
    }

    public class Heal : Ability
    {
        public Heal()
        {
            this.effect = SpecialEffect.None;
            this.Damage = 0;
            this.ValidTypes = new Type[] { typeof(Druid), typeof(Paladin), typeof(Monk), typeof(Bard) };
        }

        public override void Execute(Character source, Character target, RoomInteractions room)
        {
            // Implementation
        }
    }
}
