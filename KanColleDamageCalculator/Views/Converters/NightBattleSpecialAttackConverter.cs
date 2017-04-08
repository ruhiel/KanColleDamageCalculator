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
    [ValueConversion(typeof(NightBattleSpecialAttack), typeof(string))]
    public class NightBattleSpecialAttackConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is NightBattleSpecialAttack nightBattleSpecialAttack)
            {
                switch(nightBattleSpecialAttack)
                {
                    case NightBattleSpecialAttack.CutInMainGun:
                        return "主砲カットイン";
                    case NightBattleSpecialAttack.CutInMixed:
                        return "主砲+魚雷カットイン";
                    case NightBattleSpecialAttack.CutInSecGun:
                        return "主砲+副砲カットイン";
                    case NightBattleSpecialAttack.CutInTorpedo:
                        return "魚雷カットイン";
                    case NightBattleSpecialAttack.DoubleAttack:
                        return "連撃";
                    case NightBattleSpecialAttack.Normal:
                        return "通常";
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
                    case "主砲カットイン":
                        return NightBattleSpecialAttack.CutInMainGun;
                    case "主砲+魚雷カットイン":
                        return NightBattleSpecialAttack.CutInMixed;
                    case "主砲+副砲カットイン":
                        return NightBattleSpecialAttack.CutInSecGun;
                    case "魚雷カットイン":
                        return NightBattleSpecialAttack.CutInTorpedo;
                    case "連撃":
                        return NightBattleSpecialAttack.DoubleAttack;
                    case "通常":
                        return NightBattleSpecialAttack.Normal;
                }
            }
            return DependencyProperty.UnsetValue;
        }
    }
}
