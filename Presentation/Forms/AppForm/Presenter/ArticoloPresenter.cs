// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.Magazzino;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.AppForm.Services;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public sealed class ArticoloPresenter : PresenterBase, IDisposable
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMagazzinoService _magazinoService;
        private readonly WindowService _windowService;
        private readonly DialogService _dialogService;
        private readonly IArticoloView _view;
        private Articolo? articolo;

        public ArticoloPresenter(ILogger<ArticoloPresenter> logger,
                                 IUnitOfWork unitOfWork,
                                 IArticoloView view,
                                 IMagazzinoService magazinoService,
                                 WindowService windowService,
                                 DialogService dialogService)
            : base(view)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _magazinoService = magazinoService;
            _windowService = windowService;
            _dialogService = dialogService;
            _view = view;
            _view.LoadEvent += View_LoadEvent;
            _view.CloseEvent += View_CloseEvent;
            _logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public async Task NuovoArticolo()
        {
            await _unitOfWork.BeginAsync();
            articolo = new Articolo();
            MostraArticolo(articolo);
        }

        public async Task MostraArticolo(int id)
        {
            await _unitOfWork.BeginAsync();
            articolo = await _magazinoService.GetArticolo(id);
            MostraArticolo(articolo);
        }


        private void View_LoadEvent(object? sender, EventArgs e)
        {
            _view.NuovoArticoloEvent += View_NuovoArticoloEvent;
            _view.SalvaArticoloEvent += View_SalvaArticoloEvent;
            _view.EliminaArticoloEvent += View_EliminaArticoloEvent;
            _view.ApriArticoloEvent += View_ApriArticoloEvent;
            _view.AggiungiCategoriaEvent += View_AggiungiCategoriaEvent;
            _view.RimuoviCategoriaEvent += View_RimuoviCategoriaEvent;
            _view.SelezionaFornitore += View_SelezionaFornitore;
        }

        private void View_CloseEvent(object? sender, EventArgs e)
        {
            _view.NuovoArticoloEvent -= View_NuovoArticoloEvent;
            _view.SalvaArticoloEvent -= View_SalvaArticoloEvent;
            _view.EliminaArticoloEvent -= View_EliminaArticoloEvent;
            _view.ApriArticoloEvent -= View_ApriArticoloEvent;
            _view.AggiungiCategoriaEvent -= View_AggiungiCategoriaEvent;
            _view.RimuoviCategoriaEvent -= View_RimuoviCategoriaEvent;
            _view.SelezionaFornitore -= View_SelezionaFornitore;
        }

        private async void View_NuovoArticoloEvent(object? sender, EventArgs e)
            => await NuovoArticolo();

        private async void View_SalvaArticoloEvent(object? sender, EventArgs e)
        {
            if (articolo != null)
            {
                try
                {
                    await _magazinoService.SaveArticolo(articolo);
                    await _unitOfWork.CommitAsync();
                }
                catch (Exception)
                {
                    await _unitOfWork.RollbackAsync();
                    throw;
                }
                finally
                {
                    await _unitOfWork.BeginAsync();
                }
            }
        }

        private async void View_EliminaArticoloEvent(object? sender, int e)
        {
            try
            {
                await _magazinoService.DeleteArticolo(e);
                await _unitOfWork.CommitAsync();
                await NuovoArticolo();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
            finally
            {
                await _unitOfWork.BeginAsync();
            }
        }

        private async void View_ApriArticoloEvent(object? sender, EventArgs e)
        {
            var sav = _dialogService.OpenDialog<SelezionaArticoloPresenter>(_view);
            if (sav?.IdArticolo != 0)
            {
                await MostraArticolo(sav!.IdArticolo);
            }
        }

        private async void View_AggiungiCategoriaEvent(object? sender, EventArgs e)
        {
            var scp = _dialogService.OpenDialog<SelezionaCategoriaPresenter>(_view);
            if (scp?.IdCategoria != 0)
            {
                Categoria categoria = await _magazinoService.GetCategoria(scp!.IdCategoria);
                articolo?.AddCategoria(categoria);
            }
        }

        private void View_RimuoviCategoriaEvent(object? sender, Categoria e)
        {
            articolo?.RemoveCategoria(e);
        }

        private async void View_SelezionaFornitore(object? sender, EventArgs e)
        {
            if (articolo != null)
            {
                var sfp = _dialogService.OpenDialog<SelezionaFornitorePresenter>(_view);
                if (sfp?.IdFornitore != 0)
                {
                    var fornitore = await _magazinoService.GetFornitore(sfp!.IdFornitore);
                    articolo.Fornitore = fornitore;
                } 
            }
        }


        private void MostraArticolo(Articolo articolo)
        {
            _view.SetArticolo(articolo);
            _view.SetCategorie(articolo.Categorie);
        }


        public void Dispose()
        {
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
