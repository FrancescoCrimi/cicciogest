using CiccioGest.Application;
using CiccioGest.Presentation.AppForm.Services;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public class ListaClientiPresenter : PresenterBase, IPresenter
    {
        private readonly ILogger logger;
        private readonly IListaClientiView view;
        private readonly IClientiFornitoriService clientiFornitoriService;
        private readonly WindowService windowService;

        public ListaClientiPresenter(ILogger<ListaClientiPresenter> logger,
                                     IListaClientiView view,
                                     IClientiFornitoriService clientiFornitoriService,
                                     WindowService windowService)
            : base(view)
        {
            this.logger = logger;
            this.view = view;
            this.clientiFornitoriService = clientiFornitoriService;
            this.windowService = windowService;
            this.view.LoadEvent += View_LoadEvent;
            this.view.CloseEvent += View_CloseEvent;
            logger.LogDebug("HashCode: " + GetHashCode() + " Created");
        }

        private async void View_LoadEvent(object sender, EventArgs e)
        {
            view.NuovoClienteEvent += View_NuovoClienteEvent;
            view.SelectClienteEvent += View_SelezionaClienteEvent;
            view.CreaFatturaEvent += View_CreaFatturaEvent;
            view.ApriFattureEvent += View_ApriFattureEvent;
            var clienti = await clientiFornitoriService.GetClienti();
            view.SetClienti(clienti);
        }

        private void View_CloseEvent(object sender, EventArgs e)
        {
            view.SelectClienteEvent -= View_SelezionaClienteEvent;
            view.CreaFatturaEvent -= View_CreaFatturaEvent;
        }

        private void View_NuovoClienteEvent(object sender, EventArgs e)
        {
            view.Close();
        }

        private void View_SelezionaClienteEvent(object sender, int e)
        {
            view.Close();
        }

        private void View_CreaFatturaEvent(object sender, int e)
        {
            FatturaPresenter fatturaPresenter = windowService.OpenWindow<FatturaPresenter>();
            fatturaPresenter.NuovaFattura(e);
            view.Close();
        }

        private void View_ApriFattureEvent(object sender, int e)
        {
            view.Close();
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
