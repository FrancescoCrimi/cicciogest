using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CiccioGest.Presentation.WpfApp.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        // Se parameter == "Invert" allora true => Collapsed, false => Visible
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            bool isTrue = false;

            // Caso tipico: valore booleano (boxed) o null
            if (value is bool b)
            {
                isTrue = b;
            }
            else if (value is string s)
            {
                if (bool.TryParse(s, out var parsed)) isTrue = parsed;
            }
            else if (value is int i)
            {
                isTrue = i != 0;
            }
            else if (value != null)
            {
                // Tentativo generico: proviamo a convertire in booleano in modo sicuro
                try
                {
                    isTrue = System.Convert.ToBoolean(value, culture);
                }
                catch
                {
                    isTrue = false;
                }
            }

            bool invert = string.Equals(parameter as string, "Invert", StringComparison.OrdinalIgnoreCase);

            return isTrue
                ? (invert ? Visibility.Collapsed : Visibility.Visible)
                : (invert ? Visibility.Visible : Visibility.Collapsed);
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is Visibility v)
            {
                bool invert = string.Equals(parameter as string, "Invert", StringComparison.OrdinalIgnoreCase);
                bool result = v == Visibility.Visible;
                return invert ? !result : result;
            }

            return DependencyProperty.UnsetValue;
        }
    }
}
