using Castle.Core.Logging;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts;
using CiccioGest.Presentation.Gtk.AppGtk.Presenter;
using Gtk;
using System;
using CiccioGest.Infrastructure;
using UI = Gtk.Builder.ObjectAttribute;

namespace CiccioGest.Presentation.Gtk.AppGtk.View
{
    public class ListaFattureView : Window, IListaFattureView
    {
        private readonly Builder builder;
        private readonly ILogger logger;
        private  ListaFatturePresenter listaFatturePresenter;
        //[UI] private ListStore fattureListStore = null;
        [UI] private TreeView fattureTreeView = null;

        private ListaFattureView(Builder builder)
            : base(builder.GetObject("ListaFattureView").Handle)
        {
            builder.Autoconnect(this);
            this.builder = builder;
        }

        public ListaFattureView(ILogger logger)
            : this(new Builder("ListaFattureView.glade"))
        {
            this.logger = logger;
            fattureTreeView.RowActivated += FattureTreeViewOnRowActivated;
            DeleteEvent += (o, args) => listaFatturePresenter.Unload();
            Shown += (sender, args) => listaFatturePresenter.Load();;
        }
        
        public void setPresenter(ListaFatturePresenter listaFatturePresenter)
        {
            this.listaFatturePresenter = listaFatturePresenter;
        }
        
        private void FattureTreeViewOnRowActivated(object o, RowActivatedArgs args)
        {
            listaFatturePresenter.SelezionaFattura(args.Path);
            Close();
        }

        public ListStore FattureListStore => (ListStore)builder.GetObject("fattureListStore");
    }
}
