using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Ciccio1.Infrastructure.Conf;
using Ciccio1.Infrastructure;
using Ciccio1.Domain;
using Infrastructure.Persistence.EFC.Repository;

namespace Ciccio1.Infrastructure.Persistence.EFC
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            IConf conf = container.Resolve<IConf>();
            switch (conf.UserInterface)
            {
                case UI.Form:
                    container.Register(Component.For<DataAccess, IDataAccess>().ImplementedBy<DataAccess>().LifestyleSingleton());
                    break;
                case UI.WPF:
                    container.Register(Component.For<DataAccess, IDataAccess>().ImplementedBy<DataAccess>().LifestyleSingleton());
                    break;
                case UI.WCF:
                    break;
                case UI.REST:
                    break;
            }
            container.Register(
                Component.For<IFatturaRepository>().ImplementedBy<FatturaRepository>().LifeStyle.Transient,
                Component.For<IProdottoRepository>().ImplementedBy<ProdottoRepository>().LifeStyle.Transient,
                Component.For<ICategoriaRepository>().ImplementedBy<CategoriaRepository>().LifeStyle.Transient
                );
        }
    }
}
