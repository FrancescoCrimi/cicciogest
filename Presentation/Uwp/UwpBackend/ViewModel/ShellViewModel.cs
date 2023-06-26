// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.UwpBackend.Contracts;
using CiccioGest.Presentation.UwpBackend.Contracts.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.UwpBackend.ViewModel
{
    public sealed class ShellViewModel : ObservableObject, IDisposable
    {
        private readonly ILogger _logger;
        private readonly INavigationService _navigationService;
        private bool _isBackEnabled;
        private AsyncRelayCommand _loadedCommand;
        private RelayCommand _backRequestedCommand;
        private RelayCommand<ViewEnum> _navigateToCommand;

        public bool IsBackEnabled
        {
            get => _isBackEnabled;
            set => SetProperty(ref _isBackEnabled, value);
        }

        public IAsyncRelayCommand LoadedCommand => _loadedCommand
            ?? (_loadedCommand = new AsyncRelayCommand(OnLoaded));

        public ICommand BackRequestedCommand => _backRequestedCommand
            ?? (_backRequestedCommand = new RelayCommand(OnBackRequested));

        public ICommand NavigateToCommand => _navigateToCommand
            ?? (_navigateToCommand = new RelayCommand<ViewEnum>(OnNavigateTo));

        public ShellViewModel(ILogger<ShellViewModel> logger,
                              INavigationService navigationService)
        {
            _logger = logger;
            _navigationService = navigationService;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        private async Task OnLoaded()
        {
            await Task.CompletedTask;
        }

        private void OnBackRequested()
        {
            _navigationService.GoBack();
        }

        private void OnNavigateTo(ViewEnum view)
        {
            _navigationService.Navigate(view);
        }

        public void Dispose()
        {
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
