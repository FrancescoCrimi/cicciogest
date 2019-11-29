using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Magazino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.AppWpf1.Design
{
    class DesignMagazinoService : IMagazinoService
    {
        public async Task DeleteCategoria(int id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteArticolo(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Categoria> GetCategoria(int id)
        {
            return  DesignData.Categorie.First(c => c.Id == id);
        }

        public async Task<IEnumerable<Categoria>> GetCategorie()
        {
            return DesignData.Categorie;
        }

        public async Task<Fornitore> GetFornitore(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ArticoloReadOnly>> GetArticoli()
        {
            return DesignData.ProdottiRO;
        }

        public async Task<Articolo> GetArticolo(int id)
        {
            return DesignData.Prodotti.First(p => p.Id == id);
        }

        public async Task<Categoria> SaveCategoria(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public async Task<Articolo> SaveArticolo(Articolo prodotto)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}
