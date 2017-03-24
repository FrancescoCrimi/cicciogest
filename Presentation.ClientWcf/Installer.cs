using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CiccioGest.Application;
using CiccioGest.Infrastructure.Conf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.ClientWcf
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            IConf conf = container.Resolve<IConf>();
            container.Register(
                  Component.For<IFatturaService>().AsWcfClient(
                      WcfEndpoint.BoundTo(new WSHttpBinding()).At(conf.CS + "/FatturaService.svc")),
                  Component.For<IProdottoService>().AsWcfClient(
                      WcfEndpoint.BoundTo(new WSHttpBinding()).At(conf.CS + "/ProdottoService.svc")),
                  Component.For<ICategoriaService>().AsWcfClient(
                      WcfEndpoint.BoundTo(new WSHttpBinding()).At(conf.CS + "/CategoriaService.svc")),            
                  Component.For<IEndpointBehavior>().ImplementedBy<DomainListEndpointBehavior>());
        }
    }
}
