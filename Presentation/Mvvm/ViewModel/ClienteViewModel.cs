// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.Mvvm.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Mvvm.ViewModel
{
    public sealed partial class ClienteViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger<ClienteViewModel> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly INavigationService _navigationService;
        private readonly IMessageBoxService _messageBoxService;
        private readonly IClientiFornitoriService _clientiFornitoriService;

        [ObservableProperty]
        private Cliente? _cliente;

        [ObservableProperty]
        private Indirizzo? _indirizzo;

        public ClienteViewModel(ILogger<ClienteViewModel> logger,
                                IUnitOfWork unitOfWork,
                                INavigationService navigationService,
                                IMessageBoxService messageBoxService,
                                IClientiFornitoriService clientiFornitoriService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _navigationService = navigationService;
            _messageBoxService = messageBoxService;
            _clientiFornitoriService = clientiFornitoriService;
            RegistraMessaggi();
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        [RelayCommand]
        private void OnLoaded() { }

        [RelayCommand]
        private async Task OnNuovoCliente()
        {
            await _unitOfWork.RollbackAsync();
            var cliente = new Cliente();
            Cliente = null;
            Indirizzo = null;
            Cliente = cliente;
            Indirizzo = cliente.IndirizzoNew;
        }

        [RelayCommand]
        private async Task OnSalvaCliente()
        {
            if (Cliente != null)
            {
                try
                {
                    await _clientiFornitoriService.SaveCliente(Cliente);
                    await _unitOfWork.CommitAsync();
                }
                catch (Exception ex)
                {
                    await _unitOfWork.RollbackAsync();
                    _messageBoxService.Show("Errore: " + ex.Message);
                    throw;
                }
            }
        }

        [RelayCommand]
        private async Task OnRimuoviCliente()
        {
            if (Cliente != null)
            {
                try
                {
                    await _clientiFornitoriService.DeleteCliente(Cliente.Id);
                    await _unitOfWork.CommitAsync();
                    await OnNuovoCliente();
                }
                catch (Exception ex)
                {
                    await _unitOfWork.RollbackAsync();
                    _messageBoxService.Show("Errore: " + ex.Message);
                    throw;
                }
            }
        }

        [RelayCommand]
        private async Task OnApriCliente()
        {
            _navigationService.Navigate(nameof(ClientiViewModel), false);
            int idCliente = await Messenger.Send<IdClienteRequestMessage>();
            _navigationService.GoBack(true);
            await ApriCliente(idCliente);
        }

        private void RegistraMessaggi()
        {
            Messenger.Register<IdClienteMessage>(this, async (r, m)
                => await ApriCliente(m.Value));
        }

        private async Task ApriCliente(int idCliente)
        {
            if (idCliente != 0)
            {
                await _unitOfWork.BeginAsync();
                var cliente = await _clientiFornitoriService.GetCliente(idCliente);
                Cliente = null;
                Indirizzo = null;
                Cliente = cliente;
                Indirizzo = cliente.IndirizzoNew;
            }
        }

        public void Dispose()
        {
            Messenger.UnregisterAll(this);
            _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
        }
    }
}
