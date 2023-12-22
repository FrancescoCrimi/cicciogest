// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.ClientiFornitori;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.View
{
    public partial class ClientiView : Form, IClientiView
    {
        private readonly ILogger logger;
        public event EventHandler? LoadEvent;
        public event EventHandler? CloseEvent;
        public event EventHandler? NuovoClienteEvent;
        public event EventHandler<int>? ClienteSelezionatoEvent;
        public event EventHandler<int>? CreaFatturaEvent;

        public ClientiView(ILogger<ClientiView> logger)
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


        #region Gestione Eventi

        private void ListaClientiView_Load(object sender, EventArgs e)
            => LoadEvent?.Invoke(sender, e);

        private void ListaClientiView_FormClosing(object sender, FormClosingEventArgs e)
            => CloseEvent?.Invoke(sender, e);


        private void NuovoClienteToolStripButton_Click(object sender, EventArgs e)
            => NuovoClienteEvent?.Invoke(this, new EventArgs());

        private void ApriClienteToolStripButton_Click(object sender, EventArgs e)
            => ApriCliente();

        private void NuovaFatturaToolStripButton_Click(object sender, EventArgs e)
        {
            if (clientiDataGridView.SelectedRows.Count > 0)
            {
                if (clientiBindingSource.Current is Cliente cliente)
                    CreaFatturaEvent?.Invoke(this, cliente.Id);
            }
        }

        private void ClientiDataGridView_CellDoubleClick(object s, DataGridViewCellEventArgs e)
            => ApriCliente();

        private void AboutToolStripButton_Click(object sender, EventArgs e)
            => new AboutBox().ShowDialog();

        #endregion


        private void ApriCliente()
        {
            if (clientiDataGridView.SelectedRows.Count > 0)
            {
                if (clientiBindingSource.Current is Cliente cliente)
                    ClienteSelezionatoEvent?.Invoke(this, cliente.Id);
            }
        }
    }
}
