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
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfApp.ViewModel
{
    public class ClientiViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly IClientiFornitoriService service;
        private readonly IWindowManagerService windowManagerService;
        private Cliente clienteSelezionato;
        private RelayCommand loadCommand;
        private RelayCommand apriClienteCommand;
        private RelayCommand cancellaClienteCommand;
        private RelayCommand aggiornaClienteCommand;

        public ClientiViewModel(ILogger<ClientiViewModel> logger,
                                IClientiFornitoriService clientiFornitoriService,
                                IWindowManagerService windowManagerService)
        {
            this.logger = logger;
            this.windowManagerService = windowManagerService;
            service = clientiFornitoriService;
            Clienti = new ObservableCollection<Cliente>();
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public event EventHandler OnRequestClose;

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

        public ICommand LoadedCommand => loadCommand ??= new RelayCommand(async () =>
        {
            Clienti.Clear();
            foreach (var item in await service.GetClienti())
            {
                Clienti.Add(item);
            }
        });

        public ICommand ApriClienteCommand => apriClienteCommand ??= new RelayCommand(ApriCliente, EnableApriCliente);

        protected virtual void ApriCliente()
        {
            if (ClienteSelezionato != null)
            {
                windowManagerService.OpenWindow(typeof(ClientiView));
                Messenger.Send(new ClienteIdMessage(ClienteSelezionato.Id));
                CloseWindow();
            }
        }

        private bool EnableApriCliente() => ClienteSelezionato != null;

        public ICommand CancellaClienteCommand => cancellaClienteCommand ??= new RelayCommand(CancellaCliente, EnableCancellaCliente);

        private void CancellaCliente()
        {
        }

        protected virtual bool EnableCancellaCliente() => ClienteSelezionato != null;

        public ICommand AggiornaClienteCommand => aggiornaClienteCommand ??= new RelayCommand(AggiornaCliente);

        private void AggiornaCliente()
        {
        }

        protected void CloseWindow()
        {
            OnRequestClose?.Invoke(this, new EventArgs());
        }

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
