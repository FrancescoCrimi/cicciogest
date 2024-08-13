// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.Mvvm.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Mvvm.ViewModel
{
    public sealed partial class FatturaViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFatturaService _fatturaService;
        private readonly INavigationService _navigationService;
        private readonly IMessageBoxService _messageBoxService;

        [ObservableProperty]
        private Fattura? _fattura;

        [ObservableProperty]
        private Dettaglio? _dettaglio;

        [ObservableProperty]
        private Dettaglio? _dettaglioSelezionato;

        public FatturaViewModel(ILogger<FatturaViewModel> logger,
                                IUnitOfWork unitOfWork,
                                IFatturaService fatturaService,
                                INavigationService navigationService,
                                IMessageBoxService messageBoxService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _fatturaService = fatturaService;
            _navigationService = navigationService;
            _messageBoxService = messageBoxService;
            RegistraMessaggi();
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        [RelayCommand]
        private void OnLoaded() { }

        [RelayCommand]
        private void OnUnloaded() { }

        [RelayCommand]
        private async Task OnNuovaFattura()
        {
            await _unitOfWork.BeginAsync();
            _navigationService.Navigate(nameof(ClientiViewModel), false);
            int idCliente = await Messenger.Send<IdClienteRequestMessage>();
            _navigationService.GoBack(true);
            await NuovaFattura(idCliente);
        }

        [RelayCommand]
        private async Task OnSalvaFattura()
        {
            if (Fattura != null)
            {
                try
                {
                    await _fatturaService.SaveFattura(Fattura);
                    await _unitOfWork.CommitAsync();
                }
                catch (Exception e)
                {
                    await _unitOfWork.RollbackAsync();
                    _messageBoxService.Show("Errore: " + e.Message);
                    throw;
                }
            }
        }

        [RelayCommand]
        private async Task OnRimuoviFattura()
        {
            if (Fattura != null)
            {
                try
                {
                    await _fatturaService.DeleteFattura(Fattura.Id);
                    await _unitOfWork.CommitAsync();
                }
                catch (Exception e)
                {
                    await _unitOfWork.RollbackAsync();
                    _messageBoxService.Show("Errore: " + e.Message);
                    throw;
                }
            }
        }

        [RelayCommand]
        private async Task OnApriFattura()
        {
            await _unitOfWork.BeginAsync();
            _navigationService.Navigate(nameof(FattureViewModel), false);
            int idFattura = await Messenger.Send<IdFatturaRequestMessage>();
            _navigationService.GoBack(true);
            await ApriFattura(idFattura);
        }

        [RelayCommand]
        private async Task OnNuovoDettaglio()
        {
            _navigationService.Navigate(nameof(ArticoliViewModel), false);
            int idArticolo = await Messenger.Send<IdArticoloRequestMessage>();
            _navigationService.GoBack(true);
            var articolo = await _fatturaService.GetArticolo(idArticolo);
            Dettaglio = new Dettaglio(articolo, 1);

        }

        [RelayCommand]
        private void OnAggiungiDettaglio()
        {
            if (Dettaglio?.Quantita != 0)
            {
                Fattura?.AddDettaglio(Dettaglio!);
                OnPropertyChanged(nameof(Fattura));
                Dettaglio = null;
            }
        }

        [RelayCommand]
        private void OnRimuoviDettaglio()
        {
            if (DettaglioSelezionato != null)
            {
                Fattura?.RemoveDettaglio(DettaglioSelezionato);
                OnPropertyChanged(nameof(Fattura));
                Dettaglio = null;
            }
        }

        [RelayCommand]
        private void OnSelezionaDettaglio()
        {
            if (DettaglioSelezionato != null)
                Dettaglio = DettaglioSelezionato;
            OnPropertyChanged(nameof(Dettaglio));
        }

        private void RegistraMessaggi()
        {
            Messenger.Register<IdFatturaMessage>(this, async (r, m)
                => await ApriFattura(m.Value));

            Messenger.Register<IdClienteMessage>(this, async (r, m)
                => await NuovaFattura(m.Value));
        }

        private async Task NuovaFattura(int idCliente)
        {
            if (idCliente != 0)
            {
                await _unitOfWork.BeginAsync();
                var cliente = await _fatturaService.GetCliente(idCliente);
                var fattura = new Fattura(cliente);
                Fattura = null;
                Dettaglio = null;
                Fattura = fattura;
            }
        }

        private async Task ApriFattura(int idFattura)
        {
            await _unitOfWork.BeginAsync();
            var fattura = await _fatturaService.GetFattura(idFattura);
            Fattura = null;
            Dettaglio = null;
            Fattura = fattura;
            _logger.LogDebug("ApriFattura {Id} HashCode: {HashCode}", fattura.Id, GetHashCode().ToString());
        }


        public void Dispose()
        {
            Messenger.UnregisterAll(this);
            _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
        }
    }
}
