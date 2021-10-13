using CiccioGest.Domain.Magazino;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.View
{
    public partial class SelezionaArticoloView : Form, ISelezionaArticoloView
    {
        private readonly ILogger logger;

        public event EventHandler LoadEvent;
        public event EventHandler CloseEvent;
        public event EventHandler<int> ArticoloSelezionatoEvent;

        public SelezionaArticoloView(ILogger<ArticoliView> logger)
        {
            InitializeComponent();
            this.logger = logger;
            this.logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public void CaricaArticoli(IList<ArticoloReadOnly> articoli)
        {
            articoliBindingSource.DataSource = articoli;
            articoliDataGridView.ClearSelection();
        }


        #region Gestione Eventi

        private void ListaArticoliView_Load(object sender, EventArgs e)
            => LoadEvent?.Invoke(sender, e);

        private void ListaArticoliView_FormClosing(object sender, FormClosingEventArgs e)
            => CloseEvent?.Invoke(sender, e);


        private void ArticoliDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (articoliDataGridView.SelectedRows.Count > 0)
            {
                if (articoliBindingSource.Current is ArticoloReadOnly articolo)
                    ArticoloSelezionatoEvent?.Invoke(this, articolo.Id);
            }
        }

        #endregion
    }
}
