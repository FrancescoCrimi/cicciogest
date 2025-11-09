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

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public sealed class FatturaPresenter : PresenterBase, IDisposable
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly WindowService _windowService;
        private readonly DialogService _dialogService;
        private readonly IFatturaService _fatturaService;
        private readonly IFatturaView _view;
        private Fattura? _fattura;

        public FatturaPresenter(ILogger<FatturaPresenter> logger,
                                IUnitOfWork unitOfWork,
                                IFatturaView view,
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

        #region public method

        public async void NuovaFattura(int idCliente = 0)
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

        public async void MostraFattura(int idFattura)
        {
            if (idFattura != 0)
            {
                await _unitOfWork.BeginAsync();
                _fattura = await _fatturaService.GetFattura(idFattura);
                _view.SetFattura(_fattura);
                _view.SetDettaglio(new Dettaglio());
            }
        }

        #endregion


        #region Gestione eventi

        private void View_LoadEvent(object? sender, EventArgs e)
        {
            _view.NuovaFatturaEvent += View_NuovaFatturaEvent;
            _view.SalvaFatturaEvent += View_SalvaFatturaEvent;
            _view.ApriFatturaEvent += View_ApriFatturaEvent;
            _view.NuovoDettaglioEvent += View_NuovoDettaglioEvent;
            _view.AggiungiDettaglioEvent += View_AggiungiDettaglioEvent;
            _view.RimuoviDettaglioEvent += View_RimuoviDettaglioEvent;
        }

        private void View_CloseEvent(object? sender, EventArgs e)
        {
            _view.NuovaFatturaEvent -= View_NuovaFatturaEvent;
            _view.SalvaFatturaEvent -= View_SalvaFatturaEvent;
            _view.ApriFatturaEvent -= View_ApriFatturaEvent;
            _view.NuovoDettaglioEvent -= View_NuovoDettaglioEvent;
            _view.AggiungiDettaglioEvent -= View_AggiungiDettaglioEvent;
            _view.RimuoviDettaglioEvent -= View_RimuoviDettaglioEvent;
        }

        private void View_NuovaFatturaEvent(object? sender, EventArgs e)
        {
            var scp = _dialogService.OpenDialog<SelezionaClientePresenter>(_view);
            if (scp?.IdCliente != 0)
                NuovaFattura(scp!.IdCliente);
        }

        private async void View_SalvaFatturaEvent(object? sender, EventArgs e)
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


        private void View_ApriFatturaEvent(object? sender, EventArgs e)
        {
            var sfp = _dialogService.OpenDialog<SelezionaFatturaPresenter>(_view);
            if (sfp?.IdFattura != 0)
                MostraFattura(sfp!.IdFattura);
        }

        private async void View_NuovoDettaglioEvent(object? sender, EventArgs e)
        {
            var spv = _dialogService.OpenDialog<SelezionaArticoloPresenter>(_view);
            if (spv?.IdArticolo != 0)
            {
                var articolo = await _fatturaService.GetArticolo(spv!.IdArticolo);
                _view.SetDettaglio(new Dettaglio { Articolo = articolo, Quantita = 1 });
            }
        }

        private void View_AggiungiDettaglioEvent(object? sender, Dettaglio dettaglio)
        {
            if (dettaglio.Id == 0)
            {
                _fattura?.AddDettaglio(dettaglio);
            }
            _view.SetDettaglio(new Dettaglio(null, 0));
        }

        private void View_RimuoviDettaglioEvent(object? sender, Dettaglio dettaglio)
        {
            _fattura?.RemoveDettaglio(dettaglio);
            _view.SetDettaglio(new Dettaglio(null, 0));
        }

        #endregion


        public void Dispose()
        {
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
