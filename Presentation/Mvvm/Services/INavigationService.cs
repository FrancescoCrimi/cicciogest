// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System;

namespace CiccioGest.Presentation.Mvvm.Services
{
    public interface INavigationService
    {
        event EventHandler Navigated;
        bool CanGoBack { get; }
        bool CanGoForward { get; }
        void GoBack(bool emptyForwardStack = false);
        void GoForward(bool emptyBackStack = false);
        void Navigate(Type pageType,
                      bool clearNavigation = true);
        void Navigate(string key,
                      bool clearNavigation = true);
    }
}
