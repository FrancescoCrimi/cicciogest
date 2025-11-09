// Copyright (c) 2016 - 2025 Francesco Crimi
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
    public sealed class MainPresenter : PresenterBase, IDisposable
    {
        private readonly ILogger _logger;
        private readonly WindowService _windowService;
        private readonly DialogService _dialogService;
        private readonly IMainView _view;        

        public MainPresenter(ILogger<MainPresenter> logger,
                             IMainView view,
                             WindowService windowService,
                             DialogService dialogService)
            : base(view)
        {
            _logger = logger;
            _view = view;
            _windowService = windowService; 
            _dialogService = dialogService;
            _view.LoadEvent += View_LoadEvent;
            _view.CloseEvent += View_CloseEvent;
            _logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        #region eventi iview

        private void View_LoadEvent(object? sender, EventArgs e)
        {
            _view.ApriFatturaEvent += View_FattureEvent;
            _view.ClientiEvent += View_ClientiEvent;
            _view.FornitoriEvent += View_FornitoriEvent;
            _view.ArticoliEvent += View_ArticoliEvent;
            _view.CategorieEvent += View_CategorieEvent;
        }

        private void View_CloseEvent(object? sender, EventArgs e)
        {
            _view.ApriFatturaEvent -= View_FattureEvent;
            _view.ClientiEvent -= View_ClientiEvent;
            _view.FornitoriEvent -= View_FornitoriEvent;
            _view.ArticoliEvent -= View_ArticoliEvent;
            _view.CategorieEvent -= View_CategorieEvent;
        }

        #endregion

        #region eventi MainView

        private void View_FattureEvent(object? sender, EventArgs e)
        {
            _windowService.OpenWindow<FatturePresenter>();
        }

        private void View_ClientiEvent(object? sender, EventArgs e)
        {
            _windowService.OpenWindow<ClientiPresenter>();
        }

        private void View_FornitoriEvent(object? sender, EventArgs e)
        {
            _windowService.OpenWindow<FornitoriPresenter>();
        }

        private void View_ArticoliEvent(object? sender, EventArgs e)
        {
            _windowService.OpenWindow<ArticoliPresenter>();
        }

        private void View_CategorieEvent(object? sender, EventArgs e)
        {
            _windowService.OpenWindow<CategoriaPresenter>();
        }

        #endregion


        public void Dispose()
        {
            _view.LoadEvent -= View_LoadEvent;
            _view.CloseEvent -= View_CloseEvent;
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
