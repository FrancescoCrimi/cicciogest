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
    public partial class FatturaForm : Form, DummyForm
    {
        //private IFatturaService service;
        private ICiccioService service;
        private int idFattura;
        private Fattura fattura;

        public FatturaForm(ICiccioService service, int idFattura)
        {
            InitializeComponent();
            this.service = service;
            this.idFattura = idFattura;
        }

        private void FatturaForm_Load(object sender, EventArgs e)
        {
            mostraFattura();
        }

        private void nuovoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fattura = Factory.NewFattura();
            mostraFattura();
        }

        private void salvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fatturaBindingSource.EndEdit();
            service.SaveFattura(fattura);
        }

        private void eliminaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            service.DeleteFattura(fattura);
            fattura = Factory.NewFattura();
            mostraFattura();
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
            dettagliDataGridView.ClearSelection();
            SelectProdottoView spp = ViewResolver.Resolve<SelectProdottoView>();
            spp.ShowDialog();
            if (spp.ProdottoSelezionato != null)
            {
                Dettaglio newdett = new Dettaglio(spp.ProdottoSelezionato, 1);
                dettaglioBindingSource.DataSource = newdett;
            }
            ViewResolver.Release(spp);
        }

        private void aggiungiDettaglioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dettaglioBindingSource.EndEdit();
            Dettaglio d = dettaglioBindingSource.Current as Dettaglio;
            if (d != null)
            {
                if (d.Id == 0)
                {
                    fattura.AddDettaglio(d);
                    mostraFattura();
                }
            }

        }

        private void rimuoviDettaglioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dettaglioBindingSource.EndEdit();
            Dettaglio d = dettaglioBindingSource.Current as Dettaglio;
            if (d != null)
            {
                if (d.Id != 0)
                    fattura.RemoveDettaglio(d);
                dettaglioBindingSource.DataSource = new Dettaglio();
                mostraFattura();
            }
        }

        private void selProdottoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dettaglioBindingSource.Current != null)
            {
                Dettaglio dett = dettaglioBindingSource.Current as Dettaglio;
                SelectProdottoView spp = ViewResolver.Resolve<SelectProdottoView>();
                spp.ShowDialog();
                if (spp.ProdottoSelezionato != null)
                {
                    dett.Prodotto = spp.ProdottoSelezionato;
                    dettaglioBindingSource.DataSource = dett;
                }
                ViewResolver.Release(spp);

            }

        }

        private void dettagliDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dettagliBindingSource.Current != null)
                dettaglioBindingSource.DataSource = dettagliBindingSource.Current;
        }

        private void mostraFattura()
        {
            fattura = service.GetFattura(idFattura);
            fatturaBindingSource.DataSource = fattura;
            dettagliBindingSource.DataSource = fattura.Dettagli;
        }
    }
}
