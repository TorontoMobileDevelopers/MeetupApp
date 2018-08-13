using System;
using System.Globalization;
using Xamarin.Forms;
using Plugin.Iconize;
namespace MeetupApp.Converters
{
    public class IconToIconKeyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Icon icon)
            {
                return icon.Key;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
