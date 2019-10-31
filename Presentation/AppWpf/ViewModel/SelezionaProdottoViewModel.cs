using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;

namespace CiccioGest.Presentation.AppWpf.ViewModel
{
    public sealed class SelezionaProdottoViewModel : ViewModelBase, IDisposable, ICazzo
    {
        public ObservableCollection<ArticoloReadOnly> Prodotti { get; private set; }
        public ArticoloReadOnly ProdottoSelezionato { private get; set; }
        public ICommand SelezionaProdottoCommand => new RelayCommand(ApriProdotto);
        private readonly ILogger logger;
        private readonly INavigationService ns;

        public SelezionaProdottoViewModel(ILogger logger, IMagazinoService service, INavigationService ns)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.ns = ns ?? throw new ArgumentNullException(nameof(ns));
            if (service == null) throw new ArgumentNullException(nameof(service));

            Prodotti = new ObservableCollection<ArticoloReadOnly>();
            foreach (ArticoloReadOnly pr in service.GetArticoli())
            {
                Prodotti.Add(pr);
            }
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        private void ApriProdotto()
        {
            if (ProdottoSelezionato != null)
            {
                MessengerInstance.Send(new NotificationMessage<int>(ProdottoSelezionato.Id, "IdProdotto"));
                ns.GoBack();
            }
        }

        public void Dispose()
        {
            Cleanup();
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
