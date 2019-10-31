using Castle.MicroKernel.Registration;

namespace CiccioGest.Infrastructure
{
    public interface ISetLifeStyle
    {
        ComponentRegistration<TService> Suca<TService>(ComponentRegistration<TService> cazzo) where TService : class;
    }
}
