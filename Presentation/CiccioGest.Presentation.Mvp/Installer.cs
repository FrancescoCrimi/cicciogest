using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CiccioGest.Presentation.Mvp.Presenter;
using System;

namespace CiccioGest.Presentation.Mvp
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Install(new CiccioGest.Presentation.Client.MyInstaller());
            container.Register(
                Component.For<MainPresenter>().LifestyleTransient(),
                Component.For<ListaFatturePresenter>().LifestyleTransient(),
                Component.For<FatturaPresenter>().LifestyleTransient(),
                Component.For<ListaClientiPresenter>().LifestyleTransient(),
                Component.For<CategoriaPresenter>().LifestyleTransient(),
                Component.For<ArticoloPresenter>().LifestyleTransient(),
                Component.For<ListaFornitoriPresenter>().LifestyleTransient(),
                Component.For<ListaArticoliPresenter>().LifestyleTransient(),
                Component.For<SelectClientePresenter>().LifestyleTransient()
                );
        }
    }
}
