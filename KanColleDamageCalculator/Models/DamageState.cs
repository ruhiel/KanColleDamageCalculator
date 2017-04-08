using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanColleDamageCalculator.Models
{
    public enum DamageState
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal,
        /// <summary>
        /// 小破
        /// </summary>
        SlightlyDamaged,
        /// <summary>
        /// 中破
        /// </summary>
        ModeratelyDamaged,
        /// <summary>
        /// 大破
        /// </summary>
        HeavilyDamaged,
    }
}
