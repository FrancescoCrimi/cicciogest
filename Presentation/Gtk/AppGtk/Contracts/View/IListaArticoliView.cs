using CiccioGest.Presentation.Gtk.AppGtk.Contracts.Presenter;
using Gtk;

namespace CiccioGest.Presentation.Gtk.AppGtk.Contracts.View
{
    public interface IListaArticoliView : IView
    {
        ListStore ArticoliListStore { get; }
        void SetPresenter(IListaArticoliPresenter listaArticoliPresenter);
    }
}
