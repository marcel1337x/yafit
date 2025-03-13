using System.Globalization;
using System.Windows;
using System.Windows.Data;
using YAFIT.Databases.Entities;

namespace YAFIT.UI.Converter
{
    class FachEntityToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is FachEntity val)
            {
                return val.Name;
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
