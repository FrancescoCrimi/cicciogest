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
    public partial class ArticoliViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly IMagazinoService magazinoService;
        protected readonly INavigationService navigationService;
        private ArticoloReadOnly? articoloSelezionato;
        //private AsyncRelayCommand loadedCommand;
        //private RelayCommand nuovoArticoloCommand;
        //private RelayCommand apriArticoloCommand;
        //private AsyncRelayCommand aggiornaArticoliCommand;

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

        public ArticoloReadOnly? ArticoloSelezionato
        {
            protected get => articoloSelezionato;
            set
            {
                if (articoloSelezionato != value)
                {
                    articoloSelezionato = value;
                    ApriArticoloCommand.NotifyCanExecuteChanged();
                }
            }
        }

        //public IAsyncRelayCommand LoadedCommand
        //{
        //    get
        //    {
        //        return loadedCommand ??=
        //    new AsyncRelayCommand(AggiornaArticoli);
        //    }
        //}
        [RelayCommand]
        public Task OnLoaded() => OnAggiornaArticoli();


        //public ICommand NuovoArticoloCommand => nuovoArticoloCommand ??= new RelayCommand(()
        //    => navigationService.NavigateTo(nameof(ArticoloViewModel)));
        [RelayCommand]
        public void OnNuovoArticolo()
             => navigationService.NavigateTo(nameof(ArticoloViewModel));



        //public ICommand ApriArticoloCommand => apriArticoloCommand ??=
        //    new RelayCommand(ApriArticolo, CanApriArticolo);
        [RelayCommand(CanExecute = nameof(CanApriArticolo))]
        private void OnApriArticolo()
            => ApriArticolo();
        protected virtual void ApriArticolo()
        {
            if (ArticoloSelezionato != null)
            {
                navigationService.NavigateTo(nameof(ArticoloViewModel));
                Messenger.Send(new ArticoloIdMessage(ArticoloSelezionato.Id));
            }
        }
        private bool CanApriArticolo()
            => ArticoloSelezionato != null;



        //public IAsyncRelayCommand AggiornaArticoliCommand => aggiornaArticoliCommand ??=
        //    new AsyncRelayCommand(AggiornaArticoli);
        [RelayCommand]
        private async Task OnAggiornaArticoli()
        {
            Articoli.Clear();
            foreach (ArticoloReadOnly pr in await magazinoService.GetArticoli())
            {
                Articoli.Add(pr);
            }
        }



        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
