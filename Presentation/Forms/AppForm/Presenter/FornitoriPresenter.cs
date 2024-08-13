// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Presentation.AppForm.Services;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public sealed class FornitoriPresenter : PresenterBase, IDisposable
    {
        private readonly ILogger _logger;
        private readonly IFornitoriView _view;
        private readonly IClientiFornitoriService _clientiFornitoriService;
        private readonly WindowService _windowService;

        public FornitoriPresenter(ILogger<FornitoriPresenter> logger,
                                  IFornitoriView view,
                                  IClientiFornitoriService clientiFornitoriService,
                                  WindowService windowService)
            : base(view)
        {
            _logger = logger;
            _view = view;
            _clientiFornitoriService = clientiFornitoriService;
            _windowService = windowService;
            _view.LoadEvent += View_LoadEvent;
            _view.CloseEvent += View_CloseEvent;
            _logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        private async void View_LoadEvent(object? sender, EventArgs e)
        {
            _view.FornitoreSelezionatoEvent += View_FornitoreSelezionatoEvent;
            _view.NuovoFornitoreEvent += View_NuovoFornitoreEvent;
            _view.CaricaFornitori(await _clientiFornitoriService.GetFornitori());
        }

        private void View_CloseEvent(object? sender, EventArgs e)
        {
            _view.FornitoreSelezionatoEvent -= View_FornitoreSelezionatoEvent;
            _view.NuovoFornitoreEvent -= View_NuovoFornitoreEvent;
        }

        private void View_FornitoreSelezionatoEvent(object? sender, int e)
        {
            _windowService?.OpenWindow<FornitorePresenter>()?.ApriFornitore(e);
            _view.Close();
        }

        private void View_NuovoFornitoreEvent(object? sender, EventArgs e)
        {
            _windowService?.OpenWindow<FornitorePresenter>()?.NuovoFornitore();
            _view.Close();
        }

        public void Dispose()
        {
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
