// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Infrastructure;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Input;

namespace CiccioGest.Presentation.WinUiBackend.ViewModel
{
    public partial class ClienteViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger<ClienteViewModel> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClientiFornitoriService _clientiFornitoriService;
        private RelayCommand nuovoClienteCommand;
        private RelayCommand eliminaClienteCommand;
        private RelayCommand apriClienteCommand;
        private RelayCommand salvaClienteCommand;

        public ClienteViewModel(ILogger<ClienteViewModel> logger,
                                IUnitOfWork unitOfWork,
                                IClientiFornitoriService clientiFornitoriService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _clientiFornitoriService = clientiFornitoriService;
            RegistraMessaggi();
            _logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public Cliente Cliente { get; set; }

        public Indirizzo Indirizzo { get; set; }

        public ICommand NuovoClienteCommand
            => nuovoClienteCommand ??= new RelayCommand(NuovoCliente);

        public ICommand EliminaClienteCommand
            => eliminaClienteCommand ??= new RelayCommand(EliminaCliente);

        public ICommand ApriClienteCommand
            => apriClienteCommand ??= new RelayCommand(() =>
            {

            });

        public ICommand SalvaClienteCommand
            => salvaClienteCommand ??= new RelayCommand(SalvaCliente);


        private void RegistraMessaggi()
        {
            Messenger.Register<ClienteIdMessage>(this, async (r, m) =>
            {
                if (m.Value != 0)
                {
                    await _unitOfWork.BeginAsync();
                    ApriCliente(await _clientiFornitoriService.GetCliente(m.Value));
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
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
