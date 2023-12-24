// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Presentation.WpfBackend.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfBackend.ViewModel
{
    public partial class ClientiViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly IClientiFornitoriService clientiFornitoriService;
        protected readonly INavigationService navigationService;
        private Cliente? clienteSelezionato;
        private AsyncRelayCommand? loadCommand;
        private RelayCommand? nuovoClientiCommand;
        private RelayCommand? apriClienteCommand;
        private AsyncRelayCommand? aggiornaClientiCommand;

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

        public Cliente? ClienteSelezionato
        {
            protected get => clienteSelezionato;
            set
            {
                if (clienteSelezionato != value)
                {
                    clienteSelezionato = value;
                    apriClienteCommand?.NotifyCanExecuteChanged();
                }
            }
        }

        public IAsyncRelayCommand LoadedCommand => loadCommand ??=
            new AsyncRelayCommand(AggiornaClienti);

        public ICommand NuovoClientiCommand => nuovoClientiCommand ??= new RelayCommand(() =>
        {
        });

        public ICommand ApriClienteCommand => apriClienteCommand ??=
            new RelayCommand(ApriCliente, () => ClienteSelezionato != null);

        public IAsyncRelayCommand AggiornaClientiCommand => aggiornaClientiCommand ??=
            new AsyncRelayCommand(AggiornaClienti);




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
                navigationService.NavigateTo(nameof(ClienteViewModel));
                Messenger.Send(new ClienteIdMessage(ClienteSelezionato.Id));
            }
        }


        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
