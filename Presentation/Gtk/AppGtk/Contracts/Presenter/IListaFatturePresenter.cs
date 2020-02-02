using System;

namespace CiccioGest.Presentation.Gtk.AppGtk.Contracts.Presenter
{
    public interface IListaFatturePresenter : IPresenter
    {
        event EventHandler<int> EventoSelezione;
        void SelezionaFattura(int idFattura);
    }
}