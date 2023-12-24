// Copyright (c) 2023 Francesco Crimi
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
    public class SelezionaFornitorePresenter : PresenterBase, IDisposable
    {
        private readonly ILogger logger;
        private readonly ISelezionaFornitoreView view;
        private readonly IClientiFornitoriService clientiFornitoriService;
        public int IdFornitore { get; private set; }

        public SelezionaFornitorePresenter(ILogger<SelezionaFornitorePresenter> logger,
                                           ISelezionaFornitoreView view,
                                           IClientiFornitoriService clientiFornitoriService)
            : base(view)
        {
            this.logger = logger;
            this.view = view;
            this.clientiFornitoriService = clientiFornitoriService;
            view.LoadEvent += View_LoadEvent;
            view.CloseEvent += View_CloseEvent;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        private async void View_LoadEvent(object? sender, EventArgs e)
        {
            view.FornitoreSelezionatoEvent += View_FornitoreSelezionatoEvent;
            view.CaricaFornitori(await clientiFornitoriService.GetFornitori());
        }

        private void View_CloseEvent(object? sender, EventArgs e)
        {
            view.FornitoreSelezionatoEvent -= View_FornitoreSelezionatoEvent;
        }

        private void View_FornitoreSelezionatoEvent(object? sender, int e)
        {
            IdFornitore = e;
            view.Close();
        }

        public void Dispose()
        {
            view.LoadEvent -= View_LoadEvent;
            view.CloseEvent -= View_CloseEvent;
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
