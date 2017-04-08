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
    [ValueConversion(typeof(Formation), typeof(string))]
    public class FormationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is Formation formation)
            {
                switch(formation)
                {
                    case Formation.LineAhead:
                        return "単縦陣";
                    case Formation.DoubleLine:
                        return "複縦陣";
                    case Formation.Diamond:
                        return "輪形陣";
                    case Formation.Echelon:
                        return "梯形陣";
                    case Formation.LineAbreast:
                        return "単横陣";
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
                    case "単縦陣":
                        return Formation.LineAhead;
                    case "複縦陣":
                        return Formation.DoubleLine;
                    case "輪形陣":
                        return Formation.Diamond;
                    case "梯形陣":
                        return Formation.Echelon;
                    case "単横陣":
                        return Formation.LineAbreast;
                }
            }
            return DependencyProperty.UnsetValue;
        }
    }
}
