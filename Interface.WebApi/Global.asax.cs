using Castle.MicroKernel.Registration;
using CiccioGest.Infrastructure;
using CiccioGest.Interface.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Routing;

namespace CiccioGest.Interface.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Container container = new Container(UI.REST);
            container.Windsor.Install(new CiccioGest.Application.Impl.Installer());
            container.Windsor.Register(
                Component.For<FattureController>().LifestyleTransient(),
                Component.For<ProdottiController>().LifestyleTransient(),
                Component.For<CategorieController>().LifestyleTransient());

            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator),
                new WindsorControllerActivator(container.Windsor));

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
