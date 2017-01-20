using Castle.Core.Logging;
using Ciccio1.Application;
using Ciccio1.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ciccio1.Presentation.WinForm.Views
{
    public partial class FatturaView : Form
    {
        private ILogger logger;
        private ICiccioService service = null;

        public FatturaView(
            ILogger logger,
            ICiccioService service
            )
        {
            InitializeComponent();
            this.service = service;
            this.logger = logger;
        }

        private void View_Load(object sender, EventArgs e)
        {
            visualizzaFatture();
        }

        private void SalvaFatturaToolStripButton_Click(object sender, EventArgs e)
        {
            fatturaBindingSource.EndEdit();
            Fattura f = fatturaBindingSource.Current as Fattura;
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
            fatturaBindingSource.EndEdit();
            Fattura f = fatturaBindingSource.Current as Fattura;
            if (f != null)
            {
                dettaglioBindingSource.EndEdit();
                Dettaglio d = dettaglioBindingSource.Current as Dettaglio;
                if (d != null)
                {
                    f.RemoveDettaglio(d);
                    showDettagli(f.Dettagli);
                    clearDettaglio();
                }
            }
        }

        private void NuovoDettaglioToolStripButton_Click(object sender, EventArgs e)
        {
            dettagliDataGridView.ClearSelection();
            SelectProdottoView spp = Program.Container.Resolve<SelectProdottoView>();
            spp.ShowDialog();
            if (spp.ProdottoSelezionato != null)
            {
                Dettaglio newdett = new Dettaglio(spp.ProdottoSelezionato, 1);
                dettaglioBindingSource.DataSource = newdett;
            }
            Program.Container.Release(spp);
        }

        private void NuovaFatturaToolStripButton_Click(object sender, EventArgs e)
        {
            nuovaFattura();
        }

        private void CancellaFatturaToolStripButton_Click(object sender, EventArgs e)
        {
            fatturaBindingSource.EndEdit();
            Fattura f = fatturaBindingSource.Current as Fattura;
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
            //var asdf = kernel.Resolve<CategoriaPresenter>();
            //asdf.Show();
            CategoriaView cv = Program.Container.Resolve<CategoriaView>();
            cv.ShowDialog();
            Program.Container.Release(cv);
        }

        private void ProdottiToolStripButton_Click(object sender, EventArgs e)
        {
            //ProdottoPresenter pp = kernel.Resolve<ProdottoPresenter>();
            //pp.Show();
            ProdottoView pv = Program.Container.Resolve<ProdottoView>();
            pv.ShowDialog();
            Program.Container.Release(pv);
        }

        private void AggiungiDettaglioToolStripButton_Click(object sender, EventArgs e)
        {
            fatturaBindingSource.EndEdit();
            Fattura f = fatturaBindingSource.Current as Fattura;
            if (f != null)
            {
                dettaglioBindingSource.EndEdit();
                Dettaglio d = dettaglioBindingSource.Current as Dettaglio;
                if (d != null)
                {
                    if (d.Id == 0)
                    {
                        f.AddDettaglio(d);
                        showDettagli(f.Dettagli);
                    }
                    clearDettaglio();
                }
            }
        }

        private void AboutToolStripButton_Click(object sender, EventArgs e)
        {
            var about = new AboutBox();
            about.ShowDialog();
        }




        private void visualizzaFatture()
        {
            var fatt = service.GetFatture();
            fattureBindingSource.Clear();
            foreach (Fattura item in fatt)
            {
                fattureBindingSource.Add(item);
            }
            fattureDataGridView.ClearSelection();
            nuovaFattura();
        }

        private void nuovaFattura()
        {
            fattureDataGridView.ClearSelection();
            mostraFattura(Factory.NewFattura());
        }

        private void mostraFattura(Fattura fattura)
        {
            fatturaBindingSource.DataSource = fattura;
            showDettagli(fattura.Dettagli);
            clearDettaglio();
        }

        private void showDettagli(IEnumerable<Dettaglio> dettagli)
        {
            dettagliBindingSource.Clear();
            foreach (Dettaglio item in dettagli)
            {
                dettagliBindingSource.Add(item);
            }
            dettagliDataGridView.ClearSelection();
        }

        private void clearDettaglio()
        {
            dettaglioBindingSource.DataSource = new Dettaglio();
        }

        private void fattureDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (fattureBindingSource.Current != null)
                mostraFattura(fattureBindingSource.Current as Fattura);
        }

        private void dettagliDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dettagliBindingSource.Current != null)
            {
                dettaglioBindingSource.DataSource = dettagliBindingSource.Current;
            }
        }
    }
}
