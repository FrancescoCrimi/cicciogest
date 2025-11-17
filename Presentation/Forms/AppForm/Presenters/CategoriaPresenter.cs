// Copyright (c) 2016 - 2025 Francesco Crimi
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
    public sealed class CategoriaPresenter : PresenterBase, IDisposable
    {
        private readonly ILogger _logger;
        private readonly IMagazzinoService _magazinoService;
        private ICategoriaView _view;

        public CategoriaPresenter(ILogger<CategoriaPresenter> logger,
                                  IMagazzinoService magazinoService,
                                  ICategoriaView view)
            : base(view)
        {
            _logger = logger;
            _magazinoService = magazinoService;
            _view = view;
            _view.Load += OnLoad;
            _view.FormClosing += OnFormClosing;
            _view.SalvaCategoriaRequested += View_SalvaCategoriaEvent;
            _view.CancellaCategoriaRequested += View_CancellaCategoriaEvent;
            _logger.LogDebug("Created: " + GetHashCode().ToString());
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
            await _magazinoService.DeleteCategoria(e);
            await Refresh();
        }

        private async void View_SalvaCategoriaEvent(object? s, Categoria e)
        {
            await _magazinoService.SaveCategoria(e);
            await Refresh();
        }

        #endregion

        private async Task Refresh()
        {
            var list = await _magazinoService.GetCategorie();
            _view.SetCategorie(list);
            _view.SetCategoria(new Categoria());
        }

        public override void Dispose()
        {
            base.Dispose();
            _view.Load -= OnLoad;
            _view.FormClosing -= OnFormClosing;
            _view = null!;
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
