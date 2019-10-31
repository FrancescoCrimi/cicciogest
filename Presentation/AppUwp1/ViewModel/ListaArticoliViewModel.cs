using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;

namespace CiccioGest.Presentation.AppUwp1.ViewModel
{
    public sealed class ListaArticoliViewModel : ViewModelBase, IDisposable, ICazzo
    {
        private readonly ILogger logger;
        private readonly NavigationService ns;
        private ICommand loadedCommand;
        private ICommand selezionaArticoloCommand;

        public ListaArticoliViewModel(ILogger logger, IMagazinoService service, NavigationService ns)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.ns = ns ?? throw new ArgumentNullException(nameof(ns));
            if (service == null) throw new ArgumentNullException(nameof(service));

            Articoli = new ObservableCollection<ArticoloReadOnly>();
            foreach (ArticoloReadOnly pr in service.GetArticoli())
            {
                Articoli.Add(pr);
            }
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public ObservableCollection<ArticoloReadOnly> Articoli { get; private set; }
        public ArticoloReadOnly ArticoloSelezionato { private get; set; }
        public ICommand SelezionaArticoloCommand => selezionaArticoloCommand ?? (selezionaArticoloCommand = new RelayCommand(ApriArticolo));
        public ICommand LoadedCommand => loadedCommand ?? (loadedCommand = new RelayCommand(() => logger.Debug("Ciao Ciao")));

        private void ApriArticolo()
        {
            if (ArticoloSelezionato != null)
            {
                MessengerInstance.Send(new NotificationMessage<int>(ArticoloSelezionato.Id, "IdProdotto"));
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
