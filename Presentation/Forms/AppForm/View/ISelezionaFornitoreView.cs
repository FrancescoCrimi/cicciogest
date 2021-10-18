using CiccioGest.Domain.ClientiFornitori;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.AppForm.View
{
    public interface ISelezionaFornitoreView : IView
    {
        void CaricaFornitori(IList<Fornitore> fornitori);
        event EventHandler<int> FornitoreSelezionatoEvent;
    }
}
