// Copyright (c) 2016 - 2024 Francesco Crimi
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
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Mvvm.ViewModel
{
    public sealed partial class ArticoloViewModel : ObservableObject, IViewModel, IDisposable
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMagazzinoService _magazinoService;
        private readonly INavigationService _navigationService;
        private readonly IMessageBoxService _messageBoxService;

        [ObservableProperty]
        private Articolo? _articolo;

        [ObservableProperty]
        private Categoria? _categoriaSelezionata;

        public ArticoloViewModel(ILogger<ArticoloViewModel> logger,
                                 IUnitOfWork unitOfWork,
                                 IMagazzinoService magazinoService,
                                 INavigationService navigationService,
                                 IMessageBoxService messageBoxService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _magazinoService = magazinoService;
            _navigationService = navigationService;
            _messageBoxService = messageBoxService;
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        public void Initialize(object? parameter)
        {
            if (parameter is ArticoliViewReturn articoliViewReturn)
            {
                Task.Run(async () => await ApriArticolo(articoliViewReturn.IdArticolo));
            }
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
                    await _magazinoService.DeleteArticolo(Articolo.Id);
                    _unitOfWork.Commit();
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
                    await _magazinoService.SaveArticolo(Articolo);
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

            ArticoliViewReturnHandler articoliViewReturnHandler = ArticoliViewReturnMethod;
            _navigationService.Navigate(nameof(ArticoliViewModel), articoliViewReturnHandler, false);

            //_navigationService.Navigate(nameof(ArticoliViewModel), null, false);
            //int idArticolo = await Messenger.Send<IdArticoloRequestMessage>();
            ////TODO: dopo GoBack cancellare la crconologia forward per disposare la vista precedente
            //_navigationService.GoBack(true);
            //await ApriArticolo(idArticolo);
        }
        private async Task ArticoliViewReturnMethod(ArticoliViewReturn articoliViewReturn)
        {
            if (articoliViewReturn.Result == WizardResult.Finished)
            {
                _navigationService.GoBack();
                await ApriArticolo(articoliViewReturn.IdArticolo);
            }
        }


        [RelayCommand]
        private void OnAggiungiCategoria()
        {
            CategoriaViewReturnHandler categoriaViewReturnHandler = CategoriaViewReturnMethod;
            _navigationService.Navigate(nameof(CategoriaViewModel), categoriaViewReturnHandler, false);
        }
        private async Task CategoriaViewReturnMethod(CategoriaViewReturn categoriaViewReturn)
        {
            if (categoriaViewReturn.Result == WizardResult.Finished)
            {
                _navigationService.GoBack();
                Categoria categoria = await _magazinoService.GetCategoria(categoriaViewReturn.IdCategoria);
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
                Articolo = await _magazinoService.GetArticolo(idArticolo);
            }
            else
            {
                await OnNuovoArticolo();
            }
        }


        public void Dispose()
        {
            _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
        }
    }
}
