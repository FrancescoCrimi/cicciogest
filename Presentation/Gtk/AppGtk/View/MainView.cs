using Castle.Core.Logging;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts;
using CiccioGest.Presentation.Gtk.AppGtk.Presenter;

namespace CiccioGest.Presentation.Gtk.AppGtk.View
{
    public class MainView : IMainView
    {
        private readonly ILogger logger;
        private readonly MainPresenter mainPresenter;

        public MainView(ILogger logger, MainPresenter mainPresenter)
        {
            this.logger = logger;
            this.mainPresenter = mainPresenter;
            mainPresenter.SetView(this);
        }
    }
}
