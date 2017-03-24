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
    public class DomainListEndpointBehavior : IEndpointBehavior
    {        
        DomainListDataContractSurrogate dcs;

        public DomainListEndpointBehavior()
        {
            dcs = new DomainListDataContractSurrogate();
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            ConfigureDataContractSurrogate(endpoint.Contract);
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            ConfigureDataContractSurrogate(endpoint.Contract);
        }

        public void Validate(ServiceEndpoint endpoint)
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
