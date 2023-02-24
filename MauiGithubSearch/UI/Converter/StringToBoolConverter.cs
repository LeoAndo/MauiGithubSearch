using System;
using System.Globalization;

namespace MauiGithubSearch.UI.Converter
{
    public class StringToBoolConverter : IValueConverter
    {
        public StringToBoolConverter()
        {
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Console.WriteLine("Convert value: " + value + " targetType: " + targetType + " parameter: " + parameter + " culture: " + culture);
            return !String.IsNullOrEmpty((string)value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Console.WriteLine("ConvertBack value: " + value + " targetType: " + targetType + " parameter: " + parameter + " culture: " + culture);
            return String.IsNullOrEmpty((string)value) ? 0 : 1;
        }
    }
}

