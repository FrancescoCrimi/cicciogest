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
    public partial class FornitoreView : Form, IFornitoreView
    {
        public event EventHandler? LoadEvent;
        public event EventHandler? CloseEvent;
        public event EventHandler? NuovoFornitore;
        public event EventHandler? SalvaFornitore;
        public event EventHandler? ApriFornitore;

        public FornitoreView()
        {
            InitializeComponent();
        }

        public void MostraFornitore(Fornitore fornitore)
        {
            fornitoreBindingSource.DataSource = fornitore;
            indirizzoUserControl1.indirizzoBindingSource.DataSource = fornitore.IndirizzoNew;
        }


        #region Gestione eventi

        private void FornitoreView_Load(object sender, EventArgs e)
            => LoadEvent?.Invoke(sender, e);

        private void FornitoreView_FormClosing(object sender, FormClosingEventArgs e)
            => CloseEvent?.Invoke(sender, e);

        private void NuovoToolStripButton_Click(object sender, EventArgs e)
            => NuovoFornitore?.Invoke(sender, e);

        private void ApriToolStripButton_Click(object sender, EventArgs e)
            => ApriFornitore?.Invoke(sender, e);

        private void SalvaToolStripButton_Click(object sender, EventArgs e)
            => SalvaFornitore?.Invoke(sender, e);

        private void StampaToolStripButton_Click(object sender, EventArgs e) { }

        private void AboutToolStripButton_Click(object sender, EventArgs e)
            => new AboutBox().ShowDialog();

        #endregion
    }
}
