using CiccioGest.Domain.ClientiFornitori;
using System;

namespace CiccioGest.Presentation.AppForm.View
{
    public interface IFornitoreView : IView
    {
        event EventHandler NuovoFornitore;
        event EventHandler SalvaFornitore;
        event EventHandler ApriFornitore;
        void MostraFornitore(Fornitore fornitore);
    }
}
