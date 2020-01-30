using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;
using System;
using System.Windows.Forms;

namespace CiccioGest.Presentation.Forms.App1.Views
{
    public partial class ArticoloView : Form, ICazzo
    {
        private readonly ILogger logger;
        private readonly IMagazinoService magazinoService;

        public ArticoloView(
            ILogger logger,
            IMagazinoService magazinoService)
        {
            InitializeComponent();
            this.logger = logger;
            this.magazinoService = magazinoService;
        }
        private void View_Load(object sender, EventArgs e)
        {
            VisualizzaProdotti();
        }

        private void NuovoToolStripButton_Click(object sender, EventArgs e)
        {
            articoloBindingSource.DataSource = new Articolo();
        }

        private void SalvaToolStripButton_Click(object sender, EventArgs e)
        {
            articoloBindingSource.EndEdit();
            Articolo p = articoloBindingSource.Current as Articolo;
            if (p != null)
            {
                try
                {
                    magazinoService.SaveArticolo(p);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                VisualizzaProdotti();
            }
        }

        private void CancellaToolStripButton_Click(object sender, EventArgs e)
        {
            articoloBindingSource.EndEdit();
            Articolo p = articoloBindingSource.Current as Articolo;
            if (p != null)
            {
                try
                {
                    magazinoService.DeleteArticolo(p.Id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                VisualizzaProdotti();
            }
        }

        private void AboutToolStripButton_Click(object sender, EventArgs e)
        {
            var about = new AboutBox();
            about.ShowDialog();
        }

        private async void ProdottiDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (articoliBindingSource.Current != null)

                articoloBindingSource.DataSource = await magazinoService.GetArticolo(((ArticoloReadOnly)articoliBindingSource.Current).Id);
        }

        private async void VisualizzaProdotti()
        {
            categorieBindingSource.DataSource = await magazinoService.GetCategorie();
            articoliBindingSource.DataSource = await magazinoService.GetArticoli();
            articoloBindingSource.DataSource = new Articolo();
        }
    }
}
