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
    public sealed class MainViewModel : ViewModelBase, IDisposable, ICazzo
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

        public ICommand ApriFattureCommand => apriFattureCommand ?? (apriFattureCommand = new RelayCommand(NuovaFattura));
        public ICommand ApriProdottiCommand => apriProdottiCommand ?? (apriProdottiCommand = new RelayCommand(ApriProdotti));
        public ICommand ApriCategorieCommand => apriCategorieCommand ?? (apriCategorieCommand = new RelayCommand(ApriCategorie));
        public ICommand LoadedCommand => loadedCommand ?? (loadedCommand = new RelayCommand(() => { }));

        private void NuovaFattura()
        {
            MessengerInstance.Send(new NotificationMessage("ApriFatture"));
        }

        private void ApriCategorie()
        {
            MessengerInstance.Send(new NotificationMessage("ApriCategorie"));
        }

        private void ApriProdotti()
        {
            MessengerInstance.Send(new NotificationMessage("ApriProdotti"));
        }

        public void Dispose()
        {
            Cleanup();
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
