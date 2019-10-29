using System;
using System.Globalization;
using Xamarin.Forms;

namespace Sheleski.Xamarin.Forms.BindingConverters
{
    public class NotNullConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (value is null) ? false : true;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
    }
}
