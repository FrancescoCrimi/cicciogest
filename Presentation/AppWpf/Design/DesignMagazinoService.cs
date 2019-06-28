using CiccioGest.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CiccioGest.Domain.Magazino;
using CiccioGest.Domain.ClientiFornitori;

namespace CiccioGest.Presentation.AppWpf.Design
{
    class DesignMagazinoService : IMagazinoService
    {
        public void DeleteCategoria(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteProdotto(int id)
        {
            throw new NotImplementedException();
        }

        public Categoria GetCategoria(int id)
        {
            return DesignData.Categorie.First(c => c.Id == id);
        }

        public IEnumerable<Categoria> GetCategorie()
        {
            return DesignData.Categorie;
        }

        public Fornitore GetFornitore(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProdottoReadOnly> GetProdotti()
        {
            return DesignData.ProdottiRO;
        }

        public Prodotto GetProdotto(int id)
        {
            return DesignData.Prodotti.First(p => p.Id == id);
        }

        public Categoria SaveCategoria(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Prodotto SaveProdotto(Prodotto prodotto)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
