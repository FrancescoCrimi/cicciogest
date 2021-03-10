//using Castle.MicroKernel.Registration;
//using Castle.MicroKernel.SubSystems.Configuration;
//using Castle.Windsor;
using CiccioGest.Application;
using CiccioGest.Application.Impl;
using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.Client.Wcf;
using Microsoft.Extensions.DependencyInjection;

namespace CiccioGest.Presentation.Client
{
    //public class MyInstaller : IWindsorInstaller
    //{
    //    public void Install(IWindsorContainer container, IConfigurationStore store)
    //    {
    //        CiccioGestConf conf = container.Resolve<CiccioGestConf>();
    //        switch (conf.DataAccess)
    //        {
    //            case Storage.WCF:
    //                container.Register(
    //                      Component.For<IFatturaService>().ImplementedBy<FatturaService>().LifestyleTransient());
    //                break;
    //            default:
    //                //container.Install(FromAssembly.Named("Application.Impl"));
    //                container.Install(new CiccioGest.Application.Impl.MyInstaller());
    //                break;
    //        }
    //    }
    //}

    public static class ConfigureExtensions
    {
        public static IServiceCollection ConfigureClient(this IServiceCollection serviceCollection)
        {
            CiccioGestConf conf = serviceCollection.BuildServiceProvider().GetService<CiccioGestConf>();
            switch (conf.DataAccess)
            {
                //case Storage.NHibernate:
                //    break;
                //case Storage.EF:
                //    break;
                //case Storage.Db4o:
                //    break;
                //case Storage.LiteDb:
                //    break;
                case Storage.WCF:
                    serviceCollection.AddTransient<IFatturaService, FatturaService>();
                    break;
                //case Storage.Memory:
                //    break;
                default:
                    serviceCollection.ConfigureApplication();
                    break;
            }
            return serviceCollection;
        }
    }
}
