﻿using Castle.Core.Logging;
using Ciccio1.Application;
using Ciccio1.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ciccio1.Presentation.WinForm.Views
{
    public partial class CategoriaView : Form
    {
        private ILogger logger;
        private ICiccioService service;

        public CategoriaView(
            ILogger logger,
            ICiccioService service
            )
        {
            InitializeComponent();
            this.logger = logger;
            this.service = service;
        }

        private void CategoriaView_Load(object sender, EventArgs e)
        {
            visualizzaCategorie();
        }

        private void nuovoToolStripButton_Click(object sender, EventArgs e)
        {
            categorieDataGridView.ClearSelection();
            categoriaBindingSource.DataSource = Factory.NewCategoria();
        }

        private void salvaToolStripButton_Click(object sender, EventArgs e)
        {
            categoriaBindingSource.EndEdit();
            Categoria tp = categoriaBindingSource.Current as Categoria;
            if (tp != null)
            {
                try
                {
                    service.SaveCategoria(tp);
                    visualizzaCategorie();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void cancellaToolStripButton_Click(object sender, EventArgs e)
        {
            categoriaBindingSource.EndEdit();
            Categoria tp = categoriaBindingSource.Current as Categoria;
            if (tp != null)
            {
                try
                {
                    service.DeleteCategoria(tp);
                    visualizzaCategorie();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void aboutToolStripButton_Click(object sender, EventArgs e)
        {
            var about = new AboutBox();
            about.ShowDialog();
        }

        private void categorieDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (categorieBindingSource.Current != null)
                categoriaBindingSource.DataSource = categorieBindingSource.Current;
        }

        private void visualizzaCategorie()
        {
            categorieBindingSource.DataSource = service.GetCategorie();
            categorieDataGridView.ClearSelection();
            categoriaBindingSource.DataSource = Factory.NewCategoria();
        }
    }
}
