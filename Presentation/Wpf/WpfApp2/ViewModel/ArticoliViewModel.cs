using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Presentation.WpfApp.Contracts;
using CiccioGest.Presentation.WpfApp.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfApp.ViewModel
{
    public class ArticoliViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly IMagazinoService magazinoService;
        private readonly INavigationService navigationService;
        private ArticoloReadOnly articoloSelezionato;
        private AsyncRelayCommand loadedCommand;
        private RelayCommand apriArticoloCommand;
        private RelayCommand cancellaArticoloCommand;
        private AsyncRelayCommand aggiornaArticoliCommand;

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

        public ICommand LoadedCommand => loadedCommand ??=
            new AsyncRelayCommand(AggiornaArticoli);

        public ICommand ApriArticoloCommand => apriArticoloCommand ??=
            new RelayCommand(ApriArticolo, EnableApriArticolo);

        public ICommand CancellaArticoloCommand => cancellaArticoloCommand ??=
            new RelayCommand(CancellaArticolo);

        public ICommand AggiornaArticoliCommand => aggiornaArticoliCommand ??=
            new AsyncRelayCommand(AggiornaArticoli);

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
                navigationService.NavigateTo(typeof(ArticoloView));
                Messenger.Send(new ArticoloIdMessage(ArticoloSelezionato.Id));
            }
        }

        private bool EnableApriArticolo() => ArticoloSelezionato != null;

        private void CancellaArticolo()
        {
        }

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
