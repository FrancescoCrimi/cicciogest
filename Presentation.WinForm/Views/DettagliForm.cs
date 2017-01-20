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
    public partial class DettagliForm : Form
    {
        //private IFatturaService service;
        private ICiccioService service;
        private Fattura fattura;

        public DettagliForm(ICiccioService service, Fattura fattura)
        {
            InitializeComponent();
            this.service = service;
        }

        private void nuovoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void modificaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salvaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eliminaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void esciToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void selezProdottoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void prodottiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void categorieToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dettagliDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void nomeProdottoTextBox_DoubleClick(object sender, EventArgs e)
        {

        }

        private void nomeTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
