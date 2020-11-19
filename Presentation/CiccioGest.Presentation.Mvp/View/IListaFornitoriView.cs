using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Presentation.Mvp.View;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.Mvp.Views
{
    public interface IListaFornitoriView : IView
    {
        event EventHandler<int> SelectFornitoreEvent;

        void SetFornitori(IList<Fornitore> fornitori);
    }
}
