using System.Linq;
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
            var confmgr = new ConfigurationManager();
            var colconf = confmgr.GetAll();
            var mysql = colconf.First(c => c.Name == "mysql");
            //confmgr.SetCurrent(mysql);
            //confmgr.Save();
            IAppConf conf = confmgr.GetCurrent();
            windsor.Register(
                Component.For<IAppConf>().Instance(conf),
                Component.For<ISetLifeStyle>().ImplementedBy<SetLifeStyle>());
            windsor.Install(new CiccioGest.Application.Impl.MyInstaller());
            windsor.Register(Component.For<LoadSampleData>());
            var aaa = windsor.Resolve<LoadSampleData>();
            windsor.Release(aaa);
            windsor.Dispose();
        }
    }
}
