using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CiccioGest.Application;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Infrastructure.Wcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.WcfClient
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            IConf conf = container.Resolve<IConf>();
            //ChannelFactory<IFatturaService> cf = creaFatturaChannelFactory(conf.ConnectionString + "/FatturaService.svc");

            container.Register(
                //Component.For<IFatturaService>().AsWcfClient(                
                //    WcfEndpoint.BoundTo(new WSHttpBinding()).At(conf.ConnectionString + "/FatturaService.svc")),
                //Component.For<IFatturaService>().UsingFactoryMethod(cf.CreateChannel).LifestyleTransient());            
                Component.For<IFatturaService>().UsingFactoryMethod(suca<IFatturaService>(conf.CS + "/FatturaService.svc").CreateChannel).LifestyleTransient(),
                Component.For<IProdottoService>().UsingFactoryMethod(suca<IProdottoService>(conf.CS + "/ProdottoService.svc").CreateChannel).LifestyleTransient(),
                Component.For<ICategoriaService>().UsingFactoryMethod(suca<ICategoriaService>(conf.CS + "/CategoriaService.svc").CreateChannel).LifestyleTransient());
        }

        ChannelFactory<Service> suca<Service>(string address)
        {
            WSHttpBinding myBinding = new WSHttpBinding();
            EndpointAddress myEndpointAddress = new EndpointAddress(address);
            ChannelFactory<Service> myChannelFactory = new ChannelFactory<Service>(myBinding, myEndpointAddress);
            defineSurrogate(myChannelFactory.Endpoint);
            return myChannelFactory;
        }

        void defineSurrogate(ServiceEndpoint endpoint)
        {
            foreach (OperationDescription od in endpoint.Contract.Operations)
            {
                var dcsob = od.Behaviors.Find<DataContractSerializerOperationBehavior>();
                dcsob.DataContractSurrogate = new DomainListDataContractSurrogate();
            }
        }
    }
}




//ChannelFactory<IFatturaService> creaFatturaChannelFactory(string uri)
//{
//    WSHttpBinding myBinding = new WSHttpBinding();
//    EndpointAddress myEndpointAddress = new EndpointAddress(uri);
//    ChannelFactory<IFatturaService> myChannelFactory = new ChannelFactory<IFatturaService>(myBinding, myEndpointAddress);
//    defineSurrogate(myChannelFactory.Endpoint);
//    return myChannelFactory;
//}


//foreach (OperationDescription op in myChannelFactory.Endpoint.Contract.Operations)
//{
//    DataContractSerializerOperationBehavior dataContractBehavior =
//        op.Behaviors.Find<DataContractSerializerOperationBehavior>()
//        as DataContractSerializerOperationBehavior;
//    if (dataContractBehavior != null)
//    {
//        dataContractBehavior.DataContractSurrogate = new MyDataContractSurrogate();
//    }
//    else
//    {
//        dataContractBehavior = new DataContractSerializerOperationBehavior(op);
//        dataContractBehavior.DataContractSurrogate = new MyDataContractSurrogate();
//        op.Behaviors.Add(dataContractBehavior);
//    }
//}
