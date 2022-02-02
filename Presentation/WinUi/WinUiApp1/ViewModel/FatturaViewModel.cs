using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.WinUiApp1.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.WinUiApp1.ViewModel
{
    public sealed class FatturaViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly INavigationService navigationService;
        private readonly IFatturaService fatturaService;
        private ICommand nuovaFatturaCommand;
        private ICommand salvaFatturaCommand;
        private ICommand rimuoviFatturaCommand;
        private ICommand aggiungiDettaglioCommand;
        private ICommand rimuoviDettaglioCommand;
        private ICommand selezionaDettaglioCommand;
        private ICommand apriFatturaCommand;
        private ICommand nuovoDettaglioCommand;
        private AsyncRelayCommand loadedCommand;

        public FatturaViewModel(ILogger<FatturaViewModel> logger,
                                IFatturaService fatturaService,
                                INavigationService navigationService)
        {
            this.logger = logger;
            this.navigationService = navigationService;
            this.fatturaService = fatturaService;
            RegistraMessaggi();
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public Fattura Fattura { get; private set; }
        public Dettaglio Dettaglio { get; private set; }
        public Dettaglio DettaglioSelezionato { get; set; }

        public IAsyncRelayCommand LoadedCommand => loadedCommand 
            ?? (loadedCommand = new AsyncRelayCommand(async () => await Task.CompletedTask));

        public ICommand NuovaFatturaCommand => nuovaFatturaCommand ?? (nuovaFatturaCommand = new RelayCommand(() =>
        {
            navigationService.Navigate("ClientiViewModel");
        }));

        public ICommand SalvaFatturaCommand => salvaFatturaCommand ?? (salvaFatturaCommand = new AsyncRelayCommand(async () =>
        {
            try
            {
                await fatturaService.SaveFattura(Fattura);
            }
            catch (Exception)
            {
            }
        }));

        public ICommand RimuoviFatturaCommand => rimuoviFatturaCommand ?? (rimuoviFatturaCommand = new RelayCommand(async () =>
        {
            try
            {
                await fatturaService.DeleteFattura(Fattura.Id);
            }
            catch (Exception)
            {
            }
        }));

        public ICommand ApriFatturaCommand => apriFatturaCommand ?? (apriFatturaCommand = new RelayCommand(() =>
            navigationService.Navigate("FattureViewModel")));

        public ICommand NuovoDettaglioCommand => nuovoDettaglioCommand ?? (nuovoDettaglioCommand = new RelayCommand(() =>
            navigationService.Navigate("ArticoliPage")));

        public ICommand AggiungiDettaglioCommand => aggiungiDettaglioCommand ?? (aggiungiDettaglioCommand = new RelayCommand(() =>
        {
            if (Dettaglio.Quantita != 0)
            {
                Fattura.AddDettaglio(Dettaglio);
                OnPropertyChanged(nameof(Fattura));
                NuovoDettaglio();
            }
        }));

        public ICommand RimuoviDettaglioCommand => rimuoviDettaglioCommand ?? (rimuoviDettaglioCommand = new RelayCommand(() =>
        {
            Fattura.RemoveDettaglio(Dettaglio);
            OnPropertyChanged(nameof(Fattura));
            NuovoDettaglio();
        }));

        public ICommand SelezionaDettaglioCommand => selezionaDettaglioCommand ?? (selezionaDettaglioCommand = new RelayCommand(() =>
        {
            if (DettaglioSelezionato != null)
                Dettaglio = DettaglioSelezionato;
            OnPropertyChanged(nameof(Dettaglio));
        }));


        private void RegistraMessaggi()
        {

            Messenger.Register<FatturaIdMessage>(this, async (r, m) =>
            {
                if (m.Value != 0)
                    Mostra(await fatturaService.GetFattura(m.Value));
            });

            Messenger.Register<ArticoloIdMessage>(this, async (r, m) =>
            {
                if (m.Value != 0)
                {
                    Dettaglio = new Dettaglio(await fatturaService.GetArticolo(m.Value), 1);
                    OnPropertyChanged(nameof(Dettaglio));
                }
            });
        }

        private void Mostra(Fattura fattura)
        {
            Fattura = fattura;
            OnPropertyChanged(nameof(Fattura));
            NuovoDettaglio();
        }

        private void NuovoDettaglio()
        {
            Dettaglio = new Dettaglio(null, 1);
            OnPropertyChanged(nameof(Dettaglio));
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
