// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.WinUiBackend.Contracts;
using Microsoft.UI.Xaml;

namespace CiccioGest.Presentation.WinUiBackend.Helpers;

/// <summary>
/// Attached Property for attach Enum object
/// </summary>
public class NavEnumHelper
{
    // Helper class allows to attach an enum value on UIElement
    //
    // Usage in xaml:
    // <winui:NavigationViewItem helpers:NavEnumHelper.NavigateTo="Fatture" />
    //
    // Usage in code:
    // NavEnumHelper.SetNavigateTo(UIElement, Views.Fatture);
    public static ViewEnum GetNavigateTo(UIElement item)
        => (ViewEnum)item.GetValue(NavigateToProperty);

    public static void SetNavigateTo(UIElement item, ViewEnum value)
        => item.SetValue(NavigateToProperty, value);

    public static readonly DependencyProperty NavigateToProperty =
        DependencyProperty.RegisterAttached("NavigateTo",
                                            typeof(ViewEnum),
                                            typeof(NavEnumHelper),
                                            new PropertyMetadata(null));
}

