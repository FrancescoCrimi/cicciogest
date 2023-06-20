// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System;

namespace CiccioGest.Presentation.WpfBackend.Services
{
    public interface INavigationService
    {
        bool CanGoBack { get; }
        //bool CanGoForward { get; }
        void GoBack();
        //void GoForward();
        //void Initialize(Frame shellFrame);
        void NavigateTo(Type pageType,
                        bool clearNavigation = false);
        void NavigateTo(string key,
                        bool clearNavigation = false);
        event EventHandler Navigated;
    }
}
