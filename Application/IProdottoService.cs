using Ciccio1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Ciccio1.Application
{
    [ServiceContract(ConfigurationName = "Ciccio1.Application.IProdottoService")]
    public interface IProdottoService
    {
        [OperationContract]
        IEnumerable<Prodotto> GetProdotti();
        [OperationContract]
        Prodotto GetProdotto(Guid id);
        [OperationContract]
        Prodotto SaveProdotto(Prodotto prodotto);
        [OperationContract]
        void DeleteProdotto(Prodotto prodotto);
    }
}
