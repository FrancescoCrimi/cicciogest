using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System.Windows.Input;

namespace CiccioGest.Presentation.UwpBackend.ViewModel
{
    public class ClienteViewModel : ObservableRecipient
    {
        private RelayCommand nuovoClienteCommand;
        private RelayCommand eliminaClienteCommand;
        private RelayCommand apriClienteCommand;
        private RelayCommand salvaClienteCommand;
        private readonly ILogger<ClienteViewModel> logger;
        private readonly IClientiFornitoriService clientiFornitoriService;

        public ClienteViewModel(ILogger<ClienteViewModel> logger,
                                IClientiFornitoriService clientiFornitoriService)
        {
            this.logger = logger;
            this.clientiFornitoriService = clientiFornitoriService;
            RegistraMessaggi();
        }

        public Cliente Cliente { get; set; }

        private void RegistraMessaggi()
        {
            Messenger.Register<ClienteIdMessage>(this, async (r, m) =>
            {
                if (m.Value != 0)
                {
                    Cliente = await clientiFornitoriService.GetCliente(m.Value);
                    OnPropertyChanged(nameof(Cliente));
                }
            });
        }

        public ICommand NuovoClienteCommand => nuovoClienteCommand
            ?? (nuovoClienteCommand = new RelayCommand(NuovoCliente));

        private void NuovoCliente()
        {
        }

        public ICommand EliminaClienteCommand => eliminaClienteCommand
            ?? (eliminaClienteCommand = new RelayCommand(EliminaCliente));

        private void EliminaCliente()
        {
        }

        public ICommand ApriClienteCommand => apriClienteCommand
            ?? (apriClienteCommand = new RelayCommand(ApriCliente));

        private void ApriCliente()
        {
        }

        public ICommand SalvaClienteCommand => salvaClienteCommand ?? (salvaClienteCommand = new RelayCommand(SalvaCliente));

        private void SalvaCliente()
        {
        }


    }
}
