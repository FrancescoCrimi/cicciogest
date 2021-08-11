using CiccioGest.Presentation.WpfApp.Contracts;
using CiccioGest.Presentation.WpfApp.View;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfApp.ViewModel
{
    public sealed class MainViewModel : ViewModelBase, IDisposable
    {
        private readonly ILogger logger;
        private readonly IWindowManagerService windowManagerService;
        private ICommand loadedCommand;
        private ICommand apriFattureCommand;
        private ICommand apriProdottiCommand;
        private ICommand apriCategorieCommand;
        private RelayCommand apriClientiCommand;

        public MainViewModel(ILogger<MainViewModel> logger, IWindowManagerService windowManagerService)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.windowManagerService = windowManagerService;
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public ICommand LoadedCommand => loadedCommand ??= new RelayCommand(() => { });

        public ICommand ApriFattureCommand => apriFattureCommand ??= new RelayCommand(() =>
            windowManagerService.OpenWindow(typeof(FattureView)));

        public ICommand ApriArticoliCommand => apriProdottiCommand ??= new RelayCommand(() =>
            windowManagerService.OpenWindow(typeof(ArticoliView)));

        public ICommand ApriCategorieCommand => apriCategorieCommand ??= new RelayCommand(() =>
            windowManagerService.OpenWindow(typeof(CategoriaView)));

        public ICommand ApriClientiCommand => apriClientiCommand ??= new RelayCommand(() =>
            windowManagerService.OpenWindow(typeof(ClientiView)));

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
