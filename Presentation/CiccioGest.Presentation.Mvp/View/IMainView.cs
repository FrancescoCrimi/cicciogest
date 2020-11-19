using System;

namespace CiccioGest.Presentation.Mvp.View
{
    public interface IMainView : IView
    {
        event EventHandler FattureEvent;
        event EventHandler ClientiEvent;
        event EventHandler FornitoriEvent;
        event EventHandler ArticoliEvent;
        event EventHandler CategorieEvent;
        event EventHandler OpzioniEvent;
    }
}
