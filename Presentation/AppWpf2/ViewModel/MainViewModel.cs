using Castle.Core.Logging;
using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Globalization;
using System.Windows.Input;

namespace CiccioGest.Presentation.AppWpf2.ViewModel
{
    public sealed class MainViewModel : ViewModelBase, IDisposable, ICazzo
    {
        private readonly ILogger logger;
        private bool avviaFatturaView = false;

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

        public ICommand NuovaFatturaCommand => new RelayCommand(NuovaFattura);
        public ICommand ApriFattureCommand => new RelayCommand(ApriFatture);
        public ICommand ApriProdottiCommand => new RelayCommand(ApriProdotti);
        public ICommand ApriCategorieCommand => new RelayCommand(ApriCategorie);

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
