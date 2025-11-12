// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public sealed class CategoriePresenter : PresenterBase, IResultProvider<int>
    {
        private readonly ILogger _logger;
        private readonly IMagazzinoService _magazinoService;
        private ICategorieView _view;
        private int _idCategoria;

        public CategoriePresenter(ILogger<CategoriePresenter> logger,
                                  IMagazzinoService magazinoService,
                                  ICategorieView view)
            : base(view)
        {
            _logger = logger;
            _magazinoService = magazinoService;
            _view = view;
            _view.Load += OnLoad;
            _view.FormClosing += OnFormClosing;
            _view.CategoriaSelezionataRequested += OnCategoriaSelezionataRequested;
            _logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public int GetResult()
        {
            return _idCategoria;
        }

        #region Event Handlers

        private async void OnLoad(object? sender, EventArgs e)
        {
            _view.CaricaCategorie(await _magazinoService.GetCategorie());
        }

        private void OnFormClosing(object? sender, FormClosingEventArgs e)
        {
        }

        private void OnCategoriaSelezionataRequested(object? sender, int e)
        {
            _idCategoria = e;
            _view.DialogResult = DialogResult.OK;
        }

        #endregion

        public override void Dispose()
        {
            base.Dispose();
            _view.Load -= OnLoad;
            _view.FormClosing -= OnFormClosing;
            _view.CategoriaSelezionataRequested -= OnCategoriaSelezionataRequested;
            _view = null!;
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
