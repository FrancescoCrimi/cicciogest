using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using CiccioGest.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CiccioGest.Interface.WcfService
{
    class SetLifeStyle : ISetLifeStyle
    {
        public ComponentRegistration<TService> Suca<TService>(ComponentRegistration<TService> cazzo) where TService : class
        {
            return cazzo.LifestylePerWcfOperation();
            //return cazzo.LifestyleTransient();
        }
    }
}