using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Presentation.WpfApp.Contracts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        private readonly INavigationService navigationService;
        private RelayCommand loadCommand;
        private RelayCommand apriClienteCommand;
        private Cliente clienteSelezionato;

        public ClientiViewModel(ILogger<ClientiViewModel> logger,
                                IClientiFornitoriService clientiFornitoriService,
                                INavigationService navigationService)
        {
            this.logger = logger;
            service = clientiFornitoriService;
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

        public ICommand LoadedCommand => loadCommand ??= new RelayCommand(async () =>
        {
            Clienti.Clear();
            foreach (var item in await service.GetClienti())
            {
                Clienti.Add(item);
            }
        });

        public ICommand ApriClienteCommand => apriClienteCommand ??=
            new RelayCommand(ApriCliente, EnableApriCliente);

        protected virtual void ApriCliente()
        {
            //throw new NotImplementedException();
        }

        private bool EnableApriCliente() => ClienteSelezionato != null;

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
