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

namespace CiccioGest.Presentation.Uwp.App1.ViewModel
{
    public sealed class ListaArticoliViewModel : ViewModelBase, IDisposable, ICazzo
    {
        private readonly ILogger logger;
        private readonly IMagazinoService service;
        private readonly NavigationService ns;
        private ICommand loadedCommand;
        private ICommand selezionaArticoloCommand;

        public ListaArticoliViewModel(ILogger logger, IMagazinoService service, NavigationService ns)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.ns = ns ?? throw new ArgumentNullException(nameof(ns));
            Articoli = new ObservableCollection<ArticoloReadOnly>();
            if (IsInDesignModeStatic)
            {
                foreach (ArticoloReadOnly pr in service.GetArticoli().Result)
                {
                    Articoli.Add(pr);
                }
            }
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public ObservableCollection<ArticoloReadOnly> Articoli { get; private set; }

        public ArticoloReadOnly ArticoloSelezionato { private get; set; }

        public ICommand SelezionaArticoloCommand => selezionaArticoloCommand ??= new RelayCommand(() =>
        {
            if (ArticoloSelezionato != null)
            {
                MessengerInstance.Send(new NotificationMessage<int>(ArticoloSelezionato.Id, "IdProdotto"));
                ns.GoBack();
            }
        });

        public ICommand LoadedCommand => loadedCommand ??= new RelayCommand(async () =>
        {
            Articoli.Clear();
            foreach (ArticoloReadOnly pr in await service.GetArticoli())
            {
                Articoli.Add(pr);
            }
            logger.Debug("Ciao Ciao");
        });


        public void Dispose()
        {
            Cleanup();
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
