using CiccioGest.Domain.ClientiFornitori;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.AppForm.Views
{
    public interface IListaClientiView : IView
    {
        event EventHandler LoadEvent;
        event EventHandler<Cliente> SelezionaClienteEvent;

        void MostraClienti(IList<Cliente> clienti);
    }
}
