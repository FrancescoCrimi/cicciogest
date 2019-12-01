using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CiccioGest.Application;
using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace CiccioGest.Presentation.Client
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            IConf conf = container.Resolve<IConf>();
            switch (conf.DataAccess)
            {
                case Storage.WCF:
                    container.Register(
                          Component.For<IFatturaService>().AsWcfClient(
                              WcfEndpoint.BoundTo(new WSHttpBinding()).At(conf.CS + "/FatturaService.svc")),
                          Component.For<IMagazinoService>().AsWcfClient(
                              WcfEndpoint.BoundTo(new WSHttpBinding()).At(conf.CS + "/MagazinoService.svc")),
                          //Component.For<IClientiFornitoriService>().AsWcfClient(
                          //    WcfEndpoint.BoundTo(new WSHttpBinding()).At(conf.CS + "/CategoriaService.svc")),
                          Component.For<IEndpointBehavior>().ImplementedBy<DomainListEndpointBehavior>());
                    break;
                default:
                    //container.Install(FromAssembly.Named("Application.Impl"));
                    container.Install(new CiccioGest.Application.Impl.Installer());
                    break;
            }
        }
    }
}
