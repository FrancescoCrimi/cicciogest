using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Client
{
    public class DomainListEndpointBehavior : IEndpointBehavior
    {
        private readonly DomainListDataContractSurrogate dcs;

        public DomainListEndpointBehavior()
        {
            dcs = new DomainListDataContractSurrogate();
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            ConfigureDataContractSurrogate(endpoint);
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            ConfigureDataContractSurrogate(endpoint);
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }

        private void ConfigureDataContractSurrogate(ServiceEndpoint endpoint)
        {
            foreach (var operation in endpoint.Contract.Operations)
            {
                var serializer = operation.Behaviors.Find<DataContractSerializerOperationBehavior>();
                serializer.DataContractSurrogate = dcs;
            }
        }
    }
}
