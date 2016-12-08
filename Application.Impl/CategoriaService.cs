using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ciccio1.Domain;
using Castle.Core.Logging;
using Ciccio1.Infrastructure;

namespace Ciccio1.Application.Impl
{
    class CategoriaService : ICategoriaService
    {
        private ILogger logger;
        private IDataAccess da;
        private ICategoriaRepository categoriaRepository;

        public CategoriaService(
            ILogger logger,
            IDataAccess da,
            ICategoriaRepository categoriaRepository
            )
        {
            this.logger = logger;
            this.da = da;
            this.categoriaRepository = categoriaRepository;
            logger.Debug("CategoriaService Creata " + this.GetHashCode().ToString());
        }

        public void DeleteCategoria(Categoria categoria)
        {
            try
            {
                categoriaRepository.Delete(categoria);
                da.Commit();
            }
            catch (Exception ex)
            {
                da.Rollback();
                throw ex;
            }
        }

        public Categoria GetCategoria(int id)
        {
            return categoriaRepository.Get(id);
        }

        public IEnumerable<Categoria> GetCategorie()
        {
            return categoriaRepository.GetAll();
        }

        public Categoria SaveCategoria(Categoria categoria)
        {
            try
            {
                if (categoria.Id == 0)
                {
                    categoriaRepository.Save(categoria);
                }
                else
                {
                    categoriaRepository.Update(categoria);
                }
                da.Commit();
            }
            catch (Exception ex)
            {
                da.Rollback();
                throw ex;
            }
            return categoria;
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
