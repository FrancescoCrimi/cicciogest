using Castle.Core.Logging;
using Castle.MicroKernel;
using Castle.MicroKernel.Lifestyle;
using CiccioGest.Presentation.Mvp.View;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.View
{
    public partial class MainView : Form, IMainView
    {
        private readonly ILogger logger;
        private readonly IKernel kernel;

        public event EventHandler LoadEvent;
        public event EventHandler FattureEvent;
        public event EventHandler ClientiEvent;
        public event EventHandler FornitoriEvent;
        public event EventHandler ArticoliEvent;
        public event EventHandler CategorieEvent;
        public event EventHandler OpzioniEvent;
        public event EventHandler CloseEvent;

        public MainView(ILogger logger, IKernel kernel)
        {
            this.logger = logger;
            this.kernel = kernel;
            InitializeComponent();
            this.logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        private void MainView_Load(object s, EventArgs e) => LoadEvent?.Invoke(this, e);
        private void FattureClick(object s, EventArgs e) => FattureEvent?.Invoke(this, e);
        private void ClientiClick(object s, EventArgs e) => ClientiEvent?.Invoke(this, e);
        private void FornitoriClick(object s, EventArgs e) => FornitoriEvent?.Invoke(this, e);
        private void ArticoliClick(object s, EventArgs e) => ArticoliEvent?.Invoke(this, e);
        private void CategorieClick(object s, EventArgs e) => CategorieEvent?.Invoke(this, e);
        private void InformazioniClick(object s, EventArgs e) => new AboutBox().ShowDialog();
        private void EsciClick(object s, EventArgs e) => Close();
        private void OpzioniClick(object s, EventArgs e)
        {
            //OpzioniEvent?.Invoke(this, e);
            using (kernel.BeginScope())
            {
                var sett = kernel.Resolve<SettingView>();
                sett.FormClosing += (s, a) => kernel.ReleaseComponent(s);
                sett.Show();
            }
        }
    }
}
