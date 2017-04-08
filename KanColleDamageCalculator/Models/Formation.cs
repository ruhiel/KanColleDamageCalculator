using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanColleDamageCalculator.Models
{
    public enum Formation
    {
        /// <summary>
        /// 単縦陣
        /// </summary>
        LineAhead,
        /// <summary>
        /// 複縦陣
        /// </summary>
        DoubleLine,
        /// <summary>
        /// 輪形陣
        /// </summary>
        Diamond,
        /// <summary>
        /// 梯形陣
        /// </summary>
        Echelon,
        /// <summary>
        /// 単横陣
        /// </summary>
        LineAbreast,
    }
}
