using CiccioGest.Presentation.Gtk.AppGtk.Contracts.Presenter;

namespace CiccioGest.Presentation.Gtk.AppGtk.Contracts.View
{
    public interface IMainView : IView
    {
        void SetPresenter(IMainPresenter mainPresenter);
    }
}