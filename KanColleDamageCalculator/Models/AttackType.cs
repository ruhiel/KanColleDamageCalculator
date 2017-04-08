using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanColleDamageCalculator.Models
{
    public enum AttackType
    {
        /// <summary>
        /// 航空戦
        /// </summary>
        AirAttack,
        /// <summary>
        /// 砲撃戦
        /// </summary>
        ArtilleryDuel,
        /// <summary>
        /// 砲撃戦 (航空攻撃)
        /// </summary>
        ArtilleryDuelAir,
        /// <summary>
        /// 砲撃戦 (対潜攻撃)
        /// </summary>
        ArtilleryDuelSub,
        /// <summary>
        /// 雷撃戦
        /// </summary>
        LightningBattle,
        /// <summary>
        /// 夜戦
        /// </summary>
        NightBattle,
    }
}
