using CiccioGest.Domain.Magazino;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.Mvp.View
{
    public interface IArticoloView : IView
    {
        event EventHandler AggiungiCategoriaEvent;
        event EventHandler ApriArticoloEvent;
        event EventHandler<int> EliminaArticoloEvent;
        event EventHandler RimuoviCategoriaEvent;
        event EventHandler<Articolo> SalvaArticoloEvent;
        event EventHandler<int> SelezionaArticoloEvent;

        void SetArticoli(IList<ArticoloReadOnly> list);
        void SetArticolo(Articolo articolo);
        void SetCategorie(IList<Categoria> list);
    }
}
