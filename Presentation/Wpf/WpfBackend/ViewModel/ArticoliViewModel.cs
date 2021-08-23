using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Presentation.WpfBackend.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfBackend.ViewModel
{
    public class ArticoliViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly IMagazinoService magazinoService;
        private readonly INavigationService navigationService;
        private ArticoloReadOnly articoloSelezionato;
        private AsyncRelayCommand loadedCommand;
        private AsyncRelayCommand aggiornaArticoliCommand;
        private RelayCommand apriArticoloCommand;
        private RelayCommand cancellaArticoloCommand;

        public ArticoliViewModel(ILogger<ArticoliViewModel> logger,
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

        public ArticoloReadOnly ArticoloSelezionato
        {
            protected get => articoloSelezionato;
            set
            {
                if(articoloSelezionato != value)
                {
                    articoloSelezionato = value;
                    apriArticoloCommand.NotifyCanExecuteChanged();
                }
            }
        }

        public IAsyncRelayCommand LoadedCommand => loadedCommand
            ??= new AsyncRelayCommand(AggiornaArticoli);

        public IAsyncRelayCommand AggiornaArticoliCommand => aggiornaArticoliCommand
            ??= new AsyncRelayCommand(AggiornaArticoli);

        public ICommand ApriArticoloCommand => apriArticoloCommand
            ??= new RelayCommand(ApriArticolo, EnableApriArticolo);

        public ICommand CancellaArticoloCommand => cancellaArticoloCommand
            ??= new RelayCommand(CancellaArticolo, EnableCancellaArticolo);

        private async Task AggiornaArticoli()
        {
            Articoli.Clear();
            foreach (ArticoloReadOnly pr in await magazinoService.GetArticoli())
            {
                Articoli.Add(pr);
            }
        }

        protected virtual void ApriArticolo()
        {
            if (ArticoloSelezionato != null)
            {
                navigationService.NavigateTo(nameof(ArticoloViewModel));
                Messenger.Send(new ArticoloIdMessage(ArticoloSelezionato.Id));
            }
        }

        private bool EnableApriArticolo() => ArticoloSelezionato != null;

        private void CancellaArticolo()
        {
        }

        protected virtual bool EnableCancellaArticolo() => ArticoloSelezionato != null;

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
