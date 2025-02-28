using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace YAFIT.UI.Converter
{
    public class PercentageDisplayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is float val)
            {
                return $"{val.ToString("0.##")}%";
            }
            return "0.00%";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
