﻿using Castle.Windsor;
using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CiccioGest.Presentation.AppUtils
{
    class Serialize
    {
        IFatturaService service;

        public Serialize()
        {
            IWindsorContainer container = Bootstrap.Windsor;
            container.Install(new CiccioGest.Application.Impl.Installer());
            service = container.Resolve<IFatturaService>();
            BackupXml();
            ImportXml();
        }

        void BackupXml()
        {
            //Fattura fatt = service.GetFatture().FirstOrDefault();
            Fattura fatt = service.GetFattura(1);
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