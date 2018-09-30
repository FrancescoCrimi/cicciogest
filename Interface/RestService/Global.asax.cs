using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CiccioGest.Infrastructure;
using CiccioGest.Interface.RestService.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Routing;

namespace CiccioGest.Interface.RestService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            IWindsorContainer windsor = Bootstrap.Windsor;
            windsor.Install(new CiccioGest.Application.Impl.Installer());
            windsor.Register(
                Component.For<FattureController>().LifestyleTransient(),
                Component.For<ProdottiController>().LifestyleTransient());

            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator),
                new WindsorControllerActivator(windsor));

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
