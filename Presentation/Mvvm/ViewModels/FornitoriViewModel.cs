// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.Anagrafica;
using CiccioGest.Infrastructure;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Mvvm.ViewModels
{
    public sealed partial class FornitoriViewModel : DialogViewModelBase<int>
    {
        private readonly ILogger<FornitoriViewModel> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAnagraficaService _anagraficaService;
        private bool _disposedValue;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ConfermaCommand))]
        private Fornitore? _fornitoreSelezionato;

        public ObservableCollection<Fornitore> Fornitori { get; } = [];

        public FornitoriViewModel(ILogger<FornitoriViewModel> logger,
                                  IUnitOfWork unitOfWork,
                                  IAnagraficaService anagraficaService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _anagraficaService = anagraficaService;
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        [RelayCommand]
        private Task OnLoaded() => OnAggiorna();

        [RelayCommand]
        private async Task OnAggiorna()
        {
            await _unitOfWork.BeginAsync();
            Fornitori.Clear();
            foreach (var fornitore in await _anagraficaService.GetFornitori())
                Fornitori.Add(fornitore);
        }

        [RelayCommand(CanExecute = nameof(CanConferma))]
        private void OnConferma()
        {
            if (FornitoreSelezionato != null)
                CloseDialog(FornitoreSelezionato.Id);
        }
        private bool CanConferma() => FornitoreSelezionato != null;


        [RelayCommand]
        private void OnAnnulla() => CloseDialog(0);

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
