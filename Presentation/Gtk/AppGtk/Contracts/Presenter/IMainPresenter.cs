using Gtk;

namespace CiccioGest.Presentation.Gtk.AppGtk.Contracts.Presenter
{
    public interface IMainPresenter : IPresenter
    {
        void ApriArticoli();
        void ApriCategorie();
        void ApriFatture();
        Window View();
    }
}
