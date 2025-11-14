// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.Anagrafica;
using CiccioGest.Presentation.AppForm.Services;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public sealed class FornitorePresenter : PresenterBase, IInitializable
    {
        private readonly ILogger _logger;
        private readonly WindowService _windowService;
        private readonly IAnagraficaService _clientiFornitoriService;
        private IFornitoreView _view;

        public FornitorePresenter(ILogger<FornitorePresenter> logger,
                                  WindowService windowService,
                                  IAnagraficaService clientiFornitoriService,
                                  IFornitoreView view)
            : base(view)
        {
            _logger = logger;
            _view = view;
            _clientiFornitoriService = clientiFornitoriService;
            _windowService = windowService;
            _view.Load += OnLoad;
            _view.FormClosing += OnFormClosing;
            _view.ApriRequested += View_ApriFornitore;
            _view.NuovoRequested += View_NuovoFornitore;
            _view.SalvaRequested += View_SalvaFornitore;
            _logger.LogDebug("Created: " + GetHashCode().ToString());
        }


        public Task InitializeAsync(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void NuovoFornitore()
            => _view.MostraFornitore(new Fornitore());

        public async void ApriFornitore(int idFornitore)
            => _view.MostraFornitore(await _clientiFornitoriService.GetFornitore(idFornitore));


        #region Event Handlers

        private void OnLoad(object? sender, EventArgs e)
        {
        }

        private void OnFormClosing(object? sender, FormClosingEventArgs e)
        {
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

        public override void Dispose()
        {
            base.Dispose();
            _view.Load -= OnLoad;
            _view.FormClosing -= OnFormClosing;
            _view.ApriRequested -= View_ApriFornitore;
            _view.NuovoRequested -= View_NuovoFornitore;
            _view.SalvaRequested -= View_SalvaFornitore;
            _view = null!;
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
