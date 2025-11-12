// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public sealed class ClientiPresenter : PresenterBase, IResultProvider<int>
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAnagraficaService _clientiFornitoriService;
        private IClientiView _view;
        private int _idCliente;

        public ClientiPresenter(ILogger<ClientiPresenter> logger,
                                IUnitOfWork unitOfWork,
                                IAnagraficaService clientiFornitoriService,
                                IClientiView view)
            : base(view)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _clientiFornitoriService = clientiFornitoriService;
            _view = view;
            _view.Load += OnLoad;
            _view.FormClosing += OnFormClosing;
            _view.ClienteSelezionatoRequested += OnClienteSelezionatoRequested;
            _logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public int GetResult()
        {
            return _idCliente;
        }

        #region Event Handlers

        private async void OnLoad(object? sender, EventArgs e)
        {
            await _unitOfWork.BeginAsync();
            var clienti = await _clientiFornitoriService.GetClienti();
            _view.CaricaClienti(clienti);
        }

        private void OnFormClosing(object? sender, FormClosingEventArgs e)
        {
        }

        private void OnClienteSelezionatoRequested(object? sender, int e)
        {
            _idCliente = e;
            _view.DialogResult = DialogResult.OK;
        }

        #endregion

        public override void Dispose()
        {
            base.Dispose();
            _view.Load -= OnLoad;
            _view.FormClosing -= OnFormClosing;
            _view.ClienteSelezionatoRequested -= OnClienteSelezionatoRequested;
            _view = null!;
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
