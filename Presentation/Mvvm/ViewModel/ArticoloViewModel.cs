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
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Mvvm.ViewModel
{
    public sealed partial class ArticoloViewModel : ObservableRecipient, IDisposable
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
            RegistraMessaggi();
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
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
            _navigationService.Navigate(nameof(ArticoliViewModel), false);
            int idArticolo = await Messenger.Send<IdArticoloRequestMessage>();
            //TODO: dopo GoBack cancellare la crconologia forward per disposare la vista precedente
            _navigationService.GoBack(true);
            await ApriArticolo(idArticolo);
        }


        [RelayCommand]
        private void OnAggiungiCategoria()
            => _navigationService.Navigate(nameof(CategoriaViewModel), false);

        [RelayCommand]
        private void OnRimuoviCategoria()
        {
            if (CategoriaSelezionata != null)
            {
                Articolo?.RemoveCategoria(CategoriaSelezionata);
                //OnPropertyChanged(nameof(Categorie));
            }
        }


        private void RegistraMessaggi()
        {
            Messenger.Register<IdArticoloMessage>(this, async (r, m)
                => await ApriArticolo(m.Value));

            Messenger.Register<IdCategoriaMessage>(this, async (r, m) =>
            {
                if (m.Value != 0)
                {
                    Categoria categoria = await _magazinoService.GetCategoria(m.Value);
                    Articolo?.AddCategoria(categoria);
                    //OnPropertyChanged(nameof(Categorie));
                }
            });
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
            Messenger.UnregisterAll(this);
            _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
        }
    }
}
