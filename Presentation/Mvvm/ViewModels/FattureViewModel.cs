// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
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
    public sealed partial class FattureViewModel : ObservableObject, IViewModel, IDisposable
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFatturaService _fatturaService;
        private readonly INavigationService _navigationService;
        private FattureViewReturnHandler? _fattureViewReturnHandler;


        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ConfermaCommand))]
        private Fattura? _fatturaSelezionata;

        public ObservableCollection<Fattura> Fatture { get; } = [];

        public FattureViewModel(ILogger<FattureViewModel> logger,
                                IUnitOfWork unitOfWork,
                                IFatturaService fatturaService,
                                INavigationService navigationService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _fatturaService = fatturaService;
            _navigationService = navigationService;
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }



        public void Initialize(object? parameter)
        {
            if (parameter is FattureViewReturnHandler fattureViewReturnHandler)
            {
                _fattureViewReturnHandler = fattureViewReturnHandler;
            }
        }


        [RelayCommand]
        private Task OnLoaded() => OnAggiorna();


        [RelayCommand]
        private void OnUnloaded() { }


        [RelayCommand]
        private async Task OnAggiorna()
        {
            await _unitOfWork.BeginAsync();
            Fatture.Clear();
            foreach (Fattura fatt in await _fatturaService.GetFatture())
            {
                Fatture.Add(fatt);
            }
        }


        [RelayCommand(CanExecute = nameof(CanConferma))]
        private Task OnConferma()
        {
            if (FatturaSelezionata != null)
            {
                //_idFatturaTaskCompletionSource.SetResult(FatturaSelezionata.Id);
                if (_fattureViewReturnHandler != null)
                {
                    return _fattureViewReturnHandler!.Invoke(new FattureViewReturn(WizardResult.Finished, FatturaSelezionata.Id));
                }
            }
            return Task.CompletedTask;
        }
        private bool CanConferma() => FatturaSelezionata != null;


        [RelayCommand]
        private Task OnAnnulla()
        {
            if (_fattureViewReturnHandler != null)
                return _fattureViewReturnHandler!.Invoke(new FattureViewReturn(WizardResult.Canceled, 0));
            return Task.CompletedTask;
        }


        public void Dispose()
        {
            _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
        }
    }
}
