using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Application;
using CiccioGest.Domain.Documenti;

namespace CiccioGest.Presentation.Gtk.AppGtk.Presenter
{
    public class FatturaPresenter 
    {
        private readonly ILogger logger;
        private readonly IKernel kernel;
        private readonly IFatturaService fatturaService;

        public FatturaPresenter(ILogger logger,
                                IKernel kernel,
                                IFatturaService fatturaService)
        {
            this.logger = logger;
            this.kernel = kernel;
            this.fatturaService = fatturaService;
            logger.Debug("HashCode: " + this.GetHashCode().ToString());
        }

        //public void AprFattura()
        //{
        //    var lfp = kernel.Resolve<ListaFatturePresenter>();
        //    lfp.EventoSelezione += Lfp_EventoSelezione;
        //    lfp.ShowView();
        //}

        //public void NuovoDattaglio()
        //{
        //    var lap = kernel.Resolve<ListaArticoliPresenter>();
        //    lap.EventoSelezione += Lap_EventoSelezione;
        //    lap.ShowView();
        //}


        //private void Lfp_EventoSelezione(object sender, int e)
        //{
        //    ((ListaFatturePresenter)sender).EventoSelezione -= Lfp_EventoSelezione;
        //    if (e != 0)
        //    {
        //        var fat = fatturaService.GetFattura(e).Result;
        //        //ShowFattura(fat);
        //    }
        //}

        //private void Lap_EventoSelezione(object sender, int e)
        //{
        //    ((ListaArticoliPresenter)sender).EventoSelezione -= Lap_EventoSelezione;
        //    if (e != 0)
        //    {
        //    }
        //}
    }
}
