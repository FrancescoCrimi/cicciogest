// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Magazzino;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Views
{
    public partial class ArticoliView : Form, IArticoliView
    {
        private readonly ILogger _logger;
        public event EventHandler<int>? ArticoloSelezionatoRequested;

        public ArticoliView(ILogger<ArticoliView> logger)
        {
            InitializeComponent();
            _logger = logger;
            _logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public void CaricaArticoli(IList<Articolo> articoli)
        {
            articoliBindingSource.DataSource = articoli;
            articoliDataGridView.ClearSelection();
        }

        #region Event Handlers

        private void Apri_Click(object sender, EventArgs e)
            => ApriArticolo();

        private void Articoli_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
            => ApriArticolo();

        private void About_Click(object sender, EventArgs e)
            => new AboutBox().ShowDialog();

        #endregion


        private void ApriArticolo()
        {
            if (articoliDataGridView.SelectedRows.Count > 0)
            {
                if (articoliBindingSource.Current is Articolo articolo)
                    ArticoloSelezionatoRequested?.Invoke(this, articolo.Id);
            }
        }

    }
}
