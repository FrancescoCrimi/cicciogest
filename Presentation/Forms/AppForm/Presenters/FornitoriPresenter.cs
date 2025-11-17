// Copyright (c) 2016 - 2025 Francesco Crimi
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
    public sealed class FornitoriPresenter : PresenterBase, IResultProvider<int>
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAnagraficaService _anagraficaService;
        private IFornitoriView _view;
        private int _idFornitore;

        public FornitoriPresenter(ILogger<FornitoriPresenter> logger,
                                  IUnitOfWork unitOfWork,
                                  IAnagraficaService anagraficaService,
                                  IFornitoriView view)
            : base(view)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _anagraficaService = anagraficaService;
            _view = view;
            _view.Load += OnLoad;
            _view.FormClosing += OnFormClosing;
            _view.FornitoreSelezionatoRequested += OnFornitoreSelezionatoRequested;
            _logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public int GetResult()
        {
            return _idFornitore;
        }

        #region Event Handlers

        private async void OnLoad(object? sender, EventArgs e)
        {
            _view.CaricaFornitori(await _anagraficaService.GetFornitori());
        }

        private void OnFormClosing(object? sender, FormClosingEventArgs e)
        {
        }

        private void OnFornitoreSelezionatoRequested(object? sender, int e)
        {
            _idFornitore = e;
            _view.DialogResult = DialogResult.OK;
        }

        #endregion

        public override void Dispose()
        {
            base.Dispose();
            _view.Load -= OnLoad;
            _view.FormClosing -= OnFormClosing;
            _view.FornitoreSelezionatoRequested -= OnFornitoreSelezionatoRequested;
            _view = null!;
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
