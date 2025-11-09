// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.Mvvm.Contracts;
using CiccioGest.Presentation.WinUiBackend.Helpers;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using System;

namespace CiccioGest.Presentation.WinUiBackend.Converters
{
    /// <summary>
    /// Converts the "NavigationViewItemInvokedEventArgs" object of the 
    /// "ItemInvoked" event of a "NavigationView" object to an "EnumView"
    /// </summary>
    public class NavigationViewItemInvokedEventArgsToViewEnum : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is NavigationViewItemInvokedEventArgs args)
            {
                var selectedItem = args.InvokedItemContainer as NavigationViewItem;
                var enumvalue = selectedItem?.GetValue(NavEnumHelper.NavigateToProperty);
                if (enumvalue != null)
                    return (ViewEnum)enumvalue;
                return null!;
            }
            return null!;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

/* How to use  this converter
 * 
 * Use Attached Property for attach "ViewEnum" value on UIElement

                    <NavigationViewItem Content="Articoli"
                                        Icon="Document"
                                        helpers:NavEnumHelper.NavigateTo="Articoli" />

 *
 * Use this converter to convert the "NavigationViewItemInvokedEventArgs" object
 * of the "ItemInvoked" event of a "NavigationView" object to an "ViewEnum"

        <i:Interaction.Behaviors>
            <ic:EventTriggerBehavior EventName="ItemInvoked">
                <ic:InvokeCommandAction Command="{Binding NavigateToCommand}">
                    <ic:InvokeCommandAction.InputConverter>
                        <converters:NavigationViewItemInvokedEventArgsToViewEnum />
                    </ic:InvokeCommandAction.InputConverter>
                </ic:InvokeCommandAction>
            </ic:EventTriggerBehavior>
        </i:Interaction.Behaviors>

 *
 */
