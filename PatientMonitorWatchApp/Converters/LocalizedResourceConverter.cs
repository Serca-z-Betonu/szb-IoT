using System;
using System.Globalization;

using PatientMonitorWatchApp.Services;

using Xamarin.Forms;

namespace PatientMonitorWatchApp.Converters
{
    /// <summary>
    /// The converter defining method for value conversion from resource to localized resource.
    /// </summary>
    public class LocalizedResourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return LocalizationService.Instance.GetResource(parameter as string);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
