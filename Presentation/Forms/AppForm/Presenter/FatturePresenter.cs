// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.AppForm.Services;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public sealed class FatturePresenter : PresenterBase, IDisposable
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFattureView _view;
        private readonly IFatturaService _fatturaService;
        private readonly WindowService _windowService;
        private readonly DialogService _dialogService;

        public FatturePresenter(ILogger<FatturePresenter> logger,
                                IUnitOfWork unitOfWork,
                                IFattureView view,
                                IFatturaService fatturaService,
                                WindowService windowService,
                                DialogService dialogService)
            : base(view)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _view = view;
            _fatturaService = fatturaService;
            _windowService = windowService;
            _dialogService = dialogService;
            _view.LoadEvent += View_LoadEvent;
            _view.CloseEvent += View_CloseEvent;
            _logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        #region eventi iview

        private async void View_LoadEvent(object? sender, EventArgs e)
        {
            _view.FatturaSelezionataEvent += View_SelectFatturaEvent;
            _view.NuovaFatturaEvent += View_NuovaFatturaEvent;
            await _unitOfWork.BeginAsync();
            IList<Fattura> fatture = await _fatturaService.GetFatture();
            _view.CaricaFatture(fatture);
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
            _windowService?.OpenWindow<FatturaPresenter>()?.MostraFattura(e);
            _view.Close();
        }

        private void View_NuovaFatturaEvent(object? sender, EventArgs e)
        {
            var lcd = _dialogService.OpenDialog<SelezionaClientePresenter>(_view);
            if (lcd?.IdCliente != 0)
            {
                var fp = _windowService.OpenWindow<FatturaPresenter>();
                fp?.NuovaFattura(lcd!.IdCliente);
                _view.Close();
            }
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
