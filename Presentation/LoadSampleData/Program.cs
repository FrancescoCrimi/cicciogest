using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.Services.Logging.NLogIntegration;
using Castle.Windsor;
using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;

namespace CiccioGest.Presentation.LoadSampleData
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program();
        }

        private Program()
        {
            IWindsorContainer windsor = new WindsorContainer();
            windsor.AddFacility<LoggingFacility>(f => f.LogUsing<NLogFactory>().WithConfig("NLog.config"));
            IConf conf = ConfMgr.ReadConfiguration();
            windsor.Register(
                Component.For<IConf>().Instance(conf),
                Component.For<ISetLifeStyle>().ImplementedBy<SetLifeStyle>());
            windsor.Install(new CiccioGest.Application.Impl.Installer());
            windsor.Register(Component.For<LoadSampleData>());
            windsor.Resolve<LoadSampleData>();
            windsor.Dispose();
        }
    }
}
