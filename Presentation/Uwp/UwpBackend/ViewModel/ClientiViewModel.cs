using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Presentation.UwpBackend.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.UwpBackend.ViewModel
{
    public class ClientiViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger<ClientiViewModel> logger;
        private readonly IClientiFornitoriService clientiFornitoriService;
        private readonly INavigationService navigationService;
        private Cliente clienteSelezionato;
        private AsyncRelayCommand loadedCommand;
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
            get => clienteSelezionato;
            set
            {
                if (clienteSelezionato != value)
                {
                    clienteSelezionato = value;
                    apriClienteCommand.NotifyCanExecuteChanged();
                    cancellaClienteCommand.NotifyCanExecuteChanged();
                }
            }
        }

        public IAsyncRelayCommand LoadedCommand => loadedCommand
            ?? (loadedCommand = new AsyncRelayCommand(AggiornaClienti));

        public IAsyncRelayCommand AggiornaClientiCommand => aggiornaClientiCommand
            ?? (aggiornaClientiCommand = new AsyncRelayCommand(AggiornaClienti));

        public ICommand ApriClienteCommand => apriClienteCommand
            ?? (apriClienteCommand = new RelayCommand(ApriCliente, EnableApriCliente));

        public ICommand CancellaClienteCommand => cancellaClienteCommand
            ?? (cancellaClienteCommand = new RelayCommand(CancellaCliente, EnableCancellaCliente));

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
        }

        private bool EnableApriCliente() => ClienteSelezionato != null;

        private void CancellaCliente()
        {
        }

        private bool EnableCancellaCliente() => ClienteSelezionato != null;

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
