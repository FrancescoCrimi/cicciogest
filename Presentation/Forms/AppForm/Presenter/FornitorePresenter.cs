// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Presentation.AppForm.Services;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public sealed class FornitorePresenter : PresenterBase, IDisposable
    {
        private readonly ILogger _logger;
        private readonly IFornitoreView _view;
        private readonly IClientiFornitoriService _clientiFornitoriService;
        private readonly WindowService _windowService;

        public FornitorePresenter(ILogger<FornitorePresenter> logger,
                                  IFornitoreView view,
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

        #region Metodi Pubblici

        public void NuovoFornitore()
            => _view.MostraFornitore(new Fornitore());

        public async void ApriFornitore(int idFornitore)
            => _view.MostraFornitore(await _clientiFornitoriService.GetFornitore(idFornitore));

        #endregion

        #region Gestione eventi

        private void View_LoadEvent(object? sender, EventArgs e)
        {
            _view.ApriFornitore += View_ApriFornitore;
            _view.NuovoFornitore += View_NuovoFornitore;
            _view.SalvaFornitore += View_SalvaFornitore;
        }

        private void View_CloseEvent(object? sender, EventArgs e)
        {
            _view.ApriFornitore -= View_ApriFornitore;
            _view.NuovoFornitore -= View_NuovoFornitore;
            _view.SalvaFornitore -= View_SalvaFornitore;
        }


        private void View_SalvaFornitore(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void View_NuovoFornitore(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void View_ApriFornitore(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        public void Dispose()
        {
            _view.LoadEvent -= View_LoadEvent;
            _view.CloseEvent -= View_CloseEvent;
        }
    }
}
