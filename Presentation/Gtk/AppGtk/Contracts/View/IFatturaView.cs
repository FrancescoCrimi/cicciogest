using CiccioGest.Presentation.Gtk.AppGtk.Contracts.Presenter;
using Gtk;

namespace CiccioGest.Presentation.Gtk.AppGtk.Contracts.View
{
    public interface IFatturaView : IView
    {
        ListStore Dettagli { get; }
        EntryBuffer IdFattura { get; }
        EntryBuffer NomeFattura { get; }
        EntryBuffer NomeArticolo { get; }
        EntryBuffer Quantita { get; }
        EntryBuffer Prezzo { get; }
        EntryBuffer Totale { get; }
        void SetPresenter(IFatturaPresenter fatturaPresenter);
    }
}
