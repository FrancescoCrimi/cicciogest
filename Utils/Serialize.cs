using CiccioGest.Application;
using CiccioGest.Domain;
using CiccioGest.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CiccioGest.Utils
{
    class Serialize
    {
        IFatturaService service;

        public Serialize()
        {
            Container container = new Container(UI.Form);
            container.Install(new CiccioGest.Application.Impl.Installer());
            service = container.Resolve<IFatturaService>();
            BackupXml();
            ImportXml();
        }

        void BackupXml()
        {
            Fattura fatt = service.GetFatture().FirstOrDefault();
            FileStream fsXs = new FileStream("FatturaXS.xml", FileMode.Create);
            XmlSerializer xs = new XmlSerializer(typeof(Fattura), "http://gesttest.it");
            xs.Serialize(fsXs, fatt);
            fsXs.Close();
        }

        void ImportXml()
        {
            FileStream fsXs = new FileStream("FatturaXS.xml", FileMode.Open);
            XmlSerializer xs = new XmlSerializer(typeof(Fattura));
            Fattura impFattXs = (Fattura)xs.Deserialize(fsXs);
            fsXs.Close();
        }
    }
}
