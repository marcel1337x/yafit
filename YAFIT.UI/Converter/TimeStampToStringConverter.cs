﻿using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace YAFIT.UI.Converter
{
    public class TimeStampToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is DateTime dateTime)
            {

            }
            return "-/-";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
