using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NEA2.Ability;

namespace NEA2.Gameplay
{
    public static class CombatTurnHandler
    {
        private static Random rndm = new Random();
        public static bool IsHitting(Character source, Character target, Ability ability)
        {
            if (ability.effect == SpecialEffect.Bullseye) { return true; }
            bool missed = ability.MissChance > rndm.NextDouble();
            bool dodged = target.DodgeChance > rndm.NextDouble();
            if ((missed || dodged)) { return false; }
            if (target.ActiveStatusEffects.ContainsKey(StatusEffects.Invisible)) { return false; }
            return true;
        }
        public static int CalculateDamage(Character source, Character target, Ability ability)
        {
            int damage = ability.Damage;

            bool crit = (target.CritChance * ability.CritChanceMult) > rndm.NextDouble();
            if (ability.effect == Ability.SpecialEffect.ConfirmCrit) { crit = true; }
            if (crit) { damage *= 2; }

            if (!(ability.effect == SpecialEffect.Piercing) && damage > 0)
            {
                damage = (int)(damage * (1 - (target.Armour / 100)));
            }

            if (source.ActiveStatusEffects.Keys.Contains(StatusEffects.Strength) && damage > 0)
            {
                damage = (int)(damage * 1.5);
            }

            if (source.ActiveStatusEffects.Keys.Contains(StatusEffects.Weak) && damage > 0)
            {
                damage = (int)(damage / 0.5);
            }

            if (target.ActiveStatusEffects.ContainsKey(StatusEffects.Invincible) && damage > 0) { damage = 0; }
            
            return damage;

        }
        public static void HandleSpecialFX(Character source, Character target, Ability ability)
        {
            int defaultDuration = (int)(source.Level / 5) + 3;
            switch (ability.effect)
            {
                case SpecialEffect.DrainMana:
                    int drain = (int)Math.Min(rndm.Next(2, 6), target.Mana * 0.1);
                    target.Mana -= drain;
                    break;
                case SpecialEffect.Frost:
                    target.Speed -= (int)Math.Min(rndm.Next(1, 4), target.Speed * 0.3);
                    break;

                case SpecialEffect.Poison:
                    ApplyStatusEffect(target, StatusEffects.Poison, defaultDuration + 2);
                    break;
                case SpecialEffect.Burn:
                    ApplyStatusEffect(target, StatusEffects.Burn, defaultDuration);
                    break;
                case SpecialEffect.Weaken:
                    ApplyStatusEffect(target, StatusEffects.Weak, defaultDuration - 1);
                    break;
                case SpecialEffect.Strengthen:
                    ApplyStatusEffect(target, StatusEffects.Strength, defaultDuration - 1);
                    break;
                case SpecialEffect.HPRegen:
                    ApplyStatusEffect(target, StatusEffects.HPRegeneration, defaultDuration);
                    break;
                case SpecialEffect.ManaRegen:
                    ApplyStatusEffect(target, StatusEffects.ManaRegenetation, defaultDuration);
                    break;
            }
        }
        public static void ApplyStatusEffect(Character target, StatusEffects statuseffect, int turnDuration)
        {
            if (target.ActiveStatusEffects.Keys.Contains(statuseffect))
            {
                target.ActiveStatusEffects[statuseffect] += turnDuration;
            }
            else
            {
                target.ActiveStatusEffects.Add(statuseffect, turnDuration);
            }
        }
        /// <summary>
        /// Tick the special effects for the passed in character
        /// </summary>
        /// <param name="c">the character to tick</param>
        public static void TickSpecialFX(Character c)
        {
            List<StatusEffects> keys = new List<StatusEffects>(c.ActiveStatusEffects.Keys);

            foreach (StatusEffects key in keys)
            {
                switch (key)
                {
                    case StatusEffects.Burn:
                        c.Health -= Math.Max((int)(c.MaxHealth * 0.09), 10);
                        break;
                    case StatusEffects.Poison:
                        c.Health -= Math.Max((int)(c.MaxHealth * 0.11), 12);
                        break;
                    case StatusEffects.HPRegeneration:
                        c.Health += Math.Max((int)(c.MaxHealth * 0.08), 10);
                        break;
                    case StatusEffects.ManaRegenetation:
                        c.Mana += Math.Max((int)(c.MaxMana * 0.25), 5);
                        break;
                }
                c.ActiveStatusEffects[key] -= 1;
            }
            c.UpdateControlValues();

        }
        public static void HandleSourceImpact(Character source, Ability ability)
        {
            source.Health -= ability.Costs.Health;
            source.Mana -= ability.Costs.Mana;
        }
        public static void HandleTargetImpact(Character target, int damage)
        {
            target.Health -= damage;
        }
        /// <summary>
        /// Handles a combat interaction between 2 characters
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="ability"></param>
        /// <returns>A string of what happened in that interaction</returns>
        public static string HandleCombatInteraction(Character source, Character target, Ability ability)
        {
            
            TickSpecialFX(source); TickSpecialFX(target);
            source.ValidateStatsCombat();
            Character s, t;
            s = source; t = target;
            bool hit = false;
            if (s.CharType != t.CharType)
            {
                if (IsHitting(s, t, ability))
                {
                    hit = true;
                    HandleSourceImpact(s, ability);
                    HandleTargetImpact(t, CalculateDamage(s, t, ability));
                    HandleSpecialFX(s, t, ability);
                }
            }
            else // ally targeted
            {
                HandleTargetImpact(t, CalculateDamage(s, t, ability));
            }
            s.ValidateStatsCombat(); t.ValidateStatsCombat();
            s.UpdateControlValues(); t.UpdateControlValues();
            string output = 
                $"\nCombat Interaction Report:\n" +
                $"--------------------------------\n" +
                $"Source Character: {s.Name} ({s.ClassName}) ({(s.CharType == CharacterType.Hero ? "Hero" : "Enemy")})\n" +
                $"Target Character: {t.Name} ({t.ClassName}) ({(t.CharType == CharacterType.Hero ? "Hero" : "Enemy")})\n" +
                $"Ability Used: {ability.Name}\n" +
                $"--------------------------------\n" +
                $"Attack Hit: {(hit ? "Yes" : "No")}\n" +
                $"Damage Dealt: {(hit ? CalculateDamage(s, t, ability).ToString() : "0")}\n" +
                $"Special Effects Applied: {(ability.effect != SpecialEffect.None ? ability.effect.ToString() : "None")}\n" +
                $"--------------------------------\n";
            Console.WriteLine(output);
            return output;
            // you were fixing combat stuff and doing turns and displaying the above message
            
        }

    }

}
