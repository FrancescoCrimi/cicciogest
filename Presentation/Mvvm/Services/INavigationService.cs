// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.Mvvm.Contracts;
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
                      object? parameter = null,
                      bool clearNavigation = true);
        void Navigate(ViewEnum key,
                      object? parameter = null,
                      bool clearNavigation = false);
    }
}
