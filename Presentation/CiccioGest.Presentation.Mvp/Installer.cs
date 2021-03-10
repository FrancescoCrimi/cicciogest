//using Castle.MicroKernel.Registration;
//using Castle.MicroKernel.SubSystems.Configuration;
//using Castle.Windsor;
using CiccioGest.Presentation.Client;
using CiccioGest.Presentation.Mvp.Presenter;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace CiccioGest.Presentation.Mvp
{
    //public class Installer : IWindsorInstaller
    //{
    //    public void Install(IWindsorContainer container, IConfigurationStore store)
    //    {
    //        container.Install(new CiccioGest.Presentation.Client.MyInstaller());
    //        container.Register(
    //            Component.For<MainPresenter>().LifestyleTransient(),
    //            Component.For<ListaFatturePresenter>().LifestyleTransient(),
    //            Component.For<FatturaPresenter>().LifestyleTransient(),
    //            Component.For<ListaClientiPresenter>().LifestyleTransient(),
    //            Component.For<CategoriaPresenter>().LifestyleTransient(),
    //            Component.For<ArticoloPresenter>().LifestyleTransient(),
    //            Component.For<ListaFornitoriPresenter>().LifestyleTransient(),
    //            Component.For<ListaArticoliPresenter>().LifestyleTransient(),
    //            Component.For<SelectClientePresenter>().LifestyleTransient()
    //            );
    //    }
    //}

    public static class ConfigureExtensions
    {
        public static IServiceCollection ConfigureMvp(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .ConfigureClient()
                .AddTransient<MainPresenter>()
                .AddTransient<ListaFatturePresenter>()
                .AddTransient<FatturaPresenter>()
                .AddTransient<ListaClientiPresenter>()
                .AddTransient<CategoriaPresenter>()
                .AddTransient<ArticoloPresenter>()
                .AddTransient<ListaFornitoriPresenter>()
                .AddTransient<ListaArticoliPresenter>()
                .AddTransient<SelectClientePresenter>();
            return serviceCollection;
        }
    }
}
