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
    public partial class FattureForm : Form
    {
        //private IFatturaService service;
        private ICiccioService service;

        public FattureForm(ICiccioService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void nuovoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fattureDataGridView.ClearSelection();
            fatturaBindingSource.DataSource = Factory.NewFattura();
        }

        private void modificaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modificaFattura();
        }

        private void salvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fatturaBindingSource.EndEdit();
            Fattura f = fatturaBindingSource.Current as Fattura;
            if (f != null)
            {
                service.SaveFattura(f);
                visualizzaFatture();
            }
        }

        private void eliminaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fatturaBindingSource.EndEdit();
            Fattura f = fatturaBindingSource.Current as Fattura;
            if (f != null)
            {
                service.DeleteFattura(f);
                visualizzaFatture();
            }
        }

        private void esciToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dettagliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DettagliForm dettFrm = Program.Container.Resolve<DettagliForm>();
            dettFrm.ShowDialog();
            Program.Container.Release(dettFrm);
            visualizzaFatture();
        }

        private void prodottiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void categorieToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FattureDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            modificaFattura();
        }

        private void Fatture_Load(object sender, EventArgs e)
        {
            visualizzaFatture();
        }

        private void Fatture_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void visualizzaFatture()
        {
            //fattureLoading = true;
            IEnumerable<Fattura> fatt = service.GetFatture();
            fattureBindingSource.Clear();

            foreach (Fattura item in fatt)
            {
                fattureBindingSource.Add(item);
            }
            fattureDataGridView.ClearSelection();
            //fattureLoading = false;
            //nuovaFattura();
            fatturaBindingSource.DataSource = Factory.NewFattura();
        }

        private void modificaFattura()
        {
            if (fattureBindingSource.Current != null)
                fatturaBindingSource.DataSource = fattureBindingSource.Current;
        }
    }
}
