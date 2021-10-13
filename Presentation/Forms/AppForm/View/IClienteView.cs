using CiccioGest.Domain.ClientiFornitori;
using System;

namespace CiccioGest.Presentation.AppForm.View
{
    public interface IClienteView : IView
    {
        event EventHandler NuovoCliente;
        event EventHandler SalvaCliente;
        event EventHandler ApriCliente;
        void MostraCliente(Cliente cliente);
    }
}
