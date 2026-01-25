// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.Magazzino;
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
    public sealed partial class ArticoloViewModel : ViewModelBase, INavigationAwareAsync
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMagazzinoService _magazzinoService;
        private readonly INavigationService _navigationService;
        private readonly IMessageBoxService _messageBoxService;
        private bool _disposedValue;

        [ObservableProperty]
        private Articolo? _articolo;

        [ObservableProperty]
        private Categoria? _categoriaSelezionata;

        public ArticoloViewModel(ILogger<ArticoloViewModel> logger,
                                 IUnitOfWork unitOfWork,
                                 IMagazzinoService magazzinoService,
                                 INavigationService navigationService,
                                 IMessageBoxService messageBoxService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _magazzinoService = magazzinoService;
            _navigationService = navigationService;
            _messageBoxService = messageBoxService;
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        public async Task OnNavigatedToAsync(object? parameter, CancellationToken cancellationToken = default)
        {
            if (parameter is ArticoliViewReturn articoliViewReturn)
            {
                await ApriArticolo(articoliViewReturn.IdArticolo);
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
        private async Task OnNuovoArticolo()
        {
            await _unitOfWork.BeginAsync();
            Articolo = null;
            Articolo = new Articolo();
            //OnPropertyChanged(nameof(Articolo));
        }


        [RelayCommand]
        private async Task OnEliminaArticolo()
        {
            if (Articolo != null)
            {
                try
                {
                    await _magazzinoService.DeleteArticolo(Articolo.Id);
                    await _unitOfWork.CommitAsync();
                    await OnNuovoArticolo();
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
        private async Task SalvaArticolo()
        {
            if (Articolo != null)
            {
                try
                {
                    await _magazzinoService.SaveArticolo(Articolo);
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
        private async Task OnApriArticolo()
        {
            await _unitOfWork.BeginAsync();
            var id = await _navigationService.NavigateForResultAsync<ArticoliViewModel>();
            if (id.Type == DialogResultType.Ok)
            {
                _navigationService.GoBack();
                await ApriArticolo(id.Value);
            }
        }


        [RelayCommand]
        private async Task OnAggiungiCategoria()
        {
            var id = await _navigationService.NavigateForResultAsync<CategorieViewModel>();
            _navigationService.GoBack();
            if (id.Type == DialogResultType.Ok)
            {
                Categoria categoria = await _magazzinoService.GetCategoria(id.Value);
                Articolo?.AddCategoria(categoria);
                //OnPropertyChanged(nameof(Categorie));
            }
        }


        [RelayCommand]
        private void OnRimuoviCategoria()
        {
            if (CategoriaSelezionata != null)
            {
                Articolo?.RemoveCategoria(CategoriaSelezionata);
                //OnPropertyChanged(nameof(Categorie));
            }
        }


        private async Task ApriArticolo(int idArticolo)
        {
            if (idArticolo != 0)
            {
                await _unitOfWork.BeginAsync();
                Articolo = null;
                Articolo = await _magazzinoService.GetArticolo(idArticolo);
            }
            else
            {
                await OnNuovoArticolo();
            }
        }


        protected override void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // Libera le risorse specifiche della classe figlia
                    _magazzinoService?.Dispose();
                    _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
                }

                // Chiama sempre la base alla fine
                base.Dispose(disposing);
                _disposedValue = true;
            }
        }
    }
}
