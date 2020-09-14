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
        private ICommand apriFattureCommand;
        private ICommand apriProdottiCommand;
        private ICommand apriCategorieCommand;
        private ICommand loadedCommand;

        public MainViewModel(ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public ICommand ApriFattureCommand => apriFattureCommand ??= new RelayCommand(() =>
            MessengerInstance.Send(new NotificationMessage("ApriFatture")));

        public ICommand ApriProdottiCommand => apriProdottiCommand ??= new RelayCommand(() =>        
            MessengerInstance.Send(new NotificationMessage("ApriProdotti")));
        
        public ICommand ApriCategorieCommand => apriCategorieCommand ??= new RelayCommand(() =>
            MessengerInstance.Send(new NotificationMessage("ApriCategorie")));

        public ICommand LoadedCommand => loadedCommand ??= new RelayCommand(() => { });

        public void Dispose()
        {
            Cleanup();
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
