//using Castle.MicroKernel.Registration;
//using Castle.MicroKernel.SubSystems.Configuration;
//using Castle.Windsor;
using CiccioGest.Application.Impl;
using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.Uwp.Client.Wcf;
using Microsoft.Extensions.DependencyInjection;

namespace CiccioGest.Presentation.Uwp.Client
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
    //                      Component.For<Application.IFatturaService>().ImplementedBy<FatturaService>().LifestyleTransient()
    //                      );
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
                case Storage.WCF:
                    serviceCollection.AddTransient<IFatturaService, FatturaService>();
                    //container.Register(
                    //      Component.For<Application.IFatturaService>().ImplementedBy<FatturaService>().LifestyleTransient()
                    //      );
                    break;
                default:
                    //container.Install(FromAssembly.Named("Application.Impl"));
                    //container.Install(new CiccioGest.Application.Impl.MyInstaller());
                    serviceCollection.ConfigureApplication();
                    break;
            }
            return serviceCollection;
        }
    }
}
