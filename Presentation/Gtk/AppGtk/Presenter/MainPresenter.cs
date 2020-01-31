using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts;
using CiccioGest.Presentation.Gtk.AppGtk.View;

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
            var asd = kernel.Resolve<FatturaView>();
            asd.Show();
        }

        public void ApriArticoli()
        {

        }

        public void ApriCategorie()
        {

        }
    }
}
