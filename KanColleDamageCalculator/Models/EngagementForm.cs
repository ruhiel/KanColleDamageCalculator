using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanColleDamageCalculator.Models
{
    /// <summary>
    /// 交戦形態
    /// </summary>
    public enum EngagementForm
    {
        /// <summary>
        /// 丁字戦有利
        /// </summary>
        CrossingTheTAdvantage,
        /// <summary>
        /// 同航戦
        /// </summary>
        ParallelEngagement,
        /// <summary>
        /// 反航戦
        /// </summary>
        HeadOnEngagement,
        /// <summary>
        /// 丁字戦不利
        /// </summary>
        CrossingTheTDisadvantage,
    }
}
