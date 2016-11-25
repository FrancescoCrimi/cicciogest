using Ciccio1.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ciccio1.Domain
{
    [Serializable]
    [DataContract(Namespace = "http://gesttest.it")]
    public class Indirizzo : Entity<Indirizzo>
    {
        public override bool IsTransient()
        {
            throw new NotImplementedException();
        }
    }
}
