using Ciccio1.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Ciccio1.Domain;

namespace Ciccio1.WcfServerWeb
{
    // NOTA: è possibile utilizzare il comando "Rinomina" del menu "Refactoring" per modificare il nome di classe "FatturaService" nel codice, nel file svc e nel file di configurazione contemporaneamente.
    // NOTA: per avviare il client di prova WCF per testare il servizio, selezionare FatturaService.svc o FatturaService.svc.cs in Esplora soluzioni e avviare il debug.
    public class FatturaService : IFatturaService
    {
        public void DeleteFattura(Fattura fattura)
        {
            throw new NotImplementedException();
        }

        public Fattura GetFattura(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Fattura> GetFatture()
        {
            throw new NotImplementedException();
        }

        public Fattura SaveFattura(Fattura fattura)
        {
            throw new NotImplementedException();
        }
    }
}
