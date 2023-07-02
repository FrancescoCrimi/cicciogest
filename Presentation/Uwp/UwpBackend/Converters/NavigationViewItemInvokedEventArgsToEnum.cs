// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.UwpBackend.Contracts;
using CiccioGest.Presentation.UwpBackend.Helpers;
using Microsoft.UI.Xaml.Controls;
using System;
using Windows.UI.Xaml.Data;

namespace CiccioGest.Presentation.UwpBackend.Converters
{
    public class NavigationViewItemInvokedEventArgsToEnum : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is NavigationViewItemInvokedEventArgs args)
            {
                var selectedItem = args.InvokedItemContainer as NavigationViewItem;

                if (args.IsSettingsInvoked)
                    if(selectedItem?.GetValue(NavEnumHelper.NavigateToProperty) == null)
                        NavEnumHelper.SetNavigateTo(selectedItem, ViewEnum.Settings);

                var enumvalue = selectedItem?.GetValue(NavEnumHelper.NavigateToProperty);
                if (enumvalue != null)
                    return (ViewEnum)enumvalue;
                return null;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
