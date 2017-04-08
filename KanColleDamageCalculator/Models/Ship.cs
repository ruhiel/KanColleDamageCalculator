using Prism.Mvvm;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Reactive.Linq;
using Reactive.Bindings.Extensions;

namespace KanColleDamageCalculator.Models
{
    public class Ship : BindableBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int FirePower { get; set; }
        public int Torpedo { get; set; }
        public int Armor { get; set; }
        public int HP { get; set; }
        public string Type { get; set; }
        public int Evade { get; set; }
        public int AA { get; set; }
        public int ViewRange { get; set; }
        public int Luck { get; set; }
        public bool KanmusuFlag { get;set;}

        /// <summary>
        /// スロット数
        /// </summary>
        public int Have { get; set; }
        public DamageState DamageState { get; set; }

        /// <summary>
        /// 対潜
        /// </summary>
        public int ASW { get; set; }

        public int Slot1Num { get; set; }

        public int Slot2Num { get; set; }

        public int Slot3Num { get; set; }

        public int Slot4Num { get; set; }

        public IEnumerable<int> SlotNums()
        {
            yield return Slot1Num;
            yield return Slot2Num;
            yield return Slot3Num;
            yield return Slot4Num;
        }

        /// <summary>
        /// 最終攻撃力
        /// </summary>
        private (double normal, double critical) _FinalAttack;
        public (double normal, double critical) FinalAttack
        {
            get => _FinalAttack;
            set => SetProperty(ref _FinalAttack, value);
        }

        /// <summary>
        /// 防御力
        /// </summary>
        public (double min, double max) Defence => (Armor * 0.7, Armor * 0.7 + (Armor - 1) * 0.6);

        public override string ToString()
        {
            return Name;
        }
    }
}
