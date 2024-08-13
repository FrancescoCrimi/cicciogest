// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public sealed class SelezionaClientePresenter : PresenterBase, IDisposable
    {
        private readonly ILogger _logger;
        private readonly ISelezionaClienteView _view;
        private readonly IClientiFornitoriService _clientiFornitoriService;
        public int IdCliente { get; private set; }

        public SelezionaClientePresenter(ILogger<SelezionaClientePresenter> logger,
                                         ISelezionaClienteView view,
                                         IClientiFornitoriService clientiFornitoriService)
            : base(view)
        {
            _logger = logger;
            _view = view;
            _clientiFornitoriService = clientiFornitoriService;
            _view.LoadEvent += View_LoadEvent;
            _view.CloseEvent += View_CloseEvent;
            _logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        private async void View_LoadEvent(object? s, EventArgs e)
        {
            _view.CaricaClienti(await _clientiFornitoriService.GetClienti());
            _view.ClienteSelezionatoEvent += View_ClienteSelezionatoEvent;
        }

        private void View_CloseEvent(object? s, EventArgs e)
        {
            _view.ClienteSelezionatoEvent -= View_ClienteSelezionatoEvent;
        }

        private void View_ClienteSelezionatoEvent(object? sender, int e)
        {
            IdCliente = e;
            _view.Close();
        }

        public void Dispose()
        {
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
