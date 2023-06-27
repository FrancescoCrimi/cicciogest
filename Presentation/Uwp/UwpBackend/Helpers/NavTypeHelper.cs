// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System;
using Windows.UI.Xaml;

namespace CiccioGest.Presentation.UwpBackend.Helpers
{
    /// <summary>
    /// Attached Property for attach Type object
    /// </summary>
    public class NavTypeHelper
    {
        // Helper class to attach an Type object on UIElement
        //
        // Usage in xaml:
        // <winui:NavigationViewItem helpers:NavHelper.NavigateTo="views:MainPage" />
        //
        // Usage in code:
        // NavHelper.SetNavigateTo(navigationViewItem, typeof(MainPage));
        public static Type GetNavigateTo(UIElement item)
            => (Type)item.GetValue(NavigateToProperty);

        public static void SetNavigateTo(UIElement item, Type value)
            => item.SetValue(NavigateToProperty, value);

        public static readonly DependencyProperty NavigateToProperty =
            DependencyProperty.RegisterAttached("NavigateTo",
                                                typeof(Type),
                                                typeof(NavTypeHelper),
                                                new PropertyMetadata(null));
    }
}