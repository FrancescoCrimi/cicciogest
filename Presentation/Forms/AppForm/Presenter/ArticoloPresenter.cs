// Copyright (c) 2016 - 2025 Francesco Crimi
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
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public sealed class ArticoloPresenter : PresenterBase, IInitializable
    {
        private readonly ILogger _logger;
        private readonly WindowService _windowService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMagazzinoService _magazinoService;
        private IArticoloView _view;
        private Articolo? articolo;

        public ArticoloPresenter(ILogger<ArticoloPresenter> logger,
                                 WindowService windowService,
                                 IUnitOfWork unitOfWork,
                                 IMagazzinoService magazinoService,
                                 IArticoloView view)
            : base(view)
        {
            _logger = logger;
            _windowService = windowService;
            _unitOfWork = unitOfWork;
            _magazinoService = magazinoService;
            _view = view;
            _view.Load += OnLoad;
            _view.FormClosing += OnFormClosing;
            _view.NuovoArticoloRequested += OnNuovoArticoloRequested;
            _view.SalvaArticoloRequested += OnSalvaArticoloRequested;
            _view.EliminaArticoloRequested += OnEliminaArticoloRequested;
            _view.ApriArticoloRequested += OnApriArticoloRequested;
            _view.AggiungiCategoriaRequested += OnAggiungiCategoriaRequested;
            _view.RimuoviCategoriaRequested += OnRimuoviCategoriaRequested;
            _view.SelezionaFornitoreRequested += OnSelezionaFornitoreRequested;
            _logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public Task InitializeAsync(object? parameter)
        {
            throw new NotImplementedException();
        }

        #region Event Handlers

        private void OnLoad(object? sender, EventArgs e)
        {
        }

        private void OnFormClosing(object? sender, FormClosingEventArgs e)
        {
        }

        private async void OnNuovoArticoloRequested(object? sender, EventArgs e)
            => await NuovoArticolo();

        private async void OnSalvaArticoloRequested(object? sender, EventArgs e)
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

        private async void OnEliminaArticoloRequested(object? sender, int e)
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

        private async void OnApriArticoloRequested(object? sender, EventArgs e)
        {
            var idArticolo = await _windowService.ShowDialog<ArticoliPresenter, int>(_view);
            if (idArticolo != 0)
            {
                await MostraArticolo(idArticolo);
            }
        }

        private async void OnAggiungiCategoriaRequested(object? sender, EventArgs e)
        {
            var idCategoria = await _windowService.ShowDialog<CategoriePresenter, int>(_view);
            if (idCategoria != 0)
            {
                Categoria categoria = await _magazinoService.GetCategoria(idCategoria);
                articolo?.AddCategoria(categoria);
            }
        }

        private void OnRimuoviCategoriaRequested(object? sender, Categoria e)
        {
            articolo?.RemoveCategoria(e);
        }

        private async void OnSelezionaFornitoreRequested(object? sender, EventArgs e)
        {
            if (articolo != null)
            {
                var idFornitore = await _windowService.ShowDialog<FornitoriPresenter, int>(_view);
                if (idFornitore != 0)
                {
                    var fornitore = await _magazinoService.GetFornitore(idFornitore);
                    articolo.Fornitore = fornitore;
                }
            }
        }

        #endregion

        private void MostraArticolo(Articolo articolo)
        {
            _view.SetArticolo(articolo);
            _view.SetCategorie(articolo.Categorie);
        }

        private async Task NuovoArticolo()
        {
            await _unitOfWork.BeginAsync();
            articolo = new Articolo();
            MostraArticolo(articolo);
        }

        private async Task MostraArticolo(int id)
        {
            await _unitOfWork.BeginAsync();
            articolo = await _magazinoService.GetArticolo(id);
            MostraArticolo(articolo);
        }


        public override void Dispose()
        {
            base.Dispose();
            _view.Load -= OnLoad;
            _view.FormClosing -= OnFormClosing;
            _view.NuovoArticoloRequested -= OnNuovoArticoloRequested;
            _view.SalvaArticoloRequested -= OnSalvaArticoloRequested;
            _view.EliminaArticoloRequested -= OnEliminaArticoloRequested;
            _view.ApriArticoloRequested -= OnApriArticoloRequested;
            _view.AggiungiCategoriaRequested -= OnAggiungiCategoriaRequested;
            _view.RimuoviCategoriaRequested -= OnRimuoviCategoriaRequested;
            _view.SelezionaFornitoreRequested -= OnSelezionaFornitoreRequested;
            _view = null!;
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
