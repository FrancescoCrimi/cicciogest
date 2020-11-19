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
        //private IMainPresenter mainPresenter;

        [UI] private MenuItem fattureMenuItem = null;
        [UI] private MenuItem articoliMenuItem = null;
        [UI] private MenuItem categorieMenuItem = null;

        public MainView(ILogger logger)
            : this(new Builder("MainView.glade"))
        {
            this.logger = logger;

            //Shown += (sender, e) => mainPresenter.Load();
            //fattureMenuItem.Activated += (sender, args) => mainPresenter.ApriFatture();
            //articoliMenuItem.Activated += (sender, args) => mainPresenter.ApriArticoli();
            //categorieMenuItem.Activated += (sender, args) => mainPresenter.ApriCategorie();

            Shown += (s, e) => LoadEvent?.Invoke(s, e);
            DeleteEvent += (o, args) => gtk.Application.Quit();
            fattureMenuItem.Activated += (s, e) => FattureEvent?.Invoke(s, e);
            articoliMenuItem.Activated += (s, e) => ArticoliEvent?.Invoke(s, e);
            categorieMenuItem.Activated += (s, e) => CategorieEvent?.Invoke(s, e);

            logger.Debug("HashCode: " + this.GetHashCode().ToString());
        }

        private MainView(Builder builder)
            : base(builder.GetObject("MainView").Handle)
        {
            builder.Autoconnect(this);
        }

        public event EventHandler LoadEvent;
        public event EventHandler FattureEvent;
        public event EventHandler ClientiEvent;
        public event EventHandler FornitoriEvent;
        public event EventHandler ArticoliEvent;
        public event EventHandler CategorieEvent;
        public event EventHandler OpzioniEvent;

        //public void SetPresenter(IMainPresenter mainPresenter)
        //{
        //    this.mainPresenter = mainPresenter;
        //}
    }
}
