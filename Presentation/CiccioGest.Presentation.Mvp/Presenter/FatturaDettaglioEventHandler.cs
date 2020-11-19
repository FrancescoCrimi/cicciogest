using CiccioGest.Domain.Documenti;
using System;

namespace CiccioGest.Presentation.Mvp.Presenter
{

    public delegate void FatturaDettaglioEventHandler(object sender, FatturaDettaglioEventArgs e);

    public class FatturaDettaglioEventArgs : EventArgs
    {
        public FatturaDettaglioEventArgs(Fattura fattura, Dettaglio dettaglio)
        {
            Fattura = fattura;
            Dettaglio = dettaglio;
        }
        public Fattura Fattura { get; }
        public Dettaglio Dettaglio { get; }
    }
}
