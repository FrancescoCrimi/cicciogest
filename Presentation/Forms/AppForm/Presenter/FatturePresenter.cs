// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.AppForm.Services;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public class FatturePresenter : PresenterBase, IDisposable
    {
        private readonly ILogger logger;
        private readonly IFattureView view;
        private readonly IFatturaService fatturaService;
        private readonly WindowService windowService;
        private readonly DialogService dialogService;

        public FatturePresenter(ILogger<FatturePresenter> logger,
                                IFattureView view,
                                IFatturaService fatturaService,
                                WindowService windowService,
                                DialogService dialogService)
            : base(view)
        {
            this.logger = logger;
            this.view = view;
            this.fatturaService = fatturaService;
            this.windowService = windowService;
            this.dialogService = dialogService;
            view.LoadEvent += View_LoadEvent;
            view.CloseEvent += View_CloseEvent;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        #region eventi iview

        private async void View_LoadEvent(object? sender, EventArgs e)
        {
            view.FatturaSelezionataEvent += View_SelectFatturaEvent;
            view.NuovaFatturaEvent += View_NuovaFatturaEvent;
            IList<FatturaReadOnly> fatture = await fatturaService.GetFatture();
            view.CaricaFatture(fatture);
        }

        private void View_CloseEvent(object? sender, EventArgs e)
        {
            if (sender is IFattureView listaFattureView)
            {
                listaFattureView.FatturaSelezionataEvent -= View_SelectFatturaEvent;
                listaFattureView.NuovaFatturaEvent -= View_NuovaFatturaEvent;
            }
        }

        #endregion


        #region eventi IFattureView

        private void View_SelectFatturaEvent(object? sender, int e)
        {
            windowService.OpenWindow<FatturaPresenter>().MostraFattura(e);
            view.Close();
        }

        private void View_NuovaFatturaEvent(object? sender, EventArgs e)
        {
            var lcd = dialogService.OpenDialog<SelezionaClientePresenter>(view);
            if (lcd.IdCliente != 0)
            {
                var fp = windowService.OpenWindow<FatturaPresenter>();
                fp.NuovaFattura(lcd.IdCliente);
                view.Close();
            }
        }

        #endregion


        public void Dispose()
        {
            view.LoadEvent -= View_LoadEvent;
            view.CloseEvent -= View_CloseEvent;
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
