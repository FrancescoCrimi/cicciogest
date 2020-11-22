using Castle.Core.Logging;
using Castle.MicroKernel;
using Castle.MicroKernel.Lifestyle;
using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.Mvp.View;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace CiccioGest.Presentation.Mvp.Presenter
{
    public class ListaFatturePresenter : IPresenter
    {
        private readonly ILogger logger;
        private readonly IKernel kernel;
        private readonly IFatturaService service;
        private readonly IListaFattureView view;
        private int idFattura = 0;

        public event IdEventHandler CloseEvent;

        public ListaFatturePresenter(ILogger logger,
                                     IKernel kernel,
                                     IListaFattureView listaFattureView,
                                     IFatturaService fatturaService)
        {
            this.logger = logger;
            this.kernel = kernel;
            view = listaFattureView;
            service = fatturaService;

            view.LoadEvent += Load;
            view.CloseEvent += View_CloseEvent;
            view.SelectFatturaEvent += View_SelectFatturaEvent;
            view.NuovaEvent += Nuova;
            view.ApriEvent += Apri;

            this.logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        private void View_CloseEvent(object sender, EventArgs e)
        {
            CloseEvent?.Invoke(this, new IdEventArgs(idFattura));
        }

        private void View_SelectFatturaEvent(object sender, int e)
        {
            idFattura = e;
            view.Close();
        }

        private async void Load(object s, EventArgs e)
        {
            IList<FatturaReadOnly> fatture = await service.GetFatture();
            view.SetFatture(fatture);
        }

        private void Nuova(object s, EventArgs e)
        {
            using (kernel.BeginScope())
            {
                var lcd = kernel.Resolve<SelectClientePresenter>();
                lcd.Show();
                if (lcd.IdCliente != 0)
                {
                    //var asasa = kernel.Resolve<FatturaView>(new Arguments().AddNamed("idCliente", lcd.Cliente.Id));
                    //asasa.ShowDialog();
                    var fp = kernel.Resolve<FatturaPresenter>();
                    fp.NuovaFattura(lcd.IdCliente);
                    fp.Show();
                }
            }
        }

        private void Apri(object s, EventArgs e)
        {
        }

        private void Esci(object s, EventArgs e)
        {
        }

        public void Show() => view.Show();
    }
}
