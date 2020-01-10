using Castle.Facilities.Logging;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.Services.Logging.NLogIntegration;
using Castle.Windsor;
using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Interface.Wcf.WebService.Conf;
using System;

namespace CiccioGest.Interface.Wcf.WebService
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            IWindsorContainer container = new WindsorContainer();
            container.AddFacility<LoggingFacility>(f => f.LogUsing<NLogFactory>().WithConfig("NLog.config"));
            container.AddFacility<WcfFacility>();
            //var confmgr = new ConfigurationManager();
            //confmgr.ReadConfiguration();
            //IAppConf conf = confmgr.GetCurrent();
            IAppConf conf = ConfMgr.ReadConfiguration();
            container.Register(
                Component.For<IAppConf>().Instance(conf),
                Component.For<ISetLifeStyle>().ImplementedBy<SetLifeStyle>());
            container.Install(new CiccioGest.Application.Impl.MyInstaller());
        }       
    }
}