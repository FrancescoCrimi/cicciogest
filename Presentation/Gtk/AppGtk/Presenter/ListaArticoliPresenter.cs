using CiccioGest.Application;
using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.Gtk.AppGtk.Presenter
{
    public class ListaArticoliPresenter 
    {
        private readonly ILogger logger;
        private readonly IMagazinoService magazinoService;

        public ListaArticoliPresenter(ILogger<ListaArticoliPresenter> logger,
                                      IMagazinoService magazinoService)
        {
            this.logger = logger;
            this.magazinoService = magazinoService;
            logger.LogDebug("HashCode: " + this.GetHashCode().ToString());
        }

        public event EventHandler<int> EventoSelezione;


        public void SelezionaArticolo(int idArticolo) => EventoSelezione?.Invoke(this, idArticolo);


        public void Unload() => EventoSelezione?.Invoke(this, 0);
    }
}
