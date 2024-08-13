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
    public sealed class SelezionaArticoloPresenter : PresenterBase, IDisposable
    {
        private readonly ILogger _logger;
        private readonly ISelezionaArticoloView _view;
        private readonly IMagazzinoService _magazinoService;
        public int IdArticolo { get; private set; }

        public SelezionaArticoloPresenter(ILogger<SelezionaArticoloPresenter> logger,
                                          ISelezionaArticoloView view,
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
            _view.CaricaArticoli(await _magazinoService.GetArticoli());
            _view.ArticoloSelezionatoEvent += View_ArticoloSelezionatoEvent;
        }

        private void View_CloseEvent(object? sender, EventArgs e)
        {
            _view.ArticoloSelezionatoEvent -= View_ArticoloSelezionatoEvent;
        }

        private void View_ArticoloSelezionatoEvent(object? sender, int e)
        {
            IdArticolo = e;
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
