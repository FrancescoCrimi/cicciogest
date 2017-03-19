using CiccioGest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Application
{
    [ServiceContract(ConfigurationName = "Ciccio1.Application.IProdottoService")]
    public interface IProdottoService : IDisposable
    {
        [OperationContract]
        IEnumerable<Prodotto> GetProdotti();
        [OperationContract]
        Prodotto GetProdotto(int id);
        [OperationContract]
        Prodotto SaveProdotto(Prodotto prodotto);
        [OperationContract]
        void DeleteProdotto(Prodotto prodotto);

        [OperationContract]
        IEnumerable<Categoria> GetCategorie();
    }
}
