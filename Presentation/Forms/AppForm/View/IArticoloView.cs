using CiccioGest.Domain.Magazino;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.AppForm.View
{
    public interface IArticoloView : IView
    {
        event EventHandler NuovoArticoloEvent;
        event EventHandler SalvaArticoloEvent;
        event EventHandler<int> EliminaArticoloEvent;
        event EventHandler ApriArticoloEvent;
        event EventHandler AggiungiCategoriaEvent;
        event EventHandler<Categoria> RimuoviCategoriaEvent;
        event EventHandler SelezionaFornitore;
        void SetArticolo(Articolo articolo);
        void SetCategorie(ICollection<Categoria> list);
    }
}
