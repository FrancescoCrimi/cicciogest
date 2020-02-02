using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts.Presenter;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts.View;
using System;

namespace CiccioGest.Presentation.Gtk.AppGtk.Presenter
{
    public class ListaArticoliPresenter : IListaArticoliPresenter, ICazzo
    {
        private readonly ILogger logger;
        private readonly IMagazinoService magazinoService;
        private IListaArticoliView listaArticoliView;

        public ListaArticoliPresenter(ILogger logger,
                                      IMagazinoService magazinoService,
                                      IListaArticoliView listaArticoliView)
        {
            this.logger = logger;
            this.magazinoService = magazinoService;
            this.listaArticoliView = listaArticoliView;
            listaArticoliView.SetPresenter(this);
            logger.Debug("HashCode: " + this.GetHashCode().ToString());
        }

        public event EventHandler<int> EventoSelezione;

        public void Load()
        {
            var lstart = magazinoService.GetArticoli().Result;
            listaArticoliView.ArticoliListStore.Clear();
            foreach (var art in lstart)
            {
                listaArticoliView.ArticoliListStore.AppendValues(art.Id, art.Nome, art.Prezzo);
            }
        }

        public void SelezionaArticolo(int idArticolo) => EventoSelezione?.Invoke(this, idArticolo);

        public void ShowView() => listaArticoliView.Show();

        public void Unload() => EventoSelezione?.Invoke(this, 0);
    }
}
