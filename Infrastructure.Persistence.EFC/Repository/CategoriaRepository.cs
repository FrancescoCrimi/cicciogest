using CiccioGest.Domain;
using CiccioGest.Infrastructure.Persistence.EFC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.EFC.Repository
{
    class CategoriaRepository : ICategoriaRepository
    {
        private DataAccess da;

        public CategoriaRepository(DataAccess da)
        {
            this.da = da;
        }

        public void Delete(Categoria entity)
        {
            da.ModelContext.CategoriaSet.Remove(entity);
        }

        public Categoria Get(int id)
        {
            return da.ModelContext.CategoriaSet.Find(id);
        }

        public IEnumerable<Categoria> GetAll()
        {
            return da.ModelContext.CategoriaSet.ToList();
        }

        public int Save(Categoria entity)
        {
            da.ModelContext.CategoriaSet.Add(entity);
            return 0;
        }

        public void Update(Categoria entity)
        {
            da.ModelContext.CategoriaSet.Update(entity);
        }
    }
}
