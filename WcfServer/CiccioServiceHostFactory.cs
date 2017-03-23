using Castle.Facilities.WcfIntegration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace CiccioGest.WcfServer
{
    public class CiccioServiceHostFactory : DefaultServiceHostFactory
    {
        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            ServiceHostBase shb = base.CreateServiceHost(constructorString, baseAddresses);
            string aaa = constructorString.Split(',')[0];
            suca(shb, aaa);
            return shb;
        }

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            ServiceHost sh = base.CreateServiceHost(serviceType, baseAddresses);
            suca(sh, serviceType.FullName);
            return sh;
        }

        void suca(ServiceHostBase shb, string implementedContract)
        {
            // Aggiungi un Endpoint al ServiceHost
            ServiceEndpoint se = shb.AddServiceEndpoint(implementedContract, new WSHttpBinding(), "");
            foreach (OperationDescription od in se.Contract.Operations)
            {
                DataContractSerializerOperationBehavior dcsob = od.Behaviors.Find<DataContractSerializerOperationBehavior>();
                //Imposta DataContractSurrogate
                dcsob.DataContractSurrogate = new MyDataContractSurrogate();
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
