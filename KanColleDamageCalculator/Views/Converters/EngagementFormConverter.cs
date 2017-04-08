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
    [ValueConversion(typeof(EngagementForm), typeof(string))]
    public class EngagementFormConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is EngagementForm engagementForm)
            {
                switch(engagementForm)
                {
                    case EngagementForm.CrossingTheTAdvantage:
                        return "丁字戦有利";
                    case EngagementForm.ParallelEngagement:
                        return "同航戦";
                    case EngagementForm.HeadOnEngagement:
                        return "反航戦";
                    case EngagementForm.CrossingTheTDisadvantage:
                        return "丁字戦不利";
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
                    case "丁字戦有利":
                        return EngagementForm.CrossingTheTAdvantage;
                    case "同航戦":
                        return EngagementForm.ParallelEngagement;
                    case "反航戦":
                        return EngagementForm.HeadOnEngagement;
                    case "丁字戦不利":
                        return EngagementForm.CrossingTheTDisadvantage;
                }
            }
            return DependencyProperty.UnsetValue;
        }
    }
}
