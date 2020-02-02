using Castle.Core.Logging;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts.Presenter;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts.View;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace CiccioGest.Presentation.Gtk.AppGtk.View
{
    public class ListaFattureView : Window, IListaFattureView
    {
        private readonly ILogger logger;
        [UI] private readonly TreeView fattureTreeView = null;
        [UI] private readonly ListStore fattureListStore = null;
        private IListaFatturePresenter listaFatturePresenter;

        public ListaFattureView(ILogger logger)
            : this(new Builder("ListaFattureView.glade"))
        {
            this.logger = logger;
            Shown += (sender, args) => listaFatturePresenter.Load();
            DeleteEvent += (o, args) => listaFatturePresenter.Unload();
            fattureTreeView.RowActivated += FattureTreeViewOnRowActivated;
            logger.Debug("HashCode: " + this.GetHashCode().ToString());
        }

        private ListaFattureView(Builder builder)
            : base(builder.GetObject("ListaFattureView").Handle)
        {
            builder.Autoconnect(this);
        }

        public void SetPresenter(IListaFatturePresenter listaFatturePresenter) =>
            this.listaFatturePresenter = listaFatturePresenter;

        public ListStore FattureListStore => fattureListStore;

        private void FattureTreeViewOnRowActivated(object o, RowActivatedArgs args)
        {
            fattureListStore.GetIter(out var iter, args.Path);
            var IdFattura = (int)fattureListStore.GetValue(iter, 0);
            listaFatturePresenter.SelezionaFattura(IdFattura);
            Close();
        }
    }
}
