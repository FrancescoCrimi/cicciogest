using Castle.Core.Logging;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Views
{
    public partial class MainView : Form, IMainView
    {
        private readonly ILogger logger;
        public event EventHandler EventLoad;
        public event EventHandler EventFatture;
        public event EventHandler EventClienti;
        public event EventHandler EventFornitori;
        public event EventHandler EventArticoli;
        public event EventHandler EventCategorie;
        public event EventHandler EventInformazioni;
        public event EventHandler EventOpzioni;

        public MainView(ILogger logger)
        {
            this.logger = logger;
            InitializeComponent();
            this.logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        private void MainView_Load(object s, EventArgs e) => EventLoad?.Invoke(this, e);
        private void FattureClick(object s, EventArgs e) => EventFatture?.Invoke(this, e);
        private void ClientiClick(object s, EventArgs e) => EventClienti?.Invoke(this, e);
        private void FornitoriClick(object s, EventArgs e) => EventFornitori?.Invoke(this, e);
        private void ArticoliClick(object s, EventArgs e) => EventArticoli?.Invoke(this, e);
        private void CategorieClick(object s, EventArgs e) => EventCategorie?.Invoke(this, e);
        private void InformazioniClick(object s, EventArgs e) => EventInformazioni?.Invoke(this, e);
        private void EsciClick(object s, EventArgs e) => Close();
        private void OpzioniClick(object s, EventArgs e) => EventOpzioni?.Invoke(this, e);
    }
}
