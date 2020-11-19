using CiccioGest.Domain.Magazino;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.Mvp.View
{
    public interface IListaArticoliView : IView
    {
        event EventHandler<int> SelezionaArticoloEvent;

        void SetArticoli(IList<ArticoloReadOnly> articoli);
    }
}
