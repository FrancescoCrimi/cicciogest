// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Documenti;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.View
{
    public partial class FattureView : Form, IFattureView
    {
        private readonly ILogger logger;
        public event EventHandler? LoadEvent;
        public event EventHandler? CloseEvent;
        public event EventHandler<int>? FatturaSelezionataEvent;
        public event EventHandler? NuovaFatturaEvent;

        public FattureView(ILogger<FattureView> logger)
        {
            InitializeComponent();
            this.logger = logger;
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public void CaricaFatture(IList<FatturaReadOnly> listFatture)
        {
            fattureBindingSource.DataSource = listFatture;
            fattureDataGridView.ClearSelection();
        }


        #region Gestione Eventi

        private void ListaFattureView_Load(object sender, EventArgs e)
            => LoadEvent?.Invoke(sender, e);

        private void ListaFattureView_FormClosing(object sender, FormClosingEventArgs e)
            => CloseEvent?.Invoke(sender, e);


        private void NuovaFatturaToolStripButton_Click(object sender, EventArgs e)
            => NuovaFatturaEvent?.Invoke(sender, e);

        private void ApriFatturaToolStripButton_Click(object sender, EventArgs e)
            => ApriFattura();

        private void FattureDataGridViewCellDoubleClick(object s, DataGridViewCellEventArgs e)
            => ApriFattura();

        private void AboutToolStripButton_Click(object sender, EventArgs e)
            => new AboutBox().ShowDialog();

        #endregion


        private void ApriFattura()
        {
            if (fattureDataGridView.SelectedRows.Count > 0)
            {
                if (fattureBindingSource.Current is FatturaReadOnly fattura)
                    FatturaSelezionataEvent?.Invoke(this, fattura.Id);
            }
        }
    }
}
