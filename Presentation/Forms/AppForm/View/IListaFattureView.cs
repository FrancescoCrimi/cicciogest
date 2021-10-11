using CiccioGest.Domain.Documenti;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.AppForm.View
{
    public interface IListaFattureView : IView
    {
        event EventHandler<int> SelectFatturaEvent;
        event EventHandler NuovaFatturaEvent;
        void SetFatture(IList<FatturaReadOnly> listFatture);
    }
}
