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
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Mvvm.ViewModel
{
    public sealed partial class FornitoriViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger<FornitoriViewModel> _logger;
        private readonly IClientiFornitoriService _clientiFornitoriService;
        private readonly INavigationService _navigationService;
        private readonly TaskCompletionSource<int> _idFornitoreTaskCompletionSource;
        private Fornitore? _fornitoreSelezionato;

        public FornitoriViewModel(ILogger<FornitoriViewModel> logger,
                                  INavigationService navigationService,
                                  IClientiFornitoriService clientiFornitoriService)
        {
            _logger = logger;
            _navigationService = navigationService;
            _clientiFornitoriService = clientiFornitoriService;
            Fornitori = new ObservableCollection<Fornitore>();

            _idFornitoreTaskCompletionSource = new TaskCompletionSource<int>();
            Messenger.Register<FornitoriViewModel, IdFornitoreRequestMessage>(this, (recipient, message)
                => message.Reply(_idFornitoreTaskCompletionSource.Task));

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


        [RelayCommand]
        private Task OnLoaded() => OnAggiornaFornitori();

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
        private void OnApriFornitore()
        {
            if (FornitoreSelezionato != null)
            {
                _idFornitoreTaskCompletionSource.SetResult(FornitoreSelezionato.Id);
            }
        }
        private bool CanApriFornitore() => FornitoreSelezionato != null;


        public void Dispose()
        {
            Messenger.UnregisterAll(this);
            _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
        }
    }
}
