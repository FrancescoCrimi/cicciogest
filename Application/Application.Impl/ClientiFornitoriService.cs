using Castle.Core.Logging;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Application.Impl
{
    class ClientiFornitoriService : IClientiFornitoriService
    {
        private ILogger logger;
        private IUnitOfWork da;
        private ICategoriaRepository categoriaRepository;

        public ClientiFornitoriService(
            ILogger logger,
            IUnitOfWork da,
            ICategoriaRepository categoriaRepository
            )
        {
            this.logger = logger;
            this.da = da;
            this.categoriaRepository = categoriaRepository;
            logger.Debug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public void DeleteCategoria(Categoria categoria)
        {
            try
            {
                //categoriaRepository.Delete(categoria);
                da.Commit();
            }
            catch (Exception ex)
            {
                da.Rollback();
                throw ex;
            }
        }


        public void Dispose()
        {
            logger.Debug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
