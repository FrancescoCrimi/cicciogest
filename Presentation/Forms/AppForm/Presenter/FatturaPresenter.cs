using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public class FatturaPresenter : PresenterBase, IPresenter
    {
        private readonly ILogger logger;
        private readonly IServiceProvider serviceProvider;
        private readonly IFatturaService service;
        private readonly IFatturaView view;

        public FatturaPresenter(ILogger<FatturaPresenter> logger,
                                IFatturaView view,
                                IFatturaService fatturaService,
                                IServiceProvider serviceProvider)
            : base(view)
        {
            this.logger = logger;
            this.view = view;
            service = fatturaService;
            this.serviceProvider = serviceProvider;

            view.LoadEvent += View_LoadEvent;
            view.CloseEvent += View_CloseEvent;
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        #region public method

        public async void NuovaFattura(int idCliente = 0)
        {
            if (idCliente != 0)
            {
                var cliente = await service.GetCliente(idCliente);
                var fattura = new Fattura(cliente);
                view.SetFattura(fattura);
                view.SetDettaglio(new Dettaglio());
            }
        }

        public async void MostraFattura(int idFattura)
        {
            if (idFattura != 0)
            {
                var fattura = await service.GetFattura(idFattura);
                view.SetFattura(fattura);
                view.SetDettaglio(new Dettaglio());
            }
        }

        #endregion


        private void View_LoadEvent(object sender, EventArgs e)
        {
            view.AggiungiDettaglioEvent += View_AggiungiDettaglioEvent;
            view.ApriFatturaEvent += View_ApriFatturaEvent;
            view.EliminaFatturaEvent += View_EliminaEvent;
            view.NuovoDettaglioEvent += View_NuovoDettaglioEvent;
            view.RimuoviDettaglioEvent += View_RimuoviDettaglioEvent;
            view.SalvaFatturaEvent += View_SalvaEvent;
        }

        private void View_CloseEvent(object sender, EventArgs e)
        {
            view.AggiungiDettaglioEvent -= View_AggiungiDettaglioEvent;
            view.ApriFatturaEvent -= View_ApriFatturaEvent;
            view.EliminaFatturaEvent -= View_EliminaEvent;
            view.NuovoDettaglioEvent -= View_NuovoDettaglioEvent;
            view.RimuoviDettaglioEvent -= View_RimuoviDettaglioEvent;
            view.SalvaFatturaEvent -= View_SalvaEvent;
        }


        private void View_AggiungiDettaglioEvent(object sender, FatturaDettaglioEventArgs e)
        {
            if (e.Dettaglio.Id == 0)
            {
                e.Fattura.AddDettaglio(e.Dettaglio);
            }
            view.SetDettaglio(new Dettaglio(null, 0));
        }

        private void View_ApriFatturaEvent(object sender, EventArgs e)
        {
            var sfv = serviceProvider.GetService<ListaFatturePresenter>();
            //sfv.FormClosing += (s, a) => kernel.ReleaseComponent(s);
            sfv.Show();
        }

        private async void View_EliminaEvent(object sender, int e)
        {
            await service.DeleteFattura(e);
        }

        private async void View_NuovoDettaglioEvent(object sender, EventArgs e)
        {
            var spv = serviceProvider.GetService<ListaArticoliPresenter>();
            spv.Show();
            int idProdotto = spv.IdProdotto;
            //kernel.ReleaseComponent(spv);
            if (idProdotto != 0)
            {
                var articolo = await service.GetArticolo(idProdotto);
                view.SetDettaglio(new Dettaglio { Articolo = articolo, Quantita = 1 });
            }
        }

        private void View_RimuoviDettaglioEvent(object sender, FatturaDettaglioEventArgs e)
        {
            e.Fattura.RemoveDettaglio(e.Dettaglio);
            view.SetDettaglio(new Dettaglio(null, 0));
        }

        private async void View_SalvaEvent(object sender, Fattura e)
        {
            await service.SaveFattura(e);
        }


        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
