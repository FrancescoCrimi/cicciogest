// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.AppForm.Services;
using CiccioGest.Presentation.AppForm.Views;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Presenters
{
    public sealed class ArticoliPresenter : PresenterBase, IResultProvider<int>
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMagazzinoService _magazinoService;
        private IArticoliView _view;
        private int _idArticolo;

        public int IdProdotto { get; private set; }

        public ArticoliPresenter(ILogger<ArticoliPresenter> logger,
                                 IUnitOfWork unitOfWork,
                                 IMagazzinoService magazinoService,
                                 IArticoliView view)
            : base(view)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _magazinoService = magazinoService;
            _view = view;
            _view.Load += OnLoad;
            _view.FormClosing += OnFormClosing;
            _view.ArticoloSelezionatoRequested += OnArticoloSelezionatoRequested;
            _logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public int GetResult()
        {
            return _idArticolo;
        }

        #region Event Handlers

        private async void OnLoad(object? sender, EventArgs e)
        {
            await _unitOfWork.BeginAsync();
            _view.CaricaArticoli(await _magazinoService.GetArticoli());
        }

        private void OnFormClosing(object? sender, FormClosingEventArgs e)
        {
        }

        private void OnArticoloSelezionatoRequested(object? sender, int e)
        {
            IdProdotto = e;
            _view.DialogResult = DialogResult.OK;
        }

        #endregion

        public override void Dispose()
        {
            base.Dispose();
            _view.Load -= OnLoad;
            _view.FormClosing -= OnFormClosing;
            _view.ArticoloSelezionatoRequested -= OnArticoloSelezionatoRequested;
            _view = null!;
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
