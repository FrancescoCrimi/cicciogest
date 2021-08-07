using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.UwpApp.Services;
using CiccioGest.Presentation.UwpApp.View;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace CiccioGest.Presentation.UwpApp.ViewModel
{
    public sealed class FatturaViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly NavigationService navigationService;
        private readonly IFatturaService fatturaService;
        private ICommand nuovaFatturaCommand;
        private ICommand salvaFatturaCommand;
        private ICommand rimuoviFatturaCommand;
        private ICommand aggiungiDettaglioCommand;
        private ICommand rimuoviDettaglioCommand;
        private ICommand selezionaDettaglioCommand;
        private ICommand apriFatturaCommand;
        private ICommand nuovoDettaglioCommand;
        private ICommand loadedCommand;

        public FatturaViewModel(ILogger<FatturaViewModel> logger,
                                NavigationService navigationService,
                                IFatturaService fatturaService)
        {
            this.logger = logger;
            this.navigationService = navigationService;
            this.fatturaService = fatturaService;
            RegistraMessaggi();
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public Fattura Fattura { get; private set; }
        public Dettaglio Dettaglio { get; private set; }
        public Dettaglio DettaglioSelezionato { private get; set; }

        public ICommand LoadedCommand => loadedCommand ?? (loadedCommand = new RelayCommand(async () =>
        {
            Fattura fatt = await fatturaService.GetFattura(4);
            Mostra(fatt);
        }));

        public ICommand NuovaFatturaCommand => nuovaFatturaCommand ?? (nuovaFatturaCommand = new RelayCommand(() =>
             logger.LogDebug("Nuova Fattura Button fire")));

        public ICommand SalvaFatturaCommand => salvaFatturaCommand ?? (salvaFatturaCommand = new RelayCommand(async () =>
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

        public ICommand ApriCommand => apriFatturaCommand ?? (apriFatturaCommand = new RelayCommand(() =>
            navigationService.Navigate<FatturePage>()));

        public ICommand NuovoDettaglioCommand => nuovoDettaglioCommand ?? (nuovoDettaglioCommand = new RelayCommand(() =>
            navigationService.Navigate<ArticoliPage>()));

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

            Messenger.Register<DettaglioIdMessage>(this, async (r, m) =>
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
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }

    public class FatturaIdMessage : ValueChangedMessage<int>
    {
        public FatturaIdMessage(int value) : base(value)
        {
        }
    }

    public class DettaglioIdMessage : ValueChangedMessage<int>
    {
        public DettaglioIdMessage(int value) : base(value)
        {
        }
    }
}
