using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.AppForm.Services;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public class ListaFatturePresenter : PresenterBase, IPresenter
    {
        private readonly ILogger logger;
        private readonly IListaFattureView view;
        private readonly WindowService windowService;
        //private readonly IServiceScopeFactory serviceScopeFactory;
        private readonly IFatturaService fatturaService;
        //private int idFattura = 0;

        //public event IdEventHandler CloseEvent;

        public ListaFatturePresenter(ILogger<ListaFatturePresenter> logger,
                                     IListaFattureView view,
                                      WindowService windowService,
                                     //IServiceScopeFactory serviceScopeFactory,
                                     IFatturaService fatturaService)
            : base(view)
        {
            this.logger = logger;
            this.view = view;
            this.windowService = windowService;
            //this.serviceScopeFactory = serviceScopeFactory;
            this.fatturaService = fatturaService;

            view.LoadEvent += View_LoadEvent;
            view.CloseEvent += View_CloseEvent;

            logger.LogDebug("HashCode: " + GetHashCode() + " Created");
        }

        #region eventi iview

        private async void View_LoadEvent(object sender, EventArgs e)
        {
            view.SelectFatturaEvent += View_SelectFatturaEvent;
            view.NuovaFatturaEvent += View_NuovaFatturaEvent;
            IList<FatturaReadOnly> fatture = await fatturaService.GetFatture();
            view.SetFatture(fatture);
        }

        private void View_CloseEvent(object sender, EventArgs e)
        {
            if (sender is IListaFattureView listaFattureView)
            {
                listaFattureView.SelectFatturaEvent -= View_SelectFatturaEvent;
                listaFattureView.NuovaFatturaEvent -= View_NuovaFatturaEvent;
            }
            //CloseEvent?.Invoke(this, new IdEventArgs(idFattura));
        }

        #endregion


        #region eventi IListaFattureView

        private void View_SelectFatturaEvent(object sender, int e)
        {
            //idFattura = e;
            FatturaPresenter fatturaPresenter = windowService.OpenWindow<FatturaPresenter>();
            fatturaPresenter.MostraFattura(e);
            view.Close();
        }

        private void View_NuovaFatturaEvent(object sender, EventArgs e)
        {
            //using (var scope = serviceScopeFactory.CreateScope())
            //{
            //    var lcd = scope.ServiceProvider.GetService<SelectClientePresenter>();
            //    lcd.Show();
            //    if (lcd.IdCliente != 0)
            //    {
            //        //var asasa = kernel.Resolve<FatturaView>(new Arguments().AddNamed("idCliente", lcd.Cliente.Id));
            //        //asasa.ShowDialog();
            //        var fp = scope.ServiceProvider.GetService<FatturaPresenter>();
            //        fp.NuovaFattura(lcd.IdCliente);
            //        fp.Show();
            //    }
            //}
            ListaClientiPresenter listaClientiPresenter = windowService.OpenWindow<ListaClientiPresenter>();
            listaClientiPresenter.Show();
            view.Close();
        }

        #endregion


        public void Dispose()
        {
            view.LoadEvent -= View_LoadEvent;
            view.CloseEvent -= View_CloseEvent;
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
