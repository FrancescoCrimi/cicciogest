using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
//using CiccioGest.Infrastructure.Persistence.LiteDB;
//using CiccioGest.Infrastructure.Persistence.Memory;
using CiccioGest.Infrastructure.Persistence.Nhb;
using Microsoft.Extensions.DependencyInjection;

namespace CiccioGest.Application.Impl
{
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
                //case Storage.LiteDb:
                //    serviceCollection.ConfigurePersistenceLiteDB();
                //    break;
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
