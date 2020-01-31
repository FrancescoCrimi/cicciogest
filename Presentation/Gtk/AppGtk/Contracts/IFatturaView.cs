using Gtk;

namespace CiccioGest.Presentation.Gtk.AppGtk.Contracts
{
    public interface IFatturaView
    {
        ListStore Dettagli { get; }
        EntryBuffer IdFattura { get; }
        EntryBuffer NomeFattura { get; }
        EntryBuffer NomeArticolo { get; }
        EntryBuffer Quantita { get; }
        EntryBuffer Prezzo { get; }
        EntryBuffer Totale { get; }
    }
}
