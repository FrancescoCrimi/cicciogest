using CiccioGest.Domain.Documenti;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.AppForm.View
{
    public interface ISelezionaFatturaView : IView
    {
        void CaricaFatture(IList<FatturaReadOnly> fatture);
        event EventHandler<int> FatturaSelezionataEvent;
    }
}
