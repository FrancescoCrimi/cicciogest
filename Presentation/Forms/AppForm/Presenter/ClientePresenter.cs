// Copyright (c) 2023 Francesco Crimi
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
    public class ClientePresenter : PresenterBase, IDisposable
    {
        private readonly ILogger logger;
        private readonly IClienteView view;
        private readonly IClientiFornitoriService clientiFornitoriService;
        private readonly WindowService windowService;

        public ClientePresenter(ILogger<ClientePresenter> logger,
                                IClienteView view,
                                IClientiFornitoriService clientiFornitoriService,
                                WindowService windowService) 
            : base(view)
        {
            this.logger = logger;
            this.view = view;
            this.clientiFornitoriService = clientiFornitoriService;
            this.windowService = windowService;
            view.LoadEvent += View_LoadEvent;
            view.CloseEvent += View_CloseEvent;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        #region Metodi Pubblici

        public void NuovoCliente()
            => view.MostraCliente(new Cliente());

        public async void ApriCliente(int idCliente)
            => view.MostraCliente(await clientiFornitoriService.GetCliente(idCliente));

        #endregion

        #region gestione eventi

        private void View_LoadEvent(object? sender, EventArgs e)
        {
            view.ApriCliente += View_ApriCliente;
            view.NuovoCliente += View_NuovoCliente;
            view.SalvaCliente += View_SalvaCliente;
        }

        private void View_CloseEvent(object? sender, EventArgs e)
        {
            view.ApriCliente -= View_ApriCliente;
            view.NuovoCliente -= View_NuovoCliente;
            view.SalvaCliente -= View_SalvaCliente;
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
            throw new NotImplementedException();
        }
    }
}
