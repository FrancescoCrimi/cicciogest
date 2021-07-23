using CiccioGest.Application;
using CiccioGest.Application.Impl;
using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.Client.Wcf;
using Microsoft.Extensions.DependencyInjection;

namespace CiccioGest.Presentation.Client
{
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
