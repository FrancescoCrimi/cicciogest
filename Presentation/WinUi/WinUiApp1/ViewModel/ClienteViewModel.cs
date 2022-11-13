﻿using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Input;

namespace CiccioGest.Presentation.WinUiApp1.ViewModel
{
    public class ClienteViewModel : ObservableRecipient, IDisposable
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
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public Cliente Cliente { get; set; }

        public Indirizzo Indirizzo { get; set; }

        public ICommand NuovoClienteCommand
            => nuovoClienteCommand ?? (nuovoClienteCommand = new RelayCommand(NuovoCliente));

        public ICommand EliminaClienteCommand
            => eliminaClienteCommand ?? (eliminaClienteCommand = new RelayCommand(EliminaCliente));

        public ICommand ApriClienteCommand
            => apriClienteCommand ?? (apriClienteCommand = new RelayCommand(() => 
            {

            }));

        public ICommand SalvaClienteCommand
            => salvaClienteCommand ?? (salvaClienteCommand = new RelayCommand(SalvaCliente));


        private void RegistraMessaggi()
        {
            Messenger.Register<ClienteIdMessage>(this, async (r, m) =>
            {
                if (m.Value != 0)
                {
                    ApriCliente(await clientiFornitoriService.GetCliente(m.Value));
                }
            });
        }

        private void NuovoCliente()
        {
        }

        private void EliminaCliente()
        {
        }

        private void ApriCliente(Cliente cliente)
        {
            Cliente = cliente;
            OnPropertyChanged(nameof(Cliente));
            Indirizzo = cliente.IndirizzoNew;
            OnPropertyChanged(nameof(this.Indirizzo));
        }

        private void SalvaCliente()
        {
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
