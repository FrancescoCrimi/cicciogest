using CiccioGest.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Domain
{
    [Serializable]
    [DataContract(Namespace = "http://gesttest.it")]
    public class Indirizzo : DomainEntity<Indirizzo>
    {
    }
}
