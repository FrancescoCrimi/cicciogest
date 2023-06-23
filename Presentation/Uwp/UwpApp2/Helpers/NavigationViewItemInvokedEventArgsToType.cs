// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using Microsoft.UI.Xaml.Controls;
using System;
using Windows.UI.Xaml.Data;

namespace CiccioGest.Presentation.UwpApp.Helpers
{
    public class NavigationViewItemInvokedEventArgsToType : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is NavigationViewItemInvokedEventArgs args)
            {
                var selectedItem = args.InvokedItemContainer as NavigationViewItem;
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
