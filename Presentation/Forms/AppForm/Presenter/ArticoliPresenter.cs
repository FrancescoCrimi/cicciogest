// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.AppForm.Services;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public sealed class ArticoliPresenter : PresenterBase, IDisposable
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IArticoliView _view;
        private readonly IMagazzinoService _magazinoService;
        private readonly WindowService _windowService;

        public int IdProdotto { get; private set; }

        public ArticoliPresenter(ILogger<ArticoliPresenter> logger,
                                 IUnitOfWork unitOfWork,
                                 IArticoliView view,
                                 IMagazzinoService magazinoService,
                                 WindowService windowService)
            : base(view)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _view = view;
            _magazinoService = magazinoService;
            _windowService = windowService;
            _view.LoadEvent += View_LoadEvent;
            _view.CloseEvent += View_CloseEvent;
            _logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        private async void View_LoadEvent(object? sender, EventArgs e)
        {
            await _unitOfWork.BeginAsync();
            _view.CaricaArticoli(await _magazinoService.GetArticoli());
            _view.NuovoArticoloEvent += View_NuovoArticoloEvent;
            _view.ArticoloSelezionatoEvent += View_ArticoloSelezionatoEvent;
        }

        private void View_CloseEvent(object? sender, EventArgs e)
        {
            _view.NuovoArticoloEvent -= View_NuovoArticoloEvent;
            _view.ArticoloSelezionatoEvent -= View_ArticoloSelezionatoEvent;
        }

        private void View_NuovoArticoloEvent(object? sender, EventArgs e)
        {
            _windowService.OpenWindow<ArticoloPresenter>();
            _view.Close();
        }

        private async void View_ArticoloSelezionatoEvent(object? sender, int e)
        {
            IdProdotto = e;
            var ap = _windowService.OpenWindow<ArticoloPresenter>();
            if (ap != null)
                await ap.MostraArticolo(e);
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
