// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.WinUiBackend.Contracts;
using CiccioGest.Presentation.WinUiBackend.Contracts.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.WinUiBackend.ViewModel
{
    public partial class FattureViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFatturaService _fatturaService;
        protected readonly INavigationService _navigationService;
        private Fattura _fatturaSelezionata;
        private AsyncRelayCommand loadedCommand;
        private AsyncRelayCommand aggiornaFattureCommand;
        private RelayCommand apriFatturaCommand;
        private RelayCommand nuovaFatturaCommand;

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
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public ObservableCollection<Fattura> Fatture { get; private set; }

        public Fattura FatturaSelezionata
        {
            get => _fatturaSelezionata;
            set
            {
                if (value != _fatturaSelezionata)
                {
                    _fatturaSelezionata = value;
                    apriFatturaCommand.NotifyCanExecuteChanged();
                }
            }
        }



        public IAsyncRelayCommand LoadedCommand => loadedCommand ??= new AsyncRelayCommand(AggiornaFatture);

        public ICommand NuovaFatturaCommand => nuovaFatturaCommand ??= new RelayCommand(NuovaFattura);

        public IAsyncRelayCommand AggiornaFattureCommand => aggiornaFattureCommand ??= new AsyncRelayCommand(AggiornaFatture);

        public ICommand ApriFatturaCommand => apriFatturaCommand ??= new RelayCommand(ApriFattura, () => FatturaSelezionata != null);



        private void NuovaFattura()
        {
        }

        protected virtual void ApriFattura()
        {
            if (FatturaSelezionata != null)
            {
                _navigationService.Navigate(ViewEnum.Fattura);
                Messenger.Send(new FatturaIdMessage(FatturaSelezionata.Id));
            }
        }

        private async Task AggiornaFatture()
        {
            Fatture.Clear();
            await _unitOfWork.BeginAsync();
            foreach (Fattura fatt in await _fatturaService.GetFatture())
            {
                Fatture.Add(fatt);
            }
        }



        public void Dispose()
        {
            _logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
