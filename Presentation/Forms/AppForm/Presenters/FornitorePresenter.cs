// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.Anagrafica;
using CiccioGest.Presentation.AppForm.Services;
using CiccioGest.Presentation.AppForm.Views;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Presenters
{
    public sealed class FornitorePresenter : PresenterBase, IInitializable
    {
        private readonly ILogger _logger;
        private readonly WindowService _windowService;
        private readonly IAnagraficaService _anagraficaService;
        private IFornitoreView _view;
        private bool _disposedValue;

        public FornitorePresenter(ILogger<FornitorePresenter> logger,
                                  WindowService windowService,
                                  IAnagraficaService anagraficaService,
                                  IFornitoreView view)
            : base(view)
        {
            _logger = logger;
            _view = view;
            _anagraficaService = anagraficaService;
            _windowService = windowService;

            _view.Load += OnLoad;
            _view.FormClosing += OnFormClosing;
            _view.ApriRequested += View_ApriFornitore;
            _view.NuovoRequested += View_NuovoFornitore;
            _view.SalvaRequested += View_SalvaFornitore;

            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }


        public Task InitializeAsync(object? parameter)
        {
            throw new NotImplementedException();
        }

        private void NuovoFornitore()
            => _view.MostraFornitore(new Fornitore());

        private async void ApriFornitore(int idFornitore)
            => _view.MostraFornitore(await _anagraficaService.GetFornitore(idFornitore));


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
            NuovoFornitore();
        }

        private async void View_ApriFornitore(object? sender, EventArgs e)
        {
            var id = await _windowService.ShowDialogAsync<FornitoriPresenter>(_view);
            if (id != 0)
                ApriFornitore(id);
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // Libera le risorse specifiche della classe figlia
                    _view.Load -= OnLoad;
                    _view.FormClosing -= OnFormClosing;
                    _view.ApriRequested -= View_ApriFornitore;
                    _view.NuovoRequested -= View_NuovoFornitore;
                    _view.SalvaRequested -= View_SalvaFornitore;
                    _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
                }

                // Chiama sempre la base alla fine
                _view = null!;
                base.Dispose(disposing);
                _disposedValue = true;
            }
        }
    }
}
