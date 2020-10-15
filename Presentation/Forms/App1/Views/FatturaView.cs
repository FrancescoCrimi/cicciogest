using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Infrastructure;
using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CiccioGest.Presentation.Forms.App1.Views
{
    public partial class FatturaView : Form
    {
        private readonly ILogger logger;
        private readonly IKernel kernel;
        private readonly IFatturaService fatturaService;
        private Fattura fattura;
        private readonly int idFattura;
        private readonly int idCliente;

        public FatturaView(ILogger logger,
                           IKernel kernel,
                           IFatturaService fatturaService,
                           int idFattura = 0,
                           int idCliente = 0)
        {
            if (idFattura == 0 & idCliente == 0)
                throw new Exception("idFattura e idCliente non possono essere entrambi 0");

            this.logger = logger;
            this.kernel = kernel;
            this.fatturaService = fatturaService;
            this.idFattura = idFattura;
            this.idCliente = idCliente;
            InitializeComponent();
            this.logger.Debug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        private async void FatturaView_Load(object sender, EventArgs e)
        {
            
            if (idFattura != 0)
            {
                fattura = await fatturaService.GetFattura(idFattura);
            }
            else
            {
                var cliente = await fatturaService.GetCliente(idCliente);
                fattura = new Fattura(cliente);
            }
            fatturaBindingSource.DataSource = fattura;
            dettaglioBindingSource.DataSource = new Dettaglio();
        }

        private void ApriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sfv = kernel.Resolve<ListaFattureView>();
            sfv.FormClosing += (s, a) => kernel.ReleaseComponent(s);
            sfv.Show();
            Close();
        }

        private void DettagliDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dettagliBindingSource.Current != null)
                dettaglioBindingSource.DataSource = dettagliBindingSource.Current;
        }

        private void esciToolStripButton_Click(object sender, EventArgs e) => Close();

        private async void salvaToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                await fatturaService.SaveFattura((Fattura)fatturaBindingSource.DataSource);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void eliminaToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                await fatturaService.DeleteFattura(((Fattura)fatturaBindingSource.DataSource).Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void nuovoToolStripButton_Click(object sender, EventArgs e)
        {
            ListaArticoliView spv = kernel.Resolve<ListaArticoliView>();
            spv.ShowDialog();
            int idProdotto = spv.IdProdotto;
            kernel.ReleaseComponent(spv);
            if (idProdotto != 0)
            {
                var articolo = await fatturaService.GetArticolo(idProdotto);
                dettaglioBindingSource.DataSource = new Dettaglio { Articolo = articolo, Quantita = 1 };
            }
        }

        private void aggiungiToolStripButton_Click(object sender, EventArgs e)
        {
            Dettaglio dettaglio = (Dettaglio)dettaglioBindingSource.Current;
            Fattura fattura = (Fattura)fatturaBindingSource.DataSource;
            if (dettaglio.Id == 0)
            {
                fattura.AddDettaglio(dettaglio);
            }
            dettaglioBindingSource.DataSource = new Dettaglio(null, 0);
        }

        private void rimuoviToolStripButton1_Click(object sender, EventArgs e)
        {
            Dettaglio dettaglio = (Dettaglio)dettaglioBindingSource.Current;
            Fattura fattura = (Fattura)fatturaBindingSource.DataSource;
            fattura.RemoveDettaglio(dettaglio);
            dettaglioBindingSource.DataSource = new Dettaglio(null, 0);
        }

        private void ToolStripButton_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }
    }
}
