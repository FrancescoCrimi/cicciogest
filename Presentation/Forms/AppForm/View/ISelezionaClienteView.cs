using CiccioGest.Domain.ClientiFornitori;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.AppForm.View
{
    public interface ISelezionaClienteView : IView
    {
        void CaricaClienti(IList<Cliente> clienti);
        event EventHandler<int> ClienteSelezionatoEvent;
    }
}
