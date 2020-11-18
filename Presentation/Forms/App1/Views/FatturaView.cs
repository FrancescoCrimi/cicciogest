using Castle.Core.Logging;
using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.AppForm.Presenter;
using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Views
{
    public partial class FatturaView : Form, IFatturaView
    {
        private readonly ILogger logger;

        public event EventHandler LoadEvent;
        public event EventHandler ApriFatturaEvent;
        public event EventHandler EsciEvent;
        public event EventHandler<Fattura> SalvaEvent;
        public event EventHandler<int> EliminaEvent;
        public event EventHandler NuovoDettaglioEvent;
        public event FatturaDettaglioEventHandler AggiungiDettaglioEvent;
        public event FatturaDettaglioEventHandler RimuoviDettaglioEvent;

        public FatturaView(ILogger logger)
        {
            this.logger = logger;
            InitializeComponent();
            this.logger.Debug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public void SetDettaglio(Dettaglio dettaglio)
        {
            dettaglioBindingSource.DataSource = dettaglio;
        }

        public void SetFattura(Fattura fattura)
        {
            fatturaBindingSource.DataSource = fattura;
        }

        private void FatturaViewLoad(object sender, EventArgs e)
        {
            LoadEvent?.Invoke(this, e);
        }

        private void ApriClick(object s, EventArgs e)
        {
            ApriFatturaEvent?.Invoke(this, e);
        }

        private void DettagliDataGridViewCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dettagliBindingSource.Current != null)
                dettaglioBindingSource.DataSource = dettagliBindingSource.Current;
        }

        private void EsciClick(object s, EventArgs e) => EsciEvent?.Invoke(s, e);

        private void SalvaClick(object s, EventArgs e)
        {
            try
            {
                SalvaEvent?.Invoke(s, (Fattura)fatturaBindingSource.DataSource);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private  void EliminaClick(object s, EventArgs e)
        {
            try
            {
                EliminaEvent?.Invoke(s, ((Fattura)fatturaBindingSource.DataSource).Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NuovoDettaglioClick(object s, EventArgs e)
        {
            NuovoDettaglioEvent?.Invoke(s, e);
        }

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

        private void ToolStripButton_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }
    }
}
