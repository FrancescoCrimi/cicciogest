using CiccioGest.Domain.ClientiFornitori;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Application.FakeImpl
{
    public class DesignClientiFornitoriService : IClientiFornitoriService
    {
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
    }
}
