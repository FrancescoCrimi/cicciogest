using Ciccio1.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ciccio1.Domain;
using IO.Swagger.Api;

namespace IO.Swagger
{
    class CiccioService : ICiccioService
    {
        CategoriaApi cat = null;
        FatturaApi fat = null;
        ProdottoApi pro = null;

        public CiccioService()
        {
             cat = new CategoriaApi();
             fat = new FatturaApi();
             pro = new ProdottoApi();
        }

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
