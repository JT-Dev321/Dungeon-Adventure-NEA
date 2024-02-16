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

            damage *= (int)(1 + source.Level * 0.08f);

            return damage;

        }
        public static void HandleSpecialFX(Character source, Character target, Ability ability, CombatInstance CI)
        {
            int defaultDuration = (int)(source.Level / 5) + 3;
            int targetIndex;
            int lhs;
            int rhs;
            Character[] SplashingTo = source.CharType == CharacterType.Hero ? CI.Enemies : CI.Allies;
            switch (ability.effect)
            {
                case SpecialEffect.DrainMana:
                    int drain = (int)Math.Min(rndm.Next(2, 6), target.Mana * 0.1);
                    target.DrainMana(drain);
                    break;
                case SpecialEffect.Frost:
                    target.Speed -= (int)Math.Min(rndm.Next(1, 4), target.Speed * 0.3);
                    break;

                case SpecialEffect.Poison:
                    ApplyStatusEffect(source, target, StatusEffects.Poison, defaultDuration + 2);
                    break;
                case SpecialEffect.Burn:
                    ApplyStatusEffect(source, target, StatusEffects.Burn, defaultDuration);
                    break;
                case SpecialEffect.Weaken:
                    ApplyStatusEffect(source, target, StatusEffects.Weak, defaultDuration - 1);
                    break;
                case SpecialEffect.Strengthen:
                    ApplyStatusEffect(source, target, StatusEffects.Strength, defaultDuration - 1);
                    break;
                case SpecialEffect.HPRegen:
                    ApplyStatusEffect(source, target, StatusEffects.HPRegeneration, defaultDuration);
                    break;
                case SpecialEffect.ManaRegen:
                    ApplyStatusEffect(source, target, StatusEffects.ManaRegenetation, defaultDuration);
                    break;
                case SpecialEffect.SplashLR:
                    targetIndex = Array.IndexOf(SplashingTo, target);
                    lhs = targetIndex - 1 > 0 ? targetIndex - 1 : 0;
                    rhs = targetIndex + 1 < 4 ? targetIndex + 1 : 0;
                    if (lhs != targetIndex)
                    {
                        HandleTargetImpact(SplashingTo[lhs], CalculateDamage(source, target, ability));
                    }
                    if (rhs != targetIndex)
                    {
                        HandleTargetImpact(SplashingTo[rhs], CalculateDamage(source, target, ability));
                    }
                    break;
                case SpecialEffect.SplashR:
                    targetIndex = Array.IndexOf(SplashingTo, target);
                    rhs = targetIndex + 1 < 4 ? targetIndex + 1 : 0;
                    if (rhs != targetIndex)
                    {
                        HandleTargetImpact(SplashingTo[rhs], CalculateDamage(source, target, ability));
                    }
                    break;
                case SpecialEffect.SplashL:
                    targetIndex = Array.IndexOf(SplashingTo, target);
                    lhs = targetIndex - 1 > 0 ? targetIndex - 1 : 0;
                    if (lhs != targetIndex)
                    {
                        HandleTargetImpact(SplashingTo[lhs], CalculateDamage(source, target, ability));
                    }
                    break;
                case SpecialEffect.SplashAll:
                    foreach(Character c in SplashingTo)
                    {
                        if (c != target)
                        {
                            HandleTargetImpact(c, CalculateDamage(source, target, ability));
                            
                        }
                    }
                    break;
            }
        }
        public static void ApplyStatusEffect(Character source, Character target, StatusEffects statuseffect, int turnDuration)
        {
            if (source == target)
            {
                turnDuration++;
            }
            if (target.ActiveStatusEffects.Keys.Contains(statuseffect))
            {
                target.ActiveStatusEffects[statuseffect] += turnDuration;
            }
            else
            {
                target.ActiveStatusEffects.Add(statuseffect, turnDuration);
            }
            source.Controls.RefreshStatListBox();
            target.Controls.RefreshStatListBox();
        }
        /// <summary>
        /// Tick the special effects for the passed in character
        /// </summary>
        /// <param name="c">the character to tick</param>
        public static void TickSpecialFX(Character c)
        {
            if (c != null)
            {
                List<StatusEffects> keys = new List<StatusEffects>(c.ActiveStatusEffects.Keys);

                foreach (StatusEffects key in keys)
                {
                    if (c.ActiveStatusEffects[key] > 0)
                    {
                        switch (key)
                        {
                            case StatusEffects.Burn:
                                c.DrainHealth(Math.Max((int)(c.MaxHealth * 0.09), 10));
                                break;
                            case StatusEffects.Poison:
                                c.DrainHealth(Math.Max((int)(c.MaxHealth * 0.11), 12));
                                break;
                            case StatusEffects.HPRegeneration:
                                c.AddHealth(Math.Max((int)(c.MaxHealth * 0.08), 10));
                                break;
                            case StatusEffects.ManaRegenetation:
                                c.AddMana(Math.Max((int)(c.MaxMana * 0.25), 5));
                                break;
                        }
                        c.ActiveStatusEffects[key] -= 1;
                    }
                    else
                    {
                        c.ActiveStatusEffects.Remove(key);
                    }
                }
                c.ValidateStatsCombat();
                c.UpdateControlValues();
            }
        }
        public static void HandleSourceImpact(Character source, Ability ability)
        {
            source.DrainHealth(ability.Costs.Health);
            source.DrainMana(ability.Costs.Mana);
            source.UpdateControlValues();
        }
        public static void HandleTargetImpact(Character target, int damage)
        {
            target.DrainHealth(damage);
            target.UpdateControlValues();
        }
        /// <summary>
        /// Handles a combat interaction between 2 characters
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="ability"></param>
        /// <returns>A string of what happened in that interaction</returns>
        public static string HandleCombatInteraction(Character source, Character target, Ability ability, CombatInstance CI)
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
                    HandleSpecialFX(s, t, ability, CI);
                }
            }
            else // ally targeted
            {
                HandleTargetImpact(t, CalculateDamage(s, t, ability));
            }
            s.ValidateStatsCombat(); t.ValidateStatsCombat();
            s.UpdateControlValues(); t.UpdateControlValues();
            string output =
                $"Combat Interaction Report:\n" +
                $"--------------------------------\n" +
                $"Source: {s.Name} ({s.ClassName}) ({(s.CharType == CharacterType.Hero ? "Hero" : "Enemy")})\n" +
                $"Target: {t.Name} ({t.ClassName}) ({(t.CharType == CharacterType.Hero ? "Hero" : "Enemy")})\n" +
                $"Ability: {ability.Name}\n" +
                $"--------------------------------\n" +
                $"Attack Hit: {(hit ? "Yes" : "No")}\n";
            if (hit)
            {
                output += $"Damage Dealt: {(hit ? CalculateDamage(s, t, ability).ToString() : "0")}\n" +
                $"Special Effects: {(ability.effect != SpecialEffect.None ? ability.effect.ToString() : "None")}\n";
            }
            output += $"--------------------------------\n";
            Console.WriteLine(output);
            CI.TurnInfoLBL.Text = output;
            return output;
        }
    }
}
