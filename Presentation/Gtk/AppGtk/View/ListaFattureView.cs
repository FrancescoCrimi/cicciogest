using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.Mvp.View;
using Gtk;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using UI = Gtk.Builder.ObjectAttribute;

namespace CiccioGest.Presentation.Gtk.AppGtk.View
{
    public class ListaFattureView : Window, IListaFattureView
    {
        private readonly ILogger logger;
        [UI] private readonly TreeView fattureTreeView = null;
        [UI] private readonly ListStore fattureListStore = null;

        public event System.EventHandler<int> SelectFatturaEvent;
        public event System.EventHandler NuovaEvent;
        public event System.EventHandler ApriEvent;
        public event System.EventHandler LoadEvent;
        public event System.EventHandler CloseEvent;

        public ListaFattureView(ILogger<ListaFattureView> logger)
            : this(new Builder("ListaFattureView.glade"))
        {
            this.logger = logger;
            Shown += (sender, args) => LoadEvent?.Invoke(sender, args);
            DeleteEvent += (o, args) => CloseEvent?.Invoke(o, args);
            fattureTreeView.RowActivated += FattureTreeViewOnRowActivated;
            logger.LogDebug("HashCode: " + this.GetHashCode().ToString());
        }

        private ListaFattureView(Builder builder)
            : base(builder.GetObject("ListaFattureView").Handle)
        {
            builder.Autoconnect(this);
        }


        private void FattureTreeViewOnRowActivated(object o, RowActivatedArgs args)
        {
            fattureListStore.GetIter(out var iter, args.Path);
            var IdFattura = (int)fattureListStore.GetValue(iter, 0);
            SelectFatturaEvent?.Invoke(o, IdFattura);
        }

        public void SetFatture(IList<FatturaReadOnly> listFatture)
        {
            fattureListStore.Clear();
            foreach (var fatt in listFatture)
            {
                fattureListStore.AppendValues(fatt.Id, fatt.Nome, fatt.Totale);
            }
        }

        public void ShowDialog()
        {
            throw new System.NotImplementedException();
        }
    }
}
