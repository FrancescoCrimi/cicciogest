using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Infrastructure;
using System;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Views
{
    public partial class MainView : Form, ICazzo
    {
        private readonly ILogger logger;
        private readonly IKernel kernel;

        public MainView(ILogger logger, IKernel kernel)
        {
            this.logger = logger;
            this.kernel = kernel;
            InitializeComponent();
        }

        private void NuovaFatturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FatturaView fv = kernel.Resolve<FatturaView>();
            fv.FormClosing += FormClose;
            fv.Show();
        }

        private void CercaFatturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // FatturaView fv = Bootstrap.Windsor.Resolve<FatturaView>(new { idFattura = 0 });
            // fix windsor 5.0
            FatturaView fv = kernel.Resolve<FatturaView>(new Arguments().AddNamed("idFattura", 0));
            fv.FormClosing += FormClose;
            fv.Show();
        }

        private void ClientiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Non implementato");
        }

        private void FornitoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Non implementato");
        }

        private void EsciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void FormClose(object sender, FormClosingEventArgs e)
        {
            kernel.ReleaseComponent(sender);
        }

        private void ArticoliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArticoloView pv = kernel.Resolve<ArticoloView>();
            pv.FormClosing += FormClose;
            pv.Show();
        }

        private void CategorieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoriaView cv = kernel.Resolve<CategoriaView>();
            cv.FormClosing += FormClose;
            cv.Show();
        }
    }
}
