using Castle.Core.Logging;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
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

        public void DeleteCittà(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteCliente(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteFornitore(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Citta> GetCittà()
        {
            throw new NotImplementedException();
        }

        public Citta GetCittà(int id)
        {
            throw new NotImplementedException();
        }

        public Cliente GetCliente(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> GetClienti()
        {
            throw new NotImplementedException();
        }

        public Fornitore GetFornitore(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Fornitore> GetFornitori()
        {
            throw new NotImplementedException();
        }

        public Citta SaveCittà(Citta città)
        {
            throw new NotImplementedException();
        }

        public Cliente SaveCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Fornitore SaveFornitore(Fornitore fornitore)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
