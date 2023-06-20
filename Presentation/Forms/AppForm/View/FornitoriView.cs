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
    public partial class FornitoriView : Form, IFornitoriView
    {
        private readonly ILogger logger;
        public event EventHandler LoadEvent;
        public event EventHandler CloseEvent;
        public event EventHandler NuovoFornitoreEvent;
        public event EventHandler<int> FornitoreSelezionatoEvent;

        public FornitoriView(ILogger<FornitoriView> logger)
        {
            InitializeComponent();
            this.logger = logger;
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public void CaricaFornitori(IList<Fornitore> fornitori)
        {
            fornitoriBindingSource.DataSource = fornitori;
            fornitoriDataGridView.ClearSelection();
        }


        #region gestione eventi

        private void ListaFornitoriView_Load(object sender, EventArgs e)
            => LoadEvent?.Invoke(sender, e);

        private void ListaFornitoriView_FormClosing(object sender, FormClosingEventArgs e)
            => CloseEvent?.Invoke(sender, e);


        private void NuovoToolStripButton_Click(object sender, EventArgs e)
            => NuovoFornitoreEvent?.Invoke(sender, e);

        private void ApriToolStripButton_Click(object sender, EventArgs e)
            => ApriFornitore();

        private void AboutToolStripButton_Click(object sender, EventArgs e)
            => new AboutBox().ShowDialog();

        private void FornitoriDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
            => ApriFornitore();

        #endregion


        private void ApriFornitore()
        {
            if (fornitoriDataGridView.SelectedRows.Count > 0)
            {
                if (fornitoriBindingSource.Current is Fornitore fornitore)
                    FornitoreSelezionatoEvent?.Invoke(this, fornitore.Id);
            }
        }
    }
}
