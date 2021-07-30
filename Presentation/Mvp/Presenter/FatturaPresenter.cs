﻿using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.Mvp.View;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.Mvp.Presenter
{
    public class FatturaPresenter : PresenterBase, IPresenter
    {
        private readonly ILogger logger;
        private readonly IServiceProvider serviceProvider;
        private readonly IServiceScopeFactory serviceScopeFactory;
        private readonly IFatturaService service;
        private readonly IFatturaView view;

        public event EventHandler CloseEvent;

        public FatturaPresenter(ILogger<FatturaPresenter> logger,
                                IServiceProvider serviceProvider,
                                IServiceScopeFactory serviceScopeFactory,
                                IFatturaView fatturaView,
                                IFatturaService fatturaService)
            :base(fatturaView)
        {
            this.logger = logger;
            this.serviceProvider = serviceProvider;
            this.serviceScopeFactory = serviceScopeFactory;
            view = fatturaView;
            service = fatturaService;

            view.AggiungiDettaglioEvent += View_AggiungiDettaglioEvent;
            view.ApriFatturaEvent += View_ApriFatturaEvent;
            view.EliminaFatturaEvent += View_EliminaEvent;
            view.CloseEvent += View_EsciEvent;
            view.LoadEvent += View_LoadEvent;
            view.NuovoDettaglioEvent += View_NuovoDettaglioEvent;
            view.RimuoviDettaglioEvent += View_RimuoviDettaglioEvent;
            view.SalvaFatturaEvent += View_SalvaEvent;

            this.logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

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

        private async void View_SalvaEvent(object sender, Fattura e)
        {
            await service.SaveFattura(e);
        }

        private void View_RimuoviDettaglioEvent(object sender, FatturaDettaglioEventArgs e)
        {
            e.Fattura.RemoveDettaglio(e.Dettaglio);
            view.SetDettaglio(new Dettaglio(null, 0));
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

        private void View_LoadEvent(object sender, EventArgs e)
        {
        }

        private void View_EsciEvent(object sender, EventArgs e)
        {
        }

        private async void View_EliminaEvent(object sender, int e)
        {
            await service.DeleteFattura(e);
        }

        private void View_ApriFatturaEvent(object sender, EventArgs e)
        {
            var sfv = serviceProvider.GetService<ListaFatturePresenter>();
            //sfv.FormClosing += (s, a) => kernel.ReleaseComponent(s);
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

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}