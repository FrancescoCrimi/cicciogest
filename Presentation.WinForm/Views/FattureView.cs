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
    public partial class FattureView : Form, DummyForm
    {
        private ICiccioService service;

        public FattureView(ICiccioService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void Fatture_Load(object sender, EventArgs e)
        {
            visualizzaFatture();
        }

        private void nuovoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apriFatturaForm(0);
        }

        private void modificaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modificaFatturaSelezionata();
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

        private void fattureDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            modificaFatturaSelezionata();
        }

        private void visualizzaFatture()
        {
            IEnumerable<Fattura> fatt = service.GetFatture();
            fattureBindingSource.DataSource = fatt;
            fattureDataGridView.ClearSelection();
        }

        private void modificaFatturaSelezionata()
        {
            if (fattureBindingSource.Current != null)
            {                
                apriFatturaForm(((Fattura)fattureBindingSource.Current).Id);
            }
        }

        private void apriFatturaForm(int id)
        {
            FatturaView dettFrm = ViewResolver.Resolve<FatturaView>(new { idFattura = id });
            dettFrm.ShowDialog();
            ViewResolver.Release(dettFrm);
            visualizzaFatture();
        }
    }
}
