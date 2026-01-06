// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.AppForm.Views;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Presenters
{
    public sealed class ClientiPresenter : DialogPresenterBase
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAnagraficaService _anagraficaService;
        private IClientiView _view;
        private bool _disposedValue;

        public ClientiPresenter(ILogger<ClientiPresenter> logger,
                                IUnitOfWork unitOfWork,
                                IAnagraficaService anagraficaService,
                                IClientiView view)
            : base(view)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _anagraficaService = anagraficaService;
            _view = view;

            _view.Load += OnLoad;
            _view.FormClosing += OnFormClosing;
            _view.ClienteSelezionatoRequested += OnClienteSelezionatoRequested;

            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        #region Event Handlers

        private async void OnLoad(object? sender, EventArgs e)
        {
            await _unitOfWork.BeginAsync();
            var clienti = await _anagraficaService.GetClienti();
            _view.CaricaClienti(clienti);
        }

        private void OnFormClosing(object? sender, FormClosingEventArgs e) { }

        private void OnClienteSelezionatoRequested(object? sender, int e)
        {
            NotifySelection(e);
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // Libera le risorse specifiche della classe figlia
                    _view.Load -= OnLoad;
                    _view.FormClosing -= OnFormClosing;
                    _view.ClienteSelezionatoRequested -= OnClienteSelezionatoRequested;
                    _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
                }

                // Chiama sempre la base alla fine
                _view = null!;
                base.Dispose(disposing);
                _disposedValue = true;
            }
        }
    }
}
