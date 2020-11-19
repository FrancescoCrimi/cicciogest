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
        private readonly IFatturaService fatturaService;
        private readonly IListaFattureView view;

        public ListaFatturePresenter(ILogger logger,
                                     IKernel kernel,
                                     IListaFattureView view,
                                     IFatturaService fatturaService)
        {
            this.logger = logger;
            this.kernel = kernel;
            this.view = view;
            this.fatturaService = fatturaService;

            view.LoadEvent += Load;
            view.SelectFatturaEvent += ApriFattura;
            view.NuovaEvent += Nuova;
            view.ApriEvent += Apri;
            view.CloseEvent += Esci;

            this.logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        private async void Load(object s, EventArgs e)
        {
            IList<FatturaReadOnly> fatture = await fatturaService.GetFatture();
            view.SetFatture(fatture);
        }

        private void ApriFattura(object sender, int IdFattura)
        {
            using (kernel.BeginScope())
            {
                //var fv = kernel.Resolve<FatturaView>(new Arguments().AddNamed("idFattura", IdFattura));
                //fv.FormClosing += (s, a) => kernel.ReleaseComponent(s);
                //fv.ShowDialog();
                var fp = kernel.Resolve<FatturaPresenter>();
                fp.MostraFattura(IdFattura);
                fp.Show();
            }
        }

        private void Nuova(object s, EventArgs e)
        {
            //using (kernel.BeginScope())
            //{
            //    var lcd = kernel.Resolve<ClientiDialog>();
            //    lcd.ShowDialog();
            //    if (lcd.Cliente != null)
            //    {
            //        //var asasa = kernel.Resolve<FatturaView>(new Arguments().AddNamed("idCliente", lcd.Cliente.Id));
            //        //asasa.ShowDialog();
            //        var fp = kernel.Resolve<FatturaPresenter>();
            //        fp.NuovaFattura(lcd.Cliente.Id);
            //        fp.Show();
            //    }
            //}
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
