// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.AppForm.Services;
using CiccioGest.Presentation.AppForm.Views;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Presenters
{
    public sealed class FatturaPresenter : PresenterBase, IInitializable
    {
        private readonly ILogger _logger;
        private readonly WindowService _windowService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFatturaService _fatturaService;
        private IFatturaView _view;
        private Fattura? _fattura;

        public FatturaPresenter(ILogger<FatturaPresenter> logger,
                                WindowService windowService,
                                IUnitOfWork unitOfWork,
                                IFatturaService fatturaService,
                                IFatturaView view)
            : base(view)
        {
            _logger = logger;
            _windowService = windowService;
            _unitOfWork = unitOfWork;
            _fatturaService = fatturaService;
            _view = view;

            _view.Load += OnLoad;
            _view.FormClosing += OnFormClosing;
            _view.NuovaRequested += OnNuovaRequested;
            _view.SalvaRequested += OnSalvaRequested;
            _view.ApriRequested += OnApriRequested;
            _view.NuovoDettaglioRequested += OnNuovoDettaglioRequested;
            _view.AggiungiDettaglioRequested += OnAggiungiDettaglioRequested;
            _view.RimuoviDettaglioRequested += OnRimuoviDettaglioRequested;

            _logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public async Task InitializeAsync(object? parameter)
        {
            if (parameter != null)
            {
                if (parameter is IdFatturaParameter idFatturaParam)
                {
                    await MostraFattura(idFatturaParam.IdFattura);
                }
                if (parameter is IdClienteParameter idClienteParam)
                {
                    await NuovaFattura(idClienteParam.IdCliente);
                }
            }
        }

        #region Event Handlers

        private void OnLoad(object? sender, EventArgs e) { }

        private void OnFormClosing(object? sender, FormClosingEventArgs e) { }

        private async void OnNuovaRequested(object? sender, EventArgs e)
        {
            var idCliente = await _windowService.ShowDialog<ClientiPresenter, int>(_view);
            if (idCliente != 0)
                await NuovaFattura(idCliente);
        }

        private async void OnSalvaRequested(object? sender, EventArgs e)
        {
            if (_fattura != null)
            {
                try
                {
                    await _fatturaService.SaveFattura(_fattura);
                    _unitOfWork.Commit();
                }
                catch (Exception)
                {
                    await _unitOfWork.RollbackAsync();
                    throw;
                }
            }
        }

        private async void OnApriRequested(object? sender, EventArgs e)
        {
            var idFattura = await _windowService.ShowDialog<FatturePresenter, int>(_view);
            if (idFattura != 0)
                await MostraFattura(idFattura);
        }

        private async void OnNuovoDettaglioRequested(object? sender, EventArgs e)
        {
            var idArticolo = await _windowService.ShowDialog<ArticoliPresenter, int>(_view);
            if (idArticolo != 0)
            {
                var articolo = await _fatturaService.GetArticolo(idArticolo);
                _view.SetDettaglio(new Dettaglio { Articolo = articolo, Quantita = 1 });
            }
        }

        private void OnAggiungiDettaglioRequested(object? sender, Dettaglio dettaglio)
        {
            if (dettaglio.Id == 0)
            {
                _fattura?.AddDettaglio(dettaglio);
            }
            _view.SetDettaglio(new Dettaglio(null, 0));
        }

        private void OnRimuoviDettaglioRequested(object? sender, Dettaglio dettaglio)
        {
            _fattura?.RemoveDettaglio(dettaglio);
            _view.SetDettaglio(new Dettaglio(null, 0));
        }

        #endregion

        private async Task NuovaFattura(int idCliente = 0)
        {
            if (idCliente != 0)
            {
                await _unitOfWork.BeginAsync();
                var cliente = await _fatturaService.GetCliente(idCliente);
                _fattura = new Fattura(cliente);
                _view.SetFattura(_fattura);
                _view.SetDettaglio(new Dettaglio());
            }
        }

        private async Task MostraFattura(int idFattura)
        {
            if (idFattura != 0)
            {
                await _unitOfWork.BeginAsync();
                _fattura = await _fatturaService.GetFattura(idFattura);
                _view.SetFattura(_fattura);
                _view.SetDettaglio(new Dettaglio());
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            _view.Load -= OnLoad;
            _view.FormClosing -= OnFormClosing;
            _view.NuovaRequested -= OnNuovaRequested;
            _view.SalvaRequested -= OnSalvaRequested;
            _view.ApriRequested -= OnApriRequested;
            _view.NuovoDettaglioRequested -= OnNuovoDettaglioRequested;
            _view.AggiungiDettaglioRequested -= OnAggiungiDettaglioRequested;
            _view.RimuoviDettaglioRequested -= OnRimuoviDettaglioRequested;
            _view = null!;
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
