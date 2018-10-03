using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;
using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.AppUtils
{
    class SerializeDC
    {
        IFatturaService service;
        public SerializeDC()
        {
            IWindsorContainer container =  Bootstrap.Windsor;
            container.Install(new CiccioGest.Application.Impl.Installer());
            container.BeginScope();
            service = container.Resolve<IFatturaService>();
            serialize();
            //deserialize();
        }

        void serialize()
        {
            //Fattura fatt = service.GetFattura(1);
            Prodotto prod = service.GetProdotto(1);
            var suca = service.GetFatture();
            FileStream fs = new FileStream("ProdottoDCS.xml", FileMode.Create);
            //DataContractSerializer dcs = new DataContractSerializer(typeof(Prodotto));
            //DataContractSerializer dcs = new DataContractSerializer(typeof(Fattura), new Type[] { typeof(DomainPersistentBag<Dettaglio>) });
            DataContractSerializer dcs = new DataContractSerializer(typeof(Prodotto), new Type[0], Int16.MaxValue, false, false, new MyDataContractSurrogate());
            dcs.WriteObject(fs, prod);
            fs.Close();
        }

        void deserialize()
        {
            FileStream fs = new FileStream("ProdottoDCS.xml", FileMode.Open);
            DataContractSerializer dcs = new DataContractSerializer(typeof(Fattura));
            //DataContractSerializer dcs = new DataContractSerializer(typeof(Fattura), new Type[] { typeof(DomainList<Dettaglio>) });
            //DataContractSerializer dcs = new DataContractSerializer(typeof(Prodotto), new Type[0], Int16.MaxValue, true, false, new DomainListDataContractSurrogate(), new MyDataContractResolver());
            var aaaa = dcs.ReadObject(fs);
            Prodotto impFatt = (Prodotto)aaaa;
            fs.Close();
        }
    }
}
