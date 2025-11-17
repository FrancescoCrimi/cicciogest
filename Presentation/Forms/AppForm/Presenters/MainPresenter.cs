// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.AppForm.Services;
using CiccioGest.Presentation.AppForm.Views;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Presenters
{
    public sealed class MainPresenter : PresenterBase, IDisposable
    {
        private readonly ILogger _logger;
        private readonly WindowService _windowService;
        private IMainView _view;

        public MainPresenter(ILogger<MainPresenter> logger,
                             WindowService windowService,
                             IMainView view)
            : base(view)
        {
            _logger = logger;
            _view = view;
            _windowService = windowService;
            _view.Load += OnLoad;
            _view.FormClosing += OnFormClosing;
            _view.NuovaFatturaRequested += OnNuovaFatturaRequested;
            _view.ApriFatturaRequested += OnApriFatturaRequested;
            _view.ClientiRequested += OnClientiRequested;
            _view.FornitoriRequested += OnFornitoriRequested;
            _view.ArticoliRequested += OnArticoliRequested;
            _view.CategorieRequested += OnCategorieRequested;
            _logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public void Run()
        {
            System.Windows.Forms.Application.Run((Form)_view);
        }

        #region Event Handlers

        private void OnLoad(object? sender, EventArgs e) { }

        private void OnFormClosing(object? sender, FormClosingEventArgs e) { }

        private async void OnNuovaFatturaRequested(object? sender, EventArgs e)
        {
            var idCliente = await _windowService.ShowDialog<ClientiPresenter, int>(_view);
            if (idCliente != 0)
            {
               await _windowService.Show<FatturaPresenter>(new IdClienteParameter(idCliente));
            }
        }

        private async void OnApriFatturaRequested(object? sender, EventArgs e)
        {
            var idFattura = await _windowService.ShowDialog<FatturePresenter, int>(_view);
            if (idFattura != 0)
            {
               await _windowService.Show<FatturaPresenter>(new IdFatturaParameter(idFattura));
            }
        }

        private async void OnClientiRequested(object? sender, EventArgs e)
        {
           await _windowService.Show<ClientePresenter>();
        }

        private async void OnFornitoriRequested(object? sender, EventArgs e)
        {
          await  _windowService.Show<FornitorePresenter>();
        }

        private async void OnArticoliRequested(object? sender, EventArgs e)
        {
          await  _windowService.Show<ArticoloPresenter>();
        }

        private async void OnCategorieRequested(object? sender, EventArgs e)
        {
          await  _windowService.Show<CategoriaPresenter>();
        }

        #endregion

        public override void Dispose()
        {
            base.Dispose();
            _view.Load -= OnLoad;
            _view.FormClosing -= OnFormClosing;
            _view.ApriFatturaRequested -= OnApriFatturaRequested;
            _view.ClientiRequested -= OnClientiRequested;
            _view.FornitoriRequested -= OnFornitoriRequested;
            _view.ArticoliRequested -= OnArticoliRequested;
            _view.CategorieRequested -= OnCategorieRequested;
            _view = null!;
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
