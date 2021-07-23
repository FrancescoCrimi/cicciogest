using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Presentation.WpfApp2.Contracts;
using CiccioGest.Presentation.WpfApp2.Helpers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfApp2.ViewModel
{
    public sealed class ListaArticoliViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly IMagazinoService magazinoService;
        private readonly INavigationService navigationService;
        private ICommand loadedCommand;
        private ICommand selezionaArticoloCommand;

        public ListaArticoliViewModel(ILogger<ListaArticoliViewModel> logger,
                                      IMagazinoService magazinoService,
                                      INavigationService navigationService)
        {
            this.logger = logger;
            this.magazinoService = magazinoService;
            this.navigationService = navigationService;
            Articoli = new ObservableCollection<ArticoloReadOnly>();
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public ObservableCollection<ArticoloReadOnly> Articoli { get; private set; }

        public ArticoloReadOnly ArticoloSelezionato { private get; set; }

        public ICommand SelezionaArticoloCommand => selezionaArticoloCommand ??= new RelayCommand(() =>
        {
            if (ArticoloSelezionato != null)
            {
                Messenger.Send(new NotificationMessage<int>(ArticoloSelezionato.Id, "IdProdotto"));
                navigationService.GoBack();
            }
        });

        public ICommand LoadedCommand => loadedCommand ??= new RelayCommand(async () =>
        {
            foreach (ArticoloReadOnly pr in await magazinoService.GetArticoli())
            {
                Articoli.Add(pr);
            }
        });

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
