// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.Mvvm.ViewModels;
using System;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Mvvm.Services
{
    public interface INavigationService
    {
        event EventHandler? Navigated;

        bool CanGoBack { get; }
        bool CanGoForward { get; }

        void GoBack(bool emptyForwardStack = false);
        void GoForward(bool emptyBackStack = false);

        void Navigate<TVM>(object? parameter = null,
                           bool clearNavigation = false) where TVM : ViewModelBase;
        Task<int> NavigateForResultAsync<TVM>() where TVM : DialogViewModelBase<int>;
    }
}
