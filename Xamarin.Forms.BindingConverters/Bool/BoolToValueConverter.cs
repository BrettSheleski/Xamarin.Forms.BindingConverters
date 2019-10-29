using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Sheleski.Xamarin.Forms.BindingConverters.Bool
{
    public abstract class BoolToValueConverterBase : IValueConverter
    {

        protected abstract object GetTrueValue();
        protected abstract object GetFalseValue();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b)
            {
                return b ? GetTrueValue() : GetFalseValue();
            }

            return value;
        }
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
    }

    public class BoolToValueConverter : BoolToValueConverterBase
    {

        public BoolToValueConverter() : this(ReferenceEqualsEqualityComparer.Instance)
        {
        }

        public BoolToValueConverter(System.Collections.IEqualityComparer equalityComparer)
        {
            this.Comparer = equalityComparer;
        }

        public object TrueValue { get; set; }
        public object FalseValue { get; set; }
        public System.Collections.IEqualityComparer Comparer { get; }

        protected override object GetFalseValue() => FalseValue;
        protected override object GetTrueValue() => TrueValue;

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Comparer.Equals(value, TrueValue))
            {
                return true;
            }
            else if (Comparer.Equals(value, FalseValue))
            {
                return false;
            }

            return value;
        }

        class ReferenceEqualsEqualityComparer : System.Collections.IEqualityComparer
        {
            private ReferenceEqualsEqualityComparer()
            {
            }

            public static ReferenceEqualsEqualityComparer Instance { get; } = new ReferenceEqualsEqualityComparer();

            public bool AreRefercencesEqual(object a, object b)
            {
                return object.ReferenceEquals(a, b);
            }

            bool IEqualityComparer.Equals(object x, object y)
            {
                return this.AreRefercencesEqual(x, y);
            }

            int IEqualityComparer.GetHashCode(object obj)
            {
                return obj.GetHashCode();
            }
        }
    }

    public class BoolToValueConverter<T> : BoolToValueConverterBase
    {

        public BoolToValueConverter() : this(EqualityComparer<T>.Default)
        {

        }

        public BoolToValueConverter(IEqualityComparer<T> equalityComparer)
        {
            this.Comparer = equalityComparer;
        }


        public T TrueValue { get; set; }
        public T FalseValue { get; set; }
        public IEqualityComparer<T> Comparer { get; }

        protected override object GetFalseValue() => FalseValue;
        protected override object GetTrueValue() => TrueValue;

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is T t)
            {
                if (Comparer.Equals(t, TrueValue))
                {
                    return true;
                }
                else if (Comparer.Equals(t, FalseValue))
                {
                    return false;
                }
            }

            return value;
        }
    }
}