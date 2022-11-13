using CiccioGest.Application;
using CiccioGest.Presentation.UwpBackend.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.UwpBackend.ViewModel
{
    public sealed class CategoriaViewModel : ObservableObject, IDisposable
    {
        public CategoriaViewModel(ILogger<ArticoliViewModel> logger,
                                  IMagazinoService magazinoService,
                                  INavigationService navigationService)
        {
            this.logger = logger;
            this.magazinoService = magazinoService;
            this.navigationService = navigationService;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        private AsyncRelayCommand loadedCommand;
        private readonly ILogger<ArticoliViewModel> logger;
        private readonly IMagazinoService magazinoService;
        private readonly INavigationService navigationService;

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
