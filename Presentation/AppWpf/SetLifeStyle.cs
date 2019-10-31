﻿using Castle.MicroKernel.Registration;

using CiccioGest.Infrastructure;

namespace CiccioGest.Presentation.AppWpf
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