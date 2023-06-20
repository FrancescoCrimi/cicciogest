// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Magazino;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.View
{
    public partial class ArticoliView : Form, IArticoliView
    {
        private readonly ILogger logger;

        public event EventHandler LoadEvent;
        public event EventHandler CloseEvent;
        public event EventHandler<int> ArticoloSelezionatoEvent;
        public event EventHandler NuovoArticoloEvent;

        public ArticoliView(ILogger<ArticoliView> logger)
        {
            InitializeComponent();
            this.logger = logger;
            this.logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public void CaricaArticoli(IList<ArticoloReadOnly> articoli)
        {
            articoliBindingSource.DataSource = articoli;
            articoliDataGridView.ClearSelection();
        }


        #region Gestione Eventi

        private void ListaArticoliView_Load(object sender, EventArgs e)
            => LoadEvent?.Invoke(sender, e);

        private void ListaArticoliView_FormClosing(object sender, FormClosingEventArgs e)
            => CloseEvent?.Invoke(sender, e);


        private void NuovoToolStripButton_Click(object sender, EventArgs e)
            => NuovoArticoloEvent?.Invoke(sender, e);

        private void ApriToolStripButton_Click(object sender, EventArgs e)
            => ApriArticolo();

        private void ArticoliDataGridView_DoubleClick(object sender, EventArgs e)
            => ApriArticolo();

        private void AboutToolStripButton_Click(object sender, EventArgs e)
            => new AboutBox().ShowDialog();

        #endregion


        private void ApriArticolo()
        {
            if (articoliDataGridView.SelectedRows.Count > 0)
            {
                if (articoliBindingSource.Current is ArticoloReadOnly articolo)
                    ArticoloSelezionatoEvent?.Invoke(this, articolo.Id);
            }
        }
    }
}
