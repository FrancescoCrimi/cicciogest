using CiccioGest.Application;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public class SelezionaFatturaPresenter : PresenterBase, IDisposable
    {
        private readonly ILogger<SelezionaFatturaPresenter> logger;
        private readonly ISelezionaFatturaView view;
        private readonly IFatturaService fatturaService;
        public int IdFattura { get; private set; }

        public SelezionaFatturaPresenter(ILogger<SelezionaFatturaPresenter> logger,
                                         ISelezionaFatturaView view,
                                         IFatturaService fatturaService)
            : base(view)
        {
            this.logger = logger;
            this.view = view;
            this.fatturaService = fatturaService;
            view.LoadEvent += View_LoadEvent;
            view.CloseEvent += View_CloseEvent;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        private async void View_LoadEvent(object sender, EventArgs e)
        {
            view.FatturaSelezionataEvent += View_FatturaSelezionataEvent;
            view.CaricaFatture(await fatturaService.GetFatture());
        }

        private void View_CloseEvent(object sender, EventArgs e)
        {
            view.FatturaSelezionataEvent += View_FatturaSelezionataEvent;
        }

        private void View_FatturaSelezionataEvent(object sender, int e)
        {
            IdFattura = e;
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
