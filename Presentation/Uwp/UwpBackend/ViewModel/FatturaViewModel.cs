// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.UwpBackend.Contracts;
using CiccioGest.Presentation.UwpBackend.Contracts.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.UwpBackend.ViewModel
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
            navigationService.Navigate(ViewEnum.Clienti);
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
            navigationService.Navigate(ViewEnum.Fatture)));

        public ICommand NuovoDettaglioCommand => nuovoDettaglioCommand ?? (nuovoDettaglioCommand = new RelayCommand(() =>
            navigationService.Navigate(ViewEnum.Articoli)));

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
