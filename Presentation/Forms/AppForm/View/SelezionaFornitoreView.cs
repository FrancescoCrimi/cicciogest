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
    public partial class SelezionaFornitoreView : Form, ISelezionaFornitoreView
    {
        private readonly ILogger logger;

        public event EventHandler<int>? FornitoreSelezionatoEvent;
        public event EventHandler? LoadEvent;
        public event EventHandler? CloseEvent;

        public SelezionaFornitoreView(ILogger<SelezionaFornitoreView> logger)
        {
            InitializeComponent();
            this.logger = logger;
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public void CaricaFornitori(IList<Fornitore> articoli)
        {
            fornitoriBindingSource.DataSource = articoli;
            fornitoriDataGridView.ClearSelection();
        }

        private void SelezionaFornitoreView_Load(object sender, EventArgs e)
            => LoadEvent?.Invoke(sender, e);

        private void SelezionaFornitoreView_FormClosing(object sender, FormClosingEventArgs e)
            => CloseEvent?.Invoke(sender, e);

        private void FornitoriDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (fornitoriDataGridView.SelectedRows.Count > 0)
            {
                if (fornitoriBindingSource.Current is Fornitore fornitore)
                {
                    FornitoreSelezionatoEvent?.Invoke(sender, fornitore.Id);
                }
            }
        }
    }
}
