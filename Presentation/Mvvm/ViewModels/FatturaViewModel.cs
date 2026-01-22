// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.Fatturazione;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.Mvvm.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Mvvm.ViewModels
{
    public sealed partial class FatturaViewModel : ViewModelBase, IViewModel
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFatturaService _fatturaService;
        private readonly INavigationService _navigationService;
        private readonly IMessageBoxService _messageBoxService;
        private bool _disposedValue;

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
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        public void Initialize(object? parameter)
        {
            if (parameter is FattureViewReturn fattureDataReturn)
            {
                //Task.Run(async () => await ApriFattura(fattureDataReturn.IdFattura));
                ApriFattura(fattureDataReturn.IdFattura).ConfigureAwait(false);
            }
        }


        [RelayCommand]
        private void OnLoaded() { }


        [RelayCommand]
        private void OnUnloaded() { }


        [RelayCommand]
        private async Task OnNuovaFattura()
        {
            await _unitOfWork.BeginAsync();
            var id = await _navigationService.NavigateForResultAsync<ClientiViewModel>();
            if (id != 0)
            {
                _navigationService.GoBack(true);
                await NuovaFattura(id);
            }
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
            var id = await _navigationService.NavigateForResultAsync<FattureViewModel>();
            _navigationService.GoBack();
            if (id != 0)
                await ApriFattura(id);
        }


        [RelayCommand]
        private async Task OnNuovoDettaglio()
        {
            var id = await _navigationService.NavigateForResultAsync<ArticoliViewModel>();
            _navigationService.GoBack();
            if (id != 0)
            {
                var articolo = await _fatturaService.GetArticolo(id);
                Dettaglio = new Dettaglio(articolo, 1);
            }
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
            //OnPropertyChanged("Fattura");
            _logger.LogDebug("ApriFattura {Id} HashCode: {HashCode}", fattura.Id, GetHashCode().ToString());
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // Libera le risorse specifiche della classe figlia
                    _fatturaService?.Dispose();
                    _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
                }

                // Chiama sempre la base alla fine
                base.Dispose(disposing);
                _disposedValue = true;
            }
        }
    }
}
