using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Sheleski.Xamarin.Forms.BindingConverters.Bool
{
    public class BoolInverterConverter : IValueConverter
    {
        public static BoolInverterConverter Instance { get; } = new BoolInverterConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b)
                return !b;

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(value, targetType, parameter, culture);
        }
    }
}
