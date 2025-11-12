// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Magazzino;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.View
{
    public partial class ArticoloView : Form, IArticoloView
    {
        private readonly ILogger _logger;

        public event EventHandler? SalvaArticoloRequested;
        public event EventHandler? NuovoArticoloRequested;
        public event EventHandler? ApriArticoloRequested;
        public event EventHandler<int>? EliminaArticoloRequested;
        public event EventHandler? AggiungiCategoriaRequested;
        public event EventHandler<Categoria>? RimuoviCategoriaRequested;
        public event EventHandler? SelezionaFornitoreRequested;

        public ArticoloView(ILogger<ArticoloView> logger)
        {
            InitializeComponent();
            _logger = logger;
            _logger.LogDebug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public void SetArticolo(Articolo articolo)
        {
            articoloBindingSource.DataSource = articolo;
        }

        public void SetCategorie(ICollection<Categoria> list)
        {
            categorieBindingSource.DataSource = list;
            categorieDataGridView.ClearSelection();
        }

        #region Gestione eventi

        private void Salva_Click(object sender, EventArgs e)
        {
            articoloBindingSource.EndEdit();
            if (articoloBindingSource.Current is Articolo)
            {
                try
                {
                    SalvaArticoloRequested?.Invoke(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void NuovoToolStripButton_Click(object sender, EventArgs e)
            => NuovoArticoloRequested?.Invoke(sender, e);

        private void ApriToolStripButton_Click(object sender, EventArgs e)
            => ApriArticoloRequested?.Invoke(sender, e);

        private void Elimina_Click(object sender, EventArgs e)
        {
            articoloBindingSource.EndEdit();
            if (articoloBindingSource.Current is Articolo p)
            {
                try
                {
                    EliminaArticoloRequested?.Invoke(sender, p.Id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void AggiungiCategoriaToolStripButton_Click(object sender, EventArgs e)
            => AggiungiCategoriaRequested?.Invoke(sender, e);

        private void RimuovCategoriaToolStripButton_Click(object sender, EventArgs e)
        {
            if (categorieDataGridView.SelectedRows.Count != 0)
            {
                if (categorieBindingSource.Current is Categoria categoria)
                {
                    RimuoviCategoriaRequested?.Invoke(sender, categoria);
                }
            }
        }

        private void Fornitore_DoubleClick(object sender, EventArgs e)
            => SelezionaFornitoreRequested?.Invoke(sender, e);

        private void About_Click(object sender, EventArgs e)
            => new AboutBox().ShowDialog();

        #endregion
    }
}
