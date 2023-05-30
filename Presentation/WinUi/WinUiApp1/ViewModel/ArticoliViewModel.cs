using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Presentation.WinUiApp1.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.WinUiApp1.ViewModel
{
    public class ArticoliViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly IMagazinoService magazinoService;
        protected readonly INavigationService navigationService;
        private ArticoloReadOnly articoloSelezionato;
        private AsyncRelayCommand loadedCommand;
        private AsyncRelayCommand aggiornaArticoliCommand;
        private RelayCommand apriArticoloCommand;
        private RelayCommand nuovoArticoloCommand;

        public ArticoliViewModel(ILogger<ArticoliViewModel> logger,
                                 IMagazinoService magazinoService,
                                 INavigationService navigationService)
        {
            this.logger = logger;
            this.magazinoService = magazinoService;
            this.navigationService = navigationService;
            Articoli = new ObservableCollection<ArticoloReadOnly>();
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public ObservableCollection<ArticoloReadOnly> Articoli { get; private set; }

        public ArticoloReadOnly ArticoloSelezionato
        {
            get => articoloSelezionato;
            set
            {
                if (articoloSelezionato != value)
                {
                    articoloSelezionato = value;
                    apriArticoloCommand.NotifyCanExecuteChanged();
                    nuovoArticoloCommand.NotifyCanExecuteChanged();
                }
            }
        }



        public IAsyncRelayCommand LoadedCommand => loadedCommand ??= new AsyncRelayCommand(AggiornaArticoli);

        public ICommand NuovoArticoloCommand => nuovoArticoloCommand ??= new RelayCommand(NuovoArticolo);

        public ICommand ApriArticoloCommand => apriArticoloCommand ??= new RelayCommand(ApriArticolo, () => ArticoloSelezionato != null);

        public IAsyncRelayCommand AggiornaArticoliCommand => aggiornaArticoliCommand ??= new AsyncRelayCommand(AggiornaArticoli);



        private void NuovoArticolo()
        {
        }

        protected virtual void ApriArticolo()
        {
            if (ArticoloSelezionato != null)
            {
                navigationService.Navigate("ArticoloViewModel");
                Messenger.Send(new ArticoloIdMessage(ArticoloSelezionato.Id));
            }
        }

        private async Task AggiornaArticoli()
        {
            Articoli.Clear();
            foreach (ArticoloReadOnly pr in await magazinoService.GetArticoli())
            {
                Articoli.Add(pr);
            }
        }



        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
