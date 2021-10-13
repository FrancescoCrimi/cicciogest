using CiccioGest.Domain.Documenti;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.AppForm.View
{
    public interface IFattureView : IView
    {
        void CaricaFatture(IList<FatturaReadOnly> listFatture);
        event EventHandler<int> FatturaSelezionataEvent;
        event EventHandler NuovaFatturaEvent;
    }
}
