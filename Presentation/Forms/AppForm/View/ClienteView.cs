// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.ClientiFornitori;
using System;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.View
{
    public partial class ClienteView : Form, IClienteView
    {
        public event EventHandler? LoadEvent;
        public event EventHandler? CloseEvent;
        public event EventHandler? NuovoCliente;
        public event EventHandler? SalvaCliente;
        public event EventHandler? ApriCliente;

        public ClienteView()
        {
            InitializeComponent();
        }

        public void MostraCliente(Cliente cliente)
        {
            clienteBindingSource.DataSource = cliente;
            indirizzoUserControl1.indirizzoBindingSource.DataSource = cliente.IndirizzoNew;
        }

        #region GestioneEventi

        private void ClienteView_Load(object sender, EventArgs e)
            => LoadEvent?.Invoke(sender, e);

        private void ClienteView_FormClosing(object sender, FormClosingEventArgs e)
            => CloseEvent?.Invoke(sender, e);

        private void NuovoToolStripButton_Click(object sender, EventArgs e)
            => NuovoCliente?.Invoke(sender, e);

        private void ApriToolStripButton_Click(object sender, EventArgs e)
            => ApriCliente?.Invoke(sender, e);

        private void SalvaToolStripButton_Click(object sender, EventArgs e)
            => SalvaCliente?.Invoke(sender, e);

        private void ToolStripButton_Click(object sender, EventArgs e)
            => new AboutBox().ShowDialog();

        #endregion
    }
}
