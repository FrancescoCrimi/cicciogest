using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Presentation.WpfApp.Contracts;
using CiccioGest.Presentation.WpfApp.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfApp.ViewModel
{
    public class ClientiViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly IClientiFornitoriService clientiFornitoriService;
        private readonly INavigationService navigationService;
        private Cliente clienteSelezionato;
        private AsyncRelayCommand loadCommand;
        private AsyncRelayCommand aggiornaClientiCommand;
        private RelayCommand apriClienteCommand;
        private RelayCommand cancellaClienteCommand;

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

        public ICommand LoadedCommand => loadCommand ??=
            new AsyncRelayCommand(AggiornaClienti);

        public ICommand AggiornaClientiCommand => aggiornaClientiCommand ??=
            new AsyncRelayCommand(AggiornaClienti);

        public ICommand ApriClienteCommand => apriClienteCommand ??=
            new RelayCommand(ApriCliente, EnableApriCliente);

        public ICommand CancellaClienteCommand => cancellaClienteCommand ??=
            new RelayCommand(CancellaCliente, EnableCancellaCliente);

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
                navigationService.NavigateTo(typeof(ClienteView));
                Messenger.Send(new ClienteIdMessage(ClienteSelezionato.Id));
            }
        }

        private bool EnableApriCliente() => ClienteSelezionato != null;

        private void CancellaCliente()
        {
        }

        protected virtual bool EnableCancellaCliente() => ClienteSelezionato != null;

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
