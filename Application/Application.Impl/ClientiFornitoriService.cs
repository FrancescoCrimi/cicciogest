using Castle.Core.Logging;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace CiccioGest.Application.Impl
{
    class ClientiFornitoriService : IClientiFornitoriService
    {
        private readonly ILogger logger;
        private readonly IUnitOfWork da;
        private readonly ICategoriaRepository categoriaRepository;

        public ClientiFornitoriService(
            ILogger logger,
            IUnitOfWork da,
            ICategoriaRepository categoriaRepository
            )
        {
            this.logger = logger;
            this.da = da;
            this.categoriaRepository = categoriaRepository;
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public Task DeleteCittà(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCliente(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFornitore(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Citta>> GetCittà()
        {
            throw new NotImplementedException();
        }

        public Task<Citta> GetCittà(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> GetCliente(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Cliente>> GetClienti()
        {
            throw new NotImplementedException();
        }

        public Task<Fornitore> GetFornitore(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Fornitore>> GetFornitori()
        {
            throw new NotImplementedException();
        }

        public Task<Citta> SaveCittà(Citta città)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> SaveCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task<Fornitore> SaveFornitore(Fornitore fornitore)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
