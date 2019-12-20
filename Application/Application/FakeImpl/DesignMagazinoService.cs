using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Magazino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiccioGest.Application.FakeImpl
{
    public class DesignMagazinoService : IMagazinoService
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
            return FakeSampleData.Categorie.First(c => c.Id == id);
        }

        public async Task<IEnumerable<Categoria>> GetCategorie()
        {
            return FakeSampleData.Categorie;
        }

        public async Task<Fornitore> GetFornitore(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ArticoloReadOnly>> GetArticoli()
        {
            return FakeSampleData.ArticoliRO;
        }

        public async Task<Articolo> GetArticolo(int id)
        {
            return FakeSampleData.Articoli.First(p => p.Id == id);
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
