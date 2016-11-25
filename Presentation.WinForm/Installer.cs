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

namespace Ciccio1.Presentation.WinForm
{
    class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            IConf conf = container.Resolve<IConf>();
            switch (conf.DataAccess)
            {
                case Infrastructure.Storage.NHibernate:
                    container.Install(FromAssembly.Named("Application.Impl"));
                    break;
                case Infrastructure.Storage.Db4o:
                    container.Install(FromAssembly.Named("Application.Impl"));
                    break;
                case Infrastructure.Storage.WCF:
                    container.Install(FromAssembly.Named("WcfClient"));
                    break;
                case Infrastructure.Storage.REST:
                    break;
                default:
                    break;
            }
            registerComponent(container);
        }

        void registerComponent(IWindsorContainer container)
        {
            container.Register(
                Component.For<FatturaPresenter>().LifestyleSingleton(),
                Component.For<FatturaView>().LifestyleSingleton(),

                Component.For<ProdottoPresenter>().LifestyleTransient(),
                Component.For<ProdottoView>().LifestyleTransient(),

                Component.For<CategoriaPresenter>().LifestyleTransient(),
                Component.For<CategoriaView>().LifestyleTransient(),

                Component.For<SelectProdottoView>().LifeStyle.Transient,
                Component.For<SelectProdottoPresenter>().LifeStyle.Transient,
                Component.For<Func<ICiccioService, SelectProdottoPresenter>>().AsFactory()

                //Component.For<PresenterLocator>().LifestyleSingleton()
                );
        }
    }
}
