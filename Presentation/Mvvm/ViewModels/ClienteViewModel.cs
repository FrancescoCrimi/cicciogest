// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.Anagrafica;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.Mvvm.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Mvvm.ViewModels
{
    public sealed partial class ClienteViewModel : ViewModelBase, INavigationAwareAsync
    {
        private readonly ILogger<ClienteViewModel> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly INavigationService _navigationService;
        private readonly IMessageBoxService _messageBoxService;
        private readonly IAnagraficaService _anagraficaService;
        private bool _disposedValue;

        [ObservableProperty]
        private Cliente? _cliente;

        [ObservableProperty]
        private Indirizzo? _indirizzo;

        public ClienteViewModel(ILogger<ClienteViewModel> logger,
                                IUnitOfWork unitOfWork,
                                INavigationService navigationService,
                                IMessageBoxService messageBoxService,
                                IAnagraficaService anagraficaService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _navigationService = navigationService;
            _messageBoxService = messageBoxService;
            _anagraficaService = anagraficaService;
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        public async Task OnNavigatedToAsync(object? parameter, CancellationToken cancellationToken = default)
        {
            if (parameter is ClientiViewReturn clientiViewReturn)
            {
                await ApriCliente(clientiViewReturn.IdCliente);
            }
        }

        public Task OnNavigatedFromAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task<bool> OnNavigatingFromAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(true);
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
            Indirizzo = cliente.Indirizzo;
        }


        [RelayCommand]
        private async Task OnSalvaCliente()
        {
            if (Cliente != null)
            {
                try
                {
                    await _anagraficaService.SaveCliente(Cliente);
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
            var id = await _navigationService.NavigateForResultAsync<ClientiViewModel>();
            _navigationService.GoBack();
            if (id.Type == DialogResultType.Ok)
                await ApriCliente(id.Value);
        }


        [RelayCommand]
        private async Task OnEliminaCliente()
        {
            if (Cliente != null)
            {
                try
                {
                    await _anagraficaService.DeleteCliente(Cliente.Id);
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
                var cliente = await _anagraficaService.GetCliente(idCliente);
                Cliente = null;
                Indirizzo = null;
                Cliente = cliente;
                Indirizzo = cliente.Indirizzo;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // Libera le risorse specifiche della classe figlia
                    _anagraficaService?.Dispose();
                    _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
                }

                // Chiama sempre la base alla fine
                base.Dispose(disposing);
                _disposedValue = true;
            }
        }
    }
}
