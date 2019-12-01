using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Magazino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Uwp.App1.Design
{
    class DesignMagazinoService : IMagazinoService
    {
        public Task DeleteCategoria(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteArticolo(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Categoria> GetCategoria(int id)
        {
            return Task.Run(() => DesignData.Categorie.First(c => c.Id == id));
        }

        public Task<IEnumerable<Categoria>> GetCategorie()
        {
            return Task.Run(() => (IEnumerable<Categoria>)DesignData.Categorie);
        }

        public Task<Fornitore> GetFornitore(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ArticoloReadOnly>> GetArticoli()
        {
            return Task.Run(() => (IEnumerable<ArticoloReadOnly>)DesignData.ProdottiRO);
        }

        public Task<Articolo> GetArticolo(int id)
        {
            return Task.Run(() => DesignData.Prodotti.First(p => p.Id == id));
        }

        public Task<Categoria> SaveCategoria(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Task<Articolo> SaveArticolo(Articolo prodotto)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
