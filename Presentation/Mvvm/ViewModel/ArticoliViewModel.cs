﻿// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.Magazzino;
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
    public sealed partial class ArticoliViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger _logger;
        private readonly IMagazzinoService _magazinoService;
        private readonly INavigationService _navigationService;
        private readonly TaskCompletionSource<int> _idArticoloTaskCompletionSource;
        private Articolo? articoloSelezionato;

        public ArticoliViewModel(ILogger<ArticoliViewModel> logger,
                                 IMagazzinoService magazinoService,
                                 INavigationService navigationService)
        {
            _logger = logger;
            _magazinoService = magazinoService;
            _navigationService = navigationService;
            Articoli = new ObservableCollection<Articolo>();

            _idArticoloTaskCompletionSource = new TaskCompletionSource<int>();
            Messenger.Register<ArticoliViewModel, IdArticoloRequestMessage>(this, (recipient, message)
                => message.Reply(_idArticoloTaskCompletionSource.Task));

            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        public ObservableCollection<Articolo> Articoli { get; }

        public Articolo? ArticoloSelezionato
        {
            private get => articoloSelezionato;
            set
            {
                if (articoloSelezionato != value)
                {
                    articoloSelezionato = value;
                    ApriArticoloCommand.NotifyCanExecuteChanged();
                }
            }
        }


        [RelayCommand]
        private Task OnLoaded() => OnAggiornaArticoli();

        [RelayCommand]
        private void OnNuovoArticolo()
             => _navigationService.Navigate(nameof(ArticoloViewModel));

        [RelayCommand(CanExecute = nameof(CanApriArticolo))]
        private void OnApriArticolo()
        {
            if (ArticoloSelezionato != null)
            {
                _idArticoloTaskCompletionSource.SetResult(ArticoloSelezionato.Id);
            }
        }
        private bool CanApriArticolo() => ArticoloSelezionato != null;

        [RelayCommand]
        private async Task OnAggiornaArticoli()
        {
            Articoli.Clear();
            foreach (Articolo pr in await _magazinoService.GetArticoli())
            {
                Articoli.Add(pr);
            }
        }


        public void Dispose()
        {
            Messenger.UnregisterAll(this);
            _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
        }
    }
}
