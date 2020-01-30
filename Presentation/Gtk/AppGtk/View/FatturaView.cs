using Castle.Core.Logging;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts;
using CiccioGest.Presentation.Gtk.AppGtk.Presenter;
using Gtk;
using System;
using gtk = Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace CiccioGest.Presentation.Gtk.AppGtk.View
{
    class FatturaView : Window, ICazzo, IFatturaView
    {
        [UI] private Label _label1 = null;


        private readonly ILogger logger;
        private readonly FatturaPresenter fatturaPresenter;
        private readonly Builder builder;

        public FatturaView(ILogger logger, FatturaPresenter fatturaPresenter)
            : this(new Builder("FatturaView.glade"))
        {
            this.logger = logger;
            this.fatturaPresenter = fatturaPresenter;
            fatturaPresenter.SetView(this);
            fatturaPresenter.ShowFattura();
        }

        private FatturaView(Builder builder)
            : base(builder.GetObject("FatturaView").Handle)
        {
            builder.Autoconnect(this);
            DeleteEvent += Window_DeleteEvent;
            Shown += MainWindow_Shown;
            this.builder = builder;
        }

        public ListStore DettagliListStore => (ListStore)builder.GetObject("liststore1");
        public TextBuffer Textbuffer1 => (TextBuffer)builder.GetObject("textbuffer1");

        private void MainWindow_Shown(object sender, EventArgs e)
        {
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            gtk.Application.Quit();
        }
    }
}
