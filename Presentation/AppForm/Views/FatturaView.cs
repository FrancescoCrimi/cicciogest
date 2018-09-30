using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain;
using CiccioGest.Domain.Documenti;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Views
{
    public partial class FatturaView : Form
    {
        private ILogger logger;
        private IFatturaService service;

        public FatturaView(IFatturaService service, ILogger logger, int idFattura)
        {
            InitializeComponent();
            this.service = service;
            this.logger = logger;
            if (idFattura == 0)
                fatturaBindingSource.DataSource = new Fattura();
            else
                fatturaBindingSource.DataSource = service.GetFattura(idFattura);
            dettaglioBindingSource.DataSource = new Dettaglio();
        }

        #region metodi eventi

        private void nuovaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fatturaBindingSource.DataSource = new Fattura();
        }

        private void salvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            service.SaveFattura((Fattura)fatturaBindingSource.DataSource);
            Close();
        }

        private void eliminaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            service.DeleteFattura(((Fattura)fatturaBindingSource.DataSource).Id);
            Close();
        }

        private void esciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void prodottiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProdottoView pv = ViewResolver.Resolve<ProdottoView>();
            pv.Show();
        }

        private void categorieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoriaView cv = ViewResolver.Resolve<CategoriaView>();
            cv.Show();
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
            return idProd;
        }
        #endregion


        private void FatturaView_Load(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }
    }
}
