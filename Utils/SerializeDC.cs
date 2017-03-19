using Castle.MicroKernel.Lifestyle;
using CiccioGest.Application;
using CiccioGest.Domain;
using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Wcf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Utils
{
    class SerializeDC
    {
        IFatturaService service;
        public SerializeDC()
        {
            Container container = new Container(UI.Form);
            container.Install(new CiccioGest.Application.Impl.Installer());
            container.Windsor.BeginScope();
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
            DataContractSerializer dcs = new DataContractSerializer(typeof(Prodotto));
            //DataContractSerializer dcs = new DataContractSerializer(typeof(Fattura), new Type[] { typeof(DomainPersistentBag<Dettaglio>) });
            //DataContractSerializer dcs = new DataContractSerializer(typeof(Prodotto), new Type[0], Int16.MaxValue, false, false, null, new MyDataContractResolver());
            dcs.WriteObject(fs, prod);
            fs.Close();
        }

        void deserialize()
        {
            FileStream fs = new FileStream("ProdottoDCS.xml", FileMode.Open);
            //DataContractSerializer dcs = new DataContractSerializer(typeof(Fattura));
            //DataContractSerializer dcs = new DataContractSerializer(typeof(Fattura), new Type[] { typeof(DomainList<Dettaglio>) });
            DataContractSerializer dcs = new DataContractSerializer(typeof(Prodotto), new Type[0], Int16.MaxValue, true, false, new DomainListDataContractSurrogate(), new MyDataContractResolver());
            var aaaa = dcs.ReadObject(fs);
            Prodotto impFatt = (Prodotto)aaaa;
            fs.Close();
        }
    }
}
