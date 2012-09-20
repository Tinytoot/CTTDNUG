using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CTTDNUG.Phone.Helpers.Converters
{
    public class HtmlToStringFormatConverter
    {
         public object Convert(object value, Type targetType, CultureInfo culture)
        {
            return Regex.Replace(value.ToString(), @"<(.|\n)*?>", string.Empty);
        }

        public object ConvertBack(object value, Type targetType, CultureInfo culture)
        {
            return value;
        }
    }
}
