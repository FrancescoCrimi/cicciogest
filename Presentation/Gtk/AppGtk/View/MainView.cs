using System;
using Castle.Core.Logging;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts;
using CiccioGest.Presentation.Gtk.AppGtk.Presenter;
using Gtk;
using gtk = Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace CiccioGest.Presentation.Gtk.AppGtk.View
{
    public class MainView : Window, ICazzo, IMainView
    {
        private readonly Builder builder;
        private readonly ILogger logger;
        private readonly MainPresenter mainPresenter;

        [UI] private MenuItem fattureMenuItem = null;
        [UI] private MenuItem articoliMenuItem = null;
        [UI] private MenuItem categorieMenuItem = null;

        private MainView(Builder builder)
            : base(builder.GetObject("MainView").Handle)
        {
            builder.Autoconnect(this);
            DeleteEvent += (o, args) => gtk.Application.Quit();
            fattureMenuItem.Activated += (sender, args) => mainPresenter.ApriFatture();
            articoliMenuItem.Activated += (sender, args) => mainPresenter.ApriArticoli();
            categorieMenuItem.Activated += (sender, args) => mainPresenter.ApriCategorie();
            this.builder = builder;
        }
        
        public MainView(ILogger logger, MainPresenter mainPresenter)
            : this(new Builder("MainView.glade"))
        {
            this.logger = logger;
            this.mainPresenter = mainPresenter;
            mainPresenter.SetView(this);
        }
    }
}
