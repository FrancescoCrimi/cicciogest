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
    public sealed class SelezionaFatturaPresenter : PresenterBase, IDisposable
    {
        private readonly ILogger _logger;
        private readonly ISelezionaFatturaView _view;
        private readonly IFatturaService _fatturaService;
        public int IdFattura { get; private set; }

        public SelezionaFatturaPresenter(ILogger<SelezionaFatturaPresenter> logger,
                                         ISelezionaFatturaView view,
                                         IFatturaService fatturaService)
            : base(view)
        {
            _logger = logger;
            _view = view;
            _fatturaService = fatturaService;
            _view.LoadEvent += View_LoadEvent;
            _view.CloseEvent += View_CloseEvent;
            _logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        private async void View_LoadEvent(object? sender, EventArgs e)
        {
            _view.FatturaSelezionataEvent += View_FatturaSelezionataEvent;
            _view.CaricaFatture(await _fatturaService.GetFatture());
        }

        private void View_CloseEvent(object? sender, EventArgs e)
        {
            _view.FatturaSelezionataEvent += View_FatturaSelezionataEvent;
        }

        private void View_FatturaSelezionataEvent(object? sender, int e)
        {
            IdFattura = e;
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
