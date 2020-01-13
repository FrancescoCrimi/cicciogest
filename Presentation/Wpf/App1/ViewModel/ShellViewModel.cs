using Castle.Core.Logging;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.Wpf.App1.Contracts;
using CiccioGest.Presentation.Wpf.App1.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Globalization;
using System.Windows.Input;

namespace CiccioGest.Presentation.Wpf.App1.ViewModel
{
    public sealed class ShellViewModel : ViewModelBase, IDisposable, ICazzo
    {
        private readonly ILogger logger;
        private readonly INavigationService ns;
        private bool isRegistered;

        public ShellViewModel(ILogger logger, INavigationService ns)
        {
            this.logger = logger;
            this.ns = ns;
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public ICommand NuovaFatturaCommand => new RelayCommand(NuovaFattura);

        private void NuovaFattura()
        {
            ns.NavigateTo("Fattura", true);
        }

        public ICommand ApriFattureCommand => new RelayCommand(ApriFatture);

        private void ApriFatture()
        {
            ns.NavigateTo("ListaFatture");
            Messenger.Default.Register<NotificationMessage<int>>(this, nm =>
            {
                if (nm.Notification == "IdFattura")
                {
                    ns.NavigateTo("Fattura", true);
                    UnRegister();
                    MessengerInstance.Send(new NotificationMessage<int>(nm.Content, "IdFattura"));
                }
            });
            isRegistered = true;
        }

        public ICommand ApriProdottiCommand => new RelayCommand(ApriProdotti);

        private void ApriProdotti()
        {
            ns.NavigateTo("Articolo", true);
        }

        public ICommand ApriCategorieCommand => new RelayCommand(ApriCategorie);

        private void ApriCategorie()
        {
            ns.NavigateTo("Categoria", true);
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
            Cleanup();
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
