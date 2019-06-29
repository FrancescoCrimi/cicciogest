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
        public ICommand ApriFattureCommand { get; private set; }
        public ICommand NuovaFatturaCommand { get; private set; }
        public ICommand ApriProdottiCommand { get; private set; }
        //public ICommand NuovoProdottoCommand { get; private set; }
        public ICommand ApriCategorieCommand { get; private set; }
        private readonly ILogger logger;



        public MainViewModel(ILogger logger)
        {
            this.logger = logger;
            ApriFattureCommand = new RelayCommand(apriFatture);
            NuovaFatturaCommand = new RelayCommand(nuovaFattura);
            ApriProdottiCommand = new RelayCommand(apriProdotti);
            //NuovoProdottoCommand = new RelayCommand(nuovoProdotto);
            ApriCategorieCommand = new RelayCommand(apriCategorie);
            logger.Debug("HashCode: " + GetHashCode().ToString() + " Created");
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

        private void nuovaFattura()
        {
            MessengerInstance.Send(new NotificationMessage("ApriFattura"));
            //MessengerInstance.Send(new NotificationMessage<int>(0, "IdCliente"));
        }

        private void apriFatture()
        {
            MessengerInstance.Send(new NotificationMessage("ApriFattura"));
            MessengerInstance.Send(new NotificationMessage<int>(0, "IdFattura"));
        }

        public void Dispose()
        {
            Cleanup();
            logger.Debug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}