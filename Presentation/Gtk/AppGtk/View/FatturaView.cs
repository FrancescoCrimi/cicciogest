using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.Mvp.Presenter;
using CiccioGest.Presentation.Mvp.View;
using Gtk;
using Microsoft.Extensions.Logging;
using System;
using UI = Gtk.Builder.ObjectAttribute;

namespace CiccioGest.Presentation.AppGtk.View
{
    class FatturaView : Dialog, IFatturaView
    {
        private readonly ILogger logger;

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

        public event FatturaDettaglioEventHandler AggiungiDettaglioEvent;
        public event EventHandler ApriFatturaEvent;
        public event EventHandler<int> EliminaFatturaEvent;
        public event EventHandler NuovoDettaglioEvent;
        public event FatturaDettaglioEventHandler RimuoviDettaglioEvent;
        public event EventHandler<Fattura> SalvaFatturaEvent;
        public event EventHandler LoadEvent;
        public event EventHandler CloseEvent;
        public event EventHandler NuovaFattura;

        public FatturaView(ILogger<FatturaView> logger)
            : this(new Builder("FatturaView.glade"))
        {
            this.logger = logger;
            Shown += (sender, args) => LoadEvent?.Invoke(sender, args);
            DeleteEvent += (sender, args) => CloseEvent?.Invoke(sender, args);
            newToolButton.Clicked += (sender, args) => NuovaFattura?.Invoke(sender, args);
            openToolButton.Clicked += (sender, args) => ApriFatturaEvent?.Invoke(sender, args);
            saveToolButton.Clicked += SaveToolButton_Clicked;
            deleteToolButton.Clicked += DeleteToolButton_Clicked;
            nuovoDettaglioToolButton.Clicked += (sender, args) => NuovoDettaglioEvent?.Invoke(sender, args);
            addDettaglioToolButton.Clicked += AddDettaglioToolButton_Clicked;
            removeDettaglioToolButton.Clicked += RemoveDettaglioToolButton_Clicked;
            logger.LogDebug("HashCode: " + GetHashCode().ToString());
        }

        private FatturaView(Builder builder)
            : base(builder.GetObject("FatturaView").Handle)
        {
            builder.Autoconnect(this);
        }

        private void RemoveDettaglioToolButton_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddDettaglioToolButton_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeleteToolButton_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SaveToolButton_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void SetDettaglio(Dettaglio dettaglio)
        {
            //throw new NotImplementedException();
        }

        public void SetFattura(Fattura fattura)
        {
            idFatturaEntryBuffer.Text = fattura.Id.ToString();
            nomeFatturaEntryBuffer.Text = fattura.Nome;
            dettagliListStore.Clear();
            foreach (var item in fattura.Dettagli)
            {
                dettagliListStore.AppendValues(item.Id, item.NomeProdotto, item.PrezzoProdotto, item.Quantita, item.Totale);
            }
        }

        public void ShowDialog(object owner)
        {
            ShowDialog(owner);
        }
    }
}
