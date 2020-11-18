using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.AppForm.Presenter;
using System;

namespace CiccioGest.Presentation.AppForm.Views
{
    public interface IFatturaView : IView
    {
        event FatturaDettaglioEventHandler AggiungiDettaglioEvent;
        event EventHandler ApriFatturaEvent;
        event EventHandler<int> EliminaEvent;
        event EventHandler EsciEvent;
        event EventHandler LoadEvent;
        event EventHandler NuovoDettaglioEvent;
        event FatturaDettaglioEventHandler RimuoviDettaglioEvent;
        event EventHandler<Fattura> SalvaEvent;

        void SetDettaglio(Dettaglio dettaglio);
        void SetFattura(Fattura fattura);
    }
}
