using CiccioGest.Application;
using CiccioGest.Presentation.Mvp.View;
using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.Mvp.Presenter
{
    public class ListaFornitoriPresenter : PresenterBase, IPresenter
    {
        private readonly ILogger logger;
        private readonly IClientiFornitoriService service;
        private readonly IListaFornitoriView view;

        public ListaFornitoriPresenter(ILogger<ListaFornitoriPresenter> logger,
                                       IClientiFornitoriService clientiFornitoriService,
                                       IListaFornitoriView listaFornitoriView)
            : base(listaFornitoriView)
        {
            this.logger = logger;
            service = clientiFornitoriService;
            view = listaFornitoriView;
            view.LoadEvent += View_LoadEvent;
            view.SelectFornitoreEvent += View_SelezionaFornitoreEvent;
            this.logger.LogDebug("HashCode: " + GetHashCode() + " Created");
        }

        public event EventHandler CloseEvent;

        private async void View_LoadEvent(object sender, EventArgs e)
        {
            view.SetFornitori(await service.GetFornitori());
        }

        private void View_SelezionaFornitoreEvent(object sender, int e)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
