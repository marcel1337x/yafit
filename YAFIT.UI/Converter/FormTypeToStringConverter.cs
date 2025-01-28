using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Windows;
using System.Windows.Data;
using YAFIT.Common;
using static System.Reflection.Metadata.BlobBuilder;

namespace YAFIT.UI.Converter
{
    public class FormTypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is FeedbackFormType formType)
            {
                FieldInfo? field = formType.GetType().GetField(formType.ToString());
                if (field != null)
                {
                    DescriptionAttribute? attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                    return attribute?.Description ?? DEFAULT_VALUE;
                }
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
