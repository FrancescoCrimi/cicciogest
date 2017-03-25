using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace CiccioGest.Interface.WebApi
{
    public class WindsorControllerActivator : IHttpControllerActivator
    {
        private IWindsorContainer windsorContainer = null;

        public WindsorControllerActivator(IWindsorContainer windsorContainer)
        {
            this.windsorContainer = windsorContainer;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            return (IHttpController)windsorContainer.Resolve(controllerType);
        }
    }
}