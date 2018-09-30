using Castle.Facilities.WcfIntegration;
using Castle.Windsor;
using CiccioGest.Application;
using CiccioGest.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Interface.AppWcf
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program();
        }
        Program()
        {
            IWindsorContainer container = Bootstrap.Windsor;
            container.Install(new CiccioGest.Application.Impl.Installer());
            DefaultServiceHostFactory factory = new CiccioServiceHostFactory();
            string baseAddresses = "http://localhost:8000/";

            ServiceHostBase fatturaServiceHost = factory.CreateServiceHost(
                typeof(IFatturaService).AssemblyQualifiedName,
                new Uri[] { new Uri(baseAddresses + "FatturaService.svc") });

            ServiceHostBase prodottoServiceHost = factory.CreateServiceHost(
                typeof(IMagazinoService).AssemblyQualifiedName,
                new Uri[] { new Uri(baseAddresses + "ProdottoService.svc") });

            //ServiceHostBase categoriaServiceHost = factory.CreateServiceHost(
            //    typeof(IClientiFornitoriService).AssemblyQualifiedName,
            //    new Uri[] { new Uri(baseAddresses + "CategoriaService.svc") });

            try
            {
                fatturaServiceHost.Open();
                PrintServiceInfo(fatturaServiceHost);
                prodottoServiceHost.Open();
                PrintServiceInfo(prodottoServiceHost);
                //categoriaServiceHost.Open();
                //PrintServiceInfo(categoriaServiceHost);
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.ReadLine();
                fatturaServiceHost.Close();
                prodottoServiceHost.Close();
                //categoriaServiceHost.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred: {0}", ex.Message);
                fatturaServiceHost.Abort();
                prodottoServiceHost.Abort();
                //categoriaServiceHost.Abort();
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
