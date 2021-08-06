using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using System;
using System.Collections.Generic;
//using System.ServiceModel;
using System.Threading.Tasks;

namespace CiccioGest.Application
{
    //[ServiceContract(ConfigurationName = "CiccioGest.Application.IFatturaService")]
    public interface IFatturaService : IDisposable
    {
        //[OperationContract(Action = "http://gest.cicciosoft.tk/IFatturaService/GetFatture", ReplyAction = "http://gest.cicciosoft.tk/IFatturaService/GetFattureResponse")]
        Task<IList<FatturaReadOnly>> GetFatture();

        //[OperationContract(Action = "http://gest.cicciosoft.tk/IFatturaService/GetFattura", ReplyAction = "http://gest.cicciosoft.tk/IFatturaService/GetFatturaResponse")]
        Task<Fattura> GetFattura(int id);

        //[OperationContract(Action = "http://gest.cicciosoft.tk/IFatturaService/SaveFattura", ReplyAction = "http://gest.cicciosoft.tk/IFatturaService/SaveFatturaResponse")]
        Task<Fattura> SaveFattura(Fattura fattura);

        //[OperationContract(Action = "http://gest.cicciosoft.tk/IFatturaService/DeleteFattura", ReplyAction = "http://gest.cicciosoft.tk/IFatturaService/DeleteFatturaResponse")]
        Task DeleteFattura(int id);

        //[OperationContract(Action = "http://gest.cicciosoft.tk/IFatturaService/GetArticolo", ReplyAction = "http://gest.cicciosoft.tk/IFatturaService/GetArticoloResponse")]
        Task<Articolo> GetArticolo(int id);

        //[OperationContract(Action = "http://gest.cicciosoft.tk/IFatturaService/GetCliente", ReplyAction = "http://gest.cicciosoft.tk/IFatturaService/GetClienteResponse")]
        Task<Cliente> GetCliente(int id);
    }
}
