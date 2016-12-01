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
    // NOTA: è possibile utilizzare il comando "Rinomina" del menu "Refactoring" per modificare il nome di classe "CategoriaService" nel codice, nel file svc e nel file di configurazione contemporaneamente.
    // NOTA: per avviare il client di prova WCF per testare il servizio, selezionare CategoriaService.svc o CategoriaService.svc.cs in Esplora soluzioni e avviare il debug.
    public class CategoriaService : ICategoriaService
    {
        public void DeleteCategoria(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Categoria GetCategoria(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Categoria> GetCategorie()
        {
            throw new NotImplementedException();
        }

        public Categoria SaveCategoria(Categoria categoria)
        {
            throw new NotImplementedException();
        }
    }
}
