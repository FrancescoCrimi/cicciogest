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
        private readonly IClientiFornitoriService clientiFornitoriService;
        private readonly IListaClientiView view;

        public ListaClientiPresenter(ILogger logger,
                                     IKernel kernel,
                                     IClientiFornitoriService clientiFornitoriService,
                                     IListaClientiView view)
        {
            this.logger = logger;
            this.kernel = kernel;
            this.clientiFornitoriService = clientiFornitoriService;
            this.view = view;
            view.LoadEvent += View_LoadEvent;
            view.SelectClienteEvent += View_SelezionaClienteEvent;
        }

        private void View_SelezionaClienteEvent(object sender, int e)
        {
            throw new NotImplementedException();
        }

        private async void View_LoadEvent(object sender, EventArgs e)
        {
            var clienti = await clientiFornitoriService.GetClienti();
            view.SetClienti(clienti);
        }

        public void Show() => view.Show();
    }
}
