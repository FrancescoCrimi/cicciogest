// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Documenti;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Views
{
    public partial class FattureView : Form, IFattureView
    {
        private readonly ILogger _logger;
        public event EventHandler<int>? FatturaSelezionataRequested;

        public FattureView(ILogger<FattureView> logger)
        {
            InitializeComponent();
            _logger = logger;
            _logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public void CaricaFatture(IList<Fattura> listFatture)
        {
            fattureBindingSource.DataSource = listFatture;
            fattureDataGridView.ClearSelection();
        }


        #region Event Handlers

        private void ApriFattura_Click(object sender, EventArgs e)
            => ApriFattura();

        private void Fatture_CellDoubleClick(object s, DataGridViewCellEventArgs e)
            => ApriFattura();

        private void About_Click(object sender, EventArgs e)
            => new AboutBox().ShowDialog();

        #endregion


        private void ApriFattura()
        {
            if (fattureDataGridView.SelectedRows.Count > 0)
            {
                if (fattureBindingSource.Current is Fattura fattura)
                {
                    FatturaSelezionataRequested?.Invoke(this, fattura.Id);
                }
            }
        }
    }
}
