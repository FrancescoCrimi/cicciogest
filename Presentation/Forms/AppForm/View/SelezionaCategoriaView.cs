using CiccioGest.Domain.Magazino;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.View
{
    public partial class SelezionaCategoriaView : Form, ISelezionaCategoriaView
    {
        private readonly ILogger<SelezionaCategoriaView> logger;

        public SelezionaCategoriaView(ILogger<SelezionaCategoriaView> logger)
        {
            InitializeComponent();
            this.logger = logger;
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public event EventHandler<int> CategoriaSelezionataEvent;
        public event EventHandler LoadEvent;
        public event EventHandler CloseEvent;

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
                    CategoriaSelezionataEvent?.Invoke(sender, categoria.Id);
                }
            }
        }
    }
}
