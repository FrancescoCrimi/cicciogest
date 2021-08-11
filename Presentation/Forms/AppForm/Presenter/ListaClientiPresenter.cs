﻿using CiccioGest.Application;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public class ListaClientiPresenter : PresenterBase, IPresenter
    {
        private readonly ILogger logger;
        private readonly IClientiFornitoriService service;
        private readonly IListaClientiView view;
        private int idCliente = 0;

        public event IdEventHandler CloseEvent;

        public ListaClientiPresenter(ILogger<ListaClientiPresenter> logger,
                                     IClientiFornitoriService clientiFornitoriService,
                                     IListaClientiView listaClientiView)
            : base(listaClientiView)
        {
            this.logger = logger;
            service = clientiFornitoriService;
            view = listaClientiView;
            view.LoadEvent += View_LoadEvent;
            view.CloseEvent += View_CloseEvent;
            view.SelectClienteEvent += View_SelezionaClienteEvent;
            this.logger.LogDebug("HashCode: " + GetHashCode() + " Created");
        }

        private void View_CloseEvent(object sender, EventArgs e) =>
            CloseEvent?.Invoke(this, new IdEventArgs(idCliente));

        private void View_SelezionaClienteEvent(object sender, int e) =>
            idCliente = e;

        private async void View_LoadEvent(object sender, EventArgs e)
        {
            var clienti = await service.GetClienti();
            view.SetClienti(clienti);
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}