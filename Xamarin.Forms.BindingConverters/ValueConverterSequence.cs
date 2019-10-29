using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Sheleski.Xamarin.Forms.BindingConverters
{
    public class ValueConverterSequence : List<IValueConverter>, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConvertBase(this, value, targetType, parameter, culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IEnumerable<IValueConverter> vals = this;

            return ConvertBase(vals.Reverse(), value, targetType, parameter, culture);
        }

        object ConvertBase(IEnumerable<IValueConverter> converters, object value, Type targetType, object parameter, CultureInfo culture)
        {
            return converters.Aggregate(value, (current, converter) => converter.Convert(current, targetType, parameter, culture));
        }
    }
}
