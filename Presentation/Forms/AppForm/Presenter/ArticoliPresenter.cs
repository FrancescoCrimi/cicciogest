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
    public class ArticoliPresenter : PresenterBase, IDisposable
    {
        private readonly ILogger logger;
        private readonly IArticoliView view;
        private readonly IMagazinoService magazinoService;
        private readonly WindowService windowService;

        public int IdProdotto { get; private set; }

        public ArticoliPresenter(ILogger<ArticoliPresenter> logger,
                                 IArticoliView view,
                                 IMagazinoService magazinoService,
                                 WindowService windowService)
            : base(view)
        {
            this.logger = logger;
            this.view = view;
            this.magazinoService = magazinoService;
            this.windowService = windowService;
            view.LoadEvent += View_LoadEvent;
            view.CloseEvent += View_CloseEvent;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        private async void View_LoadEvent(object sender, EventArgs e)
        {
            view.CaricaArticoli(await magazinoService.GetArticoli());
            view.NuovoArticoloEvent += View_NuovoArticoloEvent;
            view.ArticoloSelezionatoEvent += View_ArticoloSelezionatoEvent;
        }

        private void View_CloseEvent(object sender, EventArgs e)
        {
            view.NuovoArticoloEvent -= View_NuovoArticoloEvent;
            view.ArticoloSelezionatoEvent -= View_ArticoloSelezionatoEvent;
        }

        private void View_NuovoArticoloEvent(object sender, EventArgs e)
        {
            windowService.OpenWindow<ArticoloPresenter>();
            view.Close();
        }

        private async void View_ArticoloSelezionatoEvent(object sender, int e)
        {
            IdProdotto = e;
            var ap = windowService.OpenWindow<ArticoloPresenter>();
            await ap.MostraArticolo(e);
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
