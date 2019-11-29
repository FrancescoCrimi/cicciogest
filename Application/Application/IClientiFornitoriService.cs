using CiccioGest.Domain.ClientiFornitori;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Application
{
    [ServiceContract(ConfigurationName = "CiccioGest.Application.IClientiFornitoriService")]
    public interface IClientiFornitoriService
    {
        [OperationContract]
        IEnumerable<Cliente> GetClienti();
        [OperationContract]
        Cliente GetCliente(int id);
        [OperationContract]
        Cliente SaveCliente(Cliente cliente);
        [OperationContract]
        void DeleteCliente(int id);


        [OperationContract]
        IEnumerable<Fornitore> GetFornitori();
        [OperationContract]
        Fornitore GetFornitore(int id);
        [OperationContract]
        Fornitore SaveFornitore(Fornitore fornitore);
        [OperationContract]
        void DeleteFornitore(int id);


        [OperationContract]
        IEnumerable<Citta> GetCittà();
        [OperationContract]
        Citta GetCittà(int id);
        [OperationContract]
        Citta SaveCittà(Citta città);
        [OperationContract]
        void DeleteCittà(int id);
    }
}
