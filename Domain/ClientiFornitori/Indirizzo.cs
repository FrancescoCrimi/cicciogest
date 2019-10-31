﻿using CiccioGest.Domain.Common;
using System;
using System.Runtime.Serialization;

namespace CiccioGest.Domain.ClientiFornitori
{
    [Serializable]
    [DataContract(Namespace = "http://cicciogest.it")]
    public class Indirizzo : DomainValueObject
    {
        protected Indirizzo() { }
    }
}