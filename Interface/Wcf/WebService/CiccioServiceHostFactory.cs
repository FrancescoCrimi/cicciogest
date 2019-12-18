using Castle.Facilities.WcfIntegration;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace CiccioGest.Interface.Wcf.WebService
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
            AddEndpoint(shb, aaa);
            //AddMetadataAndDebug(shb);
            return shb;
        }

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            ServiceHost sh = base.CreateServiceHost(serviceType, baseAddresses);
            AddEndpoint(sh, serviceType.FullName);
            //AddMetadataAndDebug(sh);
            return sh;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="shb"></param>
        /// <param name="implementedContract"></param>
        private void AddEndpoint(ServiceHostBase shb, string implementedContract)
        {
            // Aggiungi un Endpoint al ServiceHost
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

            //// Crea e aggiungi un Behavior per la gestione dei Metadati
            //ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            //smb.HttpGetEnabled = true;
            //smb.HttpsGetEnabled = true;
            //shb.Description.Behaviors.Add(smb);
        }

        /// <summary>
        /// Crea e aggiunge un Behavior per la gestione dei Metadati
        /// e un Behavior per debug
        /// </summary>
        /// <param name="shb"></param>
        private void AddMetadataAndDebug(ServiceHostBase shb)
        {
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.HttpsGetEnabled = true;            
            shb.Description.Behaviors.Add(smb);
            //ServiceDebugBehavior sdb = new ServiceDebugBehavior();
            //sdb.IncludeExceptionDetailInFaults = true;
            //shb.Description.Behaviors.Add(sdb);
        }
    }
}
