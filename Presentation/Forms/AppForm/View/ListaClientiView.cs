using CiccioGest.Domain.ClientiFornitori;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.View
{
    public partial class ListaClientiView : Form, IListaClientiView
    {
        private readonly ILogger logger;

        public event EventHandler LoadEvent;
        public event EventHandler CloseEvent;
        public event EventHandler NuovoClienteEvent;
        public event EventHandler<int> SelectClienteEvent;
        public event EventHandler<int> CreaFatturaEvent;
        public event EventHandler<int> ApriFattureEvent;

        public ListaClientiView(ILogger<ListaClientiView> logger)
        {
            InitializeComponent();
            this.logger = logger;
        }

        public void SetClienti(IList<Cliente> clienti)
        {
            clientiBindingSource.DataSource = clienti;
            clientiDataGridView.ClearSelection();
        }


        private void ListaClientiView_Load(object s, EventArgs e) =>
            LoadEvent?.Invoke(s, e);

        private void ListaClientiView_FormClosed(object s, FormClosedEventArgs e) =>
            CloseEvent?.Invoke(s, e);


        private void NuovoClienteToolStripButton_Click(object sender, EventArgs e)
            => NuovoClienteEvent?.Invoke(this, new EventArgs());

        private void ApriClienteToolStripButton_Click(object sender, EventArgs e)
            => SelectCliente();

        private void NuovaFatturaToolStripButton_Click(object sender, EventArgs e)
        {
            if (clientiDataGridView.SelectedRows.Count != 0)
            {
                int id = ((Cliente)clientiBindingSource.Current).Id;
                CreaFatturaEvent?.Invoke(this, id);
            }
        }

        private void ApriFattureToolStripButton_Click(object sender, EventArgs e)
        {
            if (clientiDataGridView.SelectedRows.Count != 0)
            {
                int id = ((Cliente)clientiBindingSource.Current).Id;
                ApriFattureEvent?.Invoke(this, id);
            }
        }

        private void AboutToolStripButton_Click(object sender, EventArgs e)
            => new AboutBox().ShowDialog();

        private void ClientiDataGridView_CellDoubleClick(object s, DataGridViewCellEventArgs e)
            => SelectCliente();

        private void EsciToolStripButton_Click(object sender, EventArgs e)
            => Close();


        private void SelectCliente()
        {
            if (clientiDataGridView.SelectedRows.Count != 0)
            {
                int id = ((Cliente)clientiBindingSource.Current).Id;
                SelectClienteEvent?.Invoke(this, id);
            }
        }
    }
}
