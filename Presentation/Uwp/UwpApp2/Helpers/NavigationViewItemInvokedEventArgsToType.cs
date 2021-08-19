using Microsoft.UI.Xaml.Controls;
using System;
using Windows.UI.Xaml.Data;

namespace CiccioGest.Presentation.UwpApp.Helpers
{
    public class NavigationViewItemInvokedEventArgsToType : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            NavigationViewItemInvokedEventArgs asdfg = value as NavigationViewItemInvokedEventArgs;
            if (asdfg != null)
            {
                var selectedItem = asdfg.InvokedItemContainer as Microsoft.UI.Xaml.Controls.NavigationViewItem;
                Type pageType = selectedItem?.GetValue(NavHelper.NavigateToProperty) as Type;
                return pageType;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
