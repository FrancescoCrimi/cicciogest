// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.Magazzino;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public sealed class CategoriaPresenter : PresenterBase, IDisposable
    {
        private readonly ILogger _logger;
        private readonly ICategoriaView _view;
        private readonly IMagazzinoService _magazinoService;

        public CategoriaPresenter(ILogger<CategoriaPresenter> logger,
                                  ICategoriaView view,
                                  IMagazzinoService magazinoService)
            : base(view)
        {
            _logger = logger;
            _view = view;
            _magazinoService = magazinoService;
            _view.LoadEvent += View_LoadEvent;
            _view.CloseEvent += View_CloseEvent;
            _view.SalvaCategoriaEvent += View_SalvaCategoriaEvent;
            _view.CancellaCategoriaEvent += View_CancellaCategoriaEvent;
            _logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        private async void View_LoadEvent(object? sender, EventArgs e)
        {
            await Refresh();
        }

        private void View_CloseEvent(object? sender, EventArgs e)
        {
            //throw new NotImplementedException();
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

        private async Task Refresh()
        {
            var list = await _magazinoService.GetCategorie();
            _view.SetCategorie(list);
            _view.SetCategoria(new Categoria());
        }

        public void Dispose()
        {
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
