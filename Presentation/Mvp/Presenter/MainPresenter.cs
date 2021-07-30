using CiccioGest.Presentation.Mvp.Services;
using CiccioGest.Presentation.Mvp.View;
using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.Mvp.Presenter
{
    public class MainPresenter : PresenterBase, IPresenter
    {
        private readonly ILogger<MainPresenter> logger;
        private readonly WindowService windowService;
        private readonly DialogService dialogService;
        private readonly IMainView mainView;        

        public MainPresenter(ILogger<MainPresenter> logger,
                             WindowService windowService,
                             DialogService dialogService,
                             IMainView mainView)
            :base(mainView)
        {
            this.logger = logger;
            this.windowService = windowService;
            this.dialogService = dialogService;
            this.mainView = mainView;

            mainView.ApriFatturaEvent += View_ApriFatturaEvent;
            mainView.NuovaFatturaEvent += View_NuovaFatturaEvent;
            mainView.ApriClienteEvent += View_ApriClienteEvent;
            mainView.NuovoClienteEvent += View_NuovoClienteEvent;
            mainView.ApriFornitoreEvent += View_ApriFornitoreEvent;
            mainView.NuovoFornitoreEvent += View_NuovoFornitoreEvent;
            mainView.ApriArticoloEvent += View_ApriArticoloEvent;
            mainView.NuovoArticoloEvent += View_NuovoArticoloEvent;
            mainView.CategorieEvent += View_CategorieEvent;
            this.logger.LogDebug("HashCode: " + GetHashCode() + " Created");
        }

        private void View_CategorieEvent(object sender, EventArgs e)
        {
            windowService.OpenWindow<CategoriaPresenter>();
            //catePres.CloseEvent += CatePres_Close;
        }

        private void CatePres_Close(object sender, EventArgs e)
        {
            ((CategoriaPresenter)sender).CloseEvent -= CatePres_Close;
        }

        private void View_NuovoArticoloEvent(object sender, EventArgs e)
        {
        }

        private void View_ApriArticoloEvent(object sender, EventArgs e)
        {
            windowService.OpenWindow<ArticoloPresenter>();
            //artiPres.CloseEvent += ArtiPres_Close;
        }

        private void ArtiPres_Close(object sender, EventArgs e)
        {
            ((ArticoloPresenter)sender).CloseEvent -= ArtiPres_Close;
        }

        private void View_NuovoFornitoreEvent(object sender, EventArgs e)
        {
        }

        private void View_ApriFornitoreEvent(object sender, EventArgs e)
        {
            windowService.OpenWindow<ListaFornitoriPresenter>();
            //listFornPres.CloseEvent += ListFornPres_CloseEvent;
        }

        private void ListFornPres_CloseEvent(object sender, EventArgs e)
        {
            ((ListaFornitoriPresenter)sender).CloseEvent -= ListFornPres_CloseEvent;
        }

        private void View_NuovoClienteEvent(object sender, EventArgs e)
        {
        }

        private void View_ApriClienteEvent(object sender, EventArgs e)
        {
            windowService.OpenWindow<ListaClientiPresenter>();
            //listCliePres.CloseEvent += ListCliePres_CloseEvent;
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
            windowService.OpenWindow<FatturaPresenter>();
            //    fattPres.CloseEvent += FattPres_CloseEvent;
            //    fattPres.NuovaFattura();
        }

        private void View_ApriFatturaEvent(object sender, EventArgs e)
        {
            var pres = windowService.OpenWindow<ListaFatturePresenter>();
            //var pres = dialogService.OpenDialog<ListaFatturePresenter>();
            pres.CloseEvent += ListFattPres_CloseEvent;
        }

        private void ListFattPres_CloseEvent(object sender, IdEventArgs e)
        {
            ((ListaFatturePresenter)sender).CloseEvent -= ListFattPres_CloseEvent;
            if (e.Id != 0)
            {
                var fattPres = windowService.OpenWindow<FatturaPresenter>();
                fattPres.CloseEvent += FattPres_CloseEvent;
                fattPres.MostraFattura(e.Id);
            }
        }

        private void FattPres_CloseEvent(object sender, EventArgs e)
        {
            ((FatturaPresenter)sender).CloseEvent -= FattPres_CloseEvent;
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
