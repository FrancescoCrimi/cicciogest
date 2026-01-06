// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Presentation.AppForm.Views;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Presenters
{
    public sealed class CategoriePresenter : DialogPresenterBase
    {
        private readonly ILogger _logger;
        private readonly IMagazzinoService _magazzinoService;
        private ICategorieView _view;
        private bool _disposedValue;

        public CategoriePresenter(ILogger<CategoriePresenter> logger,
                                  IMagazzinoService magazzinoService,
                                  ICategorieView view)
            : base(view)
        {
            _logger = logger;
            _magazzinoService = magazzinoService;
            _view = view;

            _view.Load += OnLoad;
            _view.FormClosing += OnFormClosing;
            _view.CategoriaSelezionataRequested += OnCategoriaSelezionataRequested;

            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        #region Event Handlers

        private async void OnLoad(object? sender, EventArgs e)
        {
            var categorie = await _magazzinoService.GetCategorie();
            _view.CaricaCategorie(categorie);
        }

        private void OnFormClosing(object? sender, FormClosingEventArgs e) { }

        private void OnCategoriaSelezionataRequested(object? sender, int e)
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
                    _view.CategoriaSelezionataRequested -= OnCategoriaSelezionataRequested;
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
