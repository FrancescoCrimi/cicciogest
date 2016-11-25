using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using Castle.Facilities.WcfIntegration;
using Ciccio1.Infrastructure;
using Ciccio1.Application;
using Ciccio1.Infrastructure.Wcf;

namespace Ciccio1.WcfServer
{
    class Program
    {
        static void Main(string[] args)
        {
            new Server();
        }
    }

    class Server
    {
        internal Server()
        {
            ServiceHostBase CiccioServiceHost = start();
            try
            {
                CiccioServiceHost.Open();
                PrintServiceInfo(CiccioServiceHost);
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.ReadLine();
                CiccioServiceHost.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred: {0}", ex.Message);
                CiccioServiceHost.Abort();
                Console.ReadLine();
            }
        }

        ServiceHostBase start()
        {
            try
            {
                Container container = new Container();
                container.Install(new Ciccio1.Application.Impl.Installer());

                Uri baseAddress = new Uri("http://localhost:8000/");
                DefaultServiceHostFactory shf = new DefaultServiceHostFactory();
                ServiceHostBase sh =
                    shf.CreateServiceHost(typeof(ICiccioService).AssemblyQualifiedName, new Uri[1] { baseAddress });

                sh.AddServiceEndpoint(typeof(ICiccioService).FullName, new WSHttpBinding(), "CiccioService.svc");
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                sh.Description.Behaviors.Add(smb);

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
                return sh;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void PrintServiceInfo(ServiceHostBase host)
        {
            Console.WriteLine("{0} is running with these endpoints", host.Description.ServiceType);
            foreach (ServiceEndpoint se in host.Description.Endpoints)
                Console.WriteLine(se.Address);
        }
    }
}
