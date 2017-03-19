using CiccioGest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Application
{
    [ServiceContract(ConfigurationName = "Ciccio1.Application.IFatturaService")]
    public interface IFatturaService : IDisposable
    {
        [OperationContract]
        IEnumerable<Fattura> GetFatture();
        [OperationContract]
        Fattura GetFattura(int id);
        [OperationContract]
        Fattura SaveFattura(Fattura fattura);
        [OperationContract]
        void DeleteFattura(Fattura fattura);

        [OperationContract]
        Prodotto GetProdotto(int id);
    }
}
