// Copyright (c) 2016 - 2025 Francesco Crimi
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
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Mvvm.ViewModels
{
    public sealed partial class CategoriaViewModel : ViewModelBase, IViewModel
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMagazzinoService _magazzinoService;
        private readonly IMessageBoxService _messageBoxService;
        private bool _disposedValue;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SalvaCategoriaCommand))]
        private Categoria? _categoriaCorrente;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(EliminaCategoriaCommand))]
        private Categoria? _categoriaSelezionata;

        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        private string? _statusMessage;

        public ObservableCollection<Categoria> Categorie { get; } = [];


        public CategoriaViewModel(ILogger<CategoriaViewModel> logger,
                                  IUnitOfWork unitOfWork,
                                  IMagazzinoService magazinoService,
                                  IMessageBoxService messageBoxService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _magazzinoService = magazinoService;
            _messageBoxService = messageBoxService;
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        public void Initialize(object? parameter)
        {
            //if (parameter is CategoriaViewReturnHandler categoriaViewReturnHandler)
            //{
            //    _categoriaViewReturnHandler = categoriaViewReturnHandler;
            //}
        }

        [RelayCommand]
        private async Task OnLoaded()
        {
            CategoriaCorrente = new Categoria();
            await AggiornaCategorie();
        }


        [RelayCommand]
        private Task OnUnloaded() => Task.CompletedTask;


        [RelayCommand]
        private void OnNuovaCategoria()
        {
            CategoriaCorrente = new Categoria();
            CategoriaSelezionata = null;
            StatusMessage = "Nuova categoria pronta per l'inserimento.";
        }


        [RelayCommand(CanExecute =nameof(CanSalvaCategoria))]
        private async Task OnSalvaCategoria()
        {
            if (CategoriaCorrente != null)
            {
                try
                {
                    var nomeCategoriaSalvata = CategoriaCorrente.Nome;
                    await _unitOfWork.BeginAsync();
                    await _magazzinoService.SaveCategoria(CategoriaCorrente);
                    await _unitOfWork.CommitAsync();

                    CategoriaCorrente = new Categoria();
                    await AggiornaCategorie();

                    StatusMessage = $"Categoria '{nomeCategoriaSalvata}' aggiunta.";
                }
                catch (Exception e)
                {
                    await _unitOfWork.RollbackAsync();
                    _messageBoxService.Show("Errore: " + e.Message);
                }
            }
        }
        private bool CanSalvaCategoria() => CategoriaCorrente != null;


        [RelayCommand(CanExecute = nameof(CanEliminaCategoria))]
        private async Task OnEliminaCategoria()
        {
            if (CategoriaSelezionata != null)
            {
                try
                {
                    var nomeCategoriaEliminata = CategoriaSelezionata.Nome;
                    await _unitOfWork.BeginAsync();
                    await _magazzinoService.DeleteCategoria(CategoriaSelezionata.Id);
                    await _unitOfWork.CommitAsync();

                    CategoriaCorrente = new Categoria();
                    await AggiornaCategorie();
                    StatusMessage = $"Categoria '{nomeCategoriaEliminata}' eliminata.";
                }
                catch (Exception e)
                {
                    await _unitOfWork.RollbackAsync();
                    _messageBoxService.Show("Errore: " + e.Message);
                }
            }
        }
        private bool CanEliminaCategoria() => CategoriaSelezionata != null;


        [RelayCommand]
        private async Task OnSelezionaCategoria()
        {
            if (CategoriaSelezionata != null && CategoriaCorrente != CategoriaSelezionata)
            {
                //if (_categoriaViewReturnHandler != null)
                //{
                //    return _categoriaViewReturnHandler.Invoke(new CategoriaViewReturn(WizardResult.Finished, CategoriaSelezionata.Id));
                //}
                await _unitOfWork.BeginAsync();
                CategoriaCorrente = await _magazzinoService.GetCategoria(CategoriaSelezionata.Id);
                await _unitOfWork.CommitAsync();
                StatusMessage = $"Modifica categoria '{CategoriaCorrente.Nome}'.";
            }
        }

        private async Task AggiornaCategorie()
        {
            Categorie.Clear();
            CategoriaSelezionata = null;
            await _unitOfWork.BeginAsync();
            foreach (Categoria categoria in await _magazzinoService.GetCategorie())
            {
                Categorie.Add(categoria);
            }
            await _unitOfWork.CommitAsync();
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
