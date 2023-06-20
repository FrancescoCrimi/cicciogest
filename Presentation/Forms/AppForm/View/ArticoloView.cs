// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Magazino;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.View
{
    public partial class ArticoloView : Form, IArticoloView
    {
        private readonly ILogger<ArticoloView> logger;

        public event EventHandler LoadEvent;
        public event EventHandler CloseEvent;
        public event EventHandler NuovoArticoloEvent;
        public event EventHandler SalvaArticoloEvent;
        public event EventHandler<int> EliminaArticoloEvent;
        public event EventHandler ApriArticoloEvent;
        public event EventHandler AggiungiCategoriaEvent;
        public event EventHandler<Categoria> RimuoviCategoriaEvent;
        public event EventHandler SelezionaFornitore;

        public ArticoloView(ILogger<ArticoloView> logger)
        {
            InitializeComponent();
            this.logger = logger;
            this.logger.LogDebug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
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

        private void View_Load(object s, EventArgs e)
            => LoadEvent?.Invoke(s, e);

        private void ArticoloView_FormClosing(object sender, FormClosingEventArgs e)
            => CloseEvent?.Invoke(sender, e);

        private void NuovoToolStripButton_Click(object sender, EventArgs e)
            => NuovoArticoloEvent?.Invoke(sender, e);

        private void SalvaToolStripButton_Click(object sender, EventArgs e)
        {
            articoloBindingSource.EndEdit();
            if (articoloBindingSource.Current is Articolo)
            {
                try
                {
                    SalvaArticoloEvent?.Invoke(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void CancellaToolStripButton_Click(object sender, EventArgs e)
        {
            articoloBindingSource.EndEdit();
            if (articoloBindingSource.Current is Articolo p)
            {
                try
                {
                    EliminaArticoloEvent?.Invoke(sender, p.Id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void ApriToolStripButton_Click(object sender, EventArgs e)
            => ApriArticoloEvent?.Invoke(sender, e);

        private void AggiungiCategoriaToolStripButton_Click(object sender, EventArgs e)
            => AggiungiCategoriaEvent?.Invoke(sender, e);

        private void RimuovCategoriaToolStripButton_Click(object sender, EventArgs e)
        {
            if (categorieDataGridView.SelectedRows.Count != 0)
            {
                if (categorieBindingSource.Current is Categoria categoria)
                {
                    RimuoviCategoriaEvent?.Invoke(sender, categoria);
                }
            }
        }

        private void textBox2_DoubleClick(object sender, EventArgs e)
            => SelezionaFornitore?.Invoke(sender, e);

        private void AboutToolStripButton_Click(object sender, EventArgs e)
            => new AboutBox().ShowDialog();

        #endregion
    }
}
