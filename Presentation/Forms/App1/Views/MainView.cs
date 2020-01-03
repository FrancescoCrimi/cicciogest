using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Infrastructure;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace CiccioGest.Presentation.Forms.App1.Views
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
            this.logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        private void NuovaFatturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FatturaView fv = kernel.Resolve<FatturaView>();
            fv.FormClosing += FormClose;
            fv.Show();
        }

        private void CercaFatturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sfv = kernel.Resolve<ListaFattureView>();
            sfv.ShowDialog();
            var IdFattura = sfv.IdFattura;
            kernel.ReleaseComponent(sfv);
            if (IdFattura != 0)
            {
                // FatturaView fv = Bootstrap.Windsor.Resolve<FatturaView>(new { idFattura = 0 });
                // fix windsor 5.0
                FatturaView fv = kernel.Resolve<FatturaView>(new Arguments().AddNamed("idFattura", IdFattura));
                fv.FormClosing += FormClose;
                fv.Show();
            }
        }

        private void ClientiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Non implementato");
        }

        private void FornitoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Non implementato");
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

        private void InformazionisuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new AboutBox().ShowDialog();
        }

        private void EsciToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void OpzioniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sett = kernel.Resolve<SettingView>();
            sett.FormClosing += FormClose;
            sett.Show();
        }
    }
}
