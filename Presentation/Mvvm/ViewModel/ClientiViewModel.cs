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

namespace CiccioGest.Presentation.Mvvm.ViewModel
{
    public sealed partial class ClientiViewModel : ObservableObject, IViewModel, IDisposable
    {
        private readonly ILogger _logger;
        private readonly IAnagraficaService _clientiFornitoriService;
        private readonly INavigationService _navigationService;
        private Cliente? _clienteSelezionato;
        private ClientiViewReturnHandler? _clientiViewReturnHandler;

        public ClientiViewModel(ILogger<ClientiViewModel> logger,
                                IAnagraficaService clientiFornitoriService,
                                INavigationService navigationService)
        {
            _logger = logger;
            _clientiFornitoriService = clientiFornitoriService;
            _navigationService = navigationService;
            Clienti = new ObservableCollection<Cliente>();
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

        public void Initialize(object? parameter)
        {
            if (parameter is ClientiViewReturnHandler clientiViewReturnHandler)
            {
                _clientiViewReturnHandler = clientiViewReturnHandler;
            }
        }


        [RelayCommand]
        private Task OnLoaded() => OnAggiornaClienti();


        [RelayCommand]
        private void OnUnloaded() { }


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
        private Task OnApriCliente()
        {
            if (ClienteSelezionato != null)
            {
                if (_clientiViewReturnHandler != null)
                {
                    //_idClienteTaskCompletionSource.SetResult(ClienteSelezionato.Id);
                    return _clientiViewReturnHandler.Invoke(new ClientiViewReturn(WizardResult.Finished, ClienteSelezionato.Id));
                }
            }
            return Task.CompletedTask;
        }
        private bool CanApriCliente() => ClienteSelezionato != null;


        public void Dispose()
        {
            _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
        }
    }
}
