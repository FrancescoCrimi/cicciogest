using CiccioGest.Domain;
using CiccioGest.Infrastructure.Persistence.EFC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.EFC.Repository
{
    class FatturaRepository : IFatturaRepository
    {
        private DataAccess da;

        public FatturaRepository(DataAccess da)
        {
            this.da = da;
        }

        public void Delete(Fattura entity)
        {
            da.ModelContext.FatturaSet.Remove(entity);
        }

        public Fattura Get(int id)
        {
            return da.ModelContext.FatturaSet.Find(id);
        }

        public IEnumerable<Fattura> GetAll()
        {
            return da.ModelContext.FatturaSet.ToList();
        }

        public int Save(Fattura entity)
        {
            da.ModelContext.FatturaSet.Add(entity);
            return 0;
        }

        public void Update(Fattura entity)
        {
            da.ModelContext.FatturaSet.Update(entity);
        }
    }
}
