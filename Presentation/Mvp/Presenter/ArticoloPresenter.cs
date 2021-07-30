using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Presentation.Mvp.View;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Mvp.Presenter
{
    public class ArticoloPresenter : PresenterBase, IPresenter
    {
        private readonly ILogger logger;
        private readonly IMagazinoService service;
        private readonly IArticoloView view;

        public event EventHandler CloseEvent;

        public ArticoloPresenter(ILogger<ArticoloPresenter> logger,
                                 IMagazinoService magazinoService,
                                 IArticoloView articoloView)
            :base(articoloView)
        {
            this.logger = logger;
            service = magazinoService;
            view = articoloView;
            view.LoadEvent += View_LoadEvent;
            view.CloseEvent += View_CloseEvent;
            view.AggiungiCategoriaEvent += View_AggiungiCategoriaEvent;
            view.ApriArticoloEvent += View_ApriArticoloEvent;
            view.EliminaArticoloEvent += View_EliminaArticoloEvent;
            view.RimuoviCategoriaEvent += View_RimuoviCategoriaEvent;
            view.SalvaArticoloEvent += View_SalvaArticoloEvent;
            view.SelezionaArticoloEvent += View_SelezionaArticoloEvent;
            this.logger.LogDebug("HashCode: " + GetHashCode() + " Created");
        }

        private void View_AggiungiCategoriaEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void View_ApriArticoloEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void View_CloseEvent(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private async void View_EliminaArticoloEvent(object sender, int e)
        {
            await service.DeleteArticolo(e);
            await VisualizzaProdotti();
        }

        private async void View_LoadEvent(object sender, EventArgs e)
        {
            await VisualizzaProdotti();
        }

        private void View_RimuoviCategoriaEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void View_SalvaArticoloEvent(object sender, Articolo e)
        {
            await service.SaveArticolo(e);
            await VisualizzaProdotti();
        }

        private async void View_SelezionaArticoloEvent(object sender, int e)
        {
            view.SetArticolo(await service.GetArticolo(e));
        }



        private async Task VisualizzaProdotti()
        {
            view.SetCategorie(await service.GetCategorie());
            view.SetArticoli(await service.GetArticoli());
            view.SetArticolo(new Articolo());
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
