using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Windows;
using System.Windows.Data;
using YAFIT.Common;

namespace YAFIT.UI.Converter
{
    public class FormTypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is FormType formType)
            {
                return formType.GetType().GetCustomAttribute<DescriptionAttribute>()?.Description??DEFAULT_VALUE;
            }
            return DEFAULT_VALUE;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }

        private const string DEFAULT_VALUE = "Unbekannt";
    }
}
