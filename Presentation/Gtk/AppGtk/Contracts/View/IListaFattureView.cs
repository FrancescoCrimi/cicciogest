using CiccioGest.Presentation.Gtk.AppGtk.Contracts.Presenter;
using Gtk;

namespace CiccioGest.Presentation.Gtk.AppGtk.Contracts.View
{
    public interface IListaFattureView : IView
    {
        ListStore FattureListStore { get; }
        void SetPresenter(IListaFatturePresenter listaFatturePresenter);
    }
}