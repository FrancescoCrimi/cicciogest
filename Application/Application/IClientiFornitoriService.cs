using CiccioGest.Domain.ClientiFornitori;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Application
{
    public interface IClientiFornitoriService
    {
        Task<IList<Cliente>> GetClienti();
        Task<Cliente> GetCliente(int id);
        Task<Cliente> SaveCliente(Cliente cliente);
        Task DeleteCliente(int id);

        Task<IList<Fornitore>> GetFornitori();
        Task<Fornitore> GetFornitore(int id);
        Task<Fornitore> SaveFornitore(Fornitore fornitore);
        Task DeleteFornitore(int id);


        Task<IList<Citta>> GetCittà();
        Task<Citta> GetCittà(int id);
        Task<Citta> SaveCittà(Citta città);
        Task DeleteCittà(int id);
    }
}
