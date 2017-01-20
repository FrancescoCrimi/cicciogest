using Ciccio1.Domain;
using Ciccio1.Infrastructure.Persistence.EFC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.EFC.Repository
{
    class ProdottoRepository : IProdottoRepository
    {
        private DataAccess da;

        public ProdottoRepository(DataAccess da)
        {
            this.da = da;
        }

        public void Delete(Prodotto entity)
        {
            da.ModelContext.ProdottoSet.Remove(entity);
        }

        public Prodotto Get(int id)
        {
            return da.ModelContext.ProdottoSet.Find(id);
        }

        public IEnumerable<Prodotto> GetAll()
        {
            return da.ModelContext.ProdottoSet.ToList();
        }

        public int Save(Prodotto entity)
        {
            da.ModelContext.ProdottoSet.Add(entity);
            return 0;
        }

        public void Update(Prodotto entity)
        {
            da.ModelContext.ProdottoSet.Update(entity);
        }
    }
}
