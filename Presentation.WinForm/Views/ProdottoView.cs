using Castle.Core.Logging;
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
    public partial class ProdottoView : Form, DummyForm
    {
        private ILogger logger;
        private ICiccioService service;

        public ProdottoView(
            ILogger logger,
            ICiccioService service
            )
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
                    service.DeleteProdotto(p);
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

        private void prodottiDataGridView_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (prodottiBindingSource.Current != null)
                prodottoBindingSource.DataSource = prodottiBindingSource.Current;
        }

        private void visualizzaProdotti()
        {
            prodottiBindingSource.DataSource = service.GetProdotti();
            prodottiDataGridView.ClearSelection();
            prodottoBindingSource.DataSource = Factory.NewProdotto();
            categorieBindingSource.DataSource = service.GetCategorie();
        }
    }
}
