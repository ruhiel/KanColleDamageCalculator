using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using Reactive.Bindings.Extensions;
using Reactive.Bindings;

namespace KanColleDamageCalculator.Models
{
    public class Calculator : BindableBase
    {
        private Ship _Friend = new Ship();
        public Ship Friend
        {
            get => _Friend;
            set
            {
                SetProperty(ref _Friend, value ?? new Ship());
                Calc();
            }
        }

        private Ship _Enemy = new Ship();
        public Ship Enemy
        {
            get => _Enemy;
            set
            {
                SetProperty(ref _Enemy, value ?? new Ship());
                Calc();
            }
        }

        private EngagementForm _EngagementForm = EngagementForm.ParallelEngagement;
        public EngagementForm EngagementForm
        {
            get => _EngagementForm;
            set
            {
                SetProperty(ref _EngagementForm, value);
                Calc();
            }
        }
        private Formation _Formation;
        public Formation Formation
        {
            get => _Formation;
            set
            {
                SetProperty(ref _Formation, value);
                Calc();
            }
        }

        private AttackType _AttackType = AttackType.ArtilleryDuel;
        public AttackType AttackType
        {
            get => _AttackType;
            set
            {
                SetProperty(ref _AttackType, value);
                Calc();
            }
        }

        private NightBattleSpecialAttack _Nightattack;
        public NightBattleSpecialAttack Nightattack
        {
            get => _Nightattack;
            set
            {
                SetProperty(ref _Nightattack, value);
                Calc();
            }
        }

        private bool _IsNighttimeTouching;
        public bool IsNighttimeTouching
        {
            get => _IsNighttimeTouching;
            set
            {
                SetProperty(ref _IsNighttimeTouching, value);
                Calc();
            }
        }

        private bool _Type3ShellSpecialEffect;
        public bool Type3ShellSpecialEffect
        {
            get => _Type3ShellSpecialEffect;
            set
            {
                SetProperty(ref _Type3ShellSpecialEffect, value);
                Calc();
            }
        }

        private bool _WG43SpecialEffect;
        public bool WG43SpecialEffect
        {
            get => _WG43SpecialEffect;
            set
            {
                SetProperty(ref _WG43SpecialEffect, value);
                Calc();
            }
        }

        private bool _ApShellEffect;
        public bool ApShellEffect
        {
            get => _ApShellEffect;
            set
            {
                SetProperty(ref _ApShellEffect, value);
                Calc();
            }
        }

        private Equip _Touching;
        public Equip Touching
        {
            get => _Touching;
            set
            {
                SetProperty(ref _Touching, value);
                Calc();
            }
        }

        private ArtillerySpotting _ArtillerySpotting;
        public ArtillerySpotting ArtillerySpotting
        {
            get => _ArtillerySpotting;
            set
            {
                SetProperty(ref _ArtillerySpotting, value);
                Calc();
            }
        }

        private DamageState _DamageState;
        public DamageState DamageState
        {
            get => _DamageState;
            set
            {
                SetProperty(ref _DamageState, value);
                Calc();
            }
        }

        public int Slot1Improvement
        {
            get => Slot1.Improvement;
            set
            {
                Slot1.Improvement = value;
                Calc();
            }
        }

        public int Slot2Improvement
        {
            get => Slot2.Improvement;
            set
            {
                Slot2.Improvement = value;
                Calc();
            }
        }

        public int Slot3Improvement
        {
            get => Slot3.Improvement;
            set
            {
                Slot3.Improvement = value;
                Calc();
            }
        }

        public int Slot4Improvement
        {
            get => Slot4.Improvement;
            set
            {
                Slot4.Improvement = value;
                Calc();
            }
        }

        private Equip _Slot1 = new Equip();


        public Equip Slot1
        {
            get => _Slot1;
            set
            {
                SetProperty(ref _Slot1, value);
                Calc();
            }
        }


        private Equip _Slot2 = new Equip();

        public Equip Slot2
        {
            get => _Slot2;
            set
            {
                SetProperty(ref _Slot2, value);
                Calc();
            }
        }


        private Equip _Slot3 = new Equip();

        public Equip Slot3
        {
            get => _Slot3;
            set
            {
                SetProperty(ref _Slot3, value);
                Calc();
            }
        }


        private Equip _Slot4 = new Equip();

        public Equip Slot4
        {
            get => _Slot4;
            set
            {
                SetProperty(ref _Slot4, value);
                Calc();
            }
        }

        private int _MinDamage;

        public int MinDamage
        {
            get => _MinDamage;
            set => SetProperty(ref _MinDamage, value);
        }

        private int _MaxDamage;

        public int MaxDamage
        {
            get => _MaxDamage;
            set => SetProperty(ref _MaxDamage, value);
        }


        private int _MinCriticalDamage;

        public int MinCriticalDamage
        {
            get => _MinCriticalDamage;
            set => SetProperty(ref _MinCriticalDamage, value);
        }

        private int _MaxCriticalDamage;

        public int MaxCriticalDamage
        {
            get => _MaxCriticalDamage;
            set => SetProperty(ref _MaxCriticalDamage, value);
        }

        private IEnumerable<Equip> Slots()
        {
            yield return Slot1;
            yield return Slot2;
            yield return Slot3;
            yield return Slot4;
        }

        private IEnumerable<Equip> SlotsWithoutSlot1()
        {
            yield return Slot2;
            yield return Slot3;
            yield return Slot4;
        }

        public int FirePowerSum => Friend.FirePower + SlotsEnabled.Sum(x => x.FirePower);

        public int TorpedorSum => Friend.Torpedo + SlotsEnabled.Sum(x => x.Torpedo);

        public int BomberSum => SlotsEnabled.Sum(x => x.Bomber);

        public int ASWSlotsSum => SlotsEnabled.Sum(x => x.ASW);

        public int ASWSum => Friend.ASW + ASWSlotsSum;

        public int HP => Enemy.HP;

        public int Armor => Enemy.Armor;

        public double ImprovementCorrectionSum(AttackType attackType) => SlotsEnabled.Sum(x => x.ImprovementCorrection(attackType));

        private IEnumerable<Equip> SlotsEnabled => Slots().Where(x => !string.IsNullOrEmpty(x?.Name));

        /// <summary>
        /// 弾薬量(0 ～ 100)
        /// </summary>
        private int _RemainAmmunition = 100;
        public int RemainAmmunition
        {
            get => _RemainAmmunition;
            set
            {
                SetProperty(ref _RemainAmmunition, value);

                Calc();
            }
        }

        /// <summary>
        /// 基本攻撃力
        /// </summary>
        /// <param name="attackType"></param>
        /// <param name="IsNighttimeTouching">夜間触接フラグ</param>
        /// <returns></returns>
        private double BaseAttack(AttackType attackType, bool IsNighttimeTouching)
        {
            switch (attackType)
            {
                case AttackType.AirAttack:
                    return BaseAttackAirAttack(attackType);
                case AttackType.ArtilleryDuel:
                    return BaseAttackArtilleryDuel(attackType);
                case AttackType.ArtilleryDuelAir:
                    return BaseAttackArtilleryDuelAir(attackType);
                case AttackType.ArtilleryDuelSub:
                    return BaseAttackArtilleryDuelSub(attackType);
                case AttackType.LightningBattle:
                    return BaseAttackLightningBattle(attackType);
                case AttackType.NightBattle:
                    return BaseAttackNightBattle(attackType, IsNighttimeTouching);
                default:
                    throw new ArgumentException(attackType.ToString());
            }
        }

        /// <summary>
        /// 基本攻撃力(航空戦)
        /// </summary>
        /// <param name="attackType"></param>
        /// <returns></returns>
        private double BaseAttackAirAttack(AttackType attackType) => Slots().Zip(Friend.SlotNums(), (equip, slotnum) => (equip, slotnum)).Sum(x => (x.Item1.AirAttack * Math.Sqrt(x.Item2) + 25) * x.Item1.AirAttackRate);

        /// <summary>
        /// 基本攻撃力(夜戦)
        /// </summary>
        /// <param name="attackType"></param>
        /// <param name="IsNighttimeTouching"></param>
        /// <returns></returns>
        private double BaseAttackNightBattle(AttackType attackType, bool IsNighttimeTouching)
        {
            return FirePowerSum + TorpedorSum + (IsNighttimeTouching ? 5 : 0) + ImprovementCorrectionSum(attackType);
        }

        private double BaseAttackLightningBattle(AttackType attackType) => 5 + TorpedorSum + ImprovementCorrectionSum(attackType);

        /// <summary>
        /// 対潜攻撃別定数
        /// </summary>
        private int ASWConst => (Friend.Type == "駆逐艦" || Friend.Type == "軽巡洋艦" || Friend.Type == "練習巡洋艦" || Friend.Type == "重雷装巡洋艦") ? 13 : 8;

        private double BaseAttackArtilleryDuelSub(AttackType attackType)
        {
            return Math.Sqrt(Friend.ASW) * 2 + ASWSlotsSum * 1.5 + ImprovementCorrectionSum(attackType) + ASWConst;
        }

        /// <summary>
        /// 三式弾特効
        /// </summary>
        /// <param name="type3ShellSpecialEffect"></param>
        /// <returns></returns>
        private double Type3ShellSpecialEffectValue(AttackType attackType, bool type3ShellSpecialEffect)
        {
            if (attackType == AttackType.AirAttack || attackType == AttackType.LightningBattle)
            {
                return 1.0;
            }
            return type3ShellSpecialEffect ? 2.5 : 1.0;
        }

        private double BaseAttackArtilleryDuelAir(AttackType attackType) => FirePowerSum + TorpedorSum + BomberSum * 1.3 + ImprovementCorrectionSum(AttackType.ArtilleryDuel);

        /// <summary>
        /// 基本攻撃力砲撃戦 (砲撃)
        /// </summary>
        /// <param name="attackType"></param>
        /// <returns></returns>
        private double BaseAttackArtilleryDuel(AttackType attackType) => 5 + FirePowerSum + ImprovementCorrectionSum(attackType);

        /// <summary>
        /// 最終攻撃力
        /// </summary>
        /// <returns></returns>
        private (double normal, double critical) FinalAttackCalc()
        {
            var postCapAttack = (int)PostCapAttack(EngagementForm, Formation, AttackType, Nightattack, IsNighttimeTouching, Type3ShellSpecialEffect, WG43SpecialEffect);

            var attack = (int)(postCapAttack * ApShellCorrection(AttackType, ApShellEffect));

            (int normal, int critical) = (attack, (int)(attack * CriticalCorrection * ProficiencyCorrection()));

            return (normal * TouchingCorrection(AttackType, Touching) * ArtillerySpotting.Correction(AttackType), critical * TouchingCorrection(AttackType, Touching) * ArtillerySpotting.Correction(AttackType));
        }

        /// <summary>
        /// キャップ前攻撃力
        /// </summary>
        /// <param name="attackType"></param>
        /// <param name="IsNighttimeTouching">夜間触接フラグ</param>
        /// <returns></returns>
        private double PreCapAttack(EngagementForm engagementForm, Formation formation, AttackType attackType, NightBattleSpecialAttack nightattack, bool IsNighttimeTouching, bool type3ShellSpecialEffect, bool wg43SpecialEffect)
        {
            var baseAttack = BaseAttack(attackType, IsNighttimeTouching);
            var type3ShellSpecialEffectValue = Type3ShellSpecialEffectValue(attackType, type3ShellSpecialEffect);
            var wg42SpecialEffect = WG42SpecialEffect(attackType, wg43SpecialEffect);
            var preCapCorrection = PreCapCorrection(engagementForm, formation, attackType, nightattack);
            var lightCruiserCorrection = LightCruiserCorrection();

            return (baseAttack * type3ShellSpecialEffectValue + wg42SpecialEffect) * preCapCorrection + lightCruiserCorrection;
        }

        /// <summary>
        /// キャップ前補正
        /// </summary>
        /// <returns></returns>
        private double PreCapCorrection(EngagementForm engagementForm, Formation formation, AttackType attackType, NightBattleSpecialAttack nightattack)
        {
            return engagementForm.Correction(attackType) *
                formation.Correction(attackType) *
                DamageState.Correction(attackType) *
                nightattack.Correction(attackType);
        }

        private double ASWSynergy(AttackType attackType)
        {
            return attackType == AttackType.ArtilleryDuelSub ? (SlotsEnabled.Any(x => x.Type == "ソナー") && SlotsEnabled.Any(x => x.Type == "爆雷") ? 1.15 : 1.0) : 1.0;
        }

        private double WG42SpecialEffect(AttackType attackType, bool wg43SpecialEffect)
        {
            if (!wg43SpecialEffect || attackType == AttackType.AirAttack || attackType == AttackType.LightningBattle)
            {
                return 1.0;
            }

            switch (SlotsEnabled.Count(x => x.Name == "WG42 (Wurfgerat 42)"))
            {
                case 1:
                    return 75;
                case 2:
                    return 110;
                case 3:
                    return 140;
                default:
                    return 160;
            }
        }

        /// <summary>
        /// キャップ後攻撃力
        /// </summary>
        /// <param name="attackType"></param>
        /// <returns></returns>
        private double PostCapAttack(EngagementForm engagementForm, Formation formation, AttackType attackType, NightBattleSpecialAttack nightattack, bool IsNighttimeTouching, bool type3ShellSpecialEffect, bool wg43SpecialEffect)
        {
            var attack = PreCapAttack(engagementForm, formation, attackType, nightattack, IsNighttimeTouching, type3ShellSpecialEffect, wg43SpecialEffect);

            return attack > attackType.Cap() ? attackType.Cap() + Math.Sqrt(attack - attackType.Cap()) : attack;
        }

        /// <summary>
        /// 軽巡軽量砲補正
        /// </summary>
        /// <returns></returns>
        private double LightCruiserCorrection()
        {
            return Friend.Type == "軽巡洋艦" || Friend.Type == "重雷装巡洋艦" || Friend.Type == "練習巡洋艦" ? Math.Sqrt(SlotsEnabled.Count(x => x.Name.Contains("15.2cm連装砲"))) * 2 + Slots().Count(x => x.Name == "14cm単装砲" || x.Name == "15.2cm単装砲") : 0;
        }

        /// <summary>
        /// 徹甲弾特効
        /// </summary>
        /// <param name="apShellEffect"></param>
        /// <returns></returns>
        private double ApShellCorrection(AttackType type, bool apShellEffect)
        {
            if (type != AttackType.ArtilleryDuel)
            {
                return 1.0;
            }

            return apShellEffect ? (Slots().Any(x => x.Type == "副砲") ? 1.15 : (Slots().Any(x => x.Type == "電探") ? 1.1 : 1.08)) : 1;
        }

        private double TouchingCorrection(AttackType type, Equip airCraft)
        {
            if (type != AttackType.AirAttack)
            {
                return 1.0;
            }

            switch (airCraft?.Hit)
            {
                case null:
                    return 1.0;
                case 3:
                    return 1.2;
                case 2:
                    return 1.17;
                case 1:
                case 0:
                    return 1.12;
                default:
                    throw new ArgumentException(airCraft.Hit.ToString());
            }

        }

        private double ProficiencyCorrection()
        {
            double Correction(Equip equip, bool first)
            {
                var correct = 1.0;
                var flag = equip?.IsAttackerAirCraft;

                if (flag.HasValue && flag.Value)
                {
                    switch (equip.Improvement)
                    {
                        case 1:
                            correct = 0.014;
                            break;
                        case 2:
                            correct = 0.028;
                            break;
                        case 3:
                            correct = 0.042;
                            break;
                        case 4:
                            correct = 0.056;
                            break;
                        case 5:
                            correct = 0.070;
                            break;
                        case 6:
                            correct = 0.084;
                            break;
                        default:
                            correct = 0.1;
                            break;
                    }

                    if (first)
                    {
                        correct *= 2;
                    }

                    correct += 1;
                }

                return correct;
            }

            var correction = Correction(Slot1, true);

            foreach (var slot in SlotsWithoutSlot1())
            {
                correction *= Correction(slot, false);
            }

            return correction;
        }

        private double CriticalCorrection => 1.5;

        private void Calc()
        {
            OnPropertyChanged(nameof(FirePowerSum));

            OnPropertyChanged(nameof(TorpedorSum));

            OnPropertyChanged(nameof(BomberSum));

            OnPropertyChanged(nameof(ASWSum));

            OnPropertyChanged(nameof(HP));

            OnPropertyChanged(nameof(Armor));

            var finalAttack = FinalAttackCalc();

            MinDamage = (int)((finalAttack.normal - Enemy.Defence.max) * RemainAmmunitionCollection());

            MaxDamage = (int)((finalAttack.normal - Enemy.Defence.min) * RemainAmmunitionCollection());

            MinCriticalDamage = (int)((finalAttack.critical - Enemy.Defence.max) * RemainAmmunitionCollection());

            MaxCriticalDamage = (int)((finalAttack.critical - Enemy.Defence.min) * RemainAmmunitionCollection());
        }

        /// <summary>
        /// 弾薬量補正
        /// </summary>
        /// <returns></returns>
        private double RemainAmmunitionCollection()
        {
            var rate = (double)RemainAmmunition / 100;

            return rate >= 0.5 ? 1.0 : rate * 2;
        }
    }
}
