﻿// Copyright (c) 2016 - 2024 Francesco Crimi
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
    public sealed partial class ClientiViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger _logger;
        private readonly IClientiFornitoriService _clientiFornitoriService;
        private readonly INavigationService _navigationService;
        private readonly TaskCompletionSource<int> _idClienteTaskCompletionSource;
        private Cliente? _clienteSelezionato;

        public ClientiViewModel(ILogger<ClientiViewModel> logger,
                                IClientiFornitoriService clientiFornitoriService,
                                INavigationService navigationService)
        {
            _logger = logger;
            _clientiFornitoriService = clientiFornitoriService;
            _navigationService = navigationService;
            Clienti = new ObservableCollection<Cliente>();

            _idClienteTaskCompletionSource = new TaskCompletionSource<int>();
            Messenger.Register<ClientiViewModel, IdClienteRequestMessage>(this, (recipient, message)
                => message.Reply(_idClienteTaskCompletionSource.Task));

            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        public ObservableCollection<Cliente> Clienti { get; }

        public Cliente? ClienteSelezionato
        {
            private get => _clienteSelezionato;
            set
            {
                if (_clienteSelezionato != value)
                {
                    _clienteSelezionato = value;
                    ApriClienteCommand.NotifyCanExecuteChanged();
                }
            }
        }


        [RelayCommand]
        private Task OnLoaded() => OnAggiornaClienti();

        [RelayCommand]
        private async Task OnAggiornaClienti()
        {
            Clienti.Clear();
            foreach (var item in await _clientiFornitoriService.GetClienti())
            {
                Clienti.Add(item);
            }
        }

        [RelayCommand]
        private void OnNuovoClienti() { }

        [RelayCommand(CanExecute = nameof(CanApriCliente))]
        private void OnApriCliente()
        {
            if (ClienteSelezionato != null)
            {
                _idClienteTaskCompletionSource.SetResult(ClienteSelezionato.Id);
            }
        }
        private bool CanApriCliente() => ClienteSelezionato != null;


        public void Dispose()
        {
            Messenger.UnregisterAll(this);
            _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
        }
    }
}
