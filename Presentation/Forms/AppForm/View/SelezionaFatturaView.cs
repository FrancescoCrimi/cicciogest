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
    public partial class SelezionaFatturaView : Form, ISelezionaFatturaView
    {
        private readonly ILogger<SelezionaFatturaView> logger;

        public SelezionaFatturaView(ILogger<SelezionaFatturaView> logger)
        {
            InitializeComponent();
            this.logger = logger;
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public event EventHandler<int> FatturaSelezionataEvent;
        public event EventHandler LoadEvent;
        public event EventHandler CloseEvent;

        public void CaricaFatture(IList<FatturaReadOnly> fatture)
        {
            fattureBindingSource.DataSource = fatture;
        }

        private void SelezionaFatturaView_Load(object sender, EventArgs e)
            => LoadEvent?.Invoke(sender, e);

        private void SelezionaFatturaView_FormClosing(object sender, FormClosingEventArgs e)
            => CloseEvent?.Invoke(sender, e);

        private void FattureDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (fattureDataGridView.SelectedRows.Count > 0)
            {
                if (fattureBindingSource.Current is FatturaReadOnly fattura)
                {
                    FatturaSelezionataEvent?.Invoke(sender, fattura.Id);
                }
            }
        }
    }
}
