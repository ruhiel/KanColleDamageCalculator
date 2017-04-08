using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanColleDamageCalculator.Models
{
    public enum NightBattleSpecialAttack
    {
        /// <summary>
        /// 通常
        /// </summary>
        Normal,
        /// <summary>
        /// 魚雷カットイン
        /// </summary>
        CutInTorpedo,
        /// <summary>
        /// 主砲+魚雷カットイン
        /// </summary>
        CutInMixed,
        /// <summary>
        /// 主砲カットイン
        /// </summary>
        CutInMainGun,
        /// <summary>
        /// 主砲+副砲カットイン
        /// </summary>
        CutInSecGun,
        /// <summary>
        /// 連撃
        /// </summary>
        DoubleAttack,
    }
}
