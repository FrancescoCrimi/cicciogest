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
using System.Threading.Tasks;

namespace CiccioGest.Presentation.WinUiBackend.ViewModel
{
    public sealed partial class MainViewModel : ObservableObject, IDisposable
    {
        private readonly ILogger _logger;
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private bool isBackEnabled;

        public MainViewModel(ILogger<MainViewModel> logger,
                              INavigationService navigationService)
        {
            _logger = logger;
            _navigationService = navigationService;
            _navigationService.Navigated += _navigationService_Navigated;
            _logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        private void _navigationService_Navigated(object sender, Microsoft.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            IsBackEnabled = _navigationService.CanGoBack;
        }

        [RelayCommand]
        private async Task OnLoaded()
        {
            await Task.CompletedTask;
        }

        [RelayCommand]
        private void OnBackRequested()
        {
            _navigationService.GoBack();
        }

        [RelayCommand]
        private void OnNavigateTo(ViewEnum key)
        {
            _navigationService.Navigate(key);
        }

        public void Dispose()
        {
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
