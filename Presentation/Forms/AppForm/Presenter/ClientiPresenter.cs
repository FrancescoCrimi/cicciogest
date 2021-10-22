using CiccioGest.Application;
using CiccioGest.Presentation.AppForm.Services;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public class ClientiPresenter : PresenterBase, IDisposable
    {
        private readonly ILogger logger;
        private readonly IClientiView view;
        private readonly IClientiFornitoriService clientiFornitoriService;
        private readonly WindowService windowService;

        public ClientiPresenter(ILogger<ClientiPresenter> logger,
                                IClientiView view,
                                IClientiFornitoriService clientiFornitoriService,
                                WindowService windowService)
            : base(view)
        {
            this.logger = logger;
            this.view = view;
            this.clientiFornitoriService = clientiFornitoriService;
            this.windowService = windowService;
            view.LoadEvent += View_LoadEvent;
            view.CloseEvent += View_CloseEvent;
            logger.LogDebug("HashCode: " + GetHashCode() + " Created");
        }

        private async void View_LoadEvent(object sender, EventArgs e)
        {
            view.NuovoClienteEvent += View_NuovoClienteEvent;
            view.ClienteSelezionatoEvent += View_ClienteSelezionatoEvent;
            view.CreaFatturaEvent += View_CreaFatturaEvent;
            var clienti = await clientiFornitoriService.GetClienti();
            view.CaricaClienti(clienti);
        }

        private void View_CloseEvent(object sender, EventArgs e)
        {
            view.NuovoClienteEvent -= View_NuovoClienteEvent;
            view.ClienteSelezionatoEvent -= View_ClienteSelezionatoEvent;
            view.CreaFatturaEvent -= View_CreaFatturaEvent;
        }

        private void View_NuovoClienteEvent(object sender, EventArgs e)
        {
            windowService.OpenWindow<ClientePresenter>().NuovoCliente();
            view.Close();
        }

        private void View_ClienteSelezionatoEvent(object sender, int e)
        {
            windowService.OpenWindow<ClientePresenter>().ApriCliente(e);
            view.Close();
        }

        private void View_CreaFatturaEvent(object sender, int e)
        {
            windowService.OpenWindow<FatturaPresenter>().NuovaFattura(e);
            view.Close();
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
