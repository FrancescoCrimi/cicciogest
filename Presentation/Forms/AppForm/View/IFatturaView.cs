using CiccioGest.Domain.Documenti;
using System;

namespace CiccioGest.Presentation.AppForm.View
{
    public interface IFatturaView : IView
    {
        event EventHandler NuovaFatturaEvent;
        event EventHandler SalvaFatturaEvent;
        event EventHandler ApriFatturaEvent;
        event EventHandler NuovoDettaglioEvent;
        event EventHandler<Dettaglio> AggiungiDettaglioEvent;
        event EventHandler<Dettaglio> RimuoviDettaglioEvent;
        void SetDettaglio(Dettaglio dettaglio);
        void SetFattura(Fattura fattura);
    }
}
