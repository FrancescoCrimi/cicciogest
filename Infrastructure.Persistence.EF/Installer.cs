using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Ciccio1.Infrastructure.Conf;
using Castle.Facilities.WcfIntegration;

namespace Ciccio1.Infrastructure.Persistence.EF
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            IConf conf = container.Resolve<IConf>();
            switch (conf.UserInterface)
            {
                case UI.Form:
                    container.Register(
                        Component.For<DataAccess, IDataAccess>().ImplementedBy<DataAccess>().LifestyleSingleton());
                    break;
                case UI.WPF:
                    container.Register(
                        Component.For<DataAccess, IDataAccess>().ImplementedBy<DataAccess>().LifestyleSingleton());
                    break;
                case UI.WCF:
                    container.Register(
                        Component.For<DataAccess, IDataAccess>().ImplementedBy<DataAccess>().LifestylePerWcfSession());
                    break;
                case UI.REST:
                    container.Register(
                        Component.For<DataAccess, IDataAccess>().ImplementedBy<DataAccess>().LifeStyle.PerWebRequest);
                    break;
                default:
                    break;
            }
        }
    }
}
