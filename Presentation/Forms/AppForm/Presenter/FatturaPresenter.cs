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

        #endregion


        #region Gestione eventi

        private void View_LoadEvent(object sender, EventArgs e)
        {
            view.AggiungiDettaglioEvent += View_AggiungiDettaglioEvent;
            view.ApriFatturaEvent += View_ApriFatturaEvent;
            view.NuovoDettaglioEvent += View_NuovoDettaglioEvent;
            view.RimuoviDettaglioEvent += View_RimuoviDettaglioEvent;
            view.SalvaFatturaEvent += View_SalvaEvent;
        }

        private void View_CloseEvent(object sender, EventArgs e)
        {
            view.AggiungiDettaglioEvent -= View_AggiungiDettaglioEvent;
            view.ApriFatturaEvent -= View_ApriFatturaEvent;
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
            windowService.OpenWindow<FatturePresenter>();
            view.Close();
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

        private void View_RimuoviDettaglioEvent(object sender, FatturaDettaglioEventArgs e)
        {
            e.Fattura.RemoveDettaglio(e.Dettaglio);
            view.SetDettaglio(new Dettaglio(null, 0));
        }

        private async void View_SalvaEvent(object sender, Fattura e)
        {
            await fatturaService.SaveFattura(e);
        }

        #endregion


        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
