using Castle.Core.Logging;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts;
using CiccioGest.Presentation.Gtk.AppGtk.Presenter;
using Gtk;
using System;
using CiccioGest.Infrastructure;

namespace CiccioGest.Presentation.Gtk.AppGtk.View
{
    public class ListaArticoliView : Window, ICazzo, IListaArticoliView
    {
        private readonly Builder builder;
        private readonly ILogger logger;
        private readonly ListaArticoliPresenter listaArticoliPresenter;

        public ListaArticoliView(ILogger logger, ListaArticoliPresenter listaArticoliPresenter)
            : this(new Builder("ListaArticoliView.glade"))
        {
            this.logger = logger;
            this.listaArticoliPresenter = listaArticoliPresenter;
            listaArticoliPresenter.SetView(this);
        }

        private ListaArticoliView(Builder builder)
            : base(builder.GetObject("ListaArticoliView").Handle)
        {
            builder.Autoconnect(this);
            this.builder = builder;
        }

        public ListStore ArticoliListStore => (ListStore)builder.GetObject("articoliListStore");
    }
}
