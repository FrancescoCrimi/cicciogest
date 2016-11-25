using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciccio1.Presentation.WinForm.Views;
using Ciccio1.Domain;
using Ciccio1.Application;
using Castle.Core.Logging;
using Castle.MicroKernel;
using System.Windows.Forms;

namespace Ciccio1.Presentation.WinForm.Presenters
{
    public class FatturaPresenter : IDisposable
    {
        private IKernel kernel;
        private ILogger logger;
        private ICiccioService service = null;
        private FatturaView view;
        private Func<ICiccioService, SelectProdottoPresenter> sppfactory;

        private bool dettIsNew = false;
        private bool fattureLoading = false;
        private bool dettagliLoading = false;


        public FatturaPresenter(
            IKernel kernel,
            ILogger logger,
            ICiccioService service,
            FatturaView view,
            Func<ICiccioService, SelectProdottoPresenter> sppfactory
            )
        {
            this.service = service;
            this.view = view;
            this.logger = logger;
            this.kernel = kernel;
            this.sppfactory = sppfactory;

            this.view.Load += View_Load;
            this.view.FattureDataGridView.SelectionChanged += FattureDataGridView_SelectionChanged;
            this.view.DettagliDataGridView.SelectionChanged += DettagliDataGridView_SelectionChanged;
            this.view.SalvaFatturaToolStripButton.Click += SalvaFatturaToolStripButton_Click;
            this.view.RimuoviDettaglioToolStripButton.Click += RimuoviDettaglioToolStripButton_Click;
            this.view.NuovoDettaglioToolStripButton.Click += NuovoDettaglioToolStripButton_Click;
            this.view.NuovaFatturaToolStripButton.Click += NuovaFatturaToolStripButton_Click;
            this.view.CancellaFatturaToolStripButton.Click += CancellaFatturaToolStripButton_Click;
            this.view.CategorieToolStripButton.Click += CategorieToolStripButton_Click;
            this.view.ProdottiToolStripButton.Click += ProdottiToolStripButton_Click;
            this.view.AggiungiDettaglioToolStripButton.Click += AggiungiDettaglioToolStripButton_Click;
            this.view.AboutToolStripButton.Click += AboutToolStripButton_Click;
            this.view.FormClosed += View_FormClosed;
            this.logger.Debug("Classe FatturaPresenter Creata");
        }

        #region metodi eventi

        private void View_Load(object sender, EventArgs e)
        {
            visualizzaFatture();
        }

        private void FattureDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (!fattureLoading)
            {
                Fattura fs = view.FattureBindingSource.Current as Fattura;
                if (fs != null)
                {
                    //var fatt = service.GetFattura(fs.IdFattura);
                    //visualizzaFattura(fatt);
                    mostraFattura(fs);
                }
            }
        }

        private void DettagliDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (!dettagliLoading)
            {
                Dettaglio d = view.DettagliBindingSource.Current as Dettaglio;
                if (d != null)
                {
                    view.DettaglioBindingSource.DataSource = d;
                    dettIsNew = false;
                }
            }
        }

        private void SalvaFatturaToolStripButton_Click(object sender, EventArgs e)
        {
            view.FatturaBindingSource.EndEdit();
            Fattura f = view.FatturaBindingSource.Current as Fattura;
            if (f != null)
            {
                try
                {
                    service.SaveFattura(f);
                    visualizzaFatture();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void RimuoviDettaglioToolStripButton_Click(object sender, EventArgs e)
        {
            view.FatturaBindingSource.EndEdit();
            Fattura f = view.FatturaBindingSource.Current as Fattura;
            if (f != null)
            {
                view.DettaglioBindingSource.EndEdit();
                Dettaglio d = view.DettaglioBindingSource.Current as Dettaglio;
                if (d != null)
                {
                    f.RemoveDettaglio(d);
                    clearDettaglio();
                }
            }
        }

        private void NuovoDettaglioToolStripButton_Click(object sender, EventArgs e)
        {
            view.DettagliDataGridView.ClearSelection();
            var spp = sppfactory(service);
            spp.Show();
            Dettaglio newdett = Factory.NuovoDettaglio(spp.ProdottoSelezionato, 1);
            spp.Dispose();
            view.DettaglioBindingSource.DataSource = newdett;
            dettIsNew = true;
        }

        private void NuovaFatturaToolStripButton_Click(object sender, EventArgs e)
        {
            nuovaFattura();
        }

        private void CancellaFatturaToolStripButton_Click(object sender, EventArgs e)
        {
            view.FatturaBindingSource.EndEdit();
            Fattura f = view.FatturaBindingSource.Current as Fattura;
            if (f != null)
            {
                try
                {
                    service.DeleteFattura(f);
                    visualizzaFatture();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void CategorieToolStripButton_Click(object sender, EventArgs e)
        {
            var asdf = kernel.Resolve<CategoriaPresenter>();
            asdf.Show();
        }

        private void ProdottiToolStripButton_Click(object sender, EventArgs e)
        {
            ProdottoPresenter pp = kernel.Resolve<ProdottoPresenter>();
            pp.Show();
        }

        private void AggiungiDettaglioToolStripButton_Click(object sender, EventArgs e)
        {
            if (dettIsNew)
            {
                view.FatturaBindingSource.EndEdit();
                Fattura f = view.FatturaBindingSource.Current as Fattura;
                if (f != null)
                {
                    view.DettaglioBindingSource.EndEdit();
                    Dettaglio d = view.DettaglioBindingSource.Current as Dettaglio;
                    if (d != null)
                    {
                        f.AddDettaglio(d);
                        showDettagli(f.Dettagli);
                        clearDettaglio();
                    }
                }
                dettIsNew = false;
            }
        }

        private void AboutToolStripButton_Click(object sender, EventArgs e)
        {
            var about = new AboutBox();
            about.ShowDialog();
        }

        private void View_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }

        #endregion metodi eventi


        public FatturaView View
        {
            get
            {
                return (FatturaView)view;
            }
        }


        private void visualizzaFatture()
        {
            fattureLoading = true;
            var fatt = service.GetFatture();
            view.FattureBindingSource.Clear();
            foreach (Fattura item in fatt)
            {
                view.FattureBindingSource.Add(item);
            }
            view.FattureDataGridView.ClearSelection();
            fattureLoading = false;
            nuovaFattura();
        }

        private void nuovaFattura()
        {
            view.FattureDataGridView.ClearSelection();
            mostraFattura(Factory.NewTransientFattura());
        }

        private void mostraFattura(Fattura fattura)
        {
            view.FatturaBindingSource.DataSource = fattura;
            showDettagli(fattura.Dettagli);
            clearDettaglio();
        }

        private void showDettagli(IEnumerable<Dettaglio> dettagli)
        {
            dettagliLoading = true;
            view.DettagliBindingSource.Clear();
            foreach (Dettaglio item in dettagli)
            {
                view.DettagliBindingSource.Add(item);
            }
            view.DettagliDataGridView.ClearSelection();
            dettagliLoading = false;
        }

        private void clearDettaglio()
        {
            view.DettaglioBindingSource.DataSource = Factory.NuovoDettaglio(null, 0);
            dettIsNew = false;
        }

        public void Dispose()
        {
            logger.Debug("FatturaPresenter Dispose");
            kernel.ReleaseComponent(service);
        }
    }
}
