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
    public enum DialogResultType
    {
        Ok,
        Cancel
    }

    public record DialogResult<T>(DialogResultType Type, T? Value);

    public interface INavigationService
    {
        event EventHandler? Navigated;

        bool CanGoBack { get; }
        bool CanGoForward { get; }

        void GoBack(bool emptyForwardStack = false);
        void GoForward(bool emptyBackStack = false);

        Task Navigate<TVM>(object? parameter = null,
                           bool clearNavigation = false) where TVM : ViewModelBase;
        Task<DialogResult<int>> NavigateForResultAsync<TVM>() where TVM : ResultViewModelBase<int>;
    }
}
