using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Presentation.UwpApp.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.UwpApp.ViewModel
{
    public class ClientiViewModel : ObservableObject, IDisposable
    {
        private readonly ILogger logger;
        private readonly IClientiFornitoriService clientiFornitoriService;
        private readonly NavigationService navigationService;
        private Cliente clienteSelezionato;
        private AsyncRelayCommand loadCommand;
        private AsyncRelayCommand aggiornaClientiCommand;
        private RelayCommand apriClienteCommand;
        private RelayCommand cancellaClienteCommand;

        public ClientiViewModel(ILogger<ClientiViewModel> logger,
                                IClientiFornitoriService clientiFornitoriService,
                                NavigationService navigationService)
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
                if(clienteSelezionato != value)
                {
                    clienteSelezionato = value;
                    apriClienteCommand.NotifyCanExecuteChanged();
                    cancellaClienteCommand.NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand LoadedCommand => loadCommand ??
            (loadCommand = new AsyncRelayCommand(AggiornaClienti));

        public ICommand AggiornaClientiCommand => aggiornaClientiCommand ??
            (aggiornaClientiCommand = new AsyncRelayCommand(AggiornaClienti));

        public ICommand ApriClienteCommand => apriClienteCommand ??
            (apriClienteCommand = new RelayCommand(ApriCliente, EnableApriCliente));

        public ICommand CancellaClienteCommand => cancellaClienteCommand ??
            (cancellaClienteCommand = new RelayCommand(CancellaCliente, EnableCancellaCliente));

        private async Task AggiornaClienti()
        {
            Clienti.Clear();
            foreach (var item in await clientiFornitoriService.GetClienti())
            {
                Clienti.Add(item);
            }
        }

        private void ApriCliente()
        {
            if (ClienteSelezionato != null)
            {

            }
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
