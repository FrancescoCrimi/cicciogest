﻿using Castle.Core.Logging;
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
        private readonly IMagazinoService service;
        private readonly ICategoriaView view;

        public event EventHandler CloseEvent;

        public CategoriaPresenter(ILogger logger,
                                  IMagazinoService magazinoService,
                                  ICategoriaView categoriaView)
        {
            this.logger = logger;
            this.service = magazinoService;
            view = categoriaView;
            view.LoadEvent += View_LoadEvent;
            view.CloseEvent += View_CloseEvent;
            view.SalvaCategoriaEvent += View_SalvaCategoriaEvent;
            view.CancellaCategoriaEvent += View_CancellaCategoriaEvent;
        }

        private void View_CloseEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Show() => view.Show();

        private async void View_CancellaCategoriaEvent(object sender, int e)
        {
            await service.DeleteCategoria(e);
            await Refresh();
        }

        private async void View_LoadEvent(object sender, EventArgs e)
        {
            await Refresh();
        }

        private async void View_SalvaCategoriaEvent(object s, Categoria e)
        {
            await service.SaveCategoria(e);
            await Refresh();
        }

        private async Task Refresh()
        {
            var list = await service.GetCategorie();
            view.SetCategorie(list);
            view.SetCategoria(new Categoria());
        }
    }
}