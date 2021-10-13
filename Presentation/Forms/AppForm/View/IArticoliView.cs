using CiccioGest.Domain.Magazino;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.AppForm.View
{
    public interface IArticoliView : IView
    {
        void CaricaArticoli(IList<ArticoloReadOnly> articoli);
        event EventHandler<int> ArticoloSelezionatoEvent;
        event EventHandler NuovoArticoloEvent;
    }
}
