using Castle.Core.Logging;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts.Presenter;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts.View;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace CiccioGest.Presentation.Gtk.AppGtk.View
{
    class FatturaView : Window, IFatturaView
    {
        private readonly ILogger logger;
        private IFatturaPresenter fatturaPresenter;

        [UI] private ListStore dettagliListStore = null;
        [UI] private EntryBuffer idFatturaEntryBuffer = null;
        [UI] private EntryBuffer nomeFatturaEntryBuffer = null;
        [UI] private EntryBuffer nomeArticoloEntryBuffer = null;
        [UI] private EntryBuffer quantitaEntryBuffer = null;
        [UI] private EntryBuffer prezzoEntryBuffer = null;
        [UI] private EntryBuffer totaleEntryBuffer = null;
        [UI] private ToolButton newToolButton = null;
        [UI] private ToolButton openToolButton = null;
        [UI] private ToolButton saveToolButton = null;
        [UI] private ToolButton deleteToolButton = null;
        [UI] private ToolButton nuovoDettaglioToolButton = null;
        [UI] private ToolButton addDettaglioToolButton = null;
        [UI] private ToolButton removeDettaglioToolButton = null;

        public FatturaView(ILogger logger)
            : this(new Builder("FatturaView.glade"))
        {
            this.logger = logger;
            Shown += (sender, args) => fatturaPresenter.Load();
            DeleteEvent += (o, args) => fatturaPresenter.Unload();
            newToolButton.Clicked += (sender, args) => fatturaPresenter.NuovaFattura();
            openToolButton.Clicked += (sender, args) => fatturaPresenter.AprFattura();
            saveToolButton.Clicked += (sender, args) => fatturaPresenter.SalvaFattura();
            deleteToolButton.Clicked += (sender, args) => fatturaPresenter.EliminaFattura();
            nuovoDettaglioToolButton.Clicked += (sender, args) => fatturaPresenter.NuovoDattaglio();
            addDettaglioToolButton.Clicked += (sender, args) => fatturaPresenter.NuovoDattaglio();
            removeDettaglioToolButton.Clicked += (sender, args) => fatturaPresenter.RimuoviDettaglio();
            logger.Debug("HashCode: " + this.GetHashCode().ToString());
        }

        private FatturaView(Builder builder)
            : base(builder.GetObject("FatturaView").Handle)
        {
            builder.Autoconnect(this);
        }

        //public ListStore Dettagli => (ListStore)builder.GetObject("dettagliListStore");
        public ListStore Dettagli => dettagliListStore;
        public EntryBuffer IdFattura => idFatturaEntryBuffer;
        public EntryBuffer NomeFattura => nomeFatturaEntryBuffer;
        public EntryBuffer NomeArticolo => nomeArticoloEntryBuffer;
        public EntryBuffer Quantita => quantitaEntryBuffer;
        public EntryBuffer Prezzo => prezzoEntryBuffer;
        public EntryBuffer Totale => totaleEntryBuffer;

        public void SetPresenter(IFatturaPresenter fatturaPresenter) => this.fatturaPresenter = fatturaPresenter;
    }
}
