using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Sheleski.Xamarin.Forms.BindingConverters
{
    public class IsNullConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value is null;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
    }
}
