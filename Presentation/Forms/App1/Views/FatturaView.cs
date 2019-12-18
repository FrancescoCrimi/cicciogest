using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Infrastructure;
using System;
using System.Windows.Forms;

namespace CiccioGest.Presentation.Forms.App1.Views
{
    public partial class FatturaView : Form, ICazzo
    {
        private readonly ILogger logger;
        private readonly IKernel kernel;
        private readonly IFatturaService service;
        private readonly int? idFattura;

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
            NuovaFattura();
        }

        private void FatturaView_Load(object sender, EventArgs e)
        {
            if (idFattura != null)
            {
                if (idFattura == 0)
                    SelectFattura();
                else
                    ApriFattura((int)idFattura);
            }
        }

        private void NuovaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuovaFattura();
        }

        private void ApriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectFattura();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void SalvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            service.SaveFattura((Fattura)fatturaBindingSource.DataSource);
        }

        private void EliminaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            service.DeleteFattura(((Fattura)fatturaBindingSource.DataSource).Id);
        }

        private void EsciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void NuovoDettaglioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dettaglioBindingSource.DataSource = new Dettaglio();
            SelectProduct();
        }

        private void AggiungiDettaglioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dettaglio dettaglio = (Dettaglio)dettaglioBindingSource.Current;
            Fattura fattura = (Fattura)fatturaBindingSource.DataSource;
            if (dettaglio.Id == 0)
            {
                fattura.AddDettaglio(dettaglio);
            }
            dettaglioBindingSource.DataSource = new Dettaglio(null, 1);
        }

        private void RimuoviDettaglioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dettaglio dettaglio = (Dettaglio)dettaglioBindingSource.Current;
            Fattura fattura = (Fattura)fatturaBindingSource.DataSource;
            if (dettaglio.Id != 0)
                fattura.RemoveDettaglio(dettaglio);
            dettaglioBindingSource.DataSource = new Dettaglio(null, 1);
        }

        private void SelProdottoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectProduct();
        }

        private void DettagliDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dettagliBindingSource.Current != null)
                dettaglioBindingSource.DataSource = dettagliBindingSource.Current;
        }

        private void NomeProdottoTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectProduct();
        }




        private void NuovaFattura()
        {
            fatturaBindingSource.DataSource = new Fattura();
            dettaglioBindingSource.DataSource = new Dettaglio();
        }

        private async void ApriFattura(int idFattura)
        {
            fatturaBindingSource.DataSource = await service.GetFattura(idFattura);
        }

        private void SelectFattura()
        {
            var sfv = kernel.Resolve<ListaFattureView>();
            sfv.ShowDialog();
            if (sfv.IdFattura == 0)
            {
                MessageBox.Show("Fattura non selezionata");
            }
            else
            {
                ApriFattura(sfv.IdFattura);
            }
            kernel.ReleaseComponent(sfv);
        }

        private async void SelectProduct()
        {
            ListaArticoliView spv = kernel.Resolve<ListaArticoliView>();
            spv.ShowDialog();
            int idProdotto = spv.IdProdotto;
            if (idProdotto == 0)
                MessageBox.Show("Prodotto non selezionato");
            else
                ((Dettaglio)dettaglioBindingSource.Current).Articolo = await service.GetArticolo(idProdotto);
            kernel.ReleaseComponent(spv);
        }
    }
}
