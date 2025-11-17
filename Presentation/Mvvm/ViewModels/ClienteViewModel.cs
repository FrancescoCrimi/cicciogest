// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.Anagrafica;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.Mvvm.Contracts;
using CiccioGest.Presentation.Mvvm.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Mvvm.ViewModels
{
    public sealed partial class ClienteViewModel : ObservableObject, IViewModel, IDisposable
    {
        private readonly ILogger<ClienteViewModel> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly INavigationService _navigationService;
        private readonly IMessageBoxService _messageBoxService;
        private readonly IAnagraficaService _clientiFornitoriService;

        [ObservableProperty]
        private Cliente? _cliente;

        [ObservableProperty]
        private Indirizzo? _indirizzo;

        public ClienteViewModel(ILogger<ClienteViewModel> logger,
                                IUnitOfWork unitOfWork,
                                INavigationService navigationService,
                                IMessageBoxService messageBoxService,
                                IAnagraficaService clientiFornitoriService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _navigationService = navigationService;
            _messageBoxService = messageBoxService;
            _clientiFornitoriService = clientiFornitoriService;
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        public void Initialize(object? parameter)
        {
            if (parameter is ClientiViewReturn clientiViewReturn)
            {
                //Task.Run(async () => await ApriCliente(clientiViewReturn.IdCliente));
                ApriCliente(clientiViewReturn.IdCliente).ConfigureAwait(false);
            }
        }


        [RelayCommand]
        private void OnLoaded() { }


        [RelayCommand]
        private void OnUnloaded() { }


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
        private async Task OnApriCliente()
        {
            await _unitOfWork.BeginAsync();
            ClientiViewReturnHandler clientiViewReturnHandler = ClientiViewReturnMethod;
            _navigationService.Navigate(ViewEnum.Clienti, clientiViewReturnHandler, false);
        }
        private async Task ClientiViewReturnMethod(ClientiViewReturn clientiViewReturn)
        {
            if (clientiViewReturn.Result == WizardResult.Finished)
            {
                _navigationService.GoBack();
                await ApriCliente(clientiViewReturn.IdCliente);
            }
        }


        [RelayCommand]
        private async Task OnEliminaCliente()
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
            _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
        }
    }
}
