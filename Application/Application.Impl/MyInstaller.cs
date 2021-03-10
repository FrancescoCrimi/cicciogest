//using Castle.MicroKernel.Registration;
//using Castle.MicroKernel.SubSystems.Configuration;
//using Castle.Windsor;
using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
//using CiccioGest.Infrastructure.Persistence.LiteDB;
//using CiccioGest.Infrastructure.Persistence.Memory;
using CiccioGest.Infrastructure.Persistence.Nhb;
using Microsoft.Extensions.DependencyInjection;

namespace CiccioGest.Application.Impl
{
    //public class MyInstaller : IWindsorInstaller
    //{
    //    public void Install(IWindsorContainer container, IConfigurationStore store)
    //    {
    //        CiccioGestConf conf = container.Resolve<CiccioGestConf>();

    //        switch (conf.DataAccess)
    //        {
    //            case Storage.NHibernate:
    //                container.Install(new CiccioGest.Infrastructure.Persistence.Nhb.MyInstaller());
    //                break;
    //            //case Storage.EF:
    //            //    container.Install(new Ciccio1.Infrastructure.Persistence.EF.Installer());
    //            //    break;
    //            //case Storage.Db4o:
    //            //    container.Install(new CiccioGest.Infrastructure.Persistence.Db4o.Installer());
    //            //    break;
    //            case Storage.Memory:
    //                container.Install(new CiccioGest.Infrastructure.Persistence.Memory.MyInstaller());
    //                break;
    //            case Storage.LiteDb:
    //                container.Install(new CiccioGest.Infrastructure.Persistence.LiteDB.MyInstaller());
    //                break;
    //        }

    //        container.Register(
    //            //Component.For<ICiccioService>().ImplementedBy<CiccioService>().LifestyleTransient(),
    //            Component.For<IFatturaService>().ImplementedBy<FatturaService>().LifestyleTransient(),
    //            Component.For<IMagazinoService>().ImplementedBy<MagazinoService>().LifestyleTransient(),
    //            Component.For<IClientiFornitoriService>().ImplementedBy<ClientiFornitoriService>().LifestyleTransient(),
    //            Component.For<ISettingService>().ImplementedBy<SettingService>().LifestyleTransient());
    //    }
    //}

    public static class ConfigureExtensions
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection serviceCollection)
        {
            CiccioGestConf conf = serviceCollection.BuildServiceProvider().GetService<CiccioGestConf>();
            switch (conf.DataAccess)
            {
                case Storage.NHibernate:
                    serviceCollection.ConfigurePersistenceNhb();
                    break;
                //case Storage.EF:
                //    break;
                //case Storage.Db4o:
                //    break;
                //case Storage.LiteDb:
                //    serviceCollection.ConfigurePersistenceLiteDB();
                //    break;
                ////case Storage.WCF:
                ////    break;
                //case Storage.Memory:
                //    serviceCollection.ConfigurePersistenceMemory();
                //    break;
                default:
                    break;
            }
            serviceCollection
                .AddTransient<IFatturaService, FatturaService>()
                .AddTransient<IMagazinoService, MagazinoService>()
                .AddTransient<IClientiFornitoriService, ClientiFornitoriService>()
                .AddTransient<ISettingService, SettingService>();
            return serviceCollection;
        }
    }
}
