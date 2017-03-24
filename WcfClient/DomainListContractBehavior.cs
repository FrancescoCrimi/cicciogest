using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.WcfClient
{
    public class DomainListContractBehavior : IContractBehavior
    {        
        DomainListDataContractSurrogate dcs;

        public DomainListContractBehavior()
        {
            dcs = new DomainListDataContractSurrogate();
        }

        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            ConfigureDataContractSurrogate(endpoint.Contract);
        }

        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            ConfigureDataContractSurrogate(endpoint.Contract);
        }

        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
        }

        private void ConfigureDataContractSurrogate(ContractDescription contractDescription)
        {
            foreach (var operation in contractDescription.Operations)
            {
                var serializer = operation.Behaviors.Find<DataContractSerializerOperationBehavior>();
                serializer.DataContractSurrogate = dcs;
            }
        }

    }
}
