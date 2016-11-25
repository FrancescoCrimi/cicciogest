using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Ciccio1.Application;
using Ciccio1.Infrastructure.Conf;
using Ciccio1.Infrastructure.Wcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Ciccio1.WcfClient
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            IConf conf = container.Resolve<IConf>();
            //container.Register(
            //    Component.For<CiccioService>().AsWcfClient<CiccioService>(
            //        WcfEndpoint.BoundTo(new WSHttpBinding()).At(conf.ConnectionString + "/CiccioService.svc"))
            //        );
            ChannelFactory<ICiccioService> cf = init(conf.ConnectionString + "/CiccioService.svc");
            container.Register(
                Component.For<ICiccioService>().UsingFactoryMethod(cf.CreateChannel).LifestyleTransient());
        }

        ChannelFactory<ICiccioService> init(string uri)
        {
            WSHttpBinding myBinding = new WSHttpBinding();
            EndpointAddress myEndpointAddress = new EndpointAddress(uri);
            ChannelFactory<ICiccioService> myChannelFactory = new ChannelFactory<ICiccioService>(myBinding, myEndpointAddress);

            foreach (OperationDescription op in myChannelFactory.Endpoint.Contract.Operations)
            {
                DataContractSerializerOperationBehavior dataContractBehavior =
                    op.Behaviors.Find<DataContractSerializerOperationBehavior>()
                    as DataContractSerializerOperationBehavior;
                if (dataContractBehavior != null)
                {
                    dataContractBehavior.DataContractSurrogate = new MyDataContractSurrogate();
                }
                else
                {
                    dataContractBehavior = new DataContractSerializerOperationBehavior(op);
                    dataContractBehavior.DataContractSurrogate = new MyDataContractSurrogate();
                    op.Behaviors.Add(dataContractBehavior);
                }
            }
            return myChannelFactory;
        }
    }
}
