using System;

namespace CiccioGest.Presentation.Gtk.AppGtk.Contracts.Presenter
{
    public interface IListaArticoliPresenter : IPresenter
    {
        event EventHandler<int> EventoSelezione;
        void SelezionaArticolo(int idArticolo);
    }
}
