using KanColleDamageCalculator.Models;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using Reactive.Bindings.Extensions;
using System.Linq;
using System.Collections.ObjectModel;

namespace KanColleDamageCalculator.ViewModels
{
    public class MainWindowViewModel
    {
        public ObservableCollection<Ship> Ships { get; private set; }

        public List<Ship> EnemyShips { get; private set; }

        public ObservableCollection<Equip> Equips1 { get; private set; }

        public ObservableCollection<Equip> Equips2 { get; private set; }

        public ObservableCollection<Equip> Equips3 { get; private set; }

        public ObservableCollection<Equip> Equips4 { get; private set; }

        public List<Equip> ReconnaissanceAircraft { get; private set; }

        public ReactiveProperty<Ship> EnemyShip { get; private set; }

        public ReactiveProperty<Ship> FriendShip { get; private set; }

        public ReactiveProperty<Equip> Slot1 { get; private set; }

        public ReactiveProperty<Equip> Slot2 { get; private set; }

        public ReactiveProperty<Equip> Slot3 { get; private set; }

        public ReactiveProperty<Equip> Slot4 { get; private set; }

        public ReactiveProperty<ArtillerySpotting> SelectedArtillerySpotting { get; private set; }

        public ReactiveProperty<AttackType> SelectedAttackType { get; private set; }

        public ReactiveProperty<DamageState> SelectedDamageState { get; private set; }

        public ReactiveProperty<EngagementForm> SelectedEngagementForm { get; private set; }

        public ReactiveProperty<Formation> SelectedFormation { get; private set; }

        public ReactiveProperty<NightBattleSpecialAttack> SelectedNightBattleSpecialAttack { get; private set; }

        public ReactiveProperty<bool> IsNighttimeTouching { get; private set; }

        public ReactiveProperty<bool> Type3ShellSpecialEffect { get; private set; }

        public ReactiveProperty<bool> WG43SpecialEffect { get; private set; }

        public ReactiveProperty<bool> ApShellEffect { get; private set; }

        public ReactiveProperty<int> RemainAmmunition { get; private set; }

        public ReactiveProperty<Equip> SelectedReconnaissanceAircraft { get; private set; }

        public ReactiveProperty<int> MinDamage { get; private set; }

        public ReactiveProperty<int> MaxDamage { get; private set; }

        public ReactiveProperty<int> MinCriticalDamage { get; private set; }

        public ReactiveProperty<int> MaxCriticalDamage { get; private set; }

        public ReactiveProperty<int> Slot1Improvement { get; private set; }

        public ReactiveProperty<int> Slot2Improvement { get; private set; }

        public ReactiveProperty<int> Slot3Improvement { get; private set; }

        public ReactiveProperty<int> Slot4Improvement { get; private set; }

        public ReadOnlyReactiveProperty<int> FirePowerSum { get; private set; }

        public ReadOnlyReactiveProperty<int> TorpedorSum { get; private set; }

        public List<string> EquipTypes1 { get; set; }

        public List<string> EquipTypes2 { get; set; }

        public List<string> EquipTypes3 { get; set; }

        public List<string> EquipTypes4 { get; set; }

        public List<string> ShipTypes { get; set; }

        public ReactiveProperty<string> NowSelectEquipType1 { get; set; } = new ReactiveProperty<string>();

        public ReactiveProperty<string> NowSelectEquipType2 { get; set; } = new ReactiveProperty<string>();

        public ReactiveProperty<string> NowSelectEquipType3 { get; set; } = new ReactiveProperty<string>();

        public ReactiveProperty<string> NowSelectEquipType4 { get; set; } = new ReactiveProperty<string>();

        public ReadOnlyReactiveProperty<int> BomberSum { get; private set; }

        public ReadOnlyReactiveProperty<int> ASWSum { get; private set; }

        public ReactiveProperty<string> SelectShipType { get; private set; }

        public ReadOnlyReactiveProperty<int> HP { get; private set; }

        public ReadOnlyReactiveProperty<int> Armor { get; private set; }

        private Calculator _Calculator;

        public MainWindowViewModel()
        {
            _Calculator = new Calculator();

            FriendShip = _Calculator.ToReactivePropertyAsSynchronized(x => x.Friend);

            EnemyShip = _Calculator.ToReactivePropertyAsSynchronized(x => x.Enemy);

            Slot1 = _Calculator.ToReactivePropertyAsSynchronized(x => x.Slot1);

            Slot2 = _Calculator.ToReactivePropertyAsSynchronized(x => x.Slot2);

            Slot3 = _Calculator.ToReactivePropertyAsSynchronized(x => x.Slot3);

            Slot4 = _Calculator.ToReactivePropertyAsSynchronized(x => x.Slot4);

            Slot1Improvement = _Calculator.ToReactivePropertyAsSynchronized(x => x.Slot1Improvement);

            Slot2Improvement = _Calculator.ToReactivePropertyAsSynchronized(x => x.Slot2Improvement);

            Slot3Improvement = _Calculator.ToReactivePropertyAsSynchronized(x => x.Slot3Improvement);

            Slot4Improvement = _Calculator.ToReactivePropertyAsSynchronized(x => x.Slot4Improvement);

            SelectedArtillerySpotting = _Calculator.ToReactivePropertyAsSynchronized(x => x.ArtillerySpotting);

            SelectedAttackType = _Calculator.ToReactivePropertyAsSynchronized(x => x.AttackType);

            SelectedDamageState = _Calculator.ToReactivePropertyAsSynchronized(x => x.DamageState);

            SelectedEngagementForm = _Calculator.ToReactivePropertyAsSynchronized(x => x.EngagementForm);

            SelectedFormation = _Calculator.ToReactivePropertyAsSynchronized(x => x.Formation);

            SelectedNightBattleSpecialAttack = _Calculator.ToReactivePropertyAsSynchronized(x => x.Nightattack);

            SelectedReconnaissanceAircraft = _Calculator.ToReactivePropertyAsSynchronized(x => x.Touching);

            IsNighttimeTouching = _Calculator.ToReactivePropertyAsSynchronized(x => x.IsNighttimeTouching);

            Type3ShellSpecialEffect = _Calculator.ToReactivePropertyAsSynchronized(x => x.Type3ShellSpecialEffect);

            WG43SpecialEffect = _Calculator.ToReactivePropertyAsSynchronized(x => x.WG43SpecialEffect);

            ApShellEffect = _Calculator.ToReactivePropertyAsSynchronized(x => x.ApShellEffect);

            RemainAmmunition = _Calculator.ToReactivePropertyAsSynchronized(x => x.RemainAmmunition);

            Ships =  new ObservableCollection<Ship>(ShipRecords.Instance.Records);

            EnemyShips = new List<Ship>(ShipRecords.Instance.Records.OrderBy(x => x.KanmusuFlag).ThenBy(y => y.ID));

            Equips1 = new ObservableCollection<Equip>(EquipRecords.Instance.Records);

            Equips2 = new ObservableCollection<Equip>(EquipRecords.Instance.Records);

            Equips3 = new ObservableCollection<Equip>(EquipRecords.Instance.Records);

            Equips4 = new ObservableCollection<Equip>(EquipRecords.Instance.Records);

            EquipTypes1 = new List<string>(new List<string>() { string.Empty }.Concat(EquipRecords.Instance.Records.Select(x => x.Type).Distinct()));

            EquipTypes2 = new List<string>(new List<string>() { string.Empty }.Concat(EquipRecords.Instance.Records.Select(x => x.Type).Distinct()));

            EquipTypes3 = new List<string>(new List<string>() { string.Empty }.Concat(EquipRecords.Instance.Records.Select(x => x.Type).Distinct()));

            EquipTypes4 = new List<string>(new List<string>() { string.Empty }.Concat(EquipRecords.Instance.Records.Select(x => x.Type).Distinct()));

            ShipTypes = new List<string>(new List<string>() { string.Empty }.Concat(ShipRecords.Instance.Records.Select(x => x.Type).Distinct()));

            SelectShipType = new ReactiveProperty<string>();

            SelectShipType.Subscribe(type => 
            {
                Ships.Clear();
                Ships.AddRange(ShipRecords.Instance.Records.Where(x => string.IsNullOrEmpty(type) ? true : x.Type == type));
            });

            ReconnaissanceAircraft = new List<Equip>(EquipRecords.Instance.Records.Where(x => x.Type == "艦上偵察機"));

            MinDamage = _Calculator.ObserveProperty(x => x.MinDamage).ToReactiveProperty();

            MaxDamage = _Calculator.ObserveProperty(x => x.MaxDamage).ToReactiveProperty();

            MinCriticalDamage = _Calculator.ObserveProperty(x => x.MinCriticalDamage).ToReactiveProperty();

            MaxCriticalDamage = _Calculator.ObserveProperty(x => x.MaxCriticalDamage).ToReactiveProperty();

            FirePowerSum = _Calculator.ObserveProperty(x => x.FirePowerSum).ToReadOnlyReactiveProperty();

            TorpedorSum = _Calculator.ObserveProperty(x => x.TorpedorSum).ToReadOnlyReactiveProperty();

            BomberSum = _Calculator.ObserveProperty(x => x.BomberSum).ToReadOnlyReactiveProperty();

            ASWSum = _Calculator.ObserveProperty(x => x.ASWSum).ToReadOnlyReactiveProperty();

            HP = _Calculator.ObserveProperty(x => x.HP).ToReadOnlyReactiveProperty();

            Armor = _Calculator.ObserveProperty(x => x.Armor).ToReadOnlyReactiveProperty();

            void AddEquipList(string type, ObservableCollection<Equip> equips)
            {
                equips.Clear();

                equips.AddRange(EquipRecords.Instance.Records.Where(x => string.IsNullOrEmpty(type) ? true : x.Type == type));
            }

            NowSelectEquipType1.Subscribe(type => AddEquipList(type, Equips1));

            NowSelectEquipType2.Subscribe(type => AddEquipList(type, Equips2));

            NowSelectEquipType3.Subscribe(type => AddEquipList(type, Equips3));

            NowSelectEquipType4.Subscribe(type => AddEquipList(type, Equips4));
        }
    }
}
