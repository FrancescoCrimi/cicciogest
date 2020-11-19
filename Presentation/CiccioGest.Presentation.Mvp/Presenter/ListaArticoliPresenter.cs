using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Presentation.Mvp.View;
using System;

namespace CiccioGest.Presentation.Mvp.Presenter
{
    public class ListaArticoliPresenter : IPresenter
    {
        private readonly ILogger logger;
        private readonly IMagazinoService service;
        private readonly IListaArticoliView view;

        public int IdProdotto { get; private set; }

        public ListaArticoliPresenter(ILogger logger,
                                      IMagazinoService magazinoService,
                                      IListaArticoliView listaArticoliView)
        {
            this.logger = logger;
            service = magazinoService;
            view = listaArticoliView;
            view.SelezionaArticoloEvent += View_SelezionaArticoloEvent;
            view.LoadEvent += View_LoadEvent;
            view.CloseEvent += View_CloseEvent;
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

        public void Show() => view.Show();
    }
}
