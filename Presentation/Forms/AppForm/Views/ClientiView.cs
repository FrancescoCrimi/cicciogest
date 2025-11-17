// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Anagrafica;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Views
{
    public partial class ClientiView : Form, IClientiView
    {
        private readonly ILogger _logger;
        public event EventHandler<int>? ClienteSelezionatoRequested;

        public ClientiView(ILogger<ClientiView> logger)
        {
            InitializeComponent();
            _logger = logger;
            _logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public void CaricaClienti(IList<Cliente> clienti)
        {
            clientiBindingSource.DataSource = clienti;
            clientiDataGridView.ClearSelection();
        }


        #region Event Handlers

        private void ApriCliente_Click(object sender, EventArgs e)
            => ApriCliente();

        private void Clienti_CellDoubleClick(object s, DataGridViewCellEventArgs e)
            => ApriCliente();

        private void About_Click(object sender, EventArgs e)
            => new AboutBox().ShowDialog();

        #endregion


        private void ApriCliente()
        {
            if (clientiDataGridView.SelectedRows.Count > 0)
            {
                if (clientiBindingSource.Current is Cliente cliente)
                    ClienteSelezionatoRequested?.Invoke(this, cliente.Id);
            }
        }
    }
}
