using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CiccioGest.WebApi.Controllers;

namespace CiccioGest.WebApi
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Install(new CiccioGest.Application.Impl.Installer());
            container.Register(
                Component.For<FattureController>().LifestyleTransient(),
                Component.For<ProdottiController>().LifestyleTransient(),
                Component.For<CategorieController>().LifestyleTransient());
        }
    }
}