using CiccioGest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Domain.ClientiFornitori
{
    [Serializable]
    [DataContract(Namespace = "http://cicciogest.it")]
    public class Fornitore : DomainEntity<Fornitore>
    {
    }
}
