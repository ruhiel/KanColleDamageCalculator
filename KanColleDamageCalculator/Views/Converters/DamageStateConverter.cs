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
    [ValueConversion(typeof(DamageState), typeof(string))]
    public class DamageStateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DamageState damageState)
            {
                switch(damageState)
                {
                    case DamageState.Normal:
                        return "正常";
                    case DamageState.SlightlyDamaged:
                        return "小破";
                    case DamageState.ModeratelyDamaged:
                        return "中破";
                    case DamageState.HeavilyDamaged:
                        return "大破";
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
                    case "正常":
                        return DamageState.Normal;
                    case "小破":
                        return DamageState.SlightlyDamaged;
                    case "中破":
                        return DamageState.ModeratelyDamaged;
                    case "大破":
                        return DamageState.HeavilyDamaged;
                }
            }

            return DependencyProperty.UnsetValue;
        }
    }
}
