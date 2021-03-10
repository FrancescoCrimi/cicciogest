using CiccioGest.Domain.Magazino;
using CiccioGest.Presentation.Mvp.View;
using Gtk;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using UI = Gtk.Builder.ObjectAttribute;

namespace CiccioGest.Presentation.Gtk.AppGtk.View
{
    public class ListaArticoliView : Window, IListaArticoliView
    {
        private readonly ILogger logger;
        [UI] private readonly TreeView articoliTreeView = null;
        [UI] private readonly ListStore articoliListStore = null;

        public event System.EventHandler<int> SelectArticoloEvent;
        public event System.EventHandler LoadEvent;
        public event System.EventHandler CloseEvent;

        public ListaArticoliView(ILogger<ListaArticoliView> logger)
            : this(new Builder("ListaArticoliView.glade"))
        {
            this.logger = logger;
            Shown += (sender, args) => LoadEvent?.Invoke(sender, args);
            DeleteEvent += (o, args) => CloseEvent?.Invoke(o, args);
            articoliTreeView.RowActivated += ArticoliTreeView_RowActivated;
            logger.LogDebug("HashCode: " + this.GetHashCode().ToString());
        }

        private ListaArticoliView(Builder builder)
            : base(builder.GetObject("ListaArticoliView").Handle)
        {
            builder.Autoconnect(this);
        }

        public void SetArticoli(IList<ArticoloReadOnly> articoli)
        {
            articoliListStore.Clear();
            foreach (var art in articoli)
            {
                articoliListStore.AppendValues(art.Id, art.Nome, art.Prezzo);
            }
        }

        public void ShowDialog()
        {
            throw new System.NotImplementedException();
        }

        private void ArticoliTreeView_RowActivated(object o, RowActivatedArgs args)
        {
            articoliListStore.GetIter(out var iter, args.Path);
            var idArticolo = (int)articoliListStore.GetValue(iter, 0);
            SelectArticoloEvent?.Invoke(o, idArticolo);
            Close();
        }
    }
}
