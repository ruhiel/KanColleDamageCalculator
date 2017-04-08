using KanColleDamageCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Globalization;
using System.Windows;

namespace KanColleDamageCalculator.Views.Converters
{
    [ValueConversion(typeof(AttackType), typeof(string))]
    public class AttackTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is AttackType attackType)
            {
                switch(attackType)
                {
                    case AttackType.AirAttack:
                        return "航空戦";
                    case AttackType.ArtilleryDuel:
                        return "砲撃戦";
                    case AttackType.ArtilleryDuelAir:
                        return "砲撃戦(航空攻撃)";
                    case AttackType.ArtilleryDuelSub:
                        return "砲撃戦(対潜攻撃)";
                    case AttackType.LightningBattle:
                        return "雷撃戦";
                    case AttackType.NightBattle:
                        return "夜戦";
                }
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str)
            {
                switch (str)
                {
                    case "航空戦":
                        return AttackType.AirAttack;
                    case "砲撃戦":
                        return AttackType.ArtilleryDuel;
                    case "砲撃戦(航空攻撃)":
                        return AttackType.ArtilleryDuelAir;
                    case "砲撃戦(対潜攻撃)":
                        return AttackType.ArtilleryDuelSub;
                    case "雷撃戦":
                        return AttackType.LightningBattle;
                    case "夜戦":
                        return AttackType.NightBattle;
                }
            }

            return DependencyProperty.UnsetValue;
        }
    }
}
