using Castle.Windsor;
using CiccioGest.Infrastructure;
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
    public partial class MainView : Form, ICazzo
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void nuovaFatturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FatturaView fv = Bootstrap.Windsor.Resolve<FatturaView>();
            fv.FormClosing += FormClose;
            fv.Show();
        }

        private void cercaFatturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FatturaView fv = Bootstrap.Windsor.Resolve<FatturaView>(new { idFattura = 0 });
            fv.FormClosing += FormClose;
            fv.Show();
        }

        private void gestioneClientiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Non implementato");
        }

        private void esciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void FormClose(object sender, FormClosingEventArgs e)
        {
            Bootstrap.Windsor.Release(sender);
        }

        private void prodottiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProdottoView pv = Bootstrap.Windsor.Resolve<ProdottoView>();
            pv.FormClosing += FormClose;
            pv.Show();
        }

        private void categorieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoriaView cv = Bootstrap.Windsor.Resolve<CategoriaView>();
            cv.FormClosing += FormClose;
            cv.Show();
        }
    }
}
