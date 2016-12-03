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
    // NOTA: è possibile utilizzare il comando "Rinomina" del menu "Refactoring" per modificare il nome di classe "CiccioService" nel codice, nel file svc e nel file di configurazione contemporaneamente.
    // NOTA: per avviare il client di prova WCF per testare il servizio, selezionare CiccioService.svc o CiccioService.svc.cs in Esplora soluzioni e avviare il debug.
    public class CiccioService : ICiccioService
    {
        public void DeleteCategoria(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public void DeleteFattura(Fattura fattura)
        {
            throw new NotImplementedException();
        }

        public void DeleteProdotto(Prodotto prodotto)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Categoria GetCategoria(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Categoria> GetCategorie()
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

        public IEnumerable<Prodotto> GetProdotti()
        {
            throw new NotImplementedException();
        }

        public Prodotto GetProdotto(int id)
        {
            throw new NotImplementedException();
        }

        public Categoria SaveCategoria(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Fattura SaveFattura(Fattura fattura)
        {
            throw new NotImplementedException();
        }

        public Prodotto SaveProdotto(Prodotto prodotto)
        {
            throw new NotImplementedException();
        }
    }
}
