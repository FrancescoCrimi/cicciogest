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

namespace CiccioGest.Presentation.AppForm.View
{
    public partial class CategorieView : Form, ICategorieView
    {
        private readonly ILogger logger;

        public event EventHandler<int>? CategoriaSelezionataRequested;
        public event EventHandler? LoadEvent;
        public event EventHandler? CloseEvent;

        public CategorieView(ILogger<CategorieView> logger)
        {
            InitializeComponent();
            this.logger = logger;
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public void CaricaCategorie(IList<Categoria> categorie)
        {
            categorieBindingSource.DataSource = categorie;
            categorieDataGridView.ClearSelection();
        }

        private void SelezionaCategoriaView_Load(object sender, EventArgs e)
            => LoadEvent?.Invoke(sender, e);

        private void SelezionaCategoriaView_FormClosing(object sender, FormClosingEventArgs e)
            => CloseEvent?.Invoke(sender, e);

        private void CategorieDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (categorieDataGridView.SelectedRows.Count > 0)
            {
                if (categorieBindingSource.Current is Categoria categoria)
                {
                    CategoriaSelezionataRequested?.Invoke(sender, categoria.Id);
                }
            }
        }
    }
}
