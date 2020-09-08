using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Infrastructure;
using System;
using System.Globalization;
using System.IdentityModel;
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
            var fv = kernel.Resolve<FatturaView>();
            fv.FormClosing += (s, a) => kernel.ReleaseComponent(s);
            fv.Show();
        }

        private void CercaFatturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sfv = kernel.Resolve<ListaFattureView>();
            sfv.Show();
            sfv.FormClosing += (s, a) => kernel.ReleaseComponent(s);
        }

        private void ClientiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Non implementato");
        }

        private void FornitoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Non implementato");
        }

        private void ArticoliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArticoloView pv = kernel.Resolve<ArticoloView>();
            pv.FormClosing += (sender2, e2) => kernel.ReleaseComponent(sender2);
            pv.Show();
        }

        private void CategorieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoriaView cv = kernel.Resolve<CategoriaView>();
            cv.FormClosing += (sender2, e2) => kernel.ReleaseComponent(sender2);
            cv.Show();
        }

        private void InformazionisuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new AboutBox().ShowDialog();
        }

        private void EsciToolStripMenuItem_Click(object sender, EventArgs e) =>  Close();

        private void OpzioniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sett = kernel.Resolve<SettingView>();
            sett.FormClosing += (sender2, e2) => kernel.ReleaseComponent(sender2);
            sett.Show();
        }
    }
}
