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
using System.Collections.ObjectModel;
using System.Threading.Tasks;


namespace CiccioGest.Presentation.Mvvm.ViewModel
{
    public sealed partial class CategoriaViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMagazzinoService _magazinoService;
        private readonly INavigationService _navigationService;
        private readonly IMessageBoxService _messageBoxService;

        [ObservableProperty]
        private Categoria? _categoria;

        [ObservableProperty]
        private Categoria? _categoriaSelezionata;

        public ObservableCollection<Categoria> Categorie { get; private set; }


        public CategoriaViewModel(ILogger<CategoriaViewModel> logger,
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
            Categorie = new ObservableCollection<Categoria>();
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        [RelayCommand]
        private Task OnLoaded() => Aggiorna();

        [RelayCommand]
        public Task OnNuovo() => Nuova();

        [RelayCommand]
        public async Task OnSalva()
        {
            if (Categoria != null)
            {
                try
                {
                    await _magazinoService.SaveCategoria(Categoria);
                    await _unitOfWork.CommitAsync();
                    await _unitOfWork.BeginAsync();
                    await Aggiorna();
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
        private async Task OnRimuovi()
        {
            if (Categoria != null)
            {
                try
                {
                    await _magazinoService.DeleteCategoria(Categoria.Id);
                    await _unitOfWork.CommitAsync();
                    await _unitOfWork.BeginAsync();
                    await Aggiorna();
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
        private void OnSelezionaCategoria()
        {
            if (CategoriaSelezionata != null && Categoria != CategoriaSelezionata)
            {
                if (_navigationService.CanGoBack)
                {
                    Messenger.Send(new IdCategoriaMessage(CategoriaSelezionata.Id));
                    _navigationService.GoBack();
                }
            }
        }

        [RelayCommand]
        private void OnModificaCategoria()
        {
            if (CategoriaSelezionata != null && Categoria != CategoriaSelezionata)
            {
                Categoria = CategoriaSelezionata;
                OnPropertyChanged(nameof(Categoria));
            }
        }

        [RelayCommand]
        private Task OnAnnullaModificheCategoria() => Nuova();


        private async Task Nuova()
        {
            await _unitOfWork.BeginAsync();
            Categoria = null;
            Categoria = new Categoria();
        }

        private async Task Aggiorna()
        {
            await Nuova();
            Categorie.Clear();
            foreach (Categoria ca in await _magazinoService.GetCategorie())
            {
                Categorie.Add(ca);
            }
        }


        public void Dispose()
        {
            _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
        }
    }
}
