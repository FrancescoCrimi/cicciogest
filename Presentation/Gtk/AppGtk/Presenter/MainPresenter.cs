using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts;

namespace CiccioGest.Presentation.Gtk.AppGtk.Presenter
{
    public class MainPresenter
    {
        private readonly ILogger logger;
        private readonly IKernel kernel;
        private IMainView mainView;

        public MainPresenter(ILogger logger, IKernel kernel)
        {
            this.logger = logger;
            this.kernel = kernel;
        }

        public void SetView(IMainView mainView)
        {
            this.mainView = mainView;
        }

        public void ApriFatture()
        {

        }

        public void ApriArticoli()
        {

        }

        public void ApriCategorie()
        {

        }
    }
}
