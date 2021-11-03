using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Presentation.WpfBackend.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfBackend.ViewModel
{
    public class ClientiViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly IClientiFornitoriService clientiFornitoriService;
        private readonly INavigationService navigationService;
        private Cliente clienteSelezionato;
        private AsyncRelayCommand loadCommand;
        private RelayCommand nuovoClientiCommand;
        private RelayCommand apriClienteCommand;
        private AsyncRelayCommand aggiornaClientiCommand;

        public ClientiViewModel(ILogger<ClientiViewModel> logger,
                                IClientiFornitoriService clientiFornitoriService,
                                INavigationService navigationService)
        {
            this.logger = logger;
            this.clientiFornitoriService = clientiFornitoriService;
            this.navigationService = navigationService;
            Clienti = new ObservableCollection<Cliente>();
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public ObservableCollection<Cliente> Clienti { get; }

        public Cliente ClienteSelezionato
        {
            protected get => clienteSelezionato;
            set
            {
                if (clienteSelezionato != value)
                {
                    clienteSelezionato = value;
                    apriClienteCommand.NotifyCanExecuteChanged();
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
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
