//using Castle.Core.Logging;
using CiccioGest.Presentation.Mvp.View;
using Gtk;
using Microsoft.Extensions.Logging;
using System;
using gtk = Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace CiccioGest.Presentation.Gtk.AppGtk.View
{
    public class MainView : Window, IMainView
    {
        private readonly ILogger logger;

        [UI] private MenuItem fattureMenuItem = null;
        [UI] private MenuItem articoliMenuItem = null;
        [UI] private MenuItem categorieMenuItem = null;

        public event EventHandler LoadEvent;
        public event EventHandler CloseEvent;
        //public event EventHandler FattureEvent;
        //public event EventHandler ClientiEvent;
        //public event EventHandler FornitoriEvent;
        //public event EventHandler ArticoliEvent;
        public event EventHandler CategorieEvent;
        public event EventHandler OpzioniEvent;
        public event EventHandler ApriFatturaEvent;
        public event EventHandler NuovaFatturaEvent;
        public event EventHandler ApriClienteEvent;
        public event EventHandler NuovoClienteEvent;
        public event EventHandler ApriFornitoreEvent;
        public event EventHandler NuovoFornitoreEvent;
        public event EventHandler ApriArticoloEvent;
        public event EventHandler NuovoArticoloEvent;

        public MainView(ILogger<MainView> logger)
            : this(new Builder("MainView.glade"))
        {
            this.logger = logger;

            Shown += (s, e) => LoadEvent?.Invoke(s, e);
            fattureMenuItem.Activated += (s, e) => ApriFatturaEvent?.Invoke(s, e);
            articoliMenuItem.Activated += (s, e) => ApriArticoloEvent?.Invoke(s, e);
            categorieMenuItem.Activated += (s, e) => CategorieEvent?.Invoke(s, e);
            DeleteEvent += (o, args) => gtk.Application.Quit();

            logger.LogDebug("HashCode: " + this.GetHashCode().ToString());
        }

        private MainView(Builder builder)
            : base(builder.GetObject("MainView").Handle)
        {
            builder.Autoconnect(this);
        }

        public void ShowDialog()
        {
            throw new NotImplementedException();
        }
    }
}
