using Castle.MicroKernel.Lifestyle;
using Ciccio1.Application;
using Ciccio1.Domain;
using Ciccio1.Infrastructure;
using Ciccio1.Infrastructure.Wcf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ciccio1.Utils
{
    class SerializeDC
    {
        IFatturaService service;
        public SerializeDC()
        {
            Container container = new Container(UI.Form);
            container.Install(new Ciccio1.Application.Impl.Installer());
            container.Windsor.BeginScope();
            service = container.Resolve<IFatturaService>();
            serialize();
            deserialize();
        }

        void serialize()
        {
            Fattura fatt = service.GetFattura(1);
            FileStream fsDcs = new FileStream("FatturaDCS.xml", FileMode.Create);
            //DataContractSerializer dcs = new DataContractSerializer(typeof(Fattura), new Type[] { typeof(DomainPersistentBag<Dettaglio>) });
            DataContractSerializer dcs = new DataContractSerializer(typeof(Fattura));
            dcs.WriteObject(fsDcs, fatt);
            fsDcs.Close();
        }

        void deserialize()
        {
            FileStream fsDcs = new FileStream("FatturaDCS.xml", FileMode.Open);
            //DataContractSerializer dcs = new DataContractSerializer(typeof(Fattura));
            //DataContractSerializer dcs = new DataContractSerializer(typeof(Fattura), new Type[] { typeof(DomainList<Dettaglio>) });
            DataContractSerializer dcs = new DataContractSerializer(typeof(Fattura), new Type[0], Int16.MaxValue, true, false, new DomainListDataContractSurrogate());
            var aaaa = dcs.ReadObject(fsDcs);
            Fattura impFattDcs = (Fattura)aaaa;
            fsDcs.Close();
        }
    }
}
