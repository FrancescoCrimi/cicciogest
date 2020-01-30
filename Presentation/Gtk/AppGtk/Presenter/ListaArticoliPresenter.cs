using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts;

namespace CiccioGest.Presentation.Gtk.AppGtk.Presenter
{
    public class ListaArticoliPresenter
    {
        private readonly ILogger logger;
        private readonly IMagazinoService magazinoService;
        private IListaArticoliView listaArticoliView;

        public ListaArticoliPresenter(ILogger logger, IMagazinoService magazinoService)
        {
            this.logger = logger;
            this.magazinoService = magazinoService;
        }

        public void SetView(IListaArticoliView listaArticoliView)
        {
            this.listaArticoliView = listaArticoliView;
        }

        public void SelezionaArticolo()
        {

        }
    }
}
