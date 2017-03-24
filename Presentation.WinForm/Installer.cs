﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using CiccioGest.Presentation.WinForm.Views;
using CiccioGest.Infrastructure.Conf;
using Castle.Facilities.TypedFactory;
using Castle.Windsor.Installer;
using CiccioGest.Application;
using CiccioGest.Infrastructure;

namespace CiccioGest.Presentation.WinForm
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
                    container.Install(FromAssembly.Named("Presentation.ClientWcf"));
                    break;
                case Storage.REST:
                    break;
            }
            registerComponent(container);
        }

        void registerComponent(IWindsorContainer container)
        {
            container.Register(
                Component.For<ProdottoView>().LifestyleTransient(),
                Component.For<CategoriaView>().LifestyleTransient(),
                Component.For<SelectProdottoView>().LifeStyle.Transient,
                Component.For<FattureView>().LifestyleTransient(),
                Component.For<FatturaView>().LifestyleTransient()
                );
        }
    }
}
