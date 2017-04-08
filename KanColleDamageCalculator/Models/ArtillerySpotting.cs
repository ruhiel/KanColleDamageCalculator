using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanColleDamageCalculator.Models
{
    public enum ArtillerySpotting
    {
        /// <summary>
        /// なし
        /// </summary>
        Normal,
        /// <summary>
        /// 連撃
        /// </summary>
        DoubleAttack,
        /// <summary>
        /// 主砲+主砲
        /// </summary>
        CutInMain,
        /// <summary>
        /// 主砲+徹甲弾
        /// </summary>
        CutInAPShell,
        /// <summary>
        /// 主砲+電探
        /// </summary>
        CutInRadar,
        /// <summary>
        /// 主砲+副砲
        /// </summary>
        CutInSec,
    }
}
