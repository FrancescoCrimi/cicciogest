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
    public sealed class ClientePresenter : PresenterBase
    {
        private readonly ILogger _logger;
        private readonly WindowService _windowService;
        private readonly IAnagraficaService _anagraficaService;
        private IClienteView _view;

        public ClientePresenter(ILogger<ClientePresenter> logger,
                                WindowService windowService,
                                IAnagraficaService anagraficaService,
                                IClienteView view)
            : base(view)
        {
            _logger = logger;
            _windowService = windowService;
            _anagraficaService = anagraficaService;
            _view = view;
            _view.Load += OnLoad;
            _view.FormClosing += OnFormClosing;
            _view.NuovoRequested += OnNuovoRequested;
            _view.SalvaRequested += OnSalvaRequested;
            _view.ApriRequested += OnApriRequested;
            _view.EliminaRequested += OnEliminaRequested;
            _logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public void NuovoCliente()
            => _view.MostraCliente(new Cliente());

        public async void ApriCliente(int idCliente)
            => _view.MostraCliente(await _anagraficaService.GetCliente(idCliente));

        #region Event Handlers

        private void OnLoad(object? sender, EventArgs e)
        {
            _view.MostraCliente(new Cliente());
        }

        private void OnFormClosing(object? sender, FormClosingEventArgs e)
        {
        }

        private void OnNuovoRequested(object? sender, EventArgs e)
        {
            _view.MostraCliente(new Cliente());
        }

        private void OnSalvaRequested(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void OnApriRequested(object? sender, EventArgs e)
        {
            var idCliente = await _windowService.ShowDialog<ClientiPresenter, int>(_view);
            if (idCliente != 0)
            {
                ApriCliente(idCliente);
            }
        }

        private void OnEliminaRequested(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        public override void Dispose()
        {
            base.Dispose();
            _view.Load -= OnLoad;
            _view.FormClosing -= OnFormClosing;
            _view.ApriRequested -= OnApriRequested;
            _view.NuovoRequested -= OnNuovoRequested;
            _view.SalvaRequested -= OnSalvaRequested;
            _view.EliminaRequested -= OnEliminaRequested;
            _view = null!;
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
