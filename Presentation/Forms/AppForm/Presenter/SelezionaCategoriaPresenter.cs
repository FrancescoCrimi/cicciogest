﻿using CiccioGest.Application;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public class SelezionaCategoriaPresenter : PresenterBase, IDisposable
    {
        private readonly ILogger<SelezionaCategoriaPresenter> logger;
        private readonly ISelezionaCategoriaView view;
        private readonly IMagazinoService magazinoService;
        public int IdCategoria { get; private set; }

        public SelezionaCategoriaPresenter(ILogger<SelezionaCategoriaPresenter> logger,
                                           ISelezionaCategoriaView view,
                                           IMagazinoService magazinoService)
            : base(view)
        {
            this.logger = logger;
            this.view = view;
            this.magazinoService = magazinoService;
            view.LoadEvent += View_LoadEvent;
            view.CloseEvent += View_CloseEvent;
            logger.LogDebug("HashCode: " + GetHashCode() + " Created");
        }

        private async void View_LoadEvent(object sender, EventArgs e)
        {
            view.CategoriaSelezionataEvent += View_CategoriaSelezionataEvent;
            view.CaricaCategorie(await magazinoService.GetCategorie());
        }

        private void View_CloseEvent(object sender, EventArgs e)
        {
            view.CategoriaSelezionataEvent -= View_CategoriaSelezionataEvent;
        }

        private void View_CategoriaSelezionataEvent(object sender, int e)
        {
            IdCategoria = e;
            view.Close();
        }

        public void Dispose()
        {
            view.LoadEvent -= View_LoadEvent;
            view.CloseEvent -= View_CloseEvent;
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}