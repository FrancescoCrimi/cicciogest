using Castle.Facilities.Logging;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.Services.Logging.NLogIntegration;
using Castle.Windsor;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
using System;

namespace CiccioGest.Interface.WcfService
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            IWindsorContainer container = new WindsorContainer();
            container.AddFacility<LoggingFacility>(f => f.LogUsing<NLogFactory>().WithConfig("NLog.config"));
            container.AddFacility<WcfFacility>();
            IConf conf = ConfMgr.ReadConfiguration();
            container.Register(
                Component.For<IConf>().Instance(conf),
                Component.For<ISetLifeStyle>().ImplementedBy<SetLifeStyle>());
            container.Install(new CiccioGest.Application.Installer());

            //AutoMapper.Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<Articolo, Articolo>();
            //    cfg.CreateMap<Categoria, Categoria>();
            //});
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}