using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.Mvp.Presenter;
using System;

namespace CiccioGest.Presentation.Mvp.View
{
    public interface IFatturaView : IView
    {
        event FatturaDettaglioEventHandler AggiungiDettaglioEvent;
        event EventHandler ApriFatturaEvent;
        event EventHandler<int> EliminaFatturaEvent;
        event EventHandler NuovoDettaglioEvent;
        event FatturaDettaglioEventHandler RimuoviDettaglioEvent;
        event EventHandler<Fattura> SalvaFatturaEvent;

        void SetDettaglio(Dettaglio dettaglio);
        void SetFattura(Fattura fattura);
    }
}
