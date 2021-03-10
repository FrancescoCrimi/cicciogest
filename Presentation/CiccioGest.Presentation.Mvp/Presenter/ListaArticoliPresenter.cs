//using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Presentation.Mvp.View;
using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.Mvp.Presenter
{
    public class ListaArticoliPresenter : IPresenter
    {
        private readonly ILogger logger;
        private readonly IMagazinoService service;
        private readonly IListaArticoliView view;

        public event EventHandler CloseEvent;

        public int IdProdotto { get; private set; }

        public ListaArticoliPresenter(ILogger<ListaArticoliPresenter> logger,
                                      IMagazinoService magazinoService,
                                      IListaArticoliView listaArticoliView)
        {
            this.logger = logger;
            service = magazinoService;
            view = listaArticoliView;
            view.SelectArticoloEvent += View_SelezionaArticoloEvent;
            view.LoadEvent += View_LoadEvent;
            view.CloseEvent += View_CloseEvent;
            this.logger.LogDebug("HashCode: " + GetHashCode() + " Created");
        }

        private void View_CloseEvent(object sender, EventArgs e)
        {
        }

        private async void View_LoadEvent(object sender, EventArgs e)
        {
            view.SetArticoli(await service.GetArticoli());
        }

        private void View_SelezionaArticoloEvent(object sender, int e)
        {
            IdProdotto = e;
        }

        public void Show() => view.ShowDialog();
    }
}
