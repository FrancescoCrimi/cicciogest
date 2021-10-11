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
        public event EventHandler ApriFatturaEvent;
        public event EventHandler CloseEvent;
        public event EventHandler<Fattura> SalvaFatturaEvent;
        public event EventHandler<int> EliminaFatturaEvent;
        public event EventHandler NuovoDettaglioEvent;
        public event FatturaDettaglioEventHandler AggiungiDettaglioEvent;
        public event FatturaDettaglioEventHandler RimuoviDettaglioEvent;
        public event EventHandler NuovaFattura;

        public FatturaView(ILogger<FatturaView> logger)
        {
            this.logger = logger;
            InitializeComponent();
            this.logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public void SetDettaglio(Dettaglio dettaglio)
            => dettaglioBindingSource.DataSource = dettaglio;

        public void SetFattura(Fattura fattura)
            => fatturaBindingSource.DataSource = fattura;


        private void FatturaViewLoad(object sender, EventArgs e)
            => LoadEvent?.Invoke(this, new EventArgs());

        private void FatturaView_FormClosed(object s, FormClosedEventArgs e)
            => CloseEvent?.Invoke(this, new EventArgs());


        private void ApriClick(object s, EventArgs e)
            => ApriFatturaEvent?.Invoke(this, new EventArgs());

        private void EsciClick(object s, EventArgs e)
            => Close();

        private void SalvaClick(object s, EventArgs e)
            => SalvaFatturaEvent?.Invoke(this, (Fattura)fatturaBindingSource.DataSource);

        private  void EliminaClick(object s, EventArgs e)
            => EliminaFatturaEvent?.Invoke(this, ((Fattura)fatturaBindingSource.DataSource).Id);

        private void NuovoDettaglioClick(object s, EventArgs e)
            => NuovoDettaglioEvent?.Invoke(this, new EventArgs());

        private void AggiungiDettaglioClick(object s, EventArgs e)
        {
            Fattura fattura = (Fattura)fatturaBindingSource.DataSource;
            Dettaglio dettaglio = (Dettaglio)dettaglioBindingSource.Current;
            AggiungiDettaglioEvent?.Invoke(s, new FatturaDettaglioEventArgs(fattura, dettaglio));
        }

        private void RimuoviDettaglioClick(object s, EventArgs e)
        {
            Fattura fattura = (Fattura)fatturaBindingSource.DataSource;
            Dettaglio dettaglio = (Dettaglio)dettaglioBindingSource.Current;
            RimuoviDettaglioEvent?.Invoke(s, new FatturaDettaglioEventArgs(fattura, dettaglio));
        }

        private void DettagliDataGridViewCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dettagliBindingSource.Current != null)
                dettaglioBindingSource.DataSource = dettagliBindingSource.Current;
        }

        private void AboutToolStripButton_Click(object sender, EventArgs e)
            => new AboutBox().ShowDialog();
    }
}
