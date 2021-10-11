using CiccioGest.Domain.Documenti;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.View
{
    public partial class ListaFattureView : Form, IListaFattureView
    {
        private readonly ILogger logger;

        public event EventHandler LoadEvent;
        public event EventHandler CloseEvent;
        public event EventHandler<int> SelectFatturaEvent;
        public event EventHandler NuovaFatturaEvent;

        public ListaFattureView(ILogger<ListaFattureView> logger)
        {
            this.logger = logger;
            InitializeComponent();
            this.logger.LogDebug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public void SetFatture(IList<FatturaReadOnly> listFatture)
        {
            fattureBindingSource.DataSource = listFatture;
            fattureDataGridView.ClearSelection();
        }


        private void ListaFattureView_Load(object sender, EventArgs e)
            => LoadEvent?.Invoke(this, new EventArgs());

        private void ListaFattureView_FormClosed(object s, FormClosedEventArgs e)
            =>  CloseEvent?.Invoke(this, new EventArgs());


        private void NuovaFatturaToolStripButton_Click(object sender, EventArgs e)
            => NuovaFatturaEvent?.Invoke(this, new EventArgs());

        private void ApriFatturaToolStripButton_Click(object sender, EventArgs e)
            => SelectFattura();

        private void EsciToolStripButton_Click(object sender, EventArgs e)
            => Close();

        private void AboutToolStripButton_Click(object sender, EventArgs e)
            => new AboutBox().ShowDialog();

        private void FattureDataGridViewCellDoubleClick(object s, DataGridViewCellEventArgs e)
            => SelectFattura();


        private void SelectFattura()
        {
            if (fattureDataGridView.SelectedRows.Count != 0)
            {
                int IdFattura = ((FatturaReadOnly)fattureBindingSource.Current).Id;
                SelectFatturaEvent?.Invoke(this, IdFattura);
            }
        }
    }
}
