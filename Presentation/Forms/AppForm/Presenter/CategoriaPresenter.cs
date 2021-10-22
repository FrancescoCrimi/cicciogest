using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public class CategoriaPresenter : PresenterBase, IDisposable
    {
        private readonly ILogger logger;
        private readonly ICategoriaView view;
        private readonly IMagazinoService magazinoService;

        public CategoriaPresenter(ILogger<CategoriaPresenter> logger,
                                  ICategoriaView view,
                                  IMagazinoService magazinoService)
            : base(view)
        {
            this.logger = logger;
            this.view = view;
            this.magazinoService = magazinoService;
            this.view.LoadEvent += View_LoadEvent;
            this.view.CloseEvent += View_CloseEvent;
            this.view.SalvaCategoriaEvent += View_SalvaCategoriaEvent;
            this.view.CancellaCategoriaEvent += View_CancellaCategoriaEvent;
            this.logger.LogDebug("HashCode: " + GetHashCode() + " Created");
        }

        private async void View_LoadEvent(object sender, EventArgs e)
        {
            await Refresh();
        }

        private void View_CloseEvent(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private async void View_CancellaCategoriaEvent(object sender, int e)
        {
            await magazinoService.DeleteCategoria(e);
            await Refresh();
        }

        private async void View_SalvaCategoriaEvent(object s, Categoria e)
        {
            await magazinoService.SaveCategoria(e);
            await Refresh();
        }

        private async Task Refresh()
        {
            var list = await magazinoService.GetCategorie();
            view.SetCategorie(list);
            view.SetCategoria(new Categoria());
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
