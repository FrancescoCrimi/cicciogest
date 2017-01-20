using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Ciccio1.Presentation.WinForm.Presenters;
using Ciccio1.Presentation.WinForm.Views;
using Ciccio1.Infrastructure.Conf;
using Castle.Facilities.TypedFactory;
using Castle.Windsor.Installer;
using Ciccio1.Application;
using Ciccio1.Infrastructure;

namespace Ciccio1.Presentation.WinForm
{
    class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            IConf conf = container.Resolve<IConf>();
            switch (conf.DataAccess)
            {
                case Storage.NHibernate:
                    container.Install(FromAssembly.Named("Application.Impl"));
                    break;
                case Storage.EFC:
                    container.Install(FromAssembly.Named("Application.Impl"));
                    break;
                case Storage.EF:
                    container.Install(FromAssembly.Named("Application.Impl"));
                    break;
                case Storage.Db4o:
                    container.Install(FromAssembly.Named("Application.Impl"));
                    break;
                case Storage.WCF:
                    container.Install(FromAssembly.Named("WcfClient"));
                    break;
                case Storage.REST:
                    break;
            }
            registerComponent(container);
        }

        void registerComponent(IWindsorContainer container)
        {
            container.Register(
                Component.For<FatturaView>().LifestyleSingleton(),
                Component.For<ProdottoView>().LifestyleTransient(),
                Component.For<CategoriaView>().LifestyleTransient(),

                Component.For<SelectProdottoView>().LifeStyle.Transient,
                Component.For<SelectProdottoPresenter>().LifeStyle.Transient,
                Component.For<Func<ICiccioService, SelectProdottoPresenter>>().AsFactory(),

                Component.For<FattureForm>().LifestyleSingleton(),
                Component.For<DettagliForm>().LifestyleTransient()
                );
        }
    }
}
