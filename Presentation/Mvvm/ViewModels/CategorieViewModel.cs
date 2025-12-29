// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.Magazzino;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Mvvm.ViewModels
{
    public sealed partial class CategorieViewModel : DialogViewModelBase<int>
    {
        private readonly ILogger _logger;
        private readonly IMagazzinoService _magazzinoService;
        private bool _disposedValue;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ConfermaCommand))]
        private Categoria? _categoriaSelezionata;

        public ObservableCollection<Categoria> Categorie { get; } = [];

        public CategorieViewModel(ILogger<CategorieViewModel> logger,
                                  IMagazzinoService magazzinoService)
        {
            _logger = logger;
            _magazzinoService = magazzinoService;
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        [RelayCommand]
        private Task OnLoaded() => OnAggiorna();

        [RelayCommand]
        private async Task OnAggiorna()
        {
            Categorie.Clear();
            foreach (var categoria in await _magazzinoService.GetCategorie())
                Categorie.Add(categoria);
        }

        [RelayCommand(CanExecute = nameof(CanConferma))]
        private void OnConferma()
        {
            if (CategoriaSelezionata != null)
                CloseDialog(CategoriaSelezionata.Id);
        }
        private bool CanConferma() => CategoriaSelezionata != null;

        [RelayCommand]
        private void OnAnnulla() => CloseDialog(0);

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
