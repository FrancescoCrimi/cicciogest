// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Documenti;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Views
{
    public partial class FatturaView : Form, IFatturaView
    {
        private readonly ILogger _logger;

        public event EventHandler? NuovaRequested;
        public event EventHandler? SalvaRequested;
        public event EventHandler? ApriRequested;
        public event EventHandler? EliminaRequested;
        public event EventHandler? NuovoDettaglioRequested;
        public event EventHandler<Dettaglio>? AggiungiDettaglioRequested;
        public event EventHandler<Dettaglio>? RimuoviDettaglioRequested;

        public FatturaView(ILogger<FatturaView> logger)
        {
            InitializeComponent();
            _logger = logger;
            _logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        #region Metodi Pubblici

        public void SetDettaglio(Dettaglio dettaglio)
            => dettaglioBindingSource.DataSource = dettaglio;

        public void SetFattura(Fattura fattura)
            => fatturaBindingSource.DataSource = fattura;

        #endregion


        #region Event Handlers

        private void Nuova_Click(object sender, EventArgs e)
            => NuovaRequested?.Invoke(sender, EventArgs.Empty);

        private void Salva_Click(object sender, EventArgs e)
            => SalvaRequested?.Invoke(sender, EventArgs.Empty);

        private void Apri_Click(object sender, EventArgs e)
            => ApriRequested?.Invoke(sender, EventArgs.Empty);

        private void Elimina_Click(object sender, EventArgs e)
            => EliminaRequested?.Invoke(sender, EventArgs.Empty);

        private void NuovoDettaglio_Click(object sender, EventArgs e)
            => NuovoDettaglioRequested?.Invoke(sender, EventArgs.Empty);

        private void AggiungiDettaglio_Click(object sender, EventArgs e)
        {
            if (dettaglioBindingSource.Current is Dettaglio dettaglio)
                AggiungiDettaglioRequested?.Invoke(sender, dettaglio);
        }

        private void RimuoviDettaglio_Click(object sender, EventArgs e)
        {
            if (dettaglioBindingSource.Current is Dettaglio dettaglio)
                RimuoviDettaglioRequested?.Invoke(sender, dettaglio);
        }

        private void About_Click(object sender, EventArgs e)
            => new AboutBox().ShowDialog();

        private void DettagliDataGridViewCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dettagliBindingSource.Current != null)
                dettaglioBindingSource.DataSource = dettagliBindingSource.Current;
        }

        #endregion
    }
}
