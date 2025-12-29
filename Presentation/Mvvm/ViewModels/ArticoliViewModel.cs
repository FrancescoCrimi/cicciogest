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
    public sealed partial class ArticoliViewModel : DialogViewModelBase<int>
    {
        private readonly ILogger _logger;
        private readonly IMagazzinoService _magazzinoService;
        private bool _disposedValue;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ConfermaCommand))]
        private Articolo? _articoloSelezionato;

        public ObservableCollection<Articolo> Articoli { get; } = [];

        public ArticoliViewModel(ILogger<ArticoliViewModel> logger,
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
            Articoli.Clear();
            foreach (var articolo in await _magazzinoService.GetArticoli())
                Articoli.Add(articolo);
        }

        [RelayCommand(CanExecute = nameof(CanConferma))]
        private void OnConferma()
        {
            if (ArticoloSelezionato != null)
                CloseDialog(ArticoloSelezionato.Id);
        }
        private bool CanConferma() => ArticoloSelezionato != null;

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
