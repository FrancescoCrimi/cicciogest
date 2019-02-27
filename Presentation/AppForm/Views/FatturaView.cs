using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Application;
using CiccioGest.Domain;
using CiccioGest.Domain.Documenti;
using CiccioGest.Infrastructure;
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
    public partial class FatturaView : Form, ICazzo
    {
        private ILogger logger;
        private IKernel kernel;
        private IFatturaService service;
        private int? idFattura;

        public FatturaView(ILogger logger, IKernel kernel, IFatturaService service)
            : this(logger, kernel, service, null)
        {
        }

        public FatturaView(ILogger logger, IKernel kernel, IFatturaService service, int? idFattura)
        {
            this.logger = logger;
            this.kernel = kernel;
            this.service = service;
            this.idFattura = idFattura;
            InitializeComponent();
            nuova();
        }

        private void FatturaView_Load(object sender, EventArgs e)
        {
            if (idFattura != null)
            {
                if (idFattura == 0)
                    selectFattura();
                else
                    apriFattura((int)idFattura);
            }
        }

        private void nuovaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nuova();
        }

        private void apriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectFattura();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void salvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            service.SaveFattura((Fattura)fatturaBindingSource.DataSource);
        }

        private void eliminaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            service.DeleteFattura(((Fattura)fatturaBindingSource.DataSource).Id);
        }

        private void esciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void nuovoDettaglioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dettaglioBindingSource.DataSource = new Dettaglio();
            selectProduct();
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
            selectProduct();
        }

        private void dettagliDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dettagliBindingSource.Current != null)
                dettaglioBindingSource.DataSource = dettagliBindingSource.Current;
        }

        private void nomeProdottoTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            selectProduct();
        }




        private void nuova()
        {
            fatturaBindingSource.DataSource = new Fattura();
            dettaglioBindingSource.DataSource = new Dettaglio();
        }

        private void apriFattura(int idFattura)
        {
            fatturaBindingSource.DataSource = service.GetFattura(idFattura);
        }

        private void selectFattura()
        {
            var sfv = kernel.Resolve<SelectFattureView>();
            sfv.ShowDialog();
            if (sfv.IdFattura == 0)
            {
                MessageBox.Show("Fattura non selezionata");
            }
            else
            {
                apriFattura(sfv.IdFattura);
            }
            kernel.ReleaseComponent(sfv);
        }

        private void selectProduct()
        {
            SelectProdottoView spv = kernel.Resolve<SelectProdottoView>();
            spv.ShowDialog();
            int idProdotto = spv.IdProdotto;
            if (idProdotto == 0)
                MessageBox.Show("Prodotto non selezionato");
            else
                ((Dettaglio)dettaglioBindingSource.Current).Prodotto = service.GetProdotto(idProdotto);
            kernel.ReleaseComponent(spv);
        }
    }
}
