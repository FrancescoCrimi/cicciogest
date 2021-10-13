using CiccioGest.Domain.Magazino;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.AppForm.View
{
    public interface ISelezionaArticoloView : IView
    {
        void CaricaArticoli(IList<ArticoloReadOnly> articoli);
        event EventHandler<int> ArticoloSelezionatoEvent;
    }
}
