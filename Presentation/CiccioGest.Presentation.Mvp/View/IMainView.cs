using System;

namespace CiccioGest.Presentation.Mvp.View
{
    public interface IMainView : IView
    {
        event EventHandler ApriFatturaEvent;
        event EventHandler NuovaFatturaEvent;
        event EventHandler ApriClienteEvent;
        event EventHandler NuovoClienteEvent;
        event EventHandler ApriFornitoreEvent;
        event EventHandler NuovoFornitoreEvent;
        event EventHandler ApriArticoloEvent;
        event EventHandler NuovoArticoloEvent;
        event EventHandler CategorieEvent;
        event EventHandler OpzioniEvent;
    }
}
