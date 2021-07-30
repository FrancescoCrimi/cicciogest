using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Presentation.AppForm.View;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.AppForm.View
{
    public interface IListaFornitoriView : IView
    {
        event EventHandler<int> SelectFornitoreEvent;

        void SetFornitori(IList<Fornitore> fornitori);
    }
}
