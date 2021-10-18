using CiccioGest.Domain.ClientiFornitori;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.View
{
    public partial class SelezionaClienteView : Form, ISelezionaClienteView
    {
        private readonly ILogger logger;
        public event EventHandler<int> ClienteSelezionatoEvent;
        public event EventHandler LoadEvent;
        public event EventHandler CloseEvent;

        public SelezionaClienteView(ILogger<SelezionaClienteView> logger)
        {
            InitializeComponent();
            this.logger = logger;
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public void CaricaClienti(IList<Cliente> clienti)
        {
            clientiBindingSource.DataSource = clienti;
            clientiDataGridView.ClearSelection();
        }

        private void SelezionaClienteView_Load(object sender, EventArgs e)
            => LoadEvent?.Invoke(sender, e);

        private void SelezionaClienteView_FormClosing(object sender, FormClosingEventArgs e)
            => CloseEvent?.Invoke(sender, e);

        private void ClientiDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (clientiDataGridView.SelectedRows.Count > 0)
            {
                if (clientiBindingSource.Current is Cliente cliente)
                    ClienteSelezionatoEvent?.Invoke(sender, cliente.Id);
            }
        }
    }
}
