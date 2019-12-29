using Castle.Facilities.Logging;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.Services.Logging.NLogIntegration;
using Castle.Windsor;
using CiccioGest.Application;
using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace CiccioGest.Interface.Wcf.AppService
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program();
        }

        Program()
        {
            IWindsorContainer container = new WindsorContainer();
            container.AddFacility<LoggingFacility>(f => f.LogUsing<NLogFactory>().WithConfig("NLog.config"));
            container.AddFacility<WcfFacility>();
            IConf conf = ConfMgr.ReadConfiguration();
            container.Register(
                Component.For<IConf>().Instance(conf),
                Component.For<ISetLifeStyle>().ImplementedBy<SetLifeStyle>());
            container.Install(new CiccioGest.Application.Impl.MyInstaller());

            var dummy = container.Resolve<IUnitOfWorkFactory>();

            DefaultServiceHostFactory factory = new CiccioServiceHostFactory();
            string baseAddresses = "http://localhost:8000/";

            ServiceHostBase fatturaServiceHost = factory.CreateServiceHost(
                typeof(IFatturaService).AssemblyQualifiedName,
                new Uri[] { new Uri(baseAddresses + "fatturaservice.svc") });

            ServiceHostBase magazinoServiceHost = factory.CreateServiceHost(
                typeof(IMagazinoService).AssemblyQualifiedName,
                new Uri[] { new Uri(baseAddresses + "magazinoservice.svc") });

            //ServiceHostBase clientiFornitoriServiceHost = factory.CreateServiceHost(
            //    typeof(IClientiFornitoriService).AssemblyQualifiedName,
            //    new Uri[] { new Uri(baseAddresses + "ClientiFornitoriService.svc") });

            try
            {
                fatturaServiceHost.Open();
                PrintServiceInfo(fatturaServiceHost);

                magazinoServiceHost.Open();
                PrintServiceInfo(magazinoServiceHost);

                //clientiFornitoriServiceHost.Open();
                //PrintServiceInfo(clientiFornitoriServiceHost);

                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.ReadLine();

                fatturaServiceHost.Close();
                magazinoServiceHost.Close();
                //clientiFornitoriServiceHost.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred: {0}", ex.Message);
                fatturaServiceHost.Abort();
                magazinoServiceHost.Abort();
                //clientiFornitoriServiceHost.Abort();
                Console.ReadLine();
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
