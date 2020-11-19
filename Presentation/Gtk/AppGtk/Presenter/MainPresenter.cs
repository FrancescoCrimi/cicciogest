using Castle.Core.Logging;
using Castle.MicroKernel;
using Castle.MicroKernel.Lifestyle;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts.Presenter;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts.View;
using Gtk;

namespace CiccioGest.Presentation.Gtk.AppGtk.Presenter
{
    public class MainPresenter
    {
        private readonly ILogger logger;
        private readonly IKernel kernel;
        private readonly IMainView view;

        public MainPresenter(ILogger logger,
                             IKernel kernel,
                             IMainView mainView)
        {
            this.logger = logger;
            this.kernel = kernel;
            view = mainView;
            view.FattureEvent += View_FattureEvent;
            logger.Debug("HashCode: " + this.GetHashCode().ToString());
        }

        private void View_FattureEvent(object sender, System.EventArgs e)
        {
            using (kernel.BeginScope())
            {
                var asd = kernel.Resolve<IFatturaPresenter>();
                asd.ShowView();
            }
        }

        public Window View() => (Window)view;
    }
}
