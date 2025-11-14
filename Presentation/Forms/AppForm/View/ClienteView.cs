// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Anagrafica;
using System;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.View
{
    public partial class ClienteView : Form, IClienteView
    {
        public event EventHandler? NuovoRequested;
        public event EventHandler? SalvaRequested;
        public event EventHandler? ApriRequested;
        public event EventHandler? EliminaRequested;

        public ClienteView()
        {
            InitializeComponent();
        }

        public void MostraCliente(Cliente cliente)
        {
            clienteBindingSource.DataSource = cliente;
            //indirizzoUserControl1.indirizzoBindingSource.DataSource = cliente.IndirizzoNew;
        }

        #region Event Handlers

        private void SalvaToolStripButton_Click(object sender, EventArgs e)
            => SalvaRequested?.Invoke(sender, EventArgs.Empty);

        private void NuovoToolStripButton_Click(object sender, EventArgs e)
            => NuovoRequested?.Invoke(sender, EventArgs.Empty);

        private void ApriToolStripButton_Click(object sender, EventArgs e)
            => ApriRequested?.Invoke(sender, EventArgs.Empty);

        private void Elimina_Click(object sender, EventArgs e)
        {
            EliminaRequested?.Invoke(sender, EventArgs.Empty);
        }

        private void About_Click(object sender, EventArgs e)
            => new AboutBox().ShowDialog();

        #endregion
    }
}
