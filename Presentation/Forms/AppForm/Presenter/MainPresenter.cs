using CiccioGest.Presentation.AppForm.Services;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public class MainPresenter : PresenterBase, IDisposable
    {
        private readonly ILogger<MainPresenter> logger;
        private readonly WindowService windowService;
        private readonly DialogService dialogService;
        private readonly IMainView view;        

        public MainPresenter(ILogger<MainPresenter> logger,
                             IMainView view,
                             WindowService windowService,
                             DialogService dialogService)
            : base(view)
        {
            this.logger = logger;
            this.view = view;
            this.windowService = windowService; 
            this.dialogService = dialogService;

            view.LoadEvent += View_LoadEvent;
            view.CloseEvent += View_CloseEvent;
            logger.LogDebug("HashCode: " + GetHashCode() + " Created");
        }

        #region eventi iview

        private void View_LoadEvent(object sender, EventArgs e)
        {
            view.ApriFatturaEvent += View_ApriFatturaEvent;
            view.NuovaFatturaEvent += View_NuovaFatturaEvent;
            view.ApriClienteEvent += View_ApriClienteEvent;
            view.NuovoClienteEvent += View_NuovoClienteEvent;
            view.ApriFornitoreEvent += View_ApriFornitoreEvent;
            view.NuovoFornitoreEvent += View_NuovoFornitoreEvent;
            view.ApriArticoloEvent += View_ApriArticoloEvent;
            view.NuovoArticoloEvent += View_NuovoArticoloEvent;
            view.CategorieEvent += View_CategorieEvent;
        }

        private void View_CloseEvent(object sender, EventArgs e)
        {
            view.ApriFatturaEvent -= View_ApriFatturaEvent;
            view.NuovaFatturaEvent -= View_NuovaFatturaEvent;
            view.ApriClienteEvent -= View_ApriClienteEvent;
            view.NuovoClienteEvent -= View_NuovoClienteEvent;
            view.ApriFornitoreEvent -= View_ApriFornitoreEvent;
            view.NuovoFornitoreEvent -= View_NuovoFornitoreEvent;
            view.ApriArticoloEvent -= View_ApriArticoloEvent;
            view.NuovoArticoloEvent -= View_NuovoArticoloEvent;
            view.CategorieEvent -= View_CategorieEvent;
        }

        #endregion

        #region eventi MainView

        private void View_ApriFatturaEvent(object sender, EventArgs e)
        {
            FatturePresenter listaFatturePresenter = windowService.OpenWindow<FatturePresenter>();
            //listaFatturePresenter.CloseEvent += ListaFatturePresenter_CloseEvent;
        }

        private void View_NuovaFatturaEvent(object sender, EventArgs e)
            => windowService.OpenWindow<FatturaPresenter>();

        private void View_ApriClienteEvent(object sender, EventArgs e)
            => windowService.OpenWindow<ClientiPresenter>();

        private void View_NuovoClienteEvent(object sender, EventArgs e) { }

        private void View_ApriFornitoreEvent(object sender, EventArgs e)
            => windowService.OpenWindow<FornitoriPresenter>();

        private void View_NuovoFornitoreEvent(object sender, EventArgs e) { }

        private void View_ApriArticoloEvent(object sender, EventArgs e)
            => windowService.OpenWindow<ArticoloPresenter>();

        private void View_NuovoArticoloEvent(object sender, EventArgs e) { }

        private void View_CategorieEvent(object sender, EventArgs e)
            => windowService.OpenWindow<CategoriaPresenter>();

        #endregion


        //private void ListaFatturePresenter_CloseEvent(object sender, IdEventArgs e)
        //{
        //    if(sender is ListaFatturePresenter listaFatturePresenter)
        //    {
        //        listaFatturePresenter.CloseEvent -= ListaFatturePresenter_CloseEvent;
        //        if (e.Id != 0)
        //        {
        //            FatturaPresenter fatturaPresenter = windowService.OpenWindow<FatturaPresenter>();
        //            fatturaPresenter.MostraFattura(e.Id);
        //        }
        //    }
        //}


        public void Dispose()
        {
            view.LoadEvent -= View_LoadEvent;
            view.CloseEvent -= View_CloseEvent;
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
