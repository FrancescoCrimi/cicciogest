using Gtk;

namespace CiccioGest.Presentation.Gtk.AppGtk.Contracts
{
    public interface IFatturaView
    {
        ListStore DettagliListStore { get; }
        TextBuffer Textbuffer1 { get; }
    }
}
