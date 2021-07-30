using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.AppForm.Presenter;
using System;

namespace CiccioGest.Presentation.AppForm.View
{
    public interface IFatturaView : IView
    {
        event FatturaDettaglioEventHandler AggiungiDettaglioEvent;
        event EventHandler ApriFatturaEvent;
        event EventHandler NuovaFattura;
        event EventHandler<int> EliminaFatturaEvent;
        event EventHandler NuovoDettaglioEvent;
        event FatturaDettaglioEventHandler RimuoviDettaglioEvent;
        event EventHandler<Fattura> SalvaFatturaEvent;

        void SetDettaglio(Dettaglio dettaglio);
        void SetFattura(Fattura fattura);
    }
}
