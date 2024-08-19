// Copyright (c) 2016 - 2024 Francesco Crimi
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
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Mvvm.ViewModel
{
    public sealed partial class FattureViewModel : ObservableObject, IViewModel, IDisposable
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFatturaService _fatturaService;
        private readonly INavigationService _navigationService;
        //private readonly TaskCompletionSource<int> _idFatturaTaskCompletionSource;
        private Fattura? _fatturaSelezionata;
        private FattureViewReturnHandler? _fattureViewReturnHandler;

        public FattureViewModel(ILogger<FattureViewModel> logger,
                                IUnitOfWork unitOfWork,
                                IFatturaService fatturaService,
                                INavigationService navigationService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _fatturaService = fatturaService;
            _navigationService = navigationService;
            Fatture = new ObservableCollection<Fattura>();

            //_idFatturaTaskCompletionSource = new TaskCompletionSource<int>();
            //Messenger.Register<FattureViewModel, IdFatturaRequestMessage>(this, (recipient, message)
            //    => message.Reply(_idFatturaTaskCompletionSource.Task));

            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        public ObservableCollection<Fattura> Fatture { get; }

        public Fattura? FatturaSelezionata
        {
            private get => _fatturaSelezionata;
            set
            {
                if (value != _fatturaSelezionata)
                {
                    _fatturaSelezionata = value;
                    ApriFatturaCommand?.NotifyCanExecuteChanged();
                }
            }
        }

        public void Initialize(object? parameter)
        {
            if (parameter is FattureViewReturnHandler fattureViewReturnHandler)
            {
                _fattureViewReturnHandler = fattureViewReturnHandler;
            }
        }


        [RelayCommand]
        private Task OnLoaded() => OnAggiornaFatture();


        [RelayCommand]
        private async Task OnAggiornaFatture()
        {
            await _unitOfWork.BeginAsync();
            Fatture.Clear();
            foreach (Fattura fatt in await _fatturaService.GetFatture())
            {
                Fatture.Add(fatt);
            }
        }


        [RelayCommand]
        private void OnNuovaFattura() { }


        [RelayCommand(CanExecute = nameof(CanApriFattura))]
        private Task OnApriFattura()
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
        private bool CanApriFattura() => FatturaSelezionata != null;


        public void Dispose()
        {
            _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
        }
    }
}
