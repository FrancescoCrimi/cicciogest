﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Castle.Core.Logging;

using CiccioGest.Application;
using CiccioGest.Domain;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;

namespace CiccioGest.Presentation.AppForm.Views
{
    public partial class CategoriaView : Form, ICazzo
    {
        private readonly ILogger logger;
        private readonly IMagazinoService service;

        public CategoriaView(
            ILogger logger,
            IMagazinoService service)
        {
            InitializeComponent();
            this.logger = logger;
            this.service = service;
        }

        private void CategoriaView_Load(object sender, EventArgs e)
        {
            VisualizzaCategorie();
        }

        private void NuovoToolStripButton_Click(object sender, EventArgs e)
        {
            categorieDataGridView.ClearSelection();
            CategoriaBindingSource.DataSource = new Categoria();
        }

        private void SalvaToolStripButton_Click(object sender, EventArgs e)
        {
            CategoriaBindingSource.EndEdit();
            if (CategoriaBindingSource.Current is Categoria tp)
            {
                try
                {
                    service.SaveCategoria(tp);
                    VisualizzaCategorie();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void CancellaToolStripButton_Click(object sender, EventArgs e)
        {
            CategoriaBindingSource.EndEdit();
            if (CategoriaBindingSource.Current is Categoria tp)
            {
                try
                {
                    service.DeleteCategoria(tp.Id);
                    VisualizzaCategorie();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void AboutToolStripButton_Click(object sender, EventArgs e)
        {
            var about = new AboutBox();
            about.ShowDialog();
        }

        private void CategorieDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (categorieBindingSource.Current != null)
                CategoriaBindingSource.DataSource = categorieBindingSource.Current;
        }

        private void VisualizzaCategorie()
        {
            categorieBindingSource.DataSource = service.GetCategorie();
            categorieDataGridView.ClearSelection();
            CategoriaBindingSource.DataSource = new Categoria();
        }
    }
}
