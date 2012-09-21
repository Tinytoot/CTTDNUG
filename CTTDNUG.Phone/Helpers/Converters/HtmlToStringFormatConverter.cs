using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Data;

namespace CTTDNUG.Phone.Helpers.Converters
{
    public class HtmlToStringFormatConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value != null)
            {
                return Regex.Replace(value.ToString(), @"<(.|\n)*?>", string.Empty);
            }
            else
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
