// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.Magazzino;
using CiccioGest.Presentation.AppForm.Views;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Presenters
{
    public sealed class CategoriaPresenter : PresenterBase
    {
        private readonly ILogger _logger;
        private readonly IMagazzinoService _magazzinoService;
        private ICategoriaView _view;
        private bool _disposedValue;

        public CategoriaPresenter(ILogger<CategoriaPresenter> logger,
                                  IMagazzinoService magazzinoService,
                                  ICategoriaView view)
            : base(view)
        {
            _logger = logger;
            _magazzinoService = magazzinoService;
            _view = view;

            _view.Load += OnLoad;
            _view.FormClosing += OnFormClosing;
            _view.SalvaCategoriaRequested += View_SalvaCategoriaEvent;
            _view.CancellaCategoriaRequested += View_CancellaCategoriaEvent;

            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        #region Event Handlers

        private async void OnLoad(object? sender, EventArgs e)
        {
            await Refresh();
        }

        private void OnFormClosing(object? sender, FormClosingEventArgs e)
        {
        }

        private async void View_CancellaCategoriaEvent(object? sender, int e)
        {
            await _magazzinoService.DeleteCategoria(e);
            await Refresh();
        }

        private async void View_SalvaCategoriaEvent(object? s, Categoria e)
        {
            await _magazzinoService.SaveCategoria(e);
            await Refresh();
        }

        #endregion

        private async Task Refresh()
        {
            var list = await _magazzinoService.GetCategorie();
            _view.SetCategorie(list);
            _view.SetCategoria(new Categoria());
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // Libera le risorse specifiche della classe figlia
                    _view.Load -= OnLoad;
                    _view.FormClosing -= OnFormClosing;
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
