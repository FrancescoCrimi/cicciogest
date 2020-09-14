using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts.Presenter;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts.View;
using Gtk;

namespace CiccioGest.Presentation.Gtk.AppGtk.Presenter
{
    public class MainPresenter : IMainPresenter
    {
        private readonly ILogger logger;
        private readonly IKernel kernel;
        private readonly IMainView mainView;

        public MainPresenter(ILogger logger,
                             IKernel kernel,
                             IMainView mainView)
        {
            this.logger = logger;
            this.kernel = kernel;
            this.mainView = mainView;
            mainView.SetPresenter(this);
            logger.Debug("HashCode: " + this.GetHashCode().ToString());
        }

        public void ApriFatture()
        {
            var asd = kernel.Resolve<IFatturaPresenter>();
            asd.ShowView();
        }

        public void ApriArticoli()
        {

        }

        public void ApriCategorie()
        {

        }

        public void Load()
        {
        }

        public void ShowView()
        {
        }

        public void Unload()
        {
        }

        public Window View() => (Window)mainView;
    }
}
