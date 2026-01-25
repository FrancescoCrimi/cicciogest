// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.Fatturazione;
using CiccioGest.Infrastructure;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Mvvm.ViewModels
{
    public sealed partial class FattureViewModel : ResultViewModelBase<int>
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFatturaService _fatturaService;
        private bool _disposedValue;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ConfermaCommand))]
        private Fattura? _fatturaSelezionata;

        public ObservableCollection<Fattura> Fatture { get; } = [];

        public FattureViewModel(ILogger<FattureViewModel> logger,
                                IUnitOfWork unitOfWork,
                                IFatturaService fatturaService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _fatturaService = fatturaService;
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        [RelayCommand]
        private Task OnLoaded()
        {
            return OnAggiorna();
        }

        [RelayCommand]
        private Task OnUnloaded()
        {
            return Task.CompletedTask;
        }

        [RelayCommand]
        private async Task OnAggiorna()
        {
            await _unitOfWork.BeginAsync();
            Fatture.Clear();
            foreach (Fattura fattura in await _fatturaService.GetFatture())
                Fatture.Add(fattura);
        }

        [RelayCommand(CanExecute = nameof(CanConferma))]
        private void OnConferma()
        {
            if (FatturaSelezionata != null)
            {
                Close(FatturaSelezionata.Id);
            }
        }
        private bool CanConferma() => FatturaSelezionata != null;

        [RelayCommand]
        private void OnAnnulla()
        {
            Cancel();
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // Libera le risorse specifiche della classe figlia
                    _unitOfWork?.Dispose();
                    _fatturaService.Dispose();
                    _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
                }

                // Chiama sempre la base alla fine
                base.Dispose(disposing);
                _disposedValue = true;
            }
        }
    }
}
