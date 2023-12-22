// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
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
        private readonly ILogger<ClientiViewModel> logger;
        private readonly IClientiFornitoriService clientiFornitoriService;
        private readonly INavigationService navigationService;
        private Cliente clienteSelezionato;
        private AsyncRelayCommand loadedCommand;
        private AsyncRelayCommand aggiornaClientiCommand;
        private RelayCommand apriClienteCommand;
        private RelayCommand nuovoClienteCommand;

        public ClientiViewModel(ILogger<ClientiViewModel> logger,
                                IClientiFornitoriService clientiFornitoriService,
                                INavigationService navigationService)
        {
            this.logger = logger;
            this.clientiFornitoriService = clientiFornitoriService;
            this.navigationService = navigationService;
            Clienti = new ObservableCollection<Cliente>();
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }



        public ObservableCollection<Cliente> Clienti { get; }

        public Cliente ClienteSelezionato
        {
            get => clienteSelezionato;
            set
            {
                if (clienteSelezionato != value)
                {
                    clienteSelezionato = value;
                    apriClienteCommand.NotifyCanExecuteChanged();
                    nuovoClienteCommand.NotifyCanExecuteChanged();
                }
            }
        }



        public IAsyncRelayCommand LoadedCommand => loadedCommand
            ?? (loadedCommand = new AsyncRelayCommand(AggiornaClienti));

        public ICommand NuovoClienteCommand => nuovoClienteCommand
            ?? (nuovoClienteCommand = new RelayCommand(NuovoCliente));

        public ICommand ApriClienteCommand => apriClienteCommand
            ?? (apriClienteCommand = new RelayCommand(ApriCliente, () => ClienteSelezionato != null));

        public IAsyncRelayCommand AggiornaClientiCommand => aggiornaClientiCommand
            ?? (aggiornaClientiCommand = new AsyncRelayCommand(AggiornaClienti));



        private async Task AggiornaClienti()
        {
            Clienti.Clear();
            foreach (var item in await clientiFornitoriService.GetClienti())
            {
                Clienti.Add(item);
            }
        }

        protected virtual void ApriCliente()
        {
            if (ClienteSelezionato != null)
            {
                navigationService.Navigate(ViewEnum.Cliente);
                Messenger.Send(new ClienteIdMessage(ClienteSelezionato.Id));
            }
        }

        private void NuovoCliente()
        {
        }


        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
