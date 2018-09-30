//using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using CiccioGest.Application;
using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.AppForm.Views;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.ServiceModel;
//using System.ServiceModel.Description;
using System.Text;

namespace CiccioGest.Presentation.AppForm
{
    class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //IConf conf = container.Resolve<IConf>();
            //switch (conf.DataAccess)
            //{
            //    case Storage.NHibernate:
            //        container.Install(FromAssembly.Named("Application.Impl"));
            //        break;
            //    //case Storage.EFC:
            //    //    container.Install(FromAssembly.Named("Application.Impl"));
            //    //    break;
            //    case Storage.EF:
            //        container.Install(FromAssembly.Named("Application.Impl"));
            //        break;
            //    case Storage.Db4o:
            //        container.Install(FromAssembly.Named("Application.Impl"));
            //        break;
            //    case Storage.WCF:
            //        //container.Install(FromAssembly.Named("Presentation.ClientWcf"));
            //        container.Register(
            //              Component.For<IFatturaService>().AsWcfClient(
            //                  WcfEndpoint.BoundTo(new WSHttpBinding()).At(conf.CS + "/FatturaService.svc")),
            //              Component.For<IProdottoService>().AsWcfClient(
            //                  WcfEndpoint.BoundTo(new WSHttpBinding()).At(conf.CS + "/ProdottoService.svc")),
            //              Component.For<ICategoriaService>().AsWcfClient(
            //                  WcfEndpoint.BoundTo(new WSHttpBinding()).At(conf.CS + "/CategoriaService.svc")),
            //              Component.For<IEndpointBehavior>().ImplementedBy<DomainListEndpointBehavior>());
            //        break;
            //    case Storage.REST:
            //        break;
            //}
            //registerComponent(container);
            container.Install(new CiccioGest.Presentation.Client.Installer());
            container.Register(
                Component.For<ProdottoView>().LifestyleTransient(),
                Component.For<CategoriaView>().LifestyleTransient(),
                Component.For<SelectProdottoView>().LifeStyle.Transient,
                Component.For<FattureView>().LifestyleTransient(),
                Component.For<FatturaView>().LifestyleTransient());
        }

        //void registerComponent(IWindsorContainer container)
        //{
        //}
    }
}
