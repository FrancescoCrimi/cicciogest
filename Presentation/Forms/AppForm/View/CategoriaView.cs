using CiccioGest.Domain.Magazino;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.View
{
    public partial class CategoriaView : Form, ICategoriaView
    {
        private readonly ILogger<CategoriaView> logger;

        public event EventHandler LoadEvent;
        public event EventHandler<Categoria> SalvaCategoriaEvent;
        public event EventHandler<int> CancellaCategoriaEvent;
        public event EventHandler CloseEvent;

        public CategoriaView(ILogger<CategoriaView> logger)
        {
            InitializeComponent();
            this.logger = logger;
        }

        public void SetCategoria(Categoria categoria)
        {
            CategoriaBindingSource.DataSource = categoria;
        }

        public void SetCategorie(IList<Categoria> list)
        {
            categorieBindingSource.DataSource = list;
            categorieDataGridView.ClearSelection();
        }

        private void CategoriaView_Load(object s, EventArgs e)
        {
            LoadEvent?.Invoke(s, e);
        }

        private void NuovoToolStripButton_Click(object sender, EventArgs e)
        {
            categorieDataGridView.ClearSelection();
            CategoriaBindingSource.DataSource = new Categoria();
        }

        private void SalvaToolStripButton_Click(object s, EventArgs e)
        {
            CategoriaBindingSource.EndEdit();
            if (CategoriaBindingSource.Current is Categoria tp)
            {
                try
                {
                    SalvaCategoriaEvent?.Invoke(s, tp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private  void CancellaToolStripButton_Click(object s, EventArgs e)
        {
            CategoriaBindingSource.EndEdit();
            if (CategoriaBindingSource.Current is Categoria tp)
            {
                try
                {
                    CancellaCategoriaEvent?.Invoke(s, tp.Id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void AboutToolStripButton_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void CategorieDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (categorieBindingSource.Current != null)
                CategoriaBindingSource.DataSource = categorieBindingSource.Current;
        }

        private void CategoriaView_FormClosing(object sender, FormClosingEventArgs e)
            => CloseEvent?.Invoke(sender, e);
    }
}
