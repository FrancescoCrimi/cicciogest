using CiccioGest.Domain.Magazino;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.AppForm.View
{
    public interface ISelezionaCategoriaView : IView
    {
        void CaricaCategorie(IList<Categoria> categorie);
        event EventHandler<int> CategoriaSelezionataEvent;
    }
}
