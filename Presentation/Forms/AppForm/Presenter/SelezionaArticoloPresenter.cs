using CiccioGest.Application;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public class SelezionaArticoloPresenter : PresenterBase, IDisposable
    {
        private readonly ILogger<SelezionaArticoloPresenter> logger;
        private readonly ISelezionaArticoloView view;
        private readonly IMagazinoService magazinoService;
        public int IdArticolo { get; private set; }

        public SelezionaArticoloPresenter(ILogger<SelezionaArticoloPresenter> logger,
                                          ISelezionaArticoloView view,
                                          IMagazinoService magazinoService)
            : base(view)
        {
            this.logger = logger;
            this.view = view;
            this.magazinoService = magazinoService;
            view.LoadEvent += View_LoadEvent;
            view.CloseEvent += View_CloseEvent;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        private async void View_LoadEvent(object sender, EventArgs e)
        {
            view.CaricaArticoli(await magazinoService.GetArticoli());
            view.ArticoloSelezionatoEvent += View_ArticoloSelezionatoEvent;
        }

        private void View_CloseEvent(object sender, EventArgs e)
        {
            view.ArticoloSelezionatoEvent -= View_ArticoloSelezionatoEvent;
        }

        private void View_ArticoloSelezionatoEvent(object sender, int e)
        {
            IdArticolo = e;
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
