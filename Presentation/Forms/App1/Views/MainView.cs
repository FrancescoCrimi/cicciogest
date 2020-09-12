using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.AppForm.Views;
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

        private void ArticoliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArticoloView pv = kernel.Resolve<ArticoloView>();
            pv.FormClosing += (s, a) => kernel.ReleaseComponent(s);
            pv.Show();
        }

        private void CategorieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoriaView cv = kernel.Resolve<CategoriaView>();
            cv.FormClosing += (s, a) => kernel.ReleaseComponent(s);
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
            sett.FormClosing += (s, a) => kernel.ReleaseComponent(s);
            sett.Show();
        }

        private void fattureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sfv = kernel.Resolve<ListaFattureView>();
            sfv.Show();
            sfv.FormClosing += (s, a) => kernel.ReleaseComponent(s);
        }

        private void clientiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lcv = kernel.Resolve<ListaClientiView>();
            lcv.FormClosing += (s, a) => kernel.ReleaseComponent(s);
            lcv.Show();
        }

        private void fornitoriToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var lfv = kernel.Resolve<ListaFornitoriView>();
            lfv.FormClosing += (s, a) => kernel.ReleaseComponent(s);
            lfv.Show();
        }
    }
}
