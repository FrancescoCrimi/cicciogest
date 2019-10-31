using Castle.Core.Logging;
using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Globalization;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.AppUwp1.ViewModel
{
    public class ShellViewModel : ViewModelBase, IDisposable, ICazzo
    {
        private readonly ILogger logger;
        private readonly NavigationService navigationService;
        private bool avviaFatturaView = false;
        private RelayCommand loadedCommand;

        public ShellViewModel(ILogger logger, NavigationService navigationService)
        {
            this.logger = logger;
            this.navigationService = navigationService;
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
        public ICommand LoadedCommand => loadedCommand ??
            (loadedCommand = new RelayCommand(() => navigationService.NavigateTo("MainPage")));

        public void Initialization(Frame frame)
        {
            navigationService.CurrentFrame = frame;
        }

        private void NuovaFattura()
        {
            MessengerInstance.Send(new NotificationMessage("ApriFatturaView"));
            //MessengerInstance.Send(new NotificationMessage<int>(0, "IdCliente"));
            navigationService.NavigateTo("FatturaPage");
        }

        private void ApriFatture()
        {
            //MessengerInstance.Send(new NotificationMessage("ApriFatturaView"));
            //MessengerInstance.Send(new NotificationMessage<int>(0, "IdFattura"));
            avviaFatturaView = true;
            //MessengerInstance.Send(new NotificationMessage("ApriSelezionaFatturaView"));
            navigationService.NavigateTo("ListaFatturePage");
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
