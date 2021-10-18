using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.AppForm.Presenter;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.View
{
    public partial class FatturaView : Form, IFatturaView
    {
        private readonly ILogger logger;

        public event EventHandler LoadEvent;
        public event EventHandler CloseEvent;
        public event EventHandler NuovaFatturaEvent;
        public event EventHandler SalvaFatturaEvent;
        public event EventHandler ApriFatturaEvent;
        public event EventHandler NuovoDettaglioEvent;
        public event EventHandler<Dettaglio> AggiungiDettaglioEvent;
        public event EventHandler<Dettaglio> RimuoviDettaglioEvent;

        public FatturaView(ILogger<FatturaView> logger)
        {
            InitializeComponent();
            this.logger = logger;
            this.logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        #region Metodi Pubblici

        public void SetDettaglio(Dettaglio dettaglio)
            => dettaglioBindingSource.DataSource = dettaglio;

        public void SetFattura(Fattura fattura)
            => fatturaBindingSource.DataSource = fattura;

        #endregion


        #region Gestione eventi

        private void FatturaView_Load(object sender, EventArgs e)
            => LoadEvent?.Invoke(sender, e);

        private void FatturaView_FormClosing(object sender, FormClosingEventArgs e)
            => CloseEvent?.Invoke(sender, e);


        private void NuovaToolStripButton_Click(object sender, EventArgs e)
            => NuovaFatturaEvent?.Invoke(sender, e);

        private void SalvaToolStripButton_Click(object sender, EventArgs e)
            => SalvaFatturaEvent?.Invoke(sender, e);

        private void ApriToolStripButton_Click(object sender, EventArgs e)
            => ApriFatturaEvent?.Invoke(sender, e);

        private void NuovoDettaglioToolStripButton_Click(object sender, EventArgs e)
            => NuovoDettaglioEvent?.Invoke(sender, e);

        private void AggiungiDettaglioToolStripButton_Click(object sender, EventArgs e)
        {
            if(dettaglioBindingSource.Current is Dettaglio dettaglio)
                AggiungiDettaglioEvent?.Invoke(sender, dettaglio);
        }

        private void RimuoviDettaglioToolStripButton_Click(object sender, EventArgs e)
        {
            if(dettaglioBindingSource.Current is Dettaglio dettaglio)
                RimuoviDettaglioEvent?.Invoke(sender, dettaglio);
        }

        private void AboutToolStripButton_Click(object sender, EventArgs e)
            => new AboutBox().ShowDialog();

        private void DettagliDataGridViewCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dettagliBindingSource.Current != null)
                dettaglioBindingSource.DataSource = dettagliBindingSource.Current;
        }

        #endregion
    }
}
