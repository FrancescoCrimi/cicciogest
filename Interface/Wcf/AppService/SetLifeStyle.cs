using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using CiccioGest.Infrastructure;

namespace CiccioGest.Interface.Wcf.AppService
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
