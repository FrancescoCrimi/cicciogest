﻿// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.Magazzino;
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
    public partial class ArticoliViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMagazzinoService magazinoService;
        protected readonly INavigationService navigationService;
        private Articolo articoloSelezionato;
        private AsyncRelayCommand loadedCommand;
        private AsyncRelayCommand aggiornaArticoliCommand;
        private RelayCommand apriArticoloCommand;
        private RelayCommand nuovoArticoloCommand;

        public ArticoliViewModel(ILogger<ArticoliViewModel> logger,
                                 IUnitOfWork unitOfWork,
                                 IMagazzinoService magazinoService,
                                 INavigationService navigationService)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
            this.magazinoService = magazinoService;
            this.navigationService = navigationService;
            Articoli = new ObservableCollection<Articolo>();
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public ObservableCollection<Articolo> Articoli { get; private set; }

        public Articolo ArticoloSelezionato
        {
            get => articoloSelezionato;
            set
            {
                if (articoloSelezionato != value)
                {
                    articoloSelezionato = value;
                    apriArticoloCommand.NotifyCanExecuteChanged();
                    nuovoArticoloCommand.NotifyCanExecuteChanged();
                }
            }
        }



        public IAsyncRelayCommand LoadedCommand => loadedCommand
            ??= new AsyncRelayCommand(AggiornaArticoli);

        public ICommand NuovoArticoloCommand => nuovoArticoloCommand
            ??= new RelayCommand(NuovoArticolo);

        public ICommand ApriArticoloCommand => apriArticoloCommand
            ??= new RelayCommand(ApriArticolo, () => ArticoloSelezionato != null);

        public IAsyncRelayCommand AggiornaArticoliCommand => aggiornaArticoliCommand 
            ??= new AsyncRelayCommand(AggiornaArticoli);



        private void NuovoArticolo()
        {
        }

        protected virtual void ApriArticolo()
        {
            if (ArticoloSelezionato != null)
            {
                navigationService.Navigate(ViewEnum.Articolo);
                Messenger.Send(new ArticoloIdMessage(ArticoloSelezionato.Id));
            }
        }

        private async Task AggiornaArticoli()
        {
            Articoli.Clear();
            await unitOfWork.BeginAsync();
            foreach (Articolo pr in await magazinoService.GetArticoli())
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
