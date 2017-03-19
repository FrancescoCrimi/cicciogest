using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CiccioGest.Presentation.WinForm.Views
{
    public partial class HomeView : Form
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void nuovaFatturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FatturaView fatturaView = ViewResolver.Resolve<FatturaView>(new { idFattura = 0 });
            fatturaView.Show();
        }
 
        private void cercaFatturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FattureView fattureView = ViewResolver.Resolve<FattureView>();
            fattureView.Show();
        }

        private void gestioneClientiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Non implementato");
        }

        private void gestioneProdottiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProdottoView prodottoView = ViewResolver.Resolve<ProdottoView>();
            prodottoView.Show();
        }

        private void gestioneCategorieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoriaView categoriaView = ViewResolver.Resolve<CategoriaView>();
            categoriaView.Show();
        }

        private void esciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }
    }
}
