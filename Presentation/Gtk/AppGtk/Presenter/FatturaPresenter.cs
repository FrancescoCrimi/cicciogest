using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts;
using CiccioGest.Presentation.Gtk.AppGtk.View;

namespace CiccioGest.Presentation.Gtk.AppGtk.Presenter
{
    public class FatturaPresenter
    {
        private readonly ILogger logger;
        private readonly IKernel kernel;
        private readonly IFatturaService fatturaService;
        private IFatturaView fatturaView;

        public FatturaPresenter(ILogger logger, IKernel kernel, IFatturaService fatturaService)
        {
            this.logger = logger;
            this.kernel = kernel;
            this.fatturaService = fatturaService;
        }

        public void SetView(IFatturaView fatturaView)
        {
            this.fatturaView = fatturaView;
        }

        public void ShowFattura()
        {
            Fattura fattura = fatturaService.GetFattura(4).Result;
            fatturaView.IdFattura.Text = fattura.Id.ToString();
            fatturaView.NomeFattura.Text = fattura.Nome;
            fatturaView.Dettagli.Clear();
            foreach (var item in fattura.Dettagli)
            {
                fatturaView.Dettagli.AppendValues(item.Id, item.NomeProdotto, item.PrezzoProdotto, item.Quantita, item.Totale);
            }
        }

        public void ApriListaFatture()
        {
            var asd = kernel.Resolve<ListaFattureView>();
            asd.Show();
        }
        public void NuovaFattura()
        {
        }
        public void EliminaFattura()
        {

        }
        public void SalvaFattura()
        {

        }
        public void NuovoDattaglio()
        {
            var qwed = kernel.Resolve<ListaArticoliView>();
            qwed.Show();
        }
        public void AggiungiDettaglio()
        {

        }
        public void RimuoviDettaglio()
        {

        }
    }
}
