using Castle.Core.Logging;
using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Globalization;
using System.Windows.Input;

namespace CiccioGest.Presentation.Wpf.App2.ViewModel
{
    public sealed class MainViewModel : ViewModelBase, IDisposable
    {
        private readonly ILogger logger;
        private readonly IWindowManagerService windowManagerService;
        private ICommand apriFattureCommand;
        private ICommand apriProdottiCommand;
        private ICommand apriCategorieCommand;
        private ICommand loadedCommand;

        public MainViewModel(ILogger logger, IWindowManagerService windowManagerService)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.windowManagerService = windowManagerService;
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public ICommand ApriFattureCommand => apriFattureCommand ??= new RelayCommand(() =>
        //MessengerInstance.Send(new NotificationMessage("ApriFatture"))
        windowManagerService.OpenInNewWindow(WindowKey.Fattura)
        );

        public ICommand ApriProdottiCommand => apriProdottiCommand ??= new RelayCommand(() =>
        //MessengerInstance.Send(new NotificationMessage("ApriProdotti"))
        windowManagerService.OpenInNewWindow(WindowKey.Articolo)
        );

        public ICommand ApriCategorieCommand => apriCategorieCommand ??= new RelayCommand(() =>
            //MessengerInstance.Send(new NotificationMessage("ApriCategorie"))
        windowManagerService.OpenInNewWindow(WindowKey.Categoria)
        );

        public ICommand LoadedCommand => loadedCommand ??= new RelayCommand(() => { });

        public void Dispose()
        {
            Cleanup();
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
