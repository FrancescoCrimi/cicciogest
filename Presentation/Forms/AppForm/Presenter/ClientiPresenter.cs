// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Presentation.AppForm.Services;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public sealed class ClientiPresenter : PresenterBase, IDisposable
    {
        private readonly ILogger _logger;
        private readonly IClientiView _view;
        private readonly IClientiFornitoriService _clientiFornitoriService;
        private readonly WindowService _windowService;

        public ClientiPresenter(ILogger<ClientiPresenter> logger,
                                IClientiView view,
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

        private async void View_LoadEvent(object? sender, EventArgs e)
        {
            _view.NuovoClienteEvent += View_NuovoClienteEvent;
            _view.ClienteSelezionatoEvent += View_ClienteSelezionatoEvent;
            _view.CreaFatturaEvent += View_CreaFatturaEvent;
            var clienti = await _clientiFornitoriService.GetClienti();
            _view.CaricaClienti(clienti);
        }

        private void View_CloseEvent(object? sender, EventArgs e)
        {
            _view.NuovoClienteEvent -= View_NuovoClienteEvent;
            _view.ClienteSelezionatoEvent -= View_ClienteSelezionatoEvent;
            _view.CreaFatturaEvent -= View_CreaFatturaEvent;
        }

        private void View_NuovoClienteEvent(object? sender, EventArgs e)
        {
            _windowService?.OpenWindow<ClientePresenter>()?.NuovoCliente();
            _view.Close();
        }

        private void View_ClienteSelezionatoEvent(object? sender, int e)
        {
            _windowService?.OpenWindow<ClientePresenter>()?.ApriCliente(e);
            _view.Close();
        }

        private void View_CreaFatturaEvent(object? sender, int e)
        {
            _windowService?.OpenWindow<FatturaPresenter>()?.NuovaFattura(e);
            _view.Close();
        }

        public void Dispose()
        {
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
