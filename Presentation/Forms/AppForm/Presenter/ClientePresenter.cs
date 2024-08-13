// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Presentation.AppForm.Services;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public sealed class ClientePresenter : PresenterBase, IDisposable
    {
        private readonly ILogger _logger;
        private readonly IClienteView _view;
        private readonly IClientiFornitoriService _clientiFornitoriService;
        private readonly WindowService _windowService;

        public ClientePresenter(ILogger<ClientePresenter> logger,
                                IClienteView view,
                                IClientiFornitoriService clientiFornitoriService,
                                WindowService windowService) 
            : base(view)
        {
            _logger = logger;
            _view = view;
            _clientiFornitoriService = clientiFornitoriService;
            _windowService = windowService;
            _view.LoadEvent += View_LoadEvent;
            _view.CloseEvent += View_CloseEvent;
            _logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        #region Metodi Pubblici

        public void NuovoCliente()
            => _view.MostraCliente(new Cliente());

        public async void ApriCliente(int idCliente)
            => _view.MostraCliente(await _clientiFornitoriService.GetCliente(idCliente));

        #endregion

        #region gestione eventi

        private void View_LoadEvent(object? sender, EventArgs e)
        {
            _view.ApriCliente += View_ApriCliente;
            _view.NuovoCliente += View_NuovoCliente;
            _view.SalvaCliente += View_SalvaCliente;
        }

        private void View_CloseEvent(object? sender, EventArgs e)
        {
            _view.ApriCliente -= View_ApriCliente;
            _view.NuovoCliente -= View_NuovoCliente;
            _view.SalvaCliente -= View_SalvaCliente;
        }


        private void View_SalvaCliente(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void View_NuovoCliente(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void View_ApriCliente(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
