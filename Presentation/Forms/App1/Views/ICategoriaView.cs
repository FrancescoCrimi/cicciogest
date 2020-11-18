using CiccioGest.Domain.Magazino;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.AppForm.Views
{
    public interface ICategoriaView : IView
    {
        event EventHandler<int> CancellaCategoriaEvent;
        event EventHandler LoadEvent;
        event EventHandler<Categoria> SalvaCategoriaEvent;

        void MostraCategoria(Categoria categoria);
        void MostraCategorie(IList<Categoria> list);
    }
}
