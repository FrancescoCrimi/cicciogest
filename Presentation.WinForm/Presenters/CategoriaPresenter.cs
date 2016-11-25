using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciccio1.Presentation.WinForm.Views;
using Ciccio1.Domain;
using Ciccio1.Application;
using System.Windows.Forms;
using Castle.MicroKernel;
using Castle.Core.Logging;

namespace Ciccio1.Presentation.WinForm.Presenters
{
    public class CategoriaPresenter : IDisposable
    {
        private IKernel kernel;
        private ILogger logger;
        private ICiccioService service;
        private CategoriaView view;

        private bool categorieLoaging = false;

        public CategoriaPresenter(
            IKernel kernel,
            ILogger logger,
            ICiccioService service,
            CategoriaView view)
        {
            this.kernel = kernel;
            this.logger = logger;
            this.service = service;
            this.view = view;

            this.view.Load += View_Load;
            this.view.NuovoToolStripButton.Click += nuovoToolStripButton_Click;
            this.view.SalvaToolStripButton.Click += salvaToolStripButton_Click;
            this.view.CancellaToolStripButton.Click += cancellaToolStripButton_Click;
            this.view.CategorieDataGridView.SelectionChanged += CategorieDataGridView_SelectionChanged;
            this.view.AboutToolStripButton.Click += aboutToolStripButton_Click;
            this.view.FormClosed += View_FormClosed;
            this.logger.Debug("CategoriaPresenter Creata");
        }

        #region metodi eventi

        private void View_Load(object sender, EventArgs e)
        {
            visualizzaCategorie();
        }

        private void nuovoToolStripButton_Click(object sender, EventArgs e)
        {
            view.CategorieDataGridView.ClearSelection();
            view.CategoriaBindingSource.DataSource = Factory.NewTransientCategoria();
        }

        private void salvaToolStripButton_Click(object sender, EventArgs e)
        {
            view.CategoriaBindingSource.EndEdit();
            Categoria tp = view.CategoriaBindingSource.Current as Categoria;
            if (tp != null)
            {
                try
                {
                    service.SaveCategoria(tp);
                    visualizzaCategorie();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void cancellaToolStripButton_Click(object sender, EventArgs e)
        {
            view.CategoriaBindingSource.EndEdit();
            Categoria tp = view.CategoriaBindingSource.Current as Categoria;
            if (tp != null)
            {
                try
                {
                    service.DeleteCategoria(tp);
                    visualizzaCategorie();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void CategorieDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (!categorieLoaging)
            {
                Categoria tp = view.CategorieBindingSource.Current as Categoria;
                if (tp != null)
                {
                    view.CategoriaBindingSource.DataSource = tp;
                }
            }
        }

        private void aboutToolStripButton_Click(object sender, EventArgs e)
        {
            var about = new AboutBox();
            about.ShowDialog();
        }

        private void View_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }

        #endregion metodi eventi

        private void visualizzaCategorie()
        {
            categorieLoaging = true;
            view.CategorieBindingSource.DataSource = service.GetCategorie();
            view.CategorieDataGridView.ClearSelection();
            categorieLoaging = false;
            view.CategoriaBindingSource.DataSource = Factory.NewTransientCategoria();
        }

        public void Show()
        {
            view.Show();
        }

        public void Dispose()
        {
            this.logger.Debug("CategoriaPresenter Dispose");
            kernel.ReleaseComponent(view);
            kernel.ReleaseComponent(service);
        }
    }
}
