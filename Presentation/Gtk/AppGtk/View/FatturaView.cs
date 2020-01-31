using Castle.Core.Logging;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts;
using CiccioGest.Presentation.Gtk.AppGtk.Presenter;
using Gtk;
using System;
using gtk = Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace CiccioGest.Presentation.Gtk.AppGtk.View
{
    class FatturaView : Window, ICazzo, IFatturaView
    {
        private readonly ILogger logger;
        private readonly FatturaPresenter fatturaPresenter;
        private readonly Builder builder;

        public FatturaView(ILogger logger, FatturaPresenter fatturaPresenter)
            : this(new Builder("FatturaView.glade"))
        {
            this.logger = logger;
            this.fatturaPresenter = fatturaPresenter;
            
            fatturaPresenter.SetView(this);
            fatturaPresenter.ShowFattura();
        }

        private FatturaView(Builder builder)
            : base(builder.GetObject("FatturaView").Handle)
        {
            builder.Autoconnect(this);
            DeleteEvent += Window_DeleteEvent;
            Shown += MainWindow_Shown;
            this.builder = builder;
        }

        public ListStore Dettagli => (ListStore)builder.GetObject("dettagliListStore");
        public EntryBuffer IdFattura => (EntryBuffer)builder.GetObject("idFatturaEntryBuffer");
        public EntryBuffer NomeFattura => (EntryBuffer)builder.GetObject("nomeFatturaEntryBuffer");
        public EntryBuffer NomeArticolo => (EntryBuffer)builder.GetObject("nomeArticoloEntryBuffer");
        public EntryBuffer Quantita => (EntryBuffer)builder.GetObject("quantitaEntryBuffer");
        public EntryBuffer Prezzo => (EntryBuffer)builder.GetObject("prezzoEntryBuffer");
        public EntryBuffer Totale => (EntryBuffer)builder.GetObject("totaleEntryBuffer");

        private void MainWindow_Shown(object sender, EventArgs e)
        {
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            gtk.Application.Quit();
        }
    }
}
