using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using Castle.Facilities.WcfIntegration;
using CiccioGest.Infrastructure;
using CiccioGest.Application;
using CiccioGest.Infrastructure.Wcf;
using Castle.MicroKernel.Registration;

namespace CiccioGest.WcfServer
{
    class Program
    {
        DefaultServiceHostFactory shf;
        string baseAddresses;

        static void Main(string[] args)
        {
            new Program();
        }

        Program()
        {
            Container container = new Container(UI.WCF);
            container.Install(new CiccioGest.Application.Impl.Installer());


            //ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            //smb.HttpGetEnabled = true;
            //container.Windsor.Register(
            //    Component.For<IServiceBehavior>().Instance(smb));


            shf = new DefaultServiceHostFactory();
            baseAddresses = "http://localhost:8000/";

            //ServiceHostBase fatturaServiceHost = creaFatturaServiceHost();
            ServiceHostBase fatturaSH = creaServiceHost(typeof(IFatturaService), "FatturaService.svc");
            ServiceHostBase prodottoSH = creaServiceHost(typeof(IProdottoService), "ProdottoService.svc");
            ServiceHostBase categoriaSH = creaServiceHost(typeof(ICategoriaService), "CategoriaService.svc");
            try
            {
                fatturaSH.Open();
                PrintServiceInfo(fatturaSH);
                prodottoSH.Open();
                PrintServiceInfo(prodottoSH);
                categoriaSH.Open();
                PrintServiceInfo(categoriaSH);
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.ReadLine();
                fatturaSH.Close();
                prodottoSH.Close();
                categoriaSH.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred: {0}", ex.Message);
                fatturaSH.Abort();
                prodottoSH.Abort();
                categoriaSH.Abort();
                Console.ReadLine();
            }
        }

        ServiceHostBase creaServiceHost(Type serviceType, string address)
        {
            // Crea ServiceHost
            ServiceHostBase shb = shf.CreateServiceHost(serviceType.AssemblyQualifiedName,
                new Uri[] { new Uri(baseAddresses + address) });

            // Aggiungi un Endpoint al ServiceHost
            ServiceEndpoint se = shb.AddServiceEndpoint(serviceType.FullName, new WSHttpBinding(), "");

            foreach (OperationDescription od in se.Contract.Operations)
            {
                DataContractSerializerOperationBehavior dcsob = od.Behaviors.Find<DataContractSerializerOperationBehavior>();
                //Imposta DataContractSurrogate
                dcsob.DataContractSurrogate = new MyDataContractSurrogate();
                //Imposta DataContractResolver
                dcsob.DataContractResolver = new MyDataContractResolver();
            }

            // Crea e aggiungi un Behavior per la gestione dei Metadati
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            shb.Description.Behaviors.Add(smb);

            return shb;
        }

        void PrintServiceInfo(ServiceHostBase host)
        {
            Console.WriteLine("{0} is running with these endpoints", host.Description.ServiceType);
            foreach (ServiceEndpoint se in host.Description.Endpoints)
                Console.WriteLine(se.Address);
        }
    }
}



//ServiceHostBase creaFatturaServiceHost()
//{
//    ServiceHostBase sh = shf.CreateServiceHost(
//        typeof(IFatturaService).AssemblyQualifiedName, baseAddresses);
//    ServiceEndpoint fatturaServiceEndpoint = sh.AddServiceEndpoint(typeof(IFatturaService).FullName, new WSHttpBinding(), "FatturaService.svc");
//    defineSurrogate(fatturaServiceEndpoint);
//    ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
//    smb.HttpGetEnabled = true;
//    sh.Description.Behaviors.Add(smb);
//    return sh;
//}

//foreach (ServiceEndpoint ep in sh.Description.Endpoints)
//{
//    foreach (OperationDescription op in ep.Contract.Operations)
//    {
//        DataContractSerializerOperationBehavior dataContractBehavior =
//            op.Behaviors.Find<DataContractSerializerOperationBehavior>()
//            as DataContractSerializerOperationBehavior;
//        if (dataContractBehavior != null)
//        {
//            dataContractBehavior.DataContractSurrogate = new MyDataContractSurrogate();
//        }
//        else
//        {
//            dataContractBehavior = new DataContractSerializerOperationBehavior(op);
//            dataContractBehavior.DataContractSurrogate = new MyDataContractSurrogate();
//            op.Behaviors.Add(dataContractBehavior);
//        }
//    }
//}
