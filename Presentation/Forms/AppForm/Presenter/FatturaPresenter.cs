using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.AppForm.Services;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public class FatturaPresenter : PresenterBase, IDisposable
    {
        private readonly ILogger logger;
        private readonly WindowService windowService;
        private readonly DialogService dialogService;
        private readonly IFatturaService fatturaService;
        private readonly IFatturaView view;
        private Fattura fattura;

        public FatturaPresenter(ILogger<FatturaPresenter> logger,
                                IFatturaView view,
                                IFatturaService fatturaService,
                                WindowService windowService,
                                DialogService dialogService)
            : base(view)
        {
            this.logger = logger;
            this.view = view;
            this.fatturaService = fatturaService;
            this.windowService = windowService;
            this.dialogService = dialogService;
            view.LoadEvent += View_LoadEvent;
            view.CloseEvent += View_CloseEvent;
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        #region public method

        public async void NuovaFattura(int idCliente = 0)
        {
            if (idCliente != 0)
            {
                var cliente = await fatturaService.GetCliente(idCliente);
                fattura = new Fattura(cliente);
                view.SetFattura(fattura);
                view.SetDettaglio(new Dettaglio());
            }
        }

        public async void MostraFattura(int idFattura)
        {
            if (idFattura != 0)
            {
                fattura = await fatturaService.GetFattura(idFattura);
                view.SetFattura(fattura);
                view.SetDettaglio(new Dettaglio());
            }
        }

        #endregion


        #region Gestione eventi

        private void View_LoadEvent(object sender, EventArgs e)
        {
            view.NuovaFatturaEvent += View_NuovaFatturaEvent;
            view.SalvaFatturaEvent += View_SalvaFatturaEvent;
            view.ApriFatturaEvent += View_ApriFatturaEvent;
            view.NuovoDettaglioEvent += View_NuovoDettaglioEvent;
            view.AggiungiDettaglioEvent += View_AggiungiDettaglioEvent;
            view.RimuoviDettaglioEvent += View_RimuoviDettaglioEvent;
        }

        private void View_CloseEvent(object sender, EventArgs e)
        {
            view.NuovaFatturaEvent -= View_NuovaFatturaEvent;
            view.SalvaFatturaEvent -= View_SalvaFatturaEvent;
            view.ApriFatturaEvent -= View_ApriFatturaEvent;
            view.NuovoDettaglioEvent -= View_NuovoDettaglioEvent;
            view.AggiungiDettaglioEvent -= View_AggiungiDettaglioEvent;
            view.RimuoviDettaglioEvent -= View_RimuoviDettaglioEvent;
        }

        private void View_NuovaFatturaEvent(object sender, EventArgs e)
        {
            var scp = dialogService.OpenDialog<SelezionaClientePresenter>(view);
            if (scp.IdCliente != 0)
                NuovaFattura(scp.IdCliente);
        }

        private async void View_SalvaFatturaEvent(object sender, EventArgs e)
        {
            await fatturaService.SaveFattura(fattura);
        }


        private void View_ApriFatturaEvent(object sender, EventArgs e)
        {
            var sfp = dialogService.OpenDialog<SelezionaFatturaPresenter>(view);
            if (sfp.IdFattura != 0)
                MostraFattura(sfp.IdFattura);
        }

        private async void View_NuovoDettaglioEvent(object sender, EventArgs e)
        {
            var spv = dialogService.OpenDialog<SelezionaArticoloPresenter>(view);
            if (spv.IdArticolo != 0)
            {
                var articolo = await fatturaService.GetArticolo(spv.IdArticolo);
                view.SetDettaglio(new Dettaglio { Articolo = articolo, Quantita = 1 });
            }
        }

        private void View_AggiungiDettaglioEvent(object sender, Dettaglio dettaglio)
        {
            if (dettaglio.Id == 0)
            {
                fattura.AddDettaglio(dettaglio);
            }
            view.SetDettaglio(new Dettaglio(null, 0));
        }

        private void View_RimuoviDettaglioEvent(object sender, Dettaglio dettaglio)
        {
            fattura.RemoveDettaglio(dettaglio);
            view.SetDettaglio(new Dettaglio(null, 0));
        }

        #endregion


        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
