using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ciccio1.Domain;
using Castle.Core.Logging;

namespace Ciccio1.Presentation.WinForm.Views
{
    public partial class Form1 : Form
    {
        public Form1(ILogger iLogger)
        {
            InitializeComponent();
        }



        public Dettaglio GetDettaglio()
        {
            dettaglioBindingSource.EndEdit();
            return dettaglioBindingSource.Current as Dettaglio;
        }

        public Fattura GetFattura()
        {
            fatturaBindingSource.EndEdit();
            return fatturaBindingSource.Current as Fattura;
        }

        public Dettaglio GetSelectedDettaglio()
        {
            return dettagliBindingSource.Current as Dettaglio;
        }

        public Fattura GetSelectedFattura()
        {
            return fattureBindingSource.Current as Fattura;
        }

        public void SetDettaglio(Dettaglio dettaglio)
        {
            dettaglioBindingSource.DataSource = dettaglio;
        }

        public void SetFattura(Fattura fattura)
        {
            fatturaBindingSource.DataSource = fattura;
        }

        public void SetFatture(IEnumerable<Fattura> list)
        {
            fattureBindingSource.DataSource = list;
        }

        //public void ShowView()
        //{
        //    throw new NotImplementedException();
        //}

        public void ShowWarning(string Title, string Message)
        {
            throw new NotImplementedException();
        }

        private void nuovaFatturaToolStripButton_Click(object sender, EventArgs e)
        {
            fattureDataGridView.ClearSelection();
        }

        private void salvaFatturaToolStripButton_Click(object sender, EventArgs e)
        {
        }

        private void cancellaFatturaToolStripButton_Click(object sender, EventArgs e)
        {
        }

        private void aboutToolStripButton_Click(object sender, EventArgs e)
        {
        }

        private void nuovoDettaglioToolStripButton_Click(object sender, EventArgs e)
        {
            dettagliDataGridView.ClearSelection();
        }

        private void aggiungiDettaglioToolStripButton_Click(object sender, EventArgs e)
        {
        }

        private void rimuoviDettaglioToolStripButton_Click(object sender, EventArgs e)
        {
        }

        private void prodottiToolStripButton_Click(object sender, EventArgs e)
        {
        }

        private void tipoProdottoToolStripButton_Click(object sender, EventArgs e)
        {
        }

        private void fattureDataGridView_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void dettagliDataGridView_SelectionChanged(object sender, EventArgs e)
        {
        }

        public void SetDettagli(IEnumerable<Dettaglio> dettagli)
        {
            throw new NotImplementedException();
        }
    }
}
