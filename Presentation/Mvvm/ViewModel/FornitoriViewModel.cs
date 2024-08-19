// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Presentation.Mvvm.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Mvvm.ViewModel
{
    public sealed partial class FornitoriViewModel : ObservableObject, IViewModel, IDisposable
    {
        private readonly ILogger<FornitoriViewModel> _logger;
        private readonly IClientiFornitoriService _clientiFornitoriService;
        private readonly INavigationService _navigationService;
        private Fornitore? _fornitoreSelezionato;
        private FornitoriViewReturnHandler? _fornitoriViewReturnHandler;

        public FornitoriViewModel(ILogger<FornitoriViewModel> logger,
                                  INavigationService navigationService,
                                  IClientiFornitoriService clientiFornitoriService)
        {
            _logger = logger;
            _navigationService = navigationService;
            _clientiFornitoriService = clientiFornitoriService;
            Fornitori = new ObservableCollection<Fornitore>();
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        public ObservableCollection<Fornitore> Fornitori { get; }

        public Fornitore? FornitoreSelezionato
        {
            private get => _fornitoreSelezionato;
            set
            {
                if (value != _fornitoreSelezionato)
                {
                    _fornitoreSelezionato = value;
                    ApriFornitoreCommand?.NotifyCanExecuteChanged();
                }
            }
        }

        public void Initialize(object? parameter)
        {
            if (parameter is FornitoriViewReturnHandler fornitoriViewReturnHandler)
            {
                _fornitoriViewReturnHandler = fornitoriViewReturnHandler;
            }
        }


        [RelayCommand]
        private Task OnLoaded() => OnAggiornaFornitori();


        [RelayCommand]
        private void OnUnloaded() { }


        [RelayCommand]
        private async Task OnAggiornaFornitori()
        {
            Fornitori.Clear();
            foreach (var item in await _clientiFornitoriService.GetFornitori())
            {
                Fornitori.Add(item);
            }
            OnPropertyChanged(nameof(Fornitori));
        }


        [RelayCommand]
        private void OnNuovoFornitore() { }


        [RelayCommand(CanExecute = nameof(CanApriFornitore))]
        private Task OnApriFornitore()
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
        private bool CanApriFornitore() => FornitoreSelezionato != null;


        public void Dispose()
        {
            _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
        }
    }
}
