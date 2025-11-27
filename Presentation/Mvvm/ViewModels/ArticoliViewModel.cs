// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.Magazzino;
using CiccioGest.Presentation.Mvvm.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Mvvm.ViewModels
{
    public sealed partial class ArticoliViewModel : ObservableObject, IViewModel, IDisposable
    {
        private readonly ILogger _logger;
        private readonly IMagazzinoService _magazinoService;
        private readonly INavigationService _navigationService;
        private ArticoliViewReturnHandler? _articoliViewReturnHandler;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ConfermaCommand))]
        private Articolo? _articoloSelezionato;

        public ObservableCollection<Articolo> Articoli { get; } = [];

        public ArticoliViewModel(ILogger<ArticoliViewModel> logger,
                                 IMagazzinoService magazinoService,
                                 INavigationService navigationService)
        {
            _logger = logger;
            _magazinoService = magazinoService;
            _navigationService = navigationService;

            //_idArticoloTaskCompletionSource = new TaskCompletionSource<int>();
            //Messenger.Register<ArticoliViewModel, IdArticoloRequestMessage>(this, (recipient, message)
            //    => message.Reply(_idArticoloTaskCompletionSource.Task));

            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        public void Initialize(object? parameter)
        {
            if (parameter is ArticoliViewReturnHandler articoliViewReturnHandler)
            {
                _articoliViewReturnHandler = articoliViewReturnHandler;
            }
        }


        [RelayCommand]
        private Task OnLoaded() => OnAggiorna();


        [RelayCommand]
        private void OnUnloaded() { }

        [RelayCommand]
        private async Task OnAggiorna()
        {
            Articoli.Clear();
            foreach (Articolo pr in await _magazinoService.GetArticoli())
            {
                Articoli.Add(pr);
            }
        }


        [RelayCommand(CanExecute = nameof(CanConferma))]
        private Task OnConferma()
        {
            if (ArticoloSelezionato != null)
            {
                //_idArticoloTaskCompletionSource.SetResult(ArticoloSelezionato.Id);
                if (_articoliViewReturnHandler != null)
                {
                    return _articoliViewReturnHandler(new ArticoliViewReturn(WizardResult.Finished, ArticoloSelezionato.Id));
                }
            }
            return Task.CompletedTask;
        }
        private bool CanConferma() => ArticoloSelezionato != null;


        [RelayCommand]
        private Task OnAnnulla()
        {
            if (_articoliViewReturnHandler != null)
                return _articoliViewReturnHandler(new ArticoliViewReturn(WizardResult.Canceled, 0));
            return Task.CompletedTask;
        }


        public void Dispose()
        {
            _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
        }
    }
}
