using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Presentation.Mvp.View;
using System;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Mvp.Presenter
{
    public class CategoriaPresenter : IPresenter
    {
        private readonly ILogger logger;
        private readonly IMagazinoService magazinoService;
        private readonly ICategoriaView view;

        public CategoriaPresenter(ILogger logger,
                                  IMagazinoService magazinoService,
                                  ICategoriaView view)
        {
            this.logger = logger;
            this.magazinoService = magazinoService;
            this.view = view;
            view.SalvaCategoriaEvent += View_SalvaCategoriaEvent;
            view.LoadEvent += View_LoadEvent;
            view.CancellaCategoriaEvent += View_CancellaCategoriaEvent;
        }

        public void Show() => view.Show();

        private async void View_CancellaCategoriaEvent(object sender, int e)
        {
            await magazinoService.DeleteCategoria(e);
            await Refresh();
        }

        private async void View_LoadEvent(object sender, EventArgs e)
        {
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
    }
}
