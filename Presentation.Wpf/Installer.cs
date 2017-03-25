using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using CiccioGest.Application;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.Wpf.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;

namespace CiccioGest.Presentation.Wpf
{
    class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            IConf conf = container.Resolve<IConf>();
            switch (conf.DataAccess)
            {
                case Infrastructure.Storage.NHibernate:
                    container.Install(FromAssembly.Named("Application.Impl"));
                    break;
                case Infrastructure.Storage.Db4o:
                    container.Install(FromAssembly.Named("Application.Impl"));
                    break;
                case Infrastructure.Storage.WCF:
                    //container.Install(FromAssembly.Named("Presentation.ClientWcf"));
                    container.Register(
                          Component.For<IFatturaService>().AsWcfClient(
                              WcfEndpoint.BoundTo(new WSHttpBinding()).At(conf.CS + "/FatturaService.svc")),
                          Component.For<IProdottoService>().AsWcfClient(
                              WcfEndpoint.BoundTo(new WSHttpBinding()).At(conf.CS + "/ProdottoService.svc")),
                          Component.For<ICategoriaService>().AsWcfClient(
                              WcfEndpoint.BoundTo(new WSHttpBinding()).At(conf.CS + "/CategoriaService.svc")),
                          Component.For<IEndpointBehavior>().ImplementedBy<DomainListEndpointBehavior>());
                    break;
                case Infrastructure.Storage.REST:
                    break;
                default:
                    break;
            }
            //registerComponent(container);
            container.Register(
                Component.For<FattureViewModel>().LifestyleTransient(),
                Component.For<FatturaViewModel>().LifestyleTransient(),
                Component.For<ProdottiViewModel>().LifestyleTransient(),
                Component.For<CategorieViewModel>().LifestyleTransient(),
                Component.For<SelezionaProdottoViewModel>().LifestyleTransient());
        }

        //void registerComponent(IWindsorContainer container)
        //{
        //}
    }
}