using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.AppForm.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public class FatturaPresenter : IPresenter
    {
        private readonly ILogger logger;
        private readonly IKernel kernel;
        private readonly IFatturaService fatturaService;
        private readonly IFatturaView view;

        public FatturaPresenter(ILogger logger,
                           IKernel kernel,
                           IFatturaView view,
                           IFatturaService fatturaService)
        {
            this.logger = logger;
            this.kernel = kernel;
            this.view = view;
            this.fatturaService = fatturaService;

            view.AggiungiDettaglioEvent += View_AggiungiDettaglioEvent;
            view.ApriFatturaEvent += View_ApriFatturaEvent;
            view.EliminaEvent += View_EliminaEvent;
            view.EsciEvent += View_EsciEvent;
            view.LoadEvent += View_LoadEvent;
            view.NuovoDettaglioEvent += View_NuovoDettaglioEvent;
            view.RimuoviDettaglioEvent += View_RimuoviDettaglioEvent;
            view.SalvaEvent += View_SalvaEvent;

            this.logger.Debug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public async void NuovaFattura(int idCliente = 0)
        {
            if (idCliente != 0)
            {
                var cliente = await fatturaService.GetCliente(idCliente);
                var fattura = new Fattura(cliente);
                view.SetFattura(fattura);
                view.SetDettaglio(new Dettaglio());
            }
        }

        public async void MostraFattura(int idFattura)
        {
            if (idFattura != 0)
            {
                var fattura = await fatturaService.GetFattura(idFattura);
                view.SetFattura(fattura);
                view.SetDettaglio(new Dettaglio());
            }
        }

        public void Show() => view.Show();

        private async void View_SalvaEvent(object sender, Fattura e)
        {
            await fatturaService.SaveFattura(e);
        }

        private void View_RimuoviDettaglioEvent(object sender, FatturaDettaglioEventArgs e)
        {
            e.Fattura.RemoveDettaglio(e.Dettaglio);
            view.SetDettaglio(new Dettaglio(null, 0));
        }

        private async void View_NuovoDettaglioEvent(object sender, EventArgs e)
        {
            ListaArticoliView spv = kernel.Resolve<ListaArticoliView>();
            spv.ShowDialog();
            int idProdotto = spv.IdProdotto;
            kernel.ReleaseComponent(spv);
            if (idProdotto != 0)
            {
                var articolo = await fatturaService.GetArticolo(idProdotto);
                view.SetDettaglio(new Dettaglio { Articolo = articolo, Quantita = 1 });
            }
        }

        private void View_LoadEvent(object sender, EventArgs e)
        {
        }

        private void View_EsciEvent(object sender, EventArgs e)
        {
        }

        private async void View_EliminaEvent(object sender, int e)
        {
            await fatturaService.DeleteFattura(e);
        }

        private void View_ApriFatturaEvent(object sender, EventArgs e)
        {
            var sfv = kernel.Resolve<ListaFattureView>();
            sfv.FormClosing += (s, a) => kernel.ReleaseComponent(s);
            sfv.Show();
        }

        private void View_AggiungiDettaglioEvent(object sender, FatturaDettaglioEventArgs e)
        {
            if (e.Dettaglio.Id == 0)
            {
                e.Fattura.AddDettaglio(e.Dettaglio);
            }
            view.SetDettaglio(new Dettaglio(null, 0));
        }
    }
}
