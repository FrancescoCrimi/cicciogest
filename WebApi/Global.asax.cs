﻿using Ciccio1.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Routing;

namespace Ciccio1.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Container container = new Container();
            container.Install(new Installer());

            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator),
                new WindsorControllerActivator(container.Windsor));

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
