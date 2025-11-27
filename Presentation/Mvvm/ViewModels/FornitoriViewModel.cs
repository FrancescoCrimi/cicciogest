// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.Anagrafica;
using CiccioGest.Presentation.Mvvm.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Mvvm.ViewModels
{
    public sealed partial class FornitoriViewModel : ObservableObject, IViewModel, IDisposable
    {
        private readonly ILogger<FornitoriViewModel> _logger;
        private readonly IAnagraficaService _clientiFornitoriService;
        private readonly INavigationService _navigationService;
        private FornitoriViewReturnHandler? _fornitoriViewReturnHandler;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ConfermaCommand))]
        private Fornitore? _fornitoreSelezionato;

        public ObservableCollection<Fornitore> Fornitori { get; } = [];

        public FornitoriViewModel(ILogger<FornitoriViewModel> logger,
                                  INavigationService navigationService,
                                  IAnagraficaService clientiFornitoriService)
        {
            _logger = logger;
            _navigationService = navigationService;
            _clientiFornitoriService = clientiFornitoriService;
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        public void Initialize(object? parameter)
        {
            if (parameter is FornitoriViewReturnHandler fornitoriViewReturnHandler)
            {
                _fornitoriViewReturnHandler = fornitoriViewReturnHandler;
            }
        }


        [RelayCommand]
        private Task OnLoaded() => OnAggiorna();


        [RelayCommand]
        private void OnUnloaded() { }


        [RelayCommand]
        private async Task OnAggiorna()
        {
            Fornitori.Clear();
            foreach (var item in await _clientiFornitoriService.GetFornitori())
            {
                Fornitori.Add(item);
            }
            OnPropertyChanged(nameof(Fornitori));
        }


        [RelayCommand(CanExecute = nameof(CanConferma))]
        private Task OnConferma()
        {
            if (FornitoreSelezionato != null)
            {
                //_idFornitoreTaskCompletionSource.SetResult(FornitoreSelezionato.Id);
                if (_fornitoriViewReturnHandler != null)
                {
                    return _fornitoriViewReturnHandler!.Invoke(new FornitoriViewReturn(WizardResult.Finished, FornitoreSelezionato.Id));
                }
            }
            return Task.CompletedTask;
        }
        private bool CanConferma() => FornitoreSelezionato != null;


        [RelayCommand]
        private Task OnAnnulla()
        {
            if (_fornitoriViewReturnHandler != null)
                return _fornitoriViewReturnHandler!.Invoke(new FornitoriViewReturn(WizardResult.Canceled, 0));
            return Task.CompletedTask;
        }


        public void Dispose()
        {
            _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
        }
    }
}
