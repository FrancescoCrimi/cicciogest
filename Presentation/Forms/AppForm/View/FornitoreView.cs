using CiccioGest.Domain.ClientiFornitori;
using System;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.View
{
    public partial class FornitoreView : Form, IFornitoreView
    {
        public FornitoreView()
        {
            InitializeComponent();
        }

        public event EventHandler LoadEvent;
        public event EventHandler CloseEvent;
        public event EventHandler NuovoFornitore;
        public event EventHandler SalvaFornitore;
        public event EventHandler ApriFornitore;

        public void MostraFornitore(Fornitore fornitore)
            => fornitoreBindingSource.DataSource = fornitore;


        #region Gestione eventi

        private void FornitoreView_Load(object sender, EventArgs e)
            => LoadEvent?.Invoke(sender, e);

        private void FornitoreView_FormClosing(object sender, FormClosingEventArgs e)
            => CloseEvent?.Invoke(sender, e);

        private void NuovoToolStripButton_Click(object sender, EventArgs e)
            => NuovoFornitore?.Invoke(sender, e);

        private void ApriToolStripButton_Click(object sender, EventArgs e)
            => ApriFornitore?.Invoke(sender, e);

        private void SalvaToolStripButton_Click(object sender, EventArgs e)
            => SalvaFornitore?.Invoke(sender, e);

        private void StampaToolStripButton_Click(object sender, EventArgs e) { }

        private void AboutToolStripButton_Click(object sender, EventArgs e)
            => new AboutBox().ShowDialog();

        #endregion
    }
}
