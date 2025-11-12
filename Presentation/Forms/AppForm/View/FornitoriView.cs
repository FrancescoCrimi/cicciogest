// Copyright (c) 2016 - 2025 Francesco Crimi
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
        private readonly ILogger _logger;
        public event EventHandler<int>? FornitoreSelezionatoRequested;

        public FornitoriView(ILogger<FornitoriView> logger)
        {
            InitializeComponent();
            _logger = logger;
            _logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public void CaricaFornitori(IList<Fornitore> fornitori)
        {
            fornitoriBindingSource.DataSource = fornitori;
            fornitoriDataGridView.ClearSelection();
        }

        #region Event Handlers

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
                    FornitoreSelezionatoRequested?.Invoke(this, fornitore.Id);
            }
        }
    }
}
