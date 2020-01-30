using Gtk;

namespace CiccioGest.Presentation.Gtk.AppGtk.Contracts
{
    public interface IListaFattureView
    {
        ListStore FattureListStore { get; }
    }
}