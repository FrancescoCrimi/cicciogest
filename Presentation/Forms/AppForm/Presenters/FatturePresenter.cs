// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.Fatturazione;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.AppForm.Views;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Presenters
{
    public sealed class FatturePresenter : DialogPresenterBase
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFatturaService _fatturaService;
        private IFattureView _view;
        private bool _disposedValue;

        public FatturePresenter(ILogger<FatturePresenter> logger,
                                IUnitOfWork unitOfWork,
                                IFatturaService fatturaService,
                                IFattureView view)
            : base(view)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _fatturaService = fatturaService;
            _view = view;

            _view.Load += OnLoad;
            _view.FormClosing += OnFormClosing;
            _view.FatturaSelezionataRequested += OnFatturaSelezionataEvent;

            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        #region Event Handlers

        private async void OnLoad(object? sender, EventArgs e)
        {
            await _unitOfWork.BeginAsync();
            IList<Fattura> fatture = await _fatturaService.GetFatture();
            _view.CaricaFatture(fatture);
        }

        private void OnFormClosing(object? sender, FormClosingEventArgs e) { }

        private void OnFatturaSelezionataEvent(object? sender, int e)
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
                    _view.FatturaSelezionataRequested -= OnFatturaSelezionataEvent;
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
