using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.WpfBackend.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfBackend.ViewModel
{
    public sealed class FatturaViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly IFatturaService fatturaService;
        private readonly INavigationService navigationService;
        private readonly IMessageBoxService messageBoxService;
        private RelayCommand loadedCommand;
        private RelayCommand nuovaFatturaCommand;
        private AsyncRelayCommand salvaFatturaCommand;
        private AsyncRelayCommand rimuoviFatturaCommand;
        private RelayCommand apriFatturaCommand;
        private RelayCommand nuovoDettaglioCommand;
        private RelayCommand aggiungiDettaglioCommand;
        private RelayCommand rimuoviDettaglioCommand;
        private RelayCommand selezionaDettaglioCommand;

        public FatturaViewModel(ILogger<FatturaViewModel> logger,
                                IFatturaService fatturaService,
                                INavigationService navigationService,
                                IMessageBoxService messageBoxService)
        {
            this.logger = logger;
            this.fatturaService = fatturaService;
            this.navigationService = navigationService;
            this.messageBoxService = messageBoxService;
            RegistraMessaggi();
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public Fattura Fattura { get; private set; }
        public Dettaglio Dettaglio { get; private set; }
        public Dettaglio DettaglioSelezionato { private get; set; }


        public ICommand LoadedCommand => loadedCommand ??= new RelayCommand(() => { });


        public ICommand NuovaFatturaCommand => nuovaFatturaCommand ??= new RelayCommand(()
            => navigationService.NavigateTo(nameof(ListaClientiViewModel)));

        public IAsyncRelayCommand SalvaFatturaCommand => salvaFatturaCommand ??= new AsyncRelayCommand(async () =>
        {
            try
            {
                await fatturaService.SaveFattura(Fattura);
            }
            catch (Exception e)
            {
                messageBoxService.Show("Errore: " + e.Message);
            }
        });

        public IAsyncRelayCommand RimuoviFatturaCommand => rimuoviFatturaCommand ??= new AsyncRelayCommand(async () =>
        {
            try
            {
                await fatturaService.DeleteFattura(Fattura.Id);
            }
            catch (Exception e)
            {
                messageBoxService.Show("Errore: " + e.Message);
            }
        });

        public ICommand ApriFatturaCommand => apriFatturaCommand ??= new RelayCommand(()
            => navigationService.NavigateTo(nameof(ListaFattureViewModel)));


        public ICommand NuovoDettaglioCommand => nuovoDettaglioCommand ??= new RelayCommand(()
            => navigationService.NavigateTo(nameof(ListaArticoliViewModel)));

        public ICommand AggiungiDettaglioCommand => aggiungiDettaglioCommand ??= new RelayCommand(() =>
        {
            if (Dettaglio.Quantita != 0)
            {
                Fattura.AddDettaglio(Dettaglio);
                OnPropertyChanged(nameof(Fattura));
                NuovoDettaglio();
            }
        });

        public ICommand RimuoviDettaglioCommand => rimuoviDettaglioCommand ??= new RelayCommand(() =>
        {
            Fattura.RemoveDettaglio(Dettaglio);
            OnPropertyChanged(nameof(Fattura));
            NuovoDettaglio();
        });

        public ICommand SelezionaDettaglioCommand => selezionaDettaglioCommand ??= new RelayCommand(() =>
        {
            if (DettaglioSelezionato != null)
                Dettaglio = DettaglioSelezionato;
            OnPropertyChanged(nameof(Dettaglio));
        });



        private void RegistraMessaggi()
        {
            Messenger.Register<FatturaIdMessage>(this, async (r, m) =>
            {
                MostraFattura(await fatturaService.GetFattura(m.Value));
            });

            Messenger.Register<ArticoloIdMessage>(this, async (r, m) =>
            {
                Dettaglio = new Dettaglio(await fatturaService.GetArticolo(m.Value), 1);
                OnPropertyChanged(nameof(Dettaglio));
            });

            Messenger.Register<ClienteIdMessage>(this, async (r, m) =>
            {
                if (m.Value != 0)
                    MostraFattura(new Fattura(await fatturaService.GetCliente(m.Value)));
            });
        }

        private void MostraFattura(Fattura fattura)
        {
            logger.LogDebug("MostraFattura " + fattura.Id + " HashCode: " + GetHashCode().ToString());
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
