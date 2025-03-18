using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Windows;
using System.Windows.Data;
using YAFIT.Common.Enums;

namespace YAFIT.UI.Converter
{
    public class FormTypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int val)
            {
                var formType = FeedbackFormType.Unknown;
                switch (val)
                {
                    case 0:
                        {
                            formType = FeedbackFormType.Unknown;
                            break;
                        }
                    case 1:
                        {
                            formType = FeedbackFormType.First;
                            break;
                        }
                    case 2:
                        {
                            formType = FeedbackFormType.Second;
                            break;
                        }
                    case 3:
                        {
                            formType = FeedbackFormType.Third;
                            break;
                        }
                    default:
                        {
                            formType = FeedbackFormType.Unknown;
                            break;
                        }
                }
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
