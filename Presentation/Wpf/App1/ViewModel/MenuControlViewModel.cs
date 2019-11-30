using Castle.Core.Logging;
using CiccioGest.Presentation.Wpf.App1.Service;
using CiccioGest.Presentation.Wpf.App1.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Globalization;
using System.Windows.Input;

namespace CiccioGest.Presentation.Wpf.App1.ViewModel
{
    public sealed class MenuControlViewModel : ViewModelBase, IDisposable
    {
        private readonly ILogger logger;
        private readonly INavigationService ns;
        private bool isRegistered;
        
        public MenuControlViewModel(ILogger logger, INavigationService ns)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.ns = ns ?? throw new ArgumentNullException(nameof(ns));
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public ICommand NuovaFatturaCommand => new RelayCommand(NuovaFattura);

        private void NuovaFattura()
        {
            ns.StartNavigate(new FatturaView());
        }

        public ICommand ApriFattureCommand => new RelayCommand(ApriFatture);

        private void ApriFatture()
        {
            ns.Navigate(new ListaFattureView());
            Messenger.Default.Register<NotificationMessage<int>>(this, nm =>
            {
                if (nm.Notification == "IdFattura")
                {
                    ns.StartNavigate(new FatturaView());
                    UnRegister();
                    MessengerInstance.Send(new NotificationMessage<int>(nm.Content, "IdFattura"));
                }
            });
            isRegistered = true;
        }

        public ICommand ApriProdottiCommand => new RelayCommand(ApriProdotti);

        private void ApriProdotti()
        {
            ns.StartNavigate(new ArticoloView());
        }

        public ICommand ApriCategorieCommand => new RelayCommand(ApriCategorie);

        private void ApriCategorie()
        {
            ns.StartNavigate(new CategoriaView());
        }


        private void UnRegister()
        {
            if (isRegistered)
            {
                Messenger.Default.Unregister(this);
                isRegistered = false;
            }
        }

        public void Dispose()
        {
            UnRegister();
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
