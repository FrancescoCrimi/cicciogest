using CiccioGest.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using CiccioGest.Presentation.AppWpf.ViewModel;
using CiccioGest.Domain.ClientiFornitori;

namespace CiccioGest.Presentation.AppWpf.Design
{
    class DesignFatturaService : IFatturaService
    {
        public void DeleteFattura(int id)
        {
            throw new NotImplementedException();
        }

        public Fattura GetFattura(int id)
        {
            return DesignData.Fatture.First(fa => fa.Id == id);
        }

        public IEnumerable<FatturaReadOnly> GetFatture()
        {
            return  DesignData.FattureRO;
        }

        public Prodotto GetProdotto(int id)
        {
            throw new NotImplementedException();
        }

        public Fattura SaveFattura(Fattura fattura)
        {
            throw new NotImplementedException();
        }

        public Cliente GetCliente(int idCliente)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
