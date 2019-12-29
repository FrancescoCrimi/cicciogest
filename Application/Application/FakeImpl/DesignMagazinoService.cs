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
        public Task DeleteCategoria(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteArticolo(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Categoria> GetCategoria(int id) => Task.Run(() =>
        {
            return FakeSampleData.Categorie.First(c => c.Id == id);
        });

        public Task<IList<Categoria>> GetCategorie() => Task.Run(() =>
        {
            return FakeSampleData.Categorie;
        });

        public Task<Fornitore> GetFornitore(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<ArticoloReadOnly>> GetArticoli() => Task.Run(() =>
        {
            return FakeSampleData.ArticoliRO;
        });

        public Task<Articolo> GetArticolo(int id) => Task.Run(() =>
        {
            return FakeSampleData.Articoli.First(p => p.Id == id);
        });

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
        }
    }
}
