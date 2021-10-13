using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.AppForm.Presenter;
using System;

namespace CiccioGest.Presentation.AppForm.View
{
    public interface IFatturaView : IView
    {
        event EventHandler NuovaFatturaEvent;
        event EventHandler<Fattura> SalvaFatturaEvent;
        event FatturaDettaglioEventHandler AggiungiDettaglioEvent;
        event EventHandler ApriFatturaEvent;
        event EventHandler NuovoDettaglioEvent;
        event FatturaDettaglioEventHandler RimuoviDettaglioEvent;
        void SetDettaglio(Dettaglio dettaglio);
        void SetFattura(Fattura fattura);
    }
}
