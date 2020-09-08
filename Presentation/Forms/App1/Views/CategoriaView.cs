using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CiccioGest.Presentation.Forms.App1.Views
{
    public partial class CategoriaView : Form, ICazzo
    {
        private readonly ILogger logger;
        private readonly IMagazinoService magazinoService;

        public CategoriaView(
            ILogger logger,
            IMagazinoService magazinoService)
        {
            InitializeComponent();
            this.logger = logger;
            this.magazinoService = magazinoService;
        }

        private async void CategoriaView_Load(object sender, EventArgs e)
        {
            await VisualizzaCategorie();
        }

        private void NuovoToolStripButton_Click(object sender, EventArgs e)
        {
            categorieDataGridView.ClearSelection();
            CategoriaBindingSource.DataSource = new Categoria();
        }

        private async void SalvaToolStripButton_Click(object sender, EventArgs e)
        {
            CategoriaBindingSource.EndEdit();
            if (CategoriaBindingSource.Current is Categoria tp)
            {
                try
                {
                    await magazinoService.SaveCategoria(tp);
                    await VisualizzaCategorie();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private async void CancellaToolStripButton_Click(object sender, EventArgs e)
        {
            CategoriaBindingSource.EndEdit();
            if (CategoriaBindingSource.Current is Categoria tp)
            {
                try
                {
                    await magazinoService.DeleteCategoria(tp.Id);
                    await VisualizzaCategorie();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void AboutToolStripButton_Click(object sender, EventArgs e)
        {
            var about = new AboutBox();
            about.ShowDialog();
        }

        private void CategorieDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (categorieBindingSource.Current != null)
                CategoriaBindingSource.DataSource = categorieBindingSource.Current;
        }

        private async Task VisualizzaCategorie()
        {
            categorieBindingSource.DataSource = await magazinoService.GetCategorie();
            categorieDataGridView.ClearSelection();
            CategoriaBindingSource.DataSource = new Categoria();
        }
    }
}
