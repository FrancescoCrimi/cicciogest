using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System;
using Castle.Core.Logging;
using GalaSoft.MvvmLight.Messaging;
using CiccioGest.Infrastructure;

namespace CiccioGest.Presentation.AppWpf.ViewModel
{
    public sealed class MainViewModel : ViewModelBase, IDisposable, ICazzo
    {
        private readonly ILogger logger;
        private bool avviaFatturaView = false;
        public ICommand NuovaFatturaCommand { get; private set; }
        public ICommand ApriFattureCommand { get; private set; }
        public ICommand ApriProdottiCommand { get; private set; }
        public ICommand ApriCategorieCommand { get; private set; }
        //public ICommand NuovoProdottoCommand { get; private set; }

        public MainViewModel(ILogger logger)
        {
            this.logger = logger;
            NuovaFatturaCommand = new RelayCommand(nuovaFattura);
            ApriFattureCommand = new RelayCommand(apriFatture);
            ApriProdottiCommand = new RelayCommand(apriProdotti);
            ApriCategorieCommand = new RelayCommand(apriCategorie);
            //NuovoProdottoCommand = new RelayCommand(nuovoProdotto);

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

            logger.Debug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        private void nuovaFattura()
        {
            MessengerInstance.Send(new NotificationMessage("ApriFatturaView"));
            //MessengerInstance.Send(new NotificationMessage<int>(0, "IdCliente"));
        }

        private void apriFatture()
        {
            //MessengerInstance.Send(new NotificationMessage("ApriFatturaView"));
            //MessengerInstance.Send(new NotificationMessage<int>(0, "IdFattura"));
            avviaFatturaView = true;
            MessengerInstance.Send(new NotificationMessage("ApriSelezionaFatturaView"));
        }

        private void apriCategorie()
        {
            MessengerInstance.Send(new NotificationMessage("ApriCategorie"));
        }

        //private void nuovoProdotto()
        //{
        //}

        private void apriProdotti()
        {
            MessengerInstance.Send(new NotificationMessage("ApriProdotti"));
        }

        public void Dispose()
        {
            Cleanup();
            logger.Debug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}