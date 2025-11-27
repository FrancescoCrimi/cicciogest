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
    public sealed partial class ClientiViewModel : ObservableObject, IViewModel, IDisposable
    {
        private readonly ILogger _logger;
        private readonly IAnagraficaService _clientiFornitoriService;
        private readonly INavigationService _navigationService;
        
        private ClientiViewReturnHandler? _clientiViewReturnHandler;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ConfermaCommand))]
        private Cliente? _clienteSelezionato;

        public ObservableCollection<Cliente> Clienti { get; } = [];

        public ClientiViewModel(ILogger<ClientiViewModel> logger,
                                IAnagraficaService clientiFornitoriService,
                                INavigationService navigationService)
        {
            _logger = logger;
            _clientiFornitoriService = clientiFornitoriService;
            _navigationService = navigationService;
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        public void Initialize(object? parameter)
        {
            if (parameter is ClientiViewReturnHandler clientiViewReturnHandler)
            {
                _clientiViewReturnHandler = clientiViewReturnHandler;
            }
        }


        [RelayCommand]
        private Task OnLoaded() => OnAggiorna();


        [RelayCommand]
        private void OnUnloaded() { }


        [RelayCommand]
        private async Task OnAggiorna()
        {
            Clienti.Clear();
            foreach (var item in await _clientiFornitoriService.GetClienti())
            {
                Clienti.Add(item);
            }
        }


        [RelayCommand(CanExecute = nameof(CanConferma))]
        private Task OnConferma()
        {
            if (ClienteSelezionato != null)
            {
                if (_clientiViewReturnHandler != null)
                {
                    //_idClienteTaskCompletionSource.SetResult(ClienteSelezionato.Id);
                    return _clientiViewReturnHandler(new ClientiViewReturn(WizardResult.Finished, ClienteSelezionato.Id));
                }
            }
            return Task.CompletedTask;
        }
        private bool CanConferma() => ClienteSelezionato != null;


        [RelayCommand]
        private Task OnAnnulla()
        {
            if (_clientiViewReturnHandler != null)
            {
                return _clientiViewReturnHandler(new ClientiViewReturn(WizardResult.Canceled, 0));
            }
            return Task.CompletedTask;
        }


        public void Dispose()
        {
            _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
        }
    }
}
