using System;

namespace CiccioGest.Presentation.AppForm.Views
{
    public interface IMainView : IView
    {
        event EventHandler EventLoad;
        event EventHandler EventFatture;
        event EventHandler EventClienti;
        event EventHandler EventFornitori;
        event EventHandler EventArticoli;
        event EventHandler EventCategorie;
        event EventHandler EventInformazioni;
        event EventHandler EventOpzioni;
    }
}
