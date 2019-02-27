using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CiccioGest.Application.Impl
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            IConf conf = container.Resolve<IConf>();

            switch (conf.DataAccess)
            {
                case Storage.NHibernate:
                    container.Install(new CiccioGest.Infrastructure.Persistence.Nhb.Installer());
                    break;
                //case Storage.EF:
                //    container.Install(new Ciccio1.Infrastructure.Persistence.EF.Installer());
                //    break;
                //case Storage.EFC:
                //    container.Install(new Ciccio1.Infrastructure.Persistence.EFC.Installer());
                //    break;
                case Storage.Db4o:
                    container.Install(new CiccioGest.Infrastructure.Persistence.Db4o.Installer());
                    break;
            }

            //switch (conf.UserInterface)
            //{
                //case UI.Form:
                    container.Register(
                        //Component.For<ICiccioService>().ImplementedBy<CiccioService>().LifestyleTransient(),
                        Component.For<IFatturaService>().ImplementedBy<FatturaService>().LifestyleTransient(),
                        Component.For<IMagazinoService>().ImplementedBy<MagazinoService>().LifestyleTransient(),
                        Component.For<IClientiFornitoriService>().ImplementedBy<ClientiFornitoriService>().LifestyleTransient());
                //    break;
                //case UI.WPF:
                //    container.Register(
                //        //Component.For<ICiccioService>().ImplementedBy<CiccioService>().LifestyleTransient(),
                //        Component.For<IFatturaService>().ImplementedBy<FatturaService>().LifestyleTransient(),
                //        Component.For<IMagazinoService>().ImplementedBy<MagazinoService>().LifestyleTransient(),
                //        Component.For<IClientiFornitoriService>().ImplementedBy<ClientiFornitoriService>().LifestyleTransient());
                //    break;
                //case UI.WCF:
                //    container.Register(
                //        //Component.For<ICiccioService>().ImplementedBy<CiccioService>().LifestylePerWcfSession());
                //        //Component.For<ICiccioService>().ImplementedBy<CiccioService>().LifestylePerWcfOperation());
                //        //Component.For<ICiccioService>().ImplementedBy<CiccioService>().LifestyleTransient());
                //        Component.For<IFatturaService>().ImplementedBy<FatturaService>().LifestyleTransient(),
                //        Component.For<IMagazinoService>().ImplementedBy<MagazinoService>().LifestyleTransient(),
                //        Component.For<IClientiFornitoriService>().ImplementedBy<ClientiFornitoriService>().LifestyleTransient());
                //    break;
                //case UI.REST:
                //    container.Register(
                //        //Component.For<ICiccioService>().ImplementedBy<CiccioService>().LifestylePerWebRequest()
                //        Component.For<IFatturaService>().ImplementedBy<FatturaService>().LifestylePerWebRequest(),
                //        Component.For<IMagazinoService>().ImplementedBy<MagazinoService>().LifestylePerWebRequest(),
                //        Component.For<IClientiFornitoriService>().ImplementedBy<ClientiFornitoriService>().LifestylePerWebRequest());
                //    break;
            //}
        }
    }
}
