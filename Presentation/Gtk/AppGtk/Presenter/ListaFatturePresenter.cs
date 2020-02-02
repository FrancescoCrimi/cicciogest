using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts.Presenter;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts.View;
using System;
using System.Globalization;

namespace CiccioGest.Presentation.Gtk.AppGtk.Presenter
{
    public class ListaFatturePresenter : IListaFatturePresenter, ICazzo
    {
        private readonly ILogger logger;
        private readonly IFatturaService fatturaService;
        private readonly IListaFattureView listaFattureView;

        public ListaFatturePresenter(ILogger logger,
                                     IFatturaService fatturaService,
                                     IListaFattureView listaFattureView)
        {
            this.logger = logger;
            this.fatturaService = fatturaService;
            this.listaFattureView = listaFattureView;
            listaFattureView.SetPresenter(this);
            this.logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public event EventHandler<int> EventoSelezione;

        public void Load()
        {
            var lstfat = fatturaService.GetFatture().Result;
            listaFattureView.FattureListStore.Clear();
            foreach (var fatt in lstfat)
            {
                listaFattureView.FattureListStore.AppendValues(fatt.Id, fatt.Nome, fatt.Totale);
            }
        }

        public void SelezionaFattura(int idFattura) => EventoSelezione?.Invoke(this, idFattura);

        public void ShowView() => listaFattureView.Show();

        public void Unload() => EventoSelezione?.Invoke(this, 0);
    }
}
