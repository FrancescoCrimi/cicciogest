using CiccioGest.Domain.ClientiFornitori;
using System.Collections.Generic;
//using System.ServiceModel;
using System.Threading.Tasks;

namespace CiccioGest.Application
{
    //[ServiceContract(ConfigurationName = "CiccioGest.Application.IClientiFornitoriService")]
    public interface IClientiFornitoriService
    {
        //[OperationContract]
        Task<IList<Cliente>> GetClienti();
        //[OperationContract]
        Task<Cliente> GetCliente(int id);
        //[OperationContract]
        Task<Cliente> SaveCliente(Cliente cliente);
        //[OperationContract]
        Task DeleteCliente(int id);


        //[OperationContract]
        Task<IList<Fornitore>> GetFornitori();
        //[OperationContract]
        Task<Fornitore> GetFornitore(int id);
        //[OperationContract]
        Task<Fornitore> SaveFornitore(Fornitore fornitore);
        //[OperationContract]
        Task DeleteFornitore(int id);


        //[OperationContract]
        Task<IList<Citta>> GetCittà();
        //[OperationContract]
        Task<Citta> GetCittà(int id);
        //[OperationContract]
        Task<Citta> SaveCittà(Citta città);
        //[OperationContract]
        Task DeleteCittà(int id);
    }
}
