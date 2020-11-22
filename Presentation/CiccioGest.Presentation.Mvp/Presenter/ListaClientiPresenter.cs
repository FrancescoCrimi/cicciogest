using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Application;
using CiccioGest.Presentation.Mvp.View;
using System;

namespace CiccioGest.Presentation.Mvp.Presenter
{
    public class ListaClientiPresenter : IPresenter
    {
        private readonly ILogger logger;
        private readonly IKernel kernel;
        private readonly IClientiFornitoriService service;
        private readonly IListaClientiView view;
        private int idCliente = 0;

        public event IdEventHandler CloseEvent;

        public ListaClientiPresenter(ILogger logger,
                                     IKernel kernel,
                                     IClientiFornitoriService clientiFornitoriService,
                                     IListaClientiView listaClientiView)
        {
            this.logger = logger;
            this.kernel = kernel;
            service = clientiFornitoriService;
            view = listaClientiView;
            view.LoadEvent += View_LoadEvent;
            view.CloseEvent += View_CloseEvent;
            view.SelectClienteEvent += View_SelezionaClienteEvent;
        }

        private void View_CloseEvent(object sender, EventArgs e) =>
            CloseEvent?.Invoke(this, new IdEventArgs(idCliente));

        private void View_SelezionaClienteEvent(object sender, int e) =>
            idCliente = e;

        private async void View_LoadEvent(object sender, EventArgs e)
        {
            var clienti = await service.GetClienti();
            view.SetClienti(clienti);
        }

        public void Show() => view.Show();
    }
}
