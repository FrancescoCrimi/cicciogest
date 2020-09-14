using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts.Presenter;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts.View;

namespace CiccioGest.Presentation.Gtk.AppGtk.Presenter
{
    public class FatturaPresenter : IFatturaPresenter
    {
        private readonly ILogger logger;
        private readonly IKernel kernel;
        private readonly IFatturaService fatturaService;
        private readonly IFatturaView fatturaView;

        public FatturaPresenter(ILogger logger,
                                IKernel kernel,
                                IFatturaService fatturaService,
                                IFatturaView fatturaView)
        {
            this.logger = logger;
            this.kernel = kernel;
            this.fatturaService = fatturaService;
            this.fatturaView = fatturaView;
            fatturaView.SetPresenter(this);
            logger.Debug("HashCode: " + this.GetHashCode().ToString());
        }

        public void AggiungiDettaglio()
        {
        }

        public void AprFattura()
        {
            var lfp = kernel.Resolve<ListaFatturePresenter>();
            lfp.EventoSelezione += Lfp_EventoSelezione;
            lfp.ShowView();
        }

        public void EliminaFattura()
        {
        }

        public void NuovaFattura()
        {
        }

        public void NuovoDattaglio()
        {
            var lap = kernel.Resolve<ListaArticoliPresenter>();
            lap.EventoSelezione += Lap_EventoSelezione;
            lap.ShowView();
        }

        public void RimuoviDettaglio()
        {
        }

        public void SalvaFattura()
        {
        }

        public void Load()
        {
            Fattura fattura = fatturaService.GetFattura(4).Result;
            ShowFattura(fattura);
        }

        public void ShowView() => fatturaView.Show();

        public void Unload()
        {
        }

        private void ShowFattura(Fattura fattura)
        {
            fatturaView.IdFattura.Text = fattura.Id.ToString();
            fatturaView.NomeFattura.Text = fattura.Nome;
            fatturaView.Dettagli.Clear();
            foreach (var item in fattura.Dettagli)
            {
                fatturaView.Dettagli.AppendValues(item.Id, item.NomeProdotto, item.PrezzoProdotto, item.Quantita, item.Totale);
            }
        }

        private void Lfp_EventoSelezione(object sender, int e)
        {
            ((ListaFatturePresenter)sender).EventoSelezione -= Lfp_EventoSelezione;
            if (e != 0)
            {
                var fat = fatturaService.GetFattura(e).Result;
                ShowFattura(fat);
            }
        }

        private void Lap_EventoSelezione(object sender, int e)
        {
            ((ListaArticoliPresenter)sender).EventoSelezione -= Lap_EventoSelezione;
            if (e != 0)
            {
            }
        }
    }
}
