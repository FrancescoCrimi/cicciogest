using Castle.Facilities.WcfIntegration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace CiccioGest.Infrastructure.Wcf
{
    public class MyServiceHostFactory : DefaultServiceHostFactory
    {
        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            ServiceHostBase shb = base.CreateServiceHost(constructorString, baseAddresses);
            return shb;
        }

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            ServiceHost sh = base.CreateServiceHost(serviceType, baseAddresses);
            return sh;
        }
    }
}
