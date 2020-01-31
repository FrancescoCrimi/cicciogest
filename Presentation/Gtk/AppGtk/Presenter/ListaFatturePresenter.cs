using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts;

namespace CiccioGest.Presentation.Gtk.AppGtk.Presenter
{
    public class ListaFatturePresenter
    {
        private readonly ILogger logger;
        private readonly IFatturaService fatturaService;
        private IListaFattureView listaFattureView;

        public ListaFatturePresenter(ILogger logger, IFatturaService fatturaService)
        {
            this.logger = logger;
            this.fatturaService = fatturaService;
        }

        public void SetView(IListaFattureView listaFattureView)
        {
            this.listaFattureView = listaFattureView;
            var lstfat = fatturaService.GetFatture().Result;
            listaFattureView.FattureListStore.Clear();
            foreach (var fatt in lstfat)
            {
                listaFattureView.FattureListStore.AppendValues(fatt.Id, fatt.Nome, fatt.Totale);
            }
        }

        public void SelezionaFattura()
        {

        }
    }
}
