// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
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
    public class ArticoliViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly IMagazinoService magazinoService;
        protected readonly INavigationService navigationService;
        private ArticoloReadOnly articoloSelezionato;
        private AsyncRelayCommand loadedCommand;
        private RelayCommand nuovoArticoloCommand;
        private RelayCommand apriArticoloCommand;
        private AsyncRelayCommand aggiornaArticoliCommand;

        public ArticoliViewModel(ILogger<ArticoliViewModel> logger,
                                 IMagazinoService magazinoService,
                                 INavigationService navigationService)
        {
            this.logger = logger;
            this.magazinoService = magazinoService;
            this.navigationService = navigationService;
            Articoli = new ObservableCollection<ArticoloReadOnly>();
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public ObservableCollection<ArticoloReadOnly> Articoli { get; }

        public ArticoloReadOnly ArticoloSelezionato
        {
            protected get => articoloSelezionato;
            set
            {
                if (articoloSelezionato != value)
                {
                    articoloSelezionato = value;
                    apriArticoloCommand.NotifyCanExecuteChanged();
                }
            }
        }

        public IAsyncRelayCommand LoadedCommand => loadedCommand ??=
            new AsyncRelayCommand(AggiornaArticoli);

        public ICommand NuovoArticoloCommand => nuovoArticoloCommand ??= new RelayCommand(()
            => navigationService.NavigateTo(nameof(ArticoloViewModel)));

        public ICommand ApriArticoloCommand => apriArticoloCommand ??=
            new RelayCommand(ApriArticolo, () => ArticoloSelezionato != null);

        public IAsyncRelayCommand AggiornaArticoliCommand => aggiornaArticoliCommand ??=
            new AsyncRelayCommand(AggiornaArticoli);



        private async Task AggiornaArticoli()
        {
            Articoli.Clear();
            foreach (ArticoloReadOnly pr in await magazinoService.GetArticoli())
            {
                Articoli.Add(pr);
            }
        }

        protected virtual void ApriArticolo()
        {
            if (ArticoloSelezionato != null)
            {
                navigationService.NavigateTo(nameof(ArticoloViewModel));
                Messenger.Send(new ArticoloIdMessage(ArticoloSelezionato.Id));
            }
        }



        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
