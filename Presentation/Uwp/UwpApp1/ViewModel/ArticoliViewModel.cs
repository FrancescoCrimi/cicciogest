using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.UwpApp.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.Messaging;


namespace CiccioGest.Presentation.UwpApp.ViewModel
{
    public sealed class ArticoliViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly IMagazinoService service;
        private readonly NavigationService ns;
        private ICommand loadedCommand;
        private ICommand selezionaArticoloCommand;

        public ArticoliViewModel(ILogger<ArticoliViewModel> logger,
                                      IMagazinoService service,
                                      NavigationService ns)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.ns = ns ?? throw new ArgumentNullException(nameof(ns));
            Articoli = new ObservableCollection<ArticoloReadOnly>();
            logger.LogDebug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public ObservableCollection<ArticoloReadOnly> Articoli { get; private set; }

        public ArticoloReadOnly ArticoloSelezionato { private get; set; }

        public ICommand SelezionaArticoloCommand => selezionaArticoloCommand ?? (selezionaArticoloCommand = new RelayCommand(() =>
        {
            if (ArticoloSelezionato != null)
            {
                //Messenger.Send(new NotificationMessage<int>(ArticoloSelezionato.Id, "IdProdotto"));
                Messenger.Send(new ArticoloIdMessage(ArticoloSelezionato.Id));
                ns.GoBack();
            }
        }));

        public ICommand LoadedCommand => loadedCommand ?? (loadedCommand = new RelayCommand(async () =>
        {
            Articoli.Clear();
            foreach (ArticoloReadOnly pr in await service.GetArticoli())
            {
                Articoli.Add(pr);
            }
            logger.LogDebug("Ciao Ciao");
        }));


        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
