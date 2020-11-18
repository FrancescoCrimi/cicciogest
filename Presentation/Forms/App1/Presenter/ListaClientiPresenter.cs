using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Presentation.AppForm.Views;
using System;

namespace CiccioGest.Presentation.AppForm.Presenter
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
            view.SelezionaClienteEvent += View_SelezionaClienteEvent;
        }

        private void View_SelezionaClienteEvent(object sender, Cliente e)
        {
            throw new NotImplementedException();
        }

        private async void View_LoadEvent(object sender, EventArgs e)
        {
            var clienti = await clientiFornitoriService.GetClienti();
            view.MostraClienti(clienti);
        }

        public void Show() => view.Show();
    }
}
