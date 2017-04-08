using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanColleDamageCalculator.Models
{
    public class Equip
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 種別
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 火力
        /// </summary>
        public int FirePower { get; set; }

        /// <summary>
        /// 雷装
        /// </summary>
        public int Torpedo { get; set; }

        /// <summary>
        /// 爆装
        /// </summary>
        public int Bomber { get; set; }

        /// <summary>
        /// 対潜
        /// </summary>
        public int ASW { get; set; }

        /// <summary>
        /// 命中
        /// </summary>
        public int Hit { get; set; }

        /// <summary>
        /// 回避
        /// </summary>
        public int Evade { get; set; }

        /// <summary>
        /// 対空
        /// </summary>
        public int AA { get; set; }

        public int ViewRange { get; set; }

        public int Armor { get; set; }

        public string Range { get; set; }

        public int Radius { get; set; }

        public int Luck { get; set; }

        /// <summary>
        /// 改修値
        /// </summary>
        public int Improvement { get; set; }

        public bool IsAttackerAirCraft => Type == "艦上攻撃機" || Type == "艦上爆撃機" || Type == "水上爆撃機";

        public int AirAttack => Type == "艦上攻撃機" ? Torpedo : Bomber;

        public double AirAttackRate => Type == "艦上攻撃機" ? 1.15 : 1.0;

        /// <summary>
        /// 装備改修補正
        /// </summary>
        /// <param name="attackType"></param>
        /// <returns></returns>
        public double ImprovementCorrection(AttackType attackType)
        {
            return Math.Sqrt(Improvement) * ImprovementCorrectionRate(attackType);
        }

        /// <summary>
        /// 装備別倍率
        /// </summary>
        /// <param name="attackType"></param>
        /// <returns></returns>
        public double ImprovementCorrectionRate(AttackType attackType)
        {
            if(attackType == AttackType.ArtilleryDuel)
            {
                if(Type == "大口径主砲")
                {
                    return 1.5;
                }
                else if (Type == "爆雷" || Type == "ソナー")
                {
                    return 1.5;
                }
            }
            else if(attackType == AttackType.LightningBattle)
            {
                if (Type == "魚雷" || Type == "機銃")
                {
                    return 1.2;
                }
            }

            return 1.0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
