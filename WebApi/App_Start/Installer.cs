using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Ciccio1.WebApi.Controllers;

namespace Ciccio1.WebApi
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Install(new Ciccio1.Application.Impl.Installer());
            container.Register(
                //Component.For<FattureController>().LifestyleTransient(),
                //Component.For<ProdottiController>().LifestyleTransient(),
                //Component.For<CategorieController>().LifestyleTransient()
                Component.For<CiccioServiceController>().LifestyleTransient()
                );
        }
    }
}