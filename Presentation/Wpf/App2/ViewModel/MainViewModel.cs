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
        private bool avviaFatturaView = false;
        private ICommand nuovaFatturaCommand;
        private ICommand apriFattureCommand;
        private ICommand apriProdottiCommand;
        private ICommand apriCategorieCommand;
        private ICommand loadedCommand;

        public MainViewModel(ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            MessengerInstance.Register<NotificationMessage<int>>(this, ns =>
            {
                if (avviaFatturaView)
                {
                    if (ns.Notification == "ApriFatturaSelezionata")
                    {
                        avviaFatturaView = false;
                        MessengerInstance.Send(new NotificationMessage("ApriFatturaView"));
                        MessengerInstance.Send(new NotificationMessage<int>(ns.Content, "ApriFatturaSelezionata"));
                    }
                }
            });

            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public ICommand NuovaFatturaCommand => nuovaFatturaCommand ?? (nuovaFatturaCommand = new RelayCommand(NuovaFattura));
        public ICommand ApriFattureCommand => apriFattureCommand ?? (apriFattureCommand = new RelayCommand(ApriFatture));
        public ICommand ApriProdottiCommand => apriProdottiCommand ?? (apriProdottiCommand = new RelayCommand(ApriProdotti));
        public ICommand ApriCategorieCommand => apriCategorieCommand ?? (apriCategorieCommand = new RelayCommand(ApriCategorie));
        public ICommand LoadedCommand => loadedCommand ?? (loadedCommand = new RelayCommand(() => { }));


        private void NuovaFattura()
        {
            MessengerInstance.Send(new NotificationMessage("ApriFatturaView"));
            //MessengerInstance.Send(new NotificationMessage<int>(0, "IdCliente"));
        }

        private void ApriFatture()
        {
            //MessengerInstance.Send(new NotificationMessage("ApriFatturaView"));
            //MessengerInstance.Send(new NotificationMessage<int>(0, "IdFattura"));
            avviaFatturaView = true;
            MessengerInstance.Send(new NotificationMessage("ApriSelezionaFatturaView"));
        }

        private void ApriCategorie()
        {
            MessengerInstance.Send(new NotificationMessage("ApriCategorie"));
        }

        //private void nuovoProdotto()
        //{
        //}

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
