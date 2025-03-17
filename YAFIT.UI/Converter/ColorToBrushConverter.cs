using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace YAFIT.UI.Converter
{
    class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is System.Drawing.Color val)
            {
                return ToSolidColorBrush(val);
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }

        private SolidColorBrush ToSolidColorBrush(System.Drawing.Color color)
        {
            return new()
            {
                Color = new System.Windows.Media.Color { R = color.R, G = color.G, B = color.B, A = color.A }
            };
        }
    }
}
