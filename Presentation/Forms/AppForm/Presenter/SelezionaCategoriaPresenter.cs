// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public sealed class SelezionaCategoriaPresenter : PresenterBase, IDisposable
    {
        private readonly ILogger _logger;
        private readonly ISelezionaCategoriaView _view;
        private readonly IMagazzinoService _magazinoService;
        public int IdCategoria { get; private set; }

        public SelezionaCategoriaPresenter(ILogger<SelezionaCategoriaPresenter> logger,
                                           ISelezionaCategoriaView view,
                                           IMagazzinoService magazinoService)
            : base(view)
        {
            _logger = logger;
            _view = view;
            _magazinoService = magazinoService;
            _view.LoadEvent += View_LoadEvent;
            _view.CloseEvent += View_CloseEvent;
            _logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        private async void View_LoadEvent(object? sender, EventArgs e)
        {
            _view.CategoriaSelezionataEvent += View_CategoriaSelezionataEvent;
            _view.CaricaCategorie(await _magazinoService.GetCategorie());
        }

        private void View_CloseEvent(object? sender, EventArgs e)
        {
            _view.CategoriaSelezionataEvent -= View_CategoriaSelezionataEvent;
        }

        private void View_CategoriaSelezionataEvent(object? sender, int e)
        {
            IdCategoria = e;
            _view.Close();
        }

        public void Dispose()
        {
            _view.LoadEvent -= View_LoadEvent;
            _view.CloseEvent -= View_CloseEvent;
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
