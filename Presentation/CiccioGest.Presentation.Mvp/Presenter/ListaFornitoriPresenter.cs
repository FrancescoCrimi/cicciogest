using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Application;
using CiccioGest.Presentation.Mvp.View;
using System;

namespace CiccioGest.Presentation.Mvp.Presenter
{
    public class ListaFornitoriPresenter : IPresenter
    {
        private readonly ILogger logger;
        private readonly IKernel kernel;
        private readonly IClientiFornitoriService service;
        private readonly IListaFornitoriView view;

        public ListaFornitoriPresenter(ILogger logger,
                                       IKernel kernel,
                                       IClientiFornitoriService clientiFornitoriService,
                                       IListaFornitoriView listaFornitoriView)
        {
            this.logger = logger;
            this.kernel = kernel;
            service = clientiFornitoriService;
            view = listaFornitoriView;
            view.LoadEvent += View_LoadEvent;
            view.SelectFornitoreEvent += View_SelezionaFornitoreEvent;
        }

        public void Show() => view.Show();

        private async void View_LoadEvent(object sender, EventArgs e)
        {
            view.SetFornitori(await service.GetFornitori());
        }

        private void View_SelezionaFornitoreEvent(object sender, int e)
        {
            throw new NotImplementedException();
        }
    }
}
