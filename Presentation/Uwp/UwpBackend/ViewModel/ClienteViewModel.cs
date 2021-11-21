using CiccioGest.Application;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;
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
        private readonly IMagazinoService magazinoService;

        public ClienteViewModel(ILogger<ClienteViewModel> logger,
                                IMagazinoService magazinoService)
        {
            this.logger = logger;
            this.magazinoService = magazinoService;
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
