// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System;
using Windows.UI.Xaml.Navigation;

namespace CiccioGest.Presentation.UwpBackend.Contracts.Services
{
    public interface INavigationService
    {
        event NavigatedEventHandler Navigated;
        event NavigationFailedEventHandler NavigationFailed;

        bool CanGoBack { get; }
        bool CanGoForward { get; }
        void GoBack();
        void GoForward();
        bool Navigate(Type pageType, object parameter = null, bool clearNavigation = false);
        bool Navigate(ViewEnum key, object parameter = null, bool clearNavigation = false);
    }
}