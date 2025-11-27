using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace CiccioGest.Presentation.WpfApp.Converters
{
    public class StringNullOrEmptyToVisibilityConverter : IValueConverter
    {
        // Se la stringa è null o vuota → Visible, altrimenti Collapsed
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str = value as string;
            return string.IsNullOrEmpty(str) ? Visibility.Visible : Visibility.Collapsed;
        }

        // Non serve la conversione inversa
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
