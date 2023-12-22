// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Magazino;
using CiccioGest.Presentation.AppForm.Services;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public class ArticoloPresenter : PresenterBase, IDisposable
    {
        private readonly ILogger logger;
        private readonly IMagazinoService magazinoService;
        private readonly WindowService windowService;
        private readonly DialogService dialogService;
        private readonly IArticoloView view;
        private Articolo articolo;

        public ArticoloPresenter(ILogger<ArticoloPresenter> logger,
                                 IArticoloView view,
                                 IMagazinoService magazinoService,
                                 WindowService windowService,
                                 DialogService dialogService)
            : base(view)
        {
            this.logger = logger;
            this.magazinoService = magazinoService;
            this.windowService = windowService;
            this.dialogService = dialogService;
            this.view = view;
            view.LoadEvent += View_LoadEvent;
            view.CloseEvent += View_CloseEvent;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public void NuovoArticolo()
        {
            articolo = new Articolo();
            MostraArticolo(articolo);
        }

        public async Task MostraArticolo(int id)
        {
            articolo = await magazinoService.GetArticolo(id);
            MostraArticolo(articolo);
        }

        private void View_LoadEvent(object? sender, EventArgs e)
        {
            view.NuovoArticoloEvent += View_NuovoArticoloEvent;
            view.SalvaArticoloEvent += View_SalvaArticoloEvent;
            view.EliminaArticoloEvent += View_EliminaArticoloEvent;
            view.ApriArticoloEvent += View_ApriArticoloEvent;
            view.AggiungiCategoriaEvent += View_AggiungiCategoriaEvent;
            view.RimuoviCategoriaEvent += View_RimuoviCategoriaEvent;
            view.SelezionaFornitore += View_SelezionaFornitore;
        }

        private void View_CloseEvent(object? sender, EventArgs e)
        {
            view.NuovoArticoloEvent -= View_NuovoArticoloEvent;
            view.SalvaArticoloEvent -= View_SalvaArticoloEvent;
            view.EliminaArticoloEvent -= View_EliminaArticoloEvent;
            view.ApriArticoloEvent -= View_ApriArticoloEvent;
            view.AggiungiCategoriaEvent -= View_AggiungiCategoriaEvent;
            view.RimuoviCategoriaEvent -= View_RimuoviCategoriaEvent;
            view.SelezionaFornitore -= View_SelezionaFornitore;
        }


        private void View_NuovoArticoloEvent(object? sender, EventArgs e)
            => NuovoArticolo();

        private async void View_SalvaArticoloEvent(object? sender, EventArgs e)
        {
            await magazinoService.SaveArticolo(articolo);
        }

        private async void View_EliminaArticoloEvent(object? sender, int e)
        {
            await magazinoService.DeleteArticolo(e);
            NuovoArticolo();
        }

        private async void View_ApriArticoloEvent(object? sender, EventArgs e)
        {
            var sav = dialogService.OpenDialog<SelezionaArticoloPresenter>(view);
            if(sav.IdArticolo != 0)
            {
                await MostraArticolo(sav.IdArticolo);
            }
        }

        private async void View_AggiungiCategoriaEvent(object? sender, EventArgs e)
        {
            var scp = dialogService.OpenDialog<SelezionaCategoriaPresenter>(view);
            if(scp.IdCategoria != 0)
            {
                Categoria categoria = await magazinoService.GetCategoria(scp.IdCategoria);
                articolo.AddCategoria(categoria);
            }
        }

        private void View_RimuoviCategoriaEvent(object? sender, Categoria e)
        {
            articolo.RemoveCategoria(e);
        }


        private void MostraArticolo(Articolo articolo)
        {
            view.SetArticolo(articolo);
            view.SetCategorie(articolo.Categorie);
        }

        private async void View_SelezionaFornitore(object? sender, EventArgs e)
        {
            var sfp = dialogService.OpenDialog<SelezionaFornitorePresenter>(view);
            if(sfp.IdFornitore != 0)
            {
                Fornitore fornitore = await magazinoService.GetFornitore(sfp.IdFornitore);
                articolo.Fornitore = fornitore;
            }
        }



        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
