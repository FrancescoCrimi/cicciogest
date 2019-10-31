using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using CiccioGest.Infrastructure;

namespace CiccioGest.Interface.AppWcf
{
    class SetLifeStyle : ISetLifeStyle
    {
        public ComponentRegistration<TService> Suca<TService>(ComponentRegistration<TService> compReg) where TService : class
        {
            return compReg.LifestylePerWcfOperation();
            //return compReg.LifestyleTransient();
        }
    }
}
