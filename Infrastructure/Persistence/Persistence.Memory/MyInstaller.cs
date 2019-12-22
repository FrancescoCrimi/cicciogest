using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure.Persistence.Memory.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Memory
{
    public class MyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                //Component.For<ISessionFactory>().UsingFactoryMethod(k => k.Resolve<DataAccess>().SessionFactory()),
                Component.For<IFatturaRepository>().ImplementedBy<FatturaRepository>().LifeStyle.Singleton,
                Component.For<IArticoloRepository>().ImplementedBy<ArticoloRepository>().LifeStyle.Singleton,
                Component.For<ICategoriaRepository>().ImplementedBy<CategoriaRepository>().LifeStyle.Singleton,
                Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>().LifeStyle.Singleton);
            FakeSampleData();
        }

        private void FakeSampleData()
        {
            CreaCategorie();
            CreaArticoli();
            CreaFatture();
        }

        private async void CreaCategorie()
        {
            //Task.Run(async () => {
            CategoriaRepository repository = new CategoriaRepository();
            for (int c = 1; c < 11; c++)
            {
                Categoria cat = new Categoria(c, "Categoria " + c.ToString());
                await repository.Save(cat);
            }
            //});
        }

        private async void CreaArticoli()
        {
            ArticoloRepository artRepo = new ArticoloRepository();
            CategoriaRepository catRepo = new CategoriaRepository();
            for (int p = 1; p < 11; p++)
            {
                Articolo prod = new Articolo(p, "Articolo " + p.ToString(), 10 + p);
                prod.Categoria = await catRepo.GetById(p);
                await artRepo.Save(prod);
            }
        }

        private async void CreaFatture()
        {
            var fatRepo = new FatturaRepository();
            var artRepo = new ArticoloRepository();
            for (int i = 1; i < 6; i++)
            {
                Fattura fatt = new Fattura(i, "Fattura " + i.ToString());
                for (int o = 1; o < (i + 1); o++)
                {
                    Dettaglio dett = new Dettaglio(await artRepo.GetById(o), o);
                    fatt.AddDettaglio(dett);
                }
                await fatRepo.Save(fatt);
            }
        }
    }
}
