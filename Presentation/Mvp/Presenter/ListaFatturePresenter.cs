using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.Mvp.View;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.Mvp.Presenter
{
    public class ListaFatturePresenter : PresenterBase, IPresenter
    {
        private readonly ILogger logger;
        private readonly IServiceScopeFactory serviceScopeFactory;
        private readonly IFatturaService service;
        private readonly IListaFattureView view;
        private int idFattura = 0;

        public event IdEventHandler CloseEvent;

        public ListaFatturePresenter(ILogger<ListaFatturePresenter> logger,
                                     IServiceScopeFactory serviceScopeFactory,
                                     IListaFattureView listaFattureView,
                                     IFatturaService fatturaService)
            : base(listaFattureView)
        {
            this.logger = logger;
            this.serviceScopeFactory = serviceScopeFactory;
            view = listaFattureView;
            service = fatturaService;

            view.LoadEvent += Load;
            view.CloseEvent += View_CloseEvent;
            view.SelectFatturaEvent += View_SelectFatturaEvent;
            view.NuovaEvent += Nuova;
            view.ApriEvent += Apri;

            this.logger.LogDebug("HashCode: " + GetHashCode() + " Created");
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
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var lcd = scope.ServiceProvider.GetService<SelectClientePresenter>();
                lcd.Show();
                if (lcd.IdCliente != 0)
                {
                    //var asasa = kernel.Resolve<FatturaView>(new Arguments().AddNamed("idCliente", lcd.Cliente.Id));
                    //asasa.ShowDialog();
                    var fp = scope.ServiceProvider.GetService<FatturaPresenter>();
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

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
