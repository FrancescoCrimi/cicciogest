using Castle.Core.Logging;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts;
using CiccioGest.Presentation.Gtk.AppGtk.Presenter;
using Gtk;
using System;

namespace CiccioGest.Presentation.Gtk.AppGtk.View
{
    public class ListaFattureView : IListaFattureView
    {
        private readonly ILogger logger;
        private readonly ListaFatturePresenter listaFatturePresenter;

        public ListaFattureView(ILogger logger, ListaFatturePresenter listaFatturePresenter)
        {
            this.logger = logger;
            this.listaFatturePresenter = listaFatturePresenter;
            listaFatturePresenter.SetView(this);
        }

        public ListStore FattureListStore => throw new NotImplementedException();
    }
}
