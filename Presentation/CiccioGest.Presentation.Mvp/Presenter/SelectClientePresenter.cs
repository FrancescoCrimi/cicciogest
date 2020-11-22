using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Presentation.Mvp.View;
using System;

namespace CiccioGest.Presentation.Mvp.Presenter
{
    public class SelectClientePresenter : IPresenter
    {
        private readonly ILogger logger;
        private readonly IClientiFornitoriService service;
        private readonly ISelectClienteView view;

        public event EventHandler CloseEvent;

        public int IdCliente { get; private set; }

        public SelectClientePresenter(ILogger logger,
                                      IClientiFornitoriService clientiFornitoriService,
                                      ISelectClienteView selectClienteView)
        {
            this.logger = logger;
            service = clientiFornitoriService;
            view = selectClienteView;
            view.CloseEvent += View_CloseEvent;
            view.LoadEvent += View_LoadEvent;
            view.SelectClienteEvent += View_SelectClienteEvent;
        }

        private void View_CloseEvent(object s, EventArgs e) { }

        private async void View_LoadEvent(object s, EventArgs e)
        {
            view.SetClienti(await service.GetClienti());
        }

        private void View_SelectClienteEvent(object s, int e) =>  IdCliente = e;

        public void Show() => view.ShowDialog();
    }
}
