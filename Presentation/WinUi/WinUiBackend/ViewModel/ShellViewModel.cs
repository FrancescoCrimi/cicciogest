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
using System.Windows.Input;

namespace CiccioGest.Presentation.WinUiBackend.ViewModel
{
    public sealed class ShellViewModel : ObservableObject, IDisposable
    {
        private readonly ILogger _logger;
        private readonly INavigationService _navigationService;
        private AsyncRelayCommand _loadedCommand;
        private RelayCommand<Type> itemInvokedCommand;
        private RelayCommand<ViewEnum> _navigateToCommand;

        public ShellViewModel(ILogger<ShellViewModel> logger,
                              INavigationService navigationService)
        {
            _logger = logger;
            _navigationService = navigationService;
            _logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public ICommand NavigateToCommand => _navigateToCommand ??= new RelayCommand<ViewEnum>(OnNavigateTo);

        public IAsyncRelayCommand LoadedCommand => _loadedCommand ??= new AsyncRelayCommand(OnLoaded);

        private void OnNavigateTo(ViewEnum key)
        {
            _navigationService.Navigate(key);
        }

        private async Task OnLoaded()
        {
            await Task.CompletedTask;
        }

        public ICommand ItemInvokedCommand => itemInvokedCommand ??= new RelayCommand<Type>((type) =>
        {
            if(type != null)
            {
                _navigationService.Navigate(type);
            }
        });

        public void Dispose()
        {
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
