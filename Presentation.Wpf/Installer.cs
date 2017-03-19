using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using CiccioGest.Presentation.Wpf.ViewModel;
using CiccioGest.Infrastructure.Conf;
using Castle.Windsor.Installer;

namespace CiccioGest.Presentation.Wpf
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
                Component.For<FattureViewModel>().LifestyleTransient(),
                Component.For<FatturaViewModel>().LifestyleTransient(),
                Component.For<ProdottiViewModel>().LifestyleTransient(),
                Component.For<CategorieViewModel>().LifestyleTransient(),
                Component.For<SelezionaProdottoViewModel>().LifestyleTransient()
                );
        }
    }
}