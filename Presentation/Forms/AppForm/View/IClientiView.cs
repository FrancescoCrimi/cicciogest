using CiccioGest.Domain.ClientiFornitori;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.AppForm.View
{
    public interface IClientiView : IView
    {
        void CaricaClienti(IList<Cliente> clienti);
        event EventHandler<int> ClienteSelezionatoEvent;
        event EventHandler NuovoClienteEvent;
        event EventHandler<int> CreaFatturaEvent;
    }
}
