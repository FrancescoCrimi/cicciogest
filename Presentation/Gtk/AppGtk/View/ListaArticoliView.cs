using Castle.Core.Logging;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts;
using CiccioGest.Presentation.Gtk.AppGtk.Presenter;
using Gtk;
using System;

namespace CiccioGest.Presentation.Gtk.AppGtk.View
{
    public class ListaArticoliView : IListaArticoliView
    {
        private readonly ILogger logger;
        private readonly ListaArticoliPresenter listaArticoliPresenter;

        public ListaArticoliView(ILogger logger, ListaArticoliPresenter listaArticoliPresenter)
        {
            this.logger = logger;
            this.listaArticoliPresenter = listaArticoliPresenter;
            listaArticoliPresenter.SetView(this);
        }

        public ListStore ArticoliListStore => throw new NotImplementedException();
    }
}
