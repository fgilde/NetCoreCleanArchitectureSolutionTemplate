using System;
using System.Globalization;
using System.Windows.Data;

namespace VSIX_CCA_ProjectTemplate
{
    public class StringToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str)
                return str.ToLower() == "true";
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b)
                return b ? "True" : "False";
            return value;
        }
    }
}