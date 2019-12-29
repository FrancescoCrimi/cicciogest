﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.Uwp.Client.Wcf;

namespace CiccioGest.Presentation.Uwp.Client
{
    public class MyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            IConf conf = container.Resolve<IConf>();
            switch (conf.DataAccess)
            {
                case Storage.WCF:
                    container.Register(
                          Component.For<Application.IFatturaService>().ImplementedBy<FatturaService>().LifestyleTransient()
                          );
                    break;
                default:
                    //container.Install(FromAssembly.Named("Application.Impl"));
                    container.Install(new CiccioGest.Application.Impl.Installer());
                    break;
            }
        }
    }
}