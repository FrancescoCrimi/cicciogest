using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using CiccioGest.Infrastructure;

namespace CiccioGest.Interface.Wcf.WebService
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