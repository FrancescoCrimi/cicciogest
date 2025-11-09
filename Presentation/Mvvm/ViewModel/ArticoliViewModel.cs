// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.Magazzino;
using CiccioGest.Presentation.Mvvm.Contracts;
using CiccioGest.Presentation.Mvvm.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Mvvm.ViewModel
{
    public sealed partial class ArticoliViewModel : ObservableObject, IViewModel, IDisposable
    {
        private readonly ILogger _logger;
        private readonly IMagazzinoService _magazinoService;
        private readonly INavigationService _navigationService;
        private Articolo? articoloSelezionato;
        private ArticoliViewReturnHandler? _articoliViewReturnHandler;

        public ArticoliViewModel(ILogger<ArticoliViewModel> logger,
                                 IMagazzinoService magazinoService,
                                 INavigationService navigationService)
        {
            _logger = logger;
            _magazinoService = magazinoService;
            _navigationService = navigationService;
            Articoli = new ObservableCollection<Articolo>();

            //_idArticoloTaskCompletionSource = new TaskCompletionSource<int>();
            //Messenger.Register<ArticoliViewModel, IdArticoloRequestMessage>(this, (recipient, message)
            //    => message.Reply(_idArticoloTaskCompletionSource.Task));

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

        public void Initialize(object? parameter)
        {
            if (parameter is ArticoliViewReturnHandler articoliViewReturnHandler)
            {
                _articoliViewReturnHandler = articoliViewReturnHandler;
            }
        }


        [RelayCommand]
        private Task OnLoaded() => OnAggiornaArticoli();


        [RelayCommand]
        private void OnUnloaded() { }


        [RelayCommand]
        private void OnNuovoArticolo()
             => _navigationService.Navigate(ViewEnum.Articolo);


        [RelayCommand(CanExecute = nameof(CanApriArticolo))]
        private Task OnApriArticolo()
        {
            if (ArticoloSelezionato != null)
            {
                //_idArticoloTaskCompletionSource.SetResult(ArticoloSelezionato.Id);
                if (_articoliViewReturnHandler != null)
                {
                    return _articoliViewReturnHandler.Invoke(new ArticoliViewReturn(WizardResult.Finished, ArticoloSelezionato.Id));
                }
            }
            return Task.CompletedTask;
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
            _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
        }
    }
}
