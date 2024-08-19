// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.WinUiBackend.Contracts;
using CiccioGest.Presentation.WinUiBackend.Contracts.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.WinUiBackend.ViewModel
{
    public partial class ClientiViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger<ClientiViewModel> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClientiFornitoriService _clientiFornitoriService;
        private readonly INavigationService _navigationService;
        private Cliente _clienteSelezionato;
        private AsyncRelayCommand loadedCommand;
        private AsyncRelayCommand aggiornaClientiCommand;
        private RelayCommand apriClienteCommand;
        private RelayCommand nuovoClienteCommand;

        public ClientiViewModel(ILogger<ClientiViewModel> logger,
                                IUnitOfWork unitOfWork,
                                IClientiFornitoriService clientiFornitoriService,
                                INavigationService navigationService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _clientiFornitoriService = clientiFornitoriService;
            _navigationService = navigationService;
            Clienti = new ObservableCollection<Cliente>();
            _logger.LogDebug("Created: " + GetHashCode().ToString());
        }



        public ObservableCollection<Cliente> Clienti { get; }

        public Cliente ClienteSelezionato
        {
            get => _clienteSelezionato;
            set
            {
                if (_clienteSelezionato != value)
                {
                    _clienteSelezionato = value;
                    apriClienteCommand.NotifyCanExecuteChanged();
                    nuovoClienteCommand.NotifyCanExecuteChanged();
                }
            }
        }



        public IAsyncRelayCommand LoadedCommand => loadedCommand ??= new AsyncRelayCommand(AggiornaClienti);

        public ICommand NuovoClienteCommand => nuovoClienteCommand ??= new RelayCommand(NuovoCliente);

        public ICommand ApriClienteCommand => apriClienteCommand ??= new RelayCommand(ApriCliente, () => ClienteSelezionato != null);

        public IAsyncRelayCommand AggiornaClientiCommand => aggiornaClientiCommand ??= new AsyncRelayCommand(AggiornaClienti);



        private async Task AggiornaClienti()
        {
            Clienti.Clear();
            await _unitOfWork.BeginAsync();
            foreach (var item in await _clientiFornitoriService.GetClienti())
            {
                Clienti.Add(item);
            }
        }

        protected virtual void ApriCliente()
        {
            if (ClienteSelezionato != null)
            {
                _navigationService.Navigate(ViewEnum.Cliente);
                Messenger.Send(new ClienteIdMessage(ClienteSelezionato.Id));
            }
        }

        private void NuovoCliente()
        {
        }


        public void Dispose()
        {
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
