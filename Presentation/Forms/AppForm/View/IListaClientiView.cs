using CiccioGest.Domain.ClientiFornitori;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.AppForm.View
{
    public interface IListaClientiView : IView
    {
        void SetClienti(IList<Cliente> clienti);
        event EventHandler NuovoClienteEvent;
        event EventHandler<int> SelectClienteEvent;
        event EventHandler<int> CreaFatturaEvent;
        event EventHandler<int> ApriFattureEvent;
    }
}
