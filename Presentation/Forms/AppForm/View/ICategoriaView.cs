using CiccioGest.Domain.Magazino;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.AppForm.View
{
    public interface ICategoriaView : IView
    {
        event EventHandler<int> CancellaCategoriaEvent;
        event EventHandler<Categoria> SalvaCategoriaEvent;

        void SetCategoria(Categoria categoria);
        void SetCategorie(IList<Categoria> list);
    }
}
