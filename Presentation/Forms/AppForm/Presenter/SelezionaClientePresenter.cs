using CiccioGest.Application;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public class SelezionaClientePresenter : PresenterBase, IDisposable
    {
        private readonly ILogger logger;
        private readonly ISelezionaClienteView view;
        private readonly IClientiFornitoriService clientiFornitoriService;
        public int IdCliente { get; private set; }

        public SelezionaClientePresenter(ILogger<SelezionaClientePresenter> logger,
                                         ISelezionaClienteView view,
                                         IClientiFornitoriService clientiFornitoriService)
            : base(view)
        {
            this.logger = logger;
            this.view = view;
            this.clientiFornitoriService = clientiFornitoriService;
            view.LoadEvent += View_LoadEvent;
            view.CloseEvent += View_CloseEvent;
            logger.LogDebug("HashCode: " + GetHashCode() + " Created");
        }

        private async void View_LoadEvent(object s, EventArgs e)
        {
            view.CaricaClienti(await clientiFornitoriService.GetClienti());
            view.ClienteSelezionatoEvent += View_ClienteSelezionatoEvent;
        }

        private void View_CloseEvent(object s, EventArgs e)
        {
            view.ClienteSelezionatoEvent -= View_ClienteSelezionatoEvent;
        }

        private void View_ClienteSelezionatoEvent(object sender, int e)
        {
            IdCliente = e;
            view.Close();
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
