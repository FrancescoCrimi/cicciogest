using Castle.Core.Logging;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts.Presenter;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts.View;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace CiccioGest.Presentation.Gtk.AppGtk.View
{
    public class ListaArticoliView : Window, IListaArticoliView
    {
        private readonly ILogger logger;
        [UI] private readonly TreeView articoliTreeView = null;
        [UI] private readonly ListStore articoliListStore = null;
        private IListaArticoliPresenter listaArticoliPresenter;

        public ListaArticoliView(ILogger logger)
            : this(new Builder("ListaArticoliView.glade"))
        {
            this.logger = logger;
            articoliTreeView.RowActivated += ArticoliTreeView_RowActivated;
            DeleteEvent += (o, args) => listaArticoliPresenter.Unload();
            Shown += (sender, args) => listaArticoliPresenter.Load();
            logger.Debug("HashCode: " + this.GetHashCode().ToString());
        }

        private ListaArticoliView(Builder builder)
            : base(builder.GetObject("ListaArticoliView").Handle)
        {
            builder.Autoconnect(this);
        }

        public ListStore ArticoliListStore => articoliListStore;

        public void SetPresenter(IListaArticoliPresenter listaArticoliPresenter) =>
            this.listaArticoliPresenter = listaArticoliPresenter;

        private void ArticoliTreeView_RowActivated(object o, RowActivatedArgs args)
        {
            articoliListStore.GetIter(out var iter, args.Path);
            var idArticolo = (int)articoliListStore.GetValue(iter, 0);
            listaArticoliPresenter.SelezionaArticolo(idArticolo);
            Close();
        }
    }
}
