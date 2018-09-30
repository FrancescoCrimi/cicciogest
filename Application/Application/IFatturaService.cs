using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Application
{
    [ServiceContract(ConfigurationName = "CiccioGest.Application.IFatturaService")]
    public interface IFatturaService : IDisposable
    {
        [OperationContract]
        IEnumerable<FatturaReadOnly> GetFatture();
        [OperationContract]
        Fattura GetFattura(int id);
        [OperationContract]
        Fattura SaveFattura(Fattura fattura);
        [OperationContract]
        void DeleteFattura(int id);

        [OperationContract]
        Prodotto GetProdotto(int id);
        [OperationContract]
        Cliente GetCliente(int idCliente);
        //Articolo GetArticolo(int idArticolo);
    }
}
