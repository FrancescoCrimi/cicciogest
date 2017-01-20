using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Ciccio1.WebApi
{
    /// <summary>
    /// 
    /// </summary>
    public class WindsorControllerActivator : IHttpControllerActivator
    {
        private IWindsorContainer windsorContainer = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="windsorContainer"></param>
        public WindsorControllerActivator(IWindsorContainer windsorContainer)
        {
            this.windsorContainer = windsorContainer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="controllerDescriptor"></param>
        /// <param name="controllerType"></param>
        /// <returns></returns>
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            return (IHttpController)windsorContainer.Resolve(controllerType);
        }
    }
}