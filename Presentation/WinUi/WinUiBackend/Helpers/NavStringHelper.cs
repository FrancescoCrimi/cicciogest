// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using Microsoft.UI.Xaml;

namespace CiccioGest.Presentation.WinUiBackend.Helpers;

/// <summary>
/// Attached Property for attach String object
/// </summary>
public class NavStringHelper
{
    // Helper class to attach a String Object on UIElement.
    //
    // Usage in XAML:
    // <NavigationViewItem helpers:NavigationHelper.NavigateTo="AppName.ViewModels.MainViewModel" />
    //
    // Usage in code:
    // NavigationHelper.SetNavigateTo(navigationViewItem, typeof(MainViewModel).FullName);
    public static string GetNavigateTo(UIElement item)
        => (string)item.GetValue(NavigateToProperty);

    public static void SetNavigateTo(UIElement item, string value)
        => item.SetValue(NavigateToProperty, value);

    public static readonly DependencyProperty NavigateToProperty =
        DependencyProperty.RegisterAttached("NavigateTo",
                                            typeof(string),
                                            typeof(NavStringHelper),
                                            new PropertyMetadata(null));
}
