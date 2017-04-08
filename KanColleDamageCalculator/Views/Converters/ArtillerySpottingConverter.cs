using KanColleDamageCalculator.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace KanColleDamageCalculator.Views.Converters
{
    [ValueConversion(typeof(ArtillerySpotting), typeof(string))]
    public class ArtillerySpottingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ArtillerySpotting artillerySpotting)
            {
                switch(artillerySpotting)
                {
                    case ArtillerySpotting.Normal:
                        return "なし";
                    case ArtillerySpotting.DoubleAttack:
                        return "連撃";
                    case ArtillerySpotting.CutInMain:
                        return "主砲カットイン";
                    case ArtillerySpotting.CutInAPShell:
                        return "徹甲弾カットイン";
                    case ArtillerySpotting.CutInRadar:
                        return "電探カットイン";
                    case ArtillerySpotting.CutInSec:
                        return "副砲カットイン";
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
                    case "なし":
                        return ArtillerySpotting.Normal;
                    case "連撃":
                        return ArtillerySpotting.DoubleAttack;
                    case "主砲カットイン":
                        return ArtillerySpotting.CutInMain;
                    case "徹甲弾カットイン":
                        return ArtillerySpotting.CutInAPShell;
                    case "電探カットイン":
                        return ArtillerySpotting.CutInRadar;
                    case "副砲カットイン":
                        return ArtillerySpotting.CutInSec;
                }
            }

            return DependencyProperty.UnsetValue;
        }
    }
}
