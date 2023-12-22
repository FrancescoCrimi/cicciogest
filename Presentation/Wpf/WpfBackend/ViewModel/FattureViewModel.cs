// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.WpfBackend.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfBackend.ViewModel
{
    public partial class FattureViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly IFatturaService fatturaService;
        protected readonly INavigationService navigationService;
        private FatturaReadOnly fatturaSelezionata;
        private AsyncRelayCommand loadedCommand;
        private RelayCommand nuovaFatturaCommand;
        private RelayCommand apriFatturaCommand;
        private AsyncRelayCommand aggiornaFattureCommand;

        public FattureViewModel(ILogger<FattureViewModel> logger,
                                IFatturaService fatturaService,
                                INavigationService navigationService)
        {
            this.logger = logger;
            this.fatturaService = fatturaService;
            this.navigationService = navigationService;
            Fatture = new ObservableCollection<FatturaReadOnly>();
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public ObservableCollection<FatturaReadOnly> Fatture { get; }

        public FatturaReadOnly FatturaSelezionata
        {
            protected get => fatturaSelezionata;
            set
            {
                if (value != fatturaSelezionata)
                {
                    fatturaSelezionata = value;
                    apriFatturaCommand.NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand LoadedCommand => loadedCommand ??=
            new AsyncRelayCommand(AggiornaFatture);

        public ICommand NuovaFatturaCommand => nuovaFatturaCommand ??= new RelayCommand(() =>
        {
        });

        public ICommand AggiornaFattureCommand => aggiornaFattureCommand ??=
            new AsyncRelayCommand(AggiornaFatture);

        public ICommand ApriFatturaCommand => apriFatturaCommand ??=
            new RelayCommand(ApriFattura, () => FatturaSelezionata != null);


        private async Task AggiornaFatture()
        {
            Fatture.Clear();
            foreach (FatturaReadOnly fatt in await fatturaService.GetFatture())
            {
                Fatture.Add(fatt);
            }
        }

        protected virtual void ApriFattura()
        {
            if (FatturaSelezionata != null)
            {
                navigationService.NavigateTo(nameof(FatturaViewModel));
                Messenger.Send(new FatturaIdMessage(FatturaSelezionata.Id));
            }
        }



        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
