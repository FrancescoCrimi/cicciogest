using CiccioGest.Domain.Documenti;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.AppForm.Views
{
    public interface IListaFattureView : IView
    {
        event EventHandler EventLoad;
        event EventHandler<int> EventSelectFattura;
        event EventHandler EventNuova;
        event EventHandler EventApri;
        event EventHandler EventEsci;
        void ViewFatture(IList<FatturaReadOnly> listFatture);
    }
}
