using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanColleDamageCalculator.Models
{
    public static class Util
    {
        public static int Cap(this AttackType type)
        {
            switch(type)
            {
                case AttackType.ArtilleryDuelSub:
                    return 100;
                case AttackType.NightBattle:
                    return 300;
                case AttackType.ArtilleryDuel:
                case AttackType.ArtilleryDuelAir:
                    return 180;
                case AttackType.AirAttack:
                case AttackType.LightningBattle:
                    return 150;
                default:
                    throw new ArgumentException(type.ToString());
            }
        }
        public static double Correction(this DamageState state, AttackType type)
        {
            switch (state)
            {
                case DamageState.Normal:
                case DamageState.SlightlyDamaged:
                    return 1.0;
                case DamageState.ModeratelyDamaged:
                    return type == AttackType.LightningBattle ? 0.8 : 0.7;
                case DamageState.HeavilyDamaged:
                    return type == AttackType.LightningBattle ? 0.0 : 0.4;
                default:
                    throw new ArgumentException(state.ToString());
            }
        }

        public static double Correction(this EngagementForm form, AttackType attackType)
        {
            if (attackType == AttackType.AirAttack || attackType == AttackType.NightBattle)
            {
                return 1.0;
            }

            switch (form)
            {
                case EngagementForm.CrossingTheTAdvantage:
                    return 1.2;
                case EngagementForm.ParallelEngagement:
                    return 1.0;
                case EngagementForm.HeadOnEngagement:
                    return 0.8;
                case EngagementForm.CrossingTheTDisadvantage:
                    return 0.6;
                default:
                    throw new ArgumentException(form.ToString());
            }
        }
        public static double Correction(this Formation formation, AttackType attackType)
        {
            if (attackType == AttackType.AirAttack || attackType == AttackType.NightBattle)
            {
                return 1.0;
            }

            switch (formation)
            {
                case Formation.LineAhead:
                    return attackType == AttackType.ArtilleryDuelSub ? 0.6 : 1.0;
                case Formation.DoubleLine:
                    return attackType == AttackType.ArtilleryDuelSub ? 0.8 : 0.8;
                case Formation.Diamond:
                    return attackType == AttackType.ArtilleryDuelSub ? 1.2 : 0.7;
                case Formation.Echelon:
                    return attackType == AttackType.ArtilleryDuelSub ? 1.0 : 0.6;
                case Formation.LineAbreast:
                    return attackType == AttackType.ArtilleryDuelSub ? 1.3 : 0.6;
                default:
                    throw new ArgumentException(formation.ToString());
            }
        }

        public static double Correction(this NightBattleSpecialAttack attack, AttackType attackType)
        {
            if(attackType != AttackType.NightBattle)
            {
                return 1.0;
            }

            switch (attack)
            {
                case NightBattleSpecialAttack.CutInTorpedo:
                    return 1.5;
                case NightBattleSpecialAttack.CutInMixed:
                    return 1.3;
                case NightBattleSpecialAttack.CutInMainGun:
                    return 2.0;
                case NightBattleSpecialAttack.CutInSecGun:
                    return 1.75;
                case NightBattleSpecialAttack.DoubleAttack:
                    return 1.2;
                case NightBattleSpecialAttack.Normal:
                    return 1.0;
                default:
                    throw new ArgumentException(attack.ToString());
            }
        }

        public static double Correction(this ArtillerySpotting artillerySpotting, AttackType attackType)
        {
            if(attackType != AttackType.ArtilleryDuel)
            {
                return 1.0;
            }

            switch(artillerySpotting)
            {
                case ArtillerySpotting.CutInMain:
                    return 1.5;
                case ArtillerySpotting.CutInAPShell:
                    return 1.3;
                case ArtillerySpotting.CutInRadar:
                    return 1.2;
                case ArtillerySpotting.CutInSec:
                    return 1.1;
                case ArtillerySpotting.DoubleAttack:
                    return 1.2;
                default:
                    return 1.0;
            }
        }

        public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> src)
        {
            foreach(var item in src)
            {
                collection.Add(item);
            }
        }
    }
}
