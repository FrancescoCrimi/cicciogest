// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.Anagrafica;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.Mvvm.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Mvvm.ViewModels
{
    public sealed partial class FornitoreViewModel : ViewModelBase, INavigationAwareAsync
    {
        private readonly ILogger<FornitoreViewModel> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly INavigationService _navigationService;
        private readonly IMessageBoxService _messageBoxService;
        private readonly IAnagraficaService _anagraficaService;
        private bool _disposedValue;

        [ObservableProperty]
        private Fornitore? _fornitore;

        [ObservableProperty]
        private Indirizzo? _indirizzo;

        public FornitoreViewModel(ILogger<FornitoreViewModel> logger,
                                  IUnitOfWork unitOfWork,
                                  INavigationService navigationService,
                                  IMessageBoxService messageBoxService,
                                  IAnagraficaService anagraficaService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _navigationService = navigationService;
            _messageBoxService = messageBoxService;
            _anagraficaService = anagraficaService;
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        public async Task OnNavigatedToAsync(object? parameter, CancellationToken cancellationToken = default)
        {
            if (parameter is FornitoriViewReturn fornitoriViewReturn)
            {
               await ApriFornitore(fornitoriViewReturn.IdFornitore);
            }
        }

        public Task OnNavigatedFromAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task<bool> OnNavigatingFromAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(true);
        }


        [RelayCommand]
        private void OnLoaded() { }


        [RelayCommand]
        private void OnUnloaded() { }


        [RelayCommand]
        private async Task OnNuovoFornitore()
        {
            await _unitOfWork.BeginAsync();
            var fornitore = new Fornitore();
            Fornitore = null;
            Indirizzo = null;
            Fornitore = fornitore;
            Indirizzo = fornitore.Indirizzo;
        }


        [RelayCommand]
        private async Task OnSalvaFornitore()
        {
            if (Fornitore != null)
            {
                try
                {
                    await _anagraficaService.SaveFornitore(Fornitore);
                    await _unitOfWork.CommitAsync();
                }
                catch (Exception ex)
                {
                    await _unitOfWork.RollbackAsync();
                    _messageBoxService.Show("Errore: " + ex.Message);
                    throw;
                }
            }
        }


        [RelayCommand]
        private async Task OnApriFornitore()
        {
            await _unitOfWork.BeginAsync();
            var id = await _navigationService.NavigateForResultAsync<FornitoriViewModel>();
            if (id.Type == DialogResultType.Ok)
            {
                _navigationService.GoBack(true);
                await ApriFornitore(id.Value);
            }
        }


        [RelayCommand]
        private async Task OnEliminaFornitore()
        {
            if (Fornitore != null)
            {
                try
                {
                    await _anagraficaService.DeleteFornitore(Fornitore.Id);
                    await _unitOfWork.CommitAsync();
                    await OnNuovoFornitore();
                }
                catch (Exception ex)
                {
                    await _unitOfWork.RollbackAsync();
                    _messageBoxService.Show("Errore: " + ex.Message);
                    throw;
                }
            }
        }


        private async Task ApriFornitore(int idFornitore)
        {
            if (idFornitore != 0)
            {
                await _unitOfWork.BeginAsync();
                Fornitore fornitore = await _anagraficaService.GetFornitore(idFornitore);
                Fornitore = null;
                Indirizzo = null;
                Fornitore = fornitore;
                Indirizzo = fornitore.Indirizzo;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // Libera le risorse specifiche della classe figlia
                    _anagraficaService?.Dispose();
                    _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
                }

                // Chiama sempre la base alla fine
                base.Dispose(disposing);
                _disposedValue = true;
            }
        }
    }
}
