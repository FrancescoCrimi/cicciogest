// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.WinUiBackend.Contracts;
using CiccioGest.Presentation.WinUiBackend.Contracts.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.WinUiBackend.ViewModel
{
    public sealed partial class FatturaViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly INavigationService _navigationService;
        private readonly IFatturaService _fatturaService;
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
                                IUnitOfWork unitOfWork,
                                IFatturaService fatturaService,
                                INavigationService navigationService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _navigationService = navigationService;
            _fatturaService = fatturaService;
            RegistraMessaggi();
            _logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public Fattura Fattura { get; private set; }
        public Dettaglio Dettaglio { get; private set; }
        public Dettaglio DettaglioSelezionato { get; set; }

        public IAsyncRelayCommand LoadedCommand => loadedCommand ??= new AsyncRelayCommand(async () => await Task.CompletedTask);

        public ICommand NuovaFatturaCommand => nuovaFatturaCommand ??= new RelayCommand(() =>
        {
            _navigationService.Navigate(ViewEnum.Clienti);
        });

        public ICommand SalvaFatturaCommand => salvaFatturaCommand ??= new AsyncRelayCommand(async () =>
        {
            try
            {
                await _fatturaService.SaveFattura(Fattura);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
            finally
            {
                await _unitOfWork.BeginAsync();
            }
        });

        public ICommand RimuoviFatturaCommand => rimuoviFatturaCommand ??= new RelayCommand(async () =>
        {
            try
            {
                await _fatturaService.DeleteFattura(Fattura.Id);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
            finally
            {
                await _unitOfWork.BeginAsync();
            }
        });

        public ICommand ApriFatturaCommand => apriFatturaCommand ??= new RelayCommand(() =>
            _navigationService.Navigate(ViewEnum.Fatture));

        public ICommand NuovoDettaglioCommand => nuovoDettaglioCommand ??= new RelayCommand(() =>
            _navigationService.Navigate(ViewEnum.Articoli));

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
                if (m.Value != 0)
                {
                    await _unitOfWork.BeginAsync();
                    Mostra(await _fatturaService.GetFattura(m.Value));
                }
            });

            Messenger.Register<ArticoloIdMessage>(this, async (r, m) =>
            {
                if (m.Value != 0)
                {
                    Dettaglio = new Dettaglio(await _fatturaService.GetArticolo(m.Value), 1);
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
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
