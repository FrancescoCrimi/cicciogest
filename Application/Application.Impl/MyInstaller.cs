using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;

namespace CiccioGest.Application.Impl
{
    public class MyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            IAppConf conf = container.Resolve<IAppConf>();

            switch (conf.DataAccess)
            {
                case Storage.NHibernate:
                    container.Install(new CiccioGest.Infrastructure.Persistence.Nhb.MyInstaller());
                    break;
                //case Storage.EF:
                //    container.Install(new Ciccio1.Infrastructure.Persistence.EF.Installer());
                //    break;
                //case Storage.Db4o:
                //    container.Install(new CiccioGest.Infrastructure.Persistence.Db4o.Installer());
                //    break;
                case Storage.Memory:
                    container.Install(new CiccioGest.Infrastructure.Persistence.Memory.MyInstaller());
                    break;
                case Storage.LiteDb:
                    container.Install(new CiccioGest.Infrastructure.Persistence.LiteDB.MyInstaller());
                    break;
            }

            //switch (conf.UserInterface)
            //{
                //case UI.Form:
                    container.Register(
                        //Component.For<ICiccioService>().ImplementedBy<CiccioService>().LifestyleTransient(),
                        Component.For<IFatturaService>().ImplementedBy<FatturaService>().LifestyleTransient(),
                        Component.For<IMagazinoService>().ImplementedBy<MagazinoService>().LifestyleTransient(),
                        Component.For<IClientiFornitoriService>().ImplementedBy<ClientiFornitoriService>().LifestyleTransient(),
                        Component.For<ISettingService>().ImplementedBy<SettingService>().LifestyleTransient());
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
