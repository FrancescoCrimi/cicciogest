using System;
using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts;
using CiccioGest.Presentation.Gtk.AppGtk.View;
using Gtk;

namespace CiccioGest.Presentation.Gtk.AppGtk.Presenter
{
    public class ListaFatturePresenter : ICazzo
    {
        private readonly ILogger logger;
        private readonly IFatturaService fatturaService;
        private readonly ListaFattureView listaFattureView;
        //private IListaFattureView ilistaFattureView;

        public ListaFatturePresenter(ILogger logger, IFatturaService fatturaService, ListaFattureView listaFattureView)
        {
            this.logger = logger;
            this.fatturaService = fatturaService;
            this.listaFattureView = listaFattureView;
            listaFattureView.setPresenter(this);
        }
        
        public event EventHandler<int> Suca;

        public void Load( )
        {
            var lstfat = fatturaService.GetFatture().Result;
            listaFattureView.FattureListStore.Clear();
            foreach (var fatt in lstfat)
            {
                listaFattureView.FattureListStore.AppendValues(fatt.Id, fatt.Nome, fatt.Totale);
            }
        }

        public void Unload()
        {
            Suca?.Invoke(this, 0);
        }
        
        public void SelezionaFattura(TreePath argsPath)
        {
            listaFattureView.FattureListStore.GetIter(out var iter, argsPath);
            var IdFattura = (int) listaFattureView.FattureListStore.GetValue (iter, 0);
            Suca?.Invoke(this, IdFattura);
        }

        public void ShowView() => listaFattureView.Show();
        // public ListaFattureView GetView() => listaFattureView;
    }
}
