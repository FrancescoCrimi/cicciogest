using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using Castle.Facilities.WcfIntegration;
using CiccioGest.Infrastructure;
using CiccioGest.Application;

namespace CiccioGest.WcfServer
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program();
        }

        Program()
        {
            Container container = new Container(UI.WCF);
            container.Install(new CiccioGest.Application.Impl.Installer());
            DefaultServiceHostFactory shf = new CiccioServiceHostFactory();
            string baseAddresses = "http://localhost:8000/";

            ServiceHostBase fatturaSH = shf.CreateServiceHost(typeof(IFatturaService).AssemblyQualifiedName, new Uri[] { new Uri(baseAddresses + "FatturaService.svc") });
            ServiceHostBase prodottoSH = shf.CreateServiceHost(typeof(IProdottoService).AssemblyQualifiedName, new Uri[] { new Uri(baseAddresses + "ProdottoService.svc") });
            ServiceHostBase categoriaSH = shf.CreateServiceHost(typeof(ICategoriaService).AssemblyQualifiedName, new Uri[] { new Uri(baseAddresses + "CategoriaService.svc") });
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

        void PrintServiceInfo(ServiceHostBase host)
        {
            Console.WriteLine("{0} is running with these endpoints", host.Description.ServiceType);
            foreach (ServiceEndpoint se in host.Description.Endpoints)
                Console.WriteLine(se.Address);
        }
    }
}
