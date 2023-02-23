using System;
using System.Globalization;

namespace MauiGithubSearch.UI.Converter
{
    public class IntToBoolConverter : IValueConverter
    {
        public IntToBoolConverter()
        {
        }

        /// <summary>
        /// ソースからターゲットに値が渡されるたびに、`Convert `メソッドが呼ばれる
        /// </summary>
        /// <param name="value">変換対象となるdataBindingのソースの値</param>
        /// <param name="targetType">dataBindingのターゲットプロパティの型</param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Console.WriteLine("Convert value: " + value + " targetType: " + targetType + " parameter: " + parameter + " culture: " + culture);
            return (int)value != 0;
        }

        /// <summary>
        /// ConvertBackメソッドは`TwoWay`または、`OneWayToSource` Bindingのみ呼び出される。
        /// </summary>
        /// <param name="value">dataBindingのターゲットの値</param>
        /// <param name="targetType">dataBindingのソースプロパティの型</param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Console.WriteLine("ConvertBack value: " + value + " targetType: " + targetType + " parameter: " + parameter + " culture: " + culture);
            return (bool)value ? 1 : 0;
        }
    }
}

