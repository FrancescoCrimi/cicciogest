﻿// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.WinUiBackend.ViewModel
{
    public sealed partial class ArticoloViewModel : ObservableRecipient, IDisposable
    {
        private AsyncRelayCommand loadedCommand;
        private readonly ILogger<ArticoloViewModel> logger;
        private readonly IMagazinoService magazinoService;
        private RelayCommand nuovoArticoloCommand;
        private RelayCommand salvaArticoloCommand;
        private RelayCommand eliminaArticoloCommand;
        private RelayCommand apriArticoloCommand;

        public ArticoloViewModel(ILogger<ArticoloViewModel> logger,
                                 IMagazinoService magazinoService)
        {
            this.logger = logger;
            this.magazinoService = magazinoService;
            RegistraMessaggi();
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }


        public Articolo Articolo { get; set; }

        public Categoria CategoriaSelezionata { get; set; }

        public IAsyncRelayCommand LoadedCommand => loadedCommand 
            ??= new AsyncRelayCommand(Loaded);

        private async Task Loaded()
        {
            await Task.CompletedTask;
        }


        public ICommand NuovoArticoloCommand => nuovoArticoloCommand 
            ??= new RelayCommand(NuovoArticolo);

        private void NuovoArticolo()
        {
        }


        public ICommand SalvaArticoloCommand => salvaArticoloCommand 
            ??= new RelayCommand(SalvaArticolo);

        private void SalvaArticolo()
        {
        }


        public ICommand EliminaArticoloCommand => eliminaArticoloCommand 
            ??= new RelayCommand(EliminaArticolo);

        private void EliminaArticolo()
        {
        }


        public ICommand ApriArticoloCommand => apriArticoloCommand 
            ??= new RelayCommand(ApriArticolo);

        private void ApriArticolo()
        {
        }

        private void RegistraMessaggi()
        {
            Messenger.Register<ArticoloIdMessage>(this, async (r, m) =>
            {
                if (m.Value != 0)
                    MostraArticolo(await magazinoService.GetArticolo(m.Value));
            });
        }

        private void MostraArticolo(Articolo articolo)
        {
            Articolo = articolo;
            OnPropertyChanged(nameof(Articolo));
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
