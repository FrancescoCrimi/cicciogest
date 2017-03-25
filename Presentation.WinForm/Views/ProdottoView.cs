using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain;
using CiccioGest.Domain.Model;
using CiccioGest.Domain.ReadOnlyModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CiccioGest.Presentation.WinForm.Views
{
    public partial class ProdottoView : Form
    {
        private ILogger logger;
        private IProdottoService service;

        public ProdottoView(
            ILogger logger,
            IProdottoService service)
        {
            InitializeComponent();
            this.logger = logger;
            this.service = service;
        }
        private void View_Load(object sender, EventArgs e)
        {
            visualizzaProdotti();
        }

        private void NuovoToolStripButton_Click(object sender, EventArgs e)
        {
            prodottoBindingSource.DataSource = Factory.NewProdotto();
        }

        private void SalvaToolStripButton_Click(object sender, EventArgs e)
        {
            prodottoBindingSource.EndEdit();
            Prodotto p = prodottoBindingSource.Current as Prodotto;
            if (p != null)
            {
                try
                {
                    service.SaveProdotto(p);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                visualizzaProdotti();
            }
        }

        private void CancellaToolStripButton_Click(object sender, EventArgs e)
        {
            prodottoBindingSource.EndEdit();
            Prodotto p = prodottoBindingSource.Current as Prodotto;
            if (p != null)
            {
                try
                {
                    service.DeleteProdotto(p.Id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                visualizzaProdotti();
            }
        }

        private void AboutToolStripButton_Click(object sender, EventArgs e)
        {
            var about = new AboutBox();
            about.ShowDialog();
        }

        private void prodottiDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (prodottiBindingSource.Current != null)
                prodottoBindingSource.DataSource = service.GetProdotto(((ProdottoReadOnly)prodottiBindingSource.Current).Id);
        }

        private void visualizzaProdotti()
        {
            categorieBindingSource.DataSource = service.GetCategorie();
            prodottiBindingSource.DataSource = service.GetProdotti();
            prodottoBindingSource.DataSource = Factory.NewProdotto();
        }
    }
}
