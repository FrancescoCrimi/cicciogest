using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
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
    public partial class FattureView : Form
    {
        private ILogger logger;
        private IFatturaService service;

        public FattureView(ILogger logger, IFatturaService service)
        {
            InitializeComponent();
            this.logger = logger;
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
            pv.Show();
        }

        private void categorieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoriaView categoriaView = ViewResolver.Resolve<CategoriaView>();
            categoriaView.Show();
        }

        private void fattureDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            modificaFatturaSelezionata();
        }

        private void visualizzaFatture()
        {
            IEnumerable<FatturaReadOnly> fatt = service.GetFatture();
            fattureBindingSource.DataSource = fatt;
            fattureDataGridView.ClearSelection();
        }

        private void modificaFatturaSelezionata()
        {
            if (fattureBindingSource.Current != null)
            {                
                apriFatturaForm(((FatturaReadOnly)fattureBindingSource.Current).Id);
            }
        }

        private void apriFatturaForm(int id)
        {
            FatturaView fatturaView = ViewResolver.Resolve<FatturaView>(new { idFattura = id });
            fatturaView.FormClosed += (object sender, FormClosedEventArgs e) => visualizzaFatture();
            fatturaView.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }
    }
}
