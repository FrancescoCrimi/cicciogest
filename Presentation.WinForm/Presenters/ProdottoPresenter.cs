using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciccio1.Presentation.WinForm.Views;
using Ciccio1.Application;
using Ciccio1.Domain;
using System.Windows.Forms;
using Castle.MicroKernel;
using Castle.Core.Logging;

namespace Ciccio1.Presentation.WinForm.Presenters
{
    public class ProdottoPresenter : IDisposable
    {
        private IKernel kernel;
        private ILogger logger;
        private ICiccioService service;
        private ProdottoView view;
        private bool prodottiLoading = false;

        public ProdottoPresenter(
            IKernel kernel,
            ILogger logger,
            ICiccioService service,
            ProdottoView view)
        {
            this.kernel = kernel;
            this.logger = logger;
            this.service = service;
            this.view = view;

            this.view.Load += View_Load;
            this.view.NuovoToolStripButton.Click += NuovoToolStripButton_Click;
            this.view.SalvaToolStripButton.Click += SalvaToolStripButton_Click;
            this.view.CancellaToolStripButton.Click += CancellaToolStripButton_Click;
            this.view.ProdottiDataGridView.SelectionChanged += ProdottiDataGridView_SelectionChanged;
            this.view.AboutToolStripButton.Click += AboutToolStripButton_Click;
            this.view.FormClosed += View_FormClosed;
            this.logger.Debug("ProdottoPresenter Creata");
        }


        #region metodi eventi

        private void View_Load(object sender, EventArgs e)
        {
            visualizzaProdotti();
        }

        private void NuovoToolStripButton_Click(object sender, EventArgs e)
        {
            view.ProdottoBindingSource.DataSource = Factory.NewProdotto();
        }

        private void SalvaToolStripButton_Click(object sender, EventArgs e)
        {
            view.ProdottoBindingSource.EndEdit();
            Prodotto p = view.ProdottoBindingSource.Current as Prodotto;
            if (p != null)
            {
                try
                {
                    service.SaveProdotto(p);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                visualizzaProdotti();
            }
        }

        private void CancellaToolStripButton_Click(object sender, EventArgs e)
        {
            view.ProdottoBindingSource.EndEdit();
            Prodotto p = view.ProdottoBindingSource.Current as Prodotto;
            if (p != null)
            {
                try
                {
                    service.DeleteProdotto(p);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                visualizzaProdotti();
            }
        }

        private void ProdottiDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (!prodottiLoading)
            {
                Prodotto p = view.ProdottiBindingSource.Current as Prodotto;
                if (p != null)
                {
                    view.ProdottoBindingSource.DataSource = p;
                }
            }
        }

        private void AboutToolStripButton_Click(object sender, EventArgs e)
        {
            var about = new AboutBox();
            about.ShowDialog();
        }

        private void View_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            Dispose();
        }

        #endregion metodi eventi


        private void visualizzaProdotti()
        {
            prodottiLoading = true;
            view.ProdottiBindingSource.DataSource = service.GetProdotti();
            view.ProdottiDataGridView.ClearSelection();
            prodottiLoading = false;
            view.ProdottoBindingSource.DataSource = Factory.NewProdotto();
            view.CategorieProdottoBindingSource.DataSource = service.GetCategorie();
        }

        public void Show()
        {
            view.ShowDialog();
        }

        public void Dispose()
        {
            this.logger.Debug("ProdottoPresenter Dispose");
            kernel.ReleaseComponent(service);
            kernel.ReleaseComponent(view);
        }
    }
}
