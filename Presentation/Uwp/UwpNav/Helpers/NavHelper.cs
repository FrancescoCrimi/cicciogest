// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System;
using Windows.UI.Xaml;

namespace CiccioGest.Presentation.UwpNav.Helpers
{
    /// <summary>
    /// attached property - proprietà associata
    /// </summary>
    public class NavHelper
    {
        // This helper class allows to specify the page that will be shown when you click on a UIElement
        //
        // Usage in xaml:
        // <winui:NavigationViewItem x:Uid="Shell_Main" Icon="Document" helpers:NavHelper.NavigateTo="views:MainPage" />
        //
        // Usage in code:
        // NavHelper.SetNavigateTo(navigationViewItem, typeof(MainPage));
        public static Type GetNavigateTo(UIElement item)
        {
            return (Type)item.GetValue(NavigateToProperty);
        }

        public static void SetNavigateTo(UIElement item, Type value)
        {
            item.SetValue(NavigateToProperty, value);
        }

        public static readonly DependencyProperty NavigateToProperty =
            DependencyProperty.RegisterAttached("NavigateTo",
                                                typeof(Type),
                                                typeof(NavHelper),
                                                new PropertyMetadata(null));
    }
}
