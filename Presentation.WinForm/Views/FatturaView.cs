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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ciccio1.Presentation.WinForm.Views
{
    public partial class FatturaView : Form, DummyForm
    {
        private ILogger logger;
        private ICiccioService service;

        public FatturaView(ICiccioService service, ILogger logger, int idFattura)
        {
            InitializeComponent();
            this.service = service;
            this.logger = logger;
            if (idFattura == 0)
                fatturaBindingSource.DataSource = Factory.NewFattura();
            else
                fatturaBindingSource.DataSource = service.GetFattura(idFattura);
            dettaglioBindingSource.DataSource = new Dettaglio();
        }

        #region metodi eventi

        private void nuovaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fatturaBindingSource.DataSource = Factory.NewFattura();
        }

        private void salvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            service.SaveFattura((Fattura)fatturaBindingSource.DataSource);
            Close();
        }

        private void eliminaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            service.DeleteFattura((Fattura)fatturaBindingSource.DataSource);
            Close();
        }

        private void esciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void prodottiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProdottoView pv = ViewResolver.Resolve<ProdottoView>();
            pv.ShowDialog();
            ViewResolver.Release(pv);
        }

        private void categorieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoriaView cv = ViewResolver.Resolve<CategoriaView>();
            cv.ShowDialog();
            ViewResolver.Release(cv);
        }

        private void nuovoDettaglioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dettaglioBindingSource.DataSource = new Dettaglio(service.GetProdotto(selectProd()), 1);
        }

        private void aggiungiDettaglioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dettaglio dettaglio = (Dettaglio)dettaglioBindingSource.Current;
            Fattura fattura = (Fattura)fatturaBindingSource.DataSource;
            if (dettaglio.Id == 0)
            {
                fattura.AddDettaglio(dettaglio);
            }
            dettaglioBindingSource.DataSource = new Dettaglio(null, 1);
        }

        private void rimuoviDettaglioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dettaglio dettaglio = (Dettaglio)dettaglioBindingSource.Current;
            Fattura fattura = (Fattura)fatturaBindingSource.DataSource;
            if (dettaglio.Id != 0)
                fattura.RemoveDettaglio(dettaglio);
            dettaglioBindingSource.DataSource = new Dettaglio(null, 1);
        }

        private void selProdottoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((Dettaglio)dettaglioBindingSource.Current).Prodotto = service.GetProdotto(selectProd());
        }

        private void dettagliDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dettagliBindingSource.Current != null)
                dettaglioBindingSource.DataSource = dettagliBindingSource.Current;
        }

        private void nomeProdottoTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ((Dettaglio)dettaglioBindingSource.Current).Prodotto = service.GetProdotto(selectProd());
        }
        #endregion

        #region metodi privati
        private int selectProd()
        {
            SelectProdottoView spv = ViewResolver.Resolve<SelectProdottoView>();
            spv.ShowDialog();
            int idProd = spv.IdProdotto;
            ViewResolver.Release(spv);
            return idProd;
        }
        #endregion
    }
}
