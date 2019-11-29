using Castle.MicroKernel.Registration;
using CiccioGest.Infrastructure;

namespace CiccioGest.Presentation.AppUwp2
{
    class SetLifeStyle : ISetLifeStyle
    {
        public ComponentRegistration<TService> Suca<TService>(ComponentRegistration<TService> compReg) where TService : class
        {
            return compReg.LifestyleBoundTo<ICazzo>();
            //return compReg.LifestyleTransient();
        }
    }
}
