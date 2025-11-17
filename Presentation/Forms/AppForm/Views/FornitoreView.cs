// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Anagrafica;
using System;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Views
{
    public partial class FornitoreView : Form, IFornitoreView
    {
        public event EventHandler? NuovoRequested;
        public event EventHandler? SalvaRequested;
        public event EventHandler? ApriRequested;
        public event EventHandler? EliminaRequested;

        public FornitoreView()
        {
            InitializeComponent();
        }

        public void MostraFornitore(Fornitore fornitore)
        {
            fornitoreBindingSource.DataSource = fornitore;
            //indirizzoUserControl1.indirizzoBindingSource.DataSource = fornitore.IndirizzoNew;
        }

        #region Event Handlers

        private void Nuovo_Click(object sender, EventArgs e)
            => NuovoRequested?.Invoke(sender, EventArgs.Empty);

        private void Salva_Click(object sender, EventArgs e)
            => SalvaRequested?.Invoke(sender, EventArgs.Empty);

        private void Apri_Click(object sender, EventArgs e)
            => ApriRequested?.Invoke(sender, EventArgs.Empty);

        private void Elimina_Click(object sender, EventArgs e)
        {
            EliminaRequested?.Invoke(sender, EventArgs.Empty);
        }

        private void AboutToolStripButton_Click(object sender, EventArgs e)
            => new AboutBox().ShowDialog();

        #endregion
    }
}
