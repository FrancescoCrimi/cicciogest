using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CiccioGest.Application;
using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.Client.Wcf;

namespace CiccioGest.Presentation.Client
{
    public class MyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            IAppConf conf = container.Resolve<IAppConf>();
            switch (conf.DataAccess)
            {
                case Storage.WCF:
                    container.Register(
                          Component.For<IFatturaService>().ImplementedBy<FatturaService>().LifestyleTransient()
                          );
                    break;
                default:
                    //container.Install(FromAssembly.Named("Application.Impl"));
                    container.Install(new CiccioGest.Application.Impl.MyInstaller());
                    break;
            }
        }
    }
}
