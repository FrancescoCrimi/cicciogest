using CiccioGest.Domain.ClientiFornitori;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.Mvp.View
{
    public interface IListaClientiView : IView
    {
        event EventHandler<int> SelectClienteEvent;

        void SetClienti(IList<Cliente> clienti);
    }
}
