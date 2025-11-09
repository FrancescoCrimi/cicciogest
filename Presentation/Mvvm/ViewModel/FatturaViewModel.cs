// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.Mvvm.Contracts;
using CiccioGest.Presentation.Mvvm.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Mvvm.ViewModel
{
    public sealed partial class FatturaViewModel : ObservableObject, IViewModel, IDisposable
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
            ClientiViewReturnHandler clientiViewReturnHandler = ClientiViewReturnMethod;
            _navigationService.Navigate(ViewEnum.Clienti, clientiViewReturnHandler, false);
        }
        private async Task ClientiViewReturnMethod(ClientiViewReturn clientiViewReturn)
        {
            if (clientiViewReturn.Result == WizardResult.Finished)
            {
                _navigationService.GoBack(true);
                await NuovaFattura(clientiViewReturn.IdCliente);
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
            FattureViewReturnHandler fattureViewReturnHandler = FattureViewReturnMethod;
            _navigationService.Navigate(ViewEnum.Fatture, fattureViewReturnHandler, false);
        }
        private async Task FattureViewReturnMethod(FattureViewReturn fattureViewReturn)
        {
            if (fattureViewReturn.Result == WizardResult.Finished)
            {
                _navigationService.GoBack();
                await ApriFattura(fattureViewReturn.IdFattura);
            }
        }


        [RelayCommand]
        private void OnNuovoDettaglio()
        {
            ArticoliViewReturnHandler articoliViewReturnHandler = ArticoliViewReturnMethod;
            _navigationService.Navigate(ViewEnum.Articoli, articoliViewReturnHandler, false);
        }
        private async Task ArticoliViewReturnMethod(ArticoliViewReturn articoliViewReturn)
        {
            if (articoliViewReturn.Result == WizardResult.Finished)
            {
                _navigationService.GoBack(true);
                var articolo = await _fatturaService.GetArticolo(articoliViewReturn.IdArticolo);
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
            _logger.LogDebug("ApriFattura {Id} HashCode: {HashCode}", fattura.Id, GetHashCode().ToString());
        }


        public void Dispose()
        {
            _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
        }
    }
}
