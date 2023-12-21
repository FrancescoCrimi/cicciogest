// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Presentation.WinUiBackend.Contracts.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.WinUiBackend.ViewModel
{
    public sealed class CategoriaViewModel : ObservableObject, IDisposable
    {
        private AsyncRelayCommand loadedCommand;
        private readonly ILogger<ArticoliViewModel> logger;
        private readonly IMagazinoService magazinoService;
        private readonly INavigationService navigationService;

        public CategoriaViewModel(ILogger<ArticoliViewModel> logger,
                                  IMagazinoService magazinoService,
                                  INavigationService navigationService)
        {
            this.logger = logger;
            this.magazinoService = magazinoService;
            this.navigationService = navigationService;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public IAsyncRelayCommand LoadedCommand => loadedCommand
            ?? (loadedCommand = new AsyncRelayCommand(Loaded));

        private async Task Loaded()
        {
            await Task.CompletedTask;
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
