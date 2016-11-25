using Ciccio1.Application;
using Ciccio1.Domain;
using Ciccio1.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciccio1.Utils
{
    class Backup
    {
        ICiccioService service;

        public Backup()
        {
            Container container = new Container();
            container.Install(new Ciccio1.Application.Impl.Installer());
            service = container.Resolve<ICiccioService>();
            BackupXml();
            ImportXml();
        }

        void BackupXml()
        {
            Fattura fatt = service.GetFatture().FirstOrDefault();
            //FileStream fsXs = new FileStream("FatturaXS.xml", FileMode.Create);
            FileStream fsDcs = new FileStream("FatturaDCS.xml", FileMode.Create);
            //XmlSerializer xs = new XmlSerializer(typeof(Fattura), "http://gesttest.it");
            System.Runtime.Serialization.DataContractSerializer dcs = new System.Runtime.Serialization.DataContractSerializer(typeof(Fattura));
            //xs.Serialize(fsXs, fatt);
            dcs.WriteObject(fsDcs, fatt);
            //fsXs.Close();
            fsDcs.Close();
        }

        void ImportXml()
        {
            //FileStream fsXs = new FileStream("FatturaXS.xml", FileMode.Open);
            FileStream fsDcs = new FileStream("FatturaDCS.xml", FileMode.Open);
            //XmlSerializer xs = new XmlSerializer(typeof(Fattura));
            System.Runtime.Serialization.DataContractSerializer dcs = new System.Runtime.Serialization.DataContractSerializer(typeof(Fattura));
            //Fattura impFattXs = (Fattura)xs.Deserialize(fsXs);
            var aaaa = dcs.ReadObject(fsDcs);
            Fattura impFattDcs = (Fattura)aaaa;
            //fsXs.Close();
            fsDcs.Close();
        }
    }
}
