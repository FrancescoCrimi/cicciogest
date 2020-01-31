using Castle.Core.Logging;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts;
using CiccioGest.Presentation.Gtk.AppGtk.Presenter;
using Gtk;
using System;
using CiccioGest.Infrastructure;

namespace CiccioGest.Presentation.Gtk.AppGtk.View
{
    public class ListaFattureView : Window, ICazzo, IListaFattureView
    {
        private readonly Builder builder;
        private readonly ILogger logger;
        private readonly ListaFatturePresenter listaFatturePresenter;

        private ListaFattureView(Builder builder)
            : base(builder.GetObject("ListaFattureView").Handle)
        {
            this.builder = builder;
            builder.Autoconnect(this);
        }

        public ListaFattureView(ILogger logger, ListaFatturePresenter listaFatturePresenter)
            : this(new Builder("ListaFattureView.glade"))
        {
            this.logger = logger;
            this.listaFatturePresenter = listaFatturePresenter;
            listaFatturePresenter.SetView(this);
        }

        public ListStore FattureListStore => (ListStore)builder.GetObject("fattureListStore");
    }
}
