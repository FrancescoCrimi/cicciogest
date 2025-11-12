// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public sealed class FatturePresenter : PresenterBase, IResultProvider<int>
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFatturaService _fatturaService;
        private IFattureView _view;
        private int _idFattura;

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

            _logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public int GetResult()
        {
            return _idFattura;
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
            _idFattura = e;
            _view.DialogResult = DialogResult.OK;
        }

        #endregion


        public override void Dispose()
        {
            base.Dispose();
            _view.Load -= OnLoad;
            _view.FormClosing -= OnFormClosing;
            _view.FatturaSelezionataRequested -= OnFatturaSelezionataEvent;
            _view = null!;
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
