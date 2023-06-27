// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.WinUiBackend.Contracts;
using CiccioGest.Presentation.WinUiBackend.Contracts.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.WinUiBackend.ViewModel
{
    public sealed partial class ShellViewModel : ObservableObject, IDisposable
    {
        private readonly ILogger _logger;
        private readonly INavigationService _navigationService;

        public ShellViewModel(ILogger<ShellViewModel> logger,
                              INavigationService navigationService)
        {
            _logger = logger;
            _navigationService = navigationService;
            _logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        [RelayCommand]
        private async Task OnLoaded()
        {
            await Task.CompletedTask;
        }

        [RelayCommand]
        private void OnNavigateTo(ViewEnum key)
        {
            _navigationService.Navigate(key);
        }

        [RelayCommand]
        private void OnBackRequested()
        {
            _navigationService.GoBack();
        }

        public void Dispose()
        {
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
