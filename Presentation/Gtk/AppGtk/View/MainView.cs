using Castle.Core.Logging;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts.Presenter;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts.View;
using Gtk;
using System;
using gtk = Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace CiccioGest.Presentation.Gtk.AppGtk.View
{
    public class MainView : Window, IMainView
    {
        private readonly ILogger logger;
        private IMainPresenter mainPresenter;

        [UI] private MenuItem fattureMenuItem = null;
        [UI] private MenuItem articoliMenuItem = null;
        [UI] private MenuItem categorieMenuItem = null;

        public MainView(ILogger logger)
            : this(new Builder("MainView.glade"))
        {
            this.logger = logger;
            Shown += (sender, e) => mainPresenter.Load();
            DeleteEvent += (o, args) => gtk.Application.Quit();
            fattureMenuItem.Activated += (sender, args) => mainPresenter.ApriFatture();
            articoliMenuItem.Activated += (sender, args) => mainPresenter.ApriArticoli();
            categorieMenuItem.Activated += (sender, args) => mainPresenter.ApriCategorie();
            logger.Debug("HashCode: " + this.GetHashCode().ToString());
        }

        private MainView(Builder builder)
            : base(builder.GetObject("MainView").Handle)
        {
            builder.Autoconnect(this);
        }

        public void SetPresenter(IMainPresenter mainPresenter)
        {
            this.mainPresenter = mainPresenter;
        }
    }
}
