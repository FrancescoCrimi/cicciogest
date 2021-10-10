using CiccioGest.Application;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public class SelectClientePresenter : PresenterBase, IPresenter
    {
        private readonly ILogger logger;
        private readonly IClientiFornitoriService service;
        private readonly ISelectClienteView view;

        public int IdCliente { get; private set; }

        public SelectClientePresenter(ILogger<SelectClientePresenter> logger,
                                      IClientiFornitoriService clientiFornitoriService,
                                      ISelectClienteView selectClienteView)
            : base(selectClienteView)
        {
            this.logger = logger;
            service = clientiFornitoriService;
            view = selectClienteView;
            view.CloseEvent += View_CloseEvent;
            view.LoadEvent += View_LoadEvent;
            view.SelectClienteEvent += View_SelectClienteEvent;
            this.logger.LogDebug("HashCode: " + GetHashCode() + " Created");
        }

        private void View_CloseEvent(object s, EventArgs e) { }

        private async void View_LoadEvent(object s, EventArgs e)
        {
            view.SetClienti(await service.GetClienti());
        }

        private void View_SelectClienteEvent(object s, int e) =>  IdCliente = e;

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
