using Castle.Facilities.WcfIntegration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Interface.Wcf.AppService
{
    public class CiccioServiceHostFactory : DefaultServiceHostFactory
    {
        private readonly MyDataContractSurrogate dcs;

        public CiccioServiceHostFactory()
        {
            dcs = new MyDataContractSurrogate();
        }

        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            ServiceHostBase shb = base.CreateServiceHost(constructorString, baseAddresses);
            string aaa = constructorString.Split(',')[0];
            Suca(shb, aaa);
            return shb;
        }

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            ServiceHost sh = base.CreateServiceHost(serviceType, baseAddresses);
            Suca(sh, serviceType.FullName);
            return sh;
        }

        void Suca(ServiceHostBase shb, string implementedContract)
        {
            // Aggiungi un Endpoint al ServiceHost
            //ServiceEndpoint se = shb.AddServiceEndpoint(implementedContract, new WSHttpBinding(), "");
            ServiceEndpoint se = shb.AddServiceEndpoint(implementedContract, new BasicHttpBinding(), "");

            // Personalizza ServiceEndpoint
            foreach (OperationDescription od in se.Contract.Operations)
            {
                var dcsob = od.Behaviors.Find<DataContractSerializerOperationBehavior>();
                //Imposta DataContractSurrogate
                dcsob.DataContractSurrogate = dcs;
                ////Imposta DataContractResolver
                //dcsob.DataContractResolver = new MyDataContractResolver();
            }

            // Crea e aggiungi un Behavior per la gestione dei Metadati
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            shb.Description.Behaviors.Add(smb);
        }
    }
}
