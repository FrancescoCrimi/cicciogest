// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.AppForm.Services;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public class MainPresenter : PresenterBase, IDisposable
    {
        private readonly ILogger logger;
        private readonly WindowService windowService;
        private readonly DialogService dialogService;
        private readonly IMainView view;        

        public MainPresenter(ILogger<MainPresenter> logger,
                             IMainView view,
                             WindowService windowService,
                             DialogService dialogService)
            : base(view)
        {
            this.logger = logger;
            this.view = view;
            this.windowService = windowService; 
            this.dialogService = dialogService;
            view.LoadEvent += View_LoadEvent;
            view.CloseEvent += View_CloseEvent;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        #region eventi iview

        private void View_LoadEvent(object? sender, EventArgs e)
        {
            view.FattureEvent += View_FattureEvent;
            view.ClientiEvent += View_ClientiEvent;
            view.FornitoriEvent += View_FornitoriEvent;
            view.ArticoliEvent += View_ArticoliEvent;
            view.CategorieEvent += View_CategorieEvent;
        }

        private void View_CloseEvent(object? sender, EventArgs e)
        {
            view.FattureEvent -= View_FattureEvent;
            view.ClientiEvent -= View_ClientiEvent;
            view.FornitoriEvent -= View_FornitoriEvent;
            view.ArticoliEvent -= View_ArticoliEvent;
            view.CategorieEvent -= View_CategorieEvent;
        }

        #endregion

        #region eventi MainView

        private void View_FattureEvent(object? sender, EventArgs e)
        {
            windowService.OpenWindow<FatturePresenter>();
        }

        private void View_ClientiEvent(object? sender, EventArgs e)
        {
            windowService.OpenWindow<ClientiPresenter>();
        }

        private void View_FornitoriEvent(object? sender, EventArgs e)
        {
            windowService.OpenWindow<FornitoriPresenter>();
        }

        private void View_ArticoliEvent(object? sender, EventArgs e)
        {
            windowService.OpenWindow<ArticoliPresenter>();
        }

        private void View_CategorieEvent(object? sender, EventArgs e)
        {
            windowService.OpenWindow<CategoriaPresenter>();
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
