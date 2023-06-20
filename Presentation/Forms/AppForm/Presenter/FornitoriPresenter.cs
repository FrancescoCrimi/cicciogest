// Copyright (c) 2023 Francesco Crimi
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
    public class FornitoriPresenter : PresenterBase, IDisposable
    {
        private readonly ILogger logger;
        private readonly IFornitoriView view;
        private readonly IClientiFornitoriService clientiFornitoriService;
        private readonly WindowService windowService;

        public FornitoriPresenter(ILogger<FornitoriPresenter> logger,
                                  IFornitoriView view,
                                  IClientiFornitoriService clientiFornitoriService,
                                  WindowService windowService)
            : base(view)
        {
            this.logger = logger;
            this.view = view;
            this.clientiFornitoriService = clientiFornitoriService;
            this.windowService = windowService;
            view.LoadEvent += View_LoadEvent;
            view.CloseEvent += View_CloseEvent;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        private async void View_LoadEvent(object sender, EventArgs e)
        {
            view.FornitoreSelezionatoEvent += View_FornitoreSelezionatoEvent;
            view.NuovoFornitoreEvent += View_NuovoFornitoreEvent;
            view.CaricaFornitori(await clientiFornitoriService.GetFornitori());
        }

        private void View_CloseEvent(object sender, EventArgs e)
        {
            view.FornitoreSelezionatoEvent -= View_FornitoreSelezionatoEvent;
            view.NuovoFornitoreEvent -= View_NuovoFornitoreEvent;
        }

        private void View_FornitoreSelezionatoEvent(object sender, int e)
        {
            windowService.OpenWindow<FornitorePresenter>().ApriFornitore(e);
            view.Close();
        }

        private void View_NuovoFornitoreEvent(object sender, EventArgs e)
        {
            windowService.OpenWindow<FornitorePresenter>().NuovoFornitore();
            view.Close();
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
