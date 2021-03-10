using CiccioGest.Presentation.Mvp.View;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;

namespace CiccioGest.Presentation.Mvp.Presenter
{
    public class MainPresenter : IPresenter
    {
        private readonly ILogger logger;
        private readonly IServiceScopeFactory serviceScopeFactory;
        private readonly IServiceProvider serviceProvider;

        public MainPresenter(ILogger<MainPresenter> logger,
                             IServiceScopeFactory serviceScopeFactory,
                             IServiceProvider serviceProvider,
                             IMainView view)
        {
            this.logger = logger;
            this.serviceScopeFactory = serviceScopeFactory;
            this.serviceProvider = serviceProvider;
            View = view;

            view.ApriFatturaEvent += View_ApriFatturaEvent;
            view.NuovaFatturaEvent += View_NuovaFatturaEvent;
            view.ApriClienteEvent += View_ApriClienteEvent;
            view.NuovoClienteEvent += View_NuovoClienteEvent;
            view.ApriFornitoreEvent += View_ApriFornitoreEvent;
            view.NuovoFornitoreEvent += View_NuovoFornitoreEvent;
            view.ApriArticoloEvent += View_ApriArticoloEvent;
            view.NuovoArticoloEvent += View_NuovoArticoloEvent;
            view.CategorieEvent += View_CategorieEvent;
            this.logger.LogDebug("HashCode: " + GetHashCode() + " Created");
        }

        private void View_CategorieEvent(object sender, EventArgs e)
        {
            //using (var scope = serviceScopeFactory.CreateScope())
            //{
            CategoriaPresenter catePres = serviceProvider.GetService<CategoriaPresenter>();
            catePres.CloseEvent += CatePres_Close;
            catePres.Show();
            //}
        }

        private void CatePres_Close(object sender, EventArgs e)
        {
            ((CategoriaPresenter)sender).CloseEvent -= CatePres_Close;
            //kernel.ReleaseComponent(sender);
        }

        private void View_NuovoArticoloEvent(object sender, EventArgs e)
        {
        }

        private void View_ApriArticoloEvent(object sender, EventArgs e)
        {
            //using (IServiceScope scope = serviceScopeFactory.CreateScope())
            //{
            var artiPres = serviceProvider.GetService<ArticoloPresenter>();
            artiPres.CloseEvent += ArtiPres_Close;
            artiPres.Show();
            //}
        }

        private void ArtiPres_Close(object sender, EventArgs e)
        {
            ((ArticoloPresenter)sender).CloseEvent -= ArtiPres_Close;
            //kernel.ReleaseComponent(sender);
        }

        private void View_NuovoFornitoreEvent(object sender, EventArgs e)
        {
        }

        private void View_ApriFornitoreEvent(object sender, EventArgs e)
        {
            var listFornPres = serviceProvider.GetService<ListaFornitoriPresenter>();
            listFornPres.CloseEvent += ListFornPres_CloseEvent;
            listFornPres.Show();
        }

        private void ListFornPres_CloseEvent(object sender, EventArgs e)
        {
            ((ListaFornitoriPresenter)sender).CloseEvent -= ListFornPres_CloseEvent;
            //kernel.ReleaseComponent(sender);
        }

        private void View_NuovoClienteEvent(object sender, EventArgs e)
        {
        }

        private void View_ApriClienteEvent(object sender, EventArgs e)
        {
            var listCliePres = serviceProvider.GetService<ListaClientiPresenter>();
            listCliePres.CloseEvent += ListCliePres_CloseEvent;
            listCliePres.Show();
        }

        private void ListCliePres_CloseEvent(object sender, IdEventArgs e)
        {
            ((ListaClientiPresenter)sender).CloseEvent -= ListCliePres_CloseEvent;
            //kernel.ReleaseComponent(sender);
            if (e.Id != 0)
            {
            }
        }

        private void View_NuovaFatturaEvent(object sender, EventArgs e)
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var fattPres = scope.ServiceProvider.GetService<FatturaPresenter>();
                fattPres.CloseEvent += FattPres_CloseEvent;
                fattPres.NuovaFattura();
                fattPres.Show();
            }
        }

        private void View_ApriFatturaEvent(object sender, EventArgs e)
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var listFattPres = serviceProvider.GetService<ListaFatturePresenter>();
                listFattPres.CloseEvent += ListFattPres_CloseEvent;
                listFattPres.Show();
            }
        }

        private void ListFattPres_CloseEvent(object sender, IdEventArgs e)
        {
            ((ListaFatturePresenter)sender).CloseEvent -= ListFattPres_CloseEvent;
            //kernel.ReleaseComponent(sender);
            if (e.Id != 0)
            {
                //using (var scope = serviceScopeFactory.CreateScope())
                //{
                var fattPres = serviceProvider.GetService<FatturaPresenter>();
                fattPres.CloseEvent += FattPres_CloseEvent;
                fattPres.MostraFattura(e.Id);
                fattPres.Show();
                //}
            }
        }

        private void FattPres_CloseEvent(object sender, EventArgs e)
        {
            ((FatturaPresenter)sender).CloseEvent -= FattPres_CloseEvent;
            //kernel.ReleaseComponent(sender);
        }


        public void Show() { }

        public IMainView View { get; }
    }
}
