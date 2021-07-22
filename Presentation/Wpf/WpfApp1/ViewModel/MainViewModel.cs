using CiccioGest.Presentation.WpfApp1.Contracts;
using CiccioGest.Presentation.WpfApp1.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfApp1.ViewModel
{
    public sealed class MainViewModel : ObservableObject, IDisposable
    {
        private readonly ILogger logger;
        private readonly IWindowManagerService windowManagerService;
        private ICommand apriFattureCommand;
        private ICommand apriProdottiCommand;
        private ICommand apriCategorieCommand;
        private ICommand loadedCommand;

        public MainViewModel(ILogger<MainViewModel> logger, IWindowManagerService windowManagerService)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.windowManagerService = windowManagerService;
            logger.LogDebug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public ICommand ApriFattureCommand => apriFattureCommand ??= new RelayCommand(() =>
        {
            windowManagerService.OpenWindow(typeof(FatturaView));
        });

        public ICommand ApriArticoliCommand => apriProdottiCommand ??= new RelayCommand(() =>
            windowManagerService.OpenWindow(typeof(ArticoloView)));

        public ICommand ApriCategorieCommand => apriCategorieCommand ??= new RelayCommand(() =>
            windowManagerService.OpenWindow(typeof(CategoriaView)));

        public ICommand LoadedCommand => loadedCommand ??= new RelayCommand(() => { });

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
