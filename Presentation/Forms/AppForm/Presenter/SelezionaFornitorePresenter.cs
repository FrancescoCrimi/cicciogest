// Copyright (c) 2016 - 2025 Francesco Crimi
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
    public sealed class SelezionaFornitorePresenter : PresenterBase, IDisposable
    {
        private readonly ILogger _logger;
        private readonly ISelezionaFornitoreView _view;
        private readonly IClientiFornitoriService _clientiFornitoriService;
        public int IdFornitore { get; private set; }

        public SelezionaFornitorePresenter(ILogger<SelezionaFornitorePresenter> logger,
                                           ISelezionaFornitoreView view,
                                           IClientiFornitoriService clientiFornitoriService)
            : base(view)
        {
            _logger = logger;
            _view = view;
            _clientiFornitoriService = clientiFornitoriService;
            _view.LoadEvent += View_LoadEvent;
            _view.CloseEvent += View_CloseEvent;
            _logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        private async void View_LoadEvent(object? sender, EventArgs e)
        {
            _view.FornitoreSelezionatoEvent += View_FornitoreSelezionatoEvent;
            _view.CaricaFornitori(await _clientiFornitoriService.GetFornitori());
        }

        private void View_CloseEvent(object? sender, EventArgs e)
        {
            _view.FornitoreSelezionatoEvent -= View_FornitoreSelezionatoEvent;
        }

        private void View_FornitoreSelezionatoEvent(object? sender, int e)
        {
            IdFornitore = e;
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
