using System;
using System.Runtime.Serialization;

namespace CiccioGest.Domain.ClientiFornitori
{
    [Serializable]
    public class Stato
    {
        public Stato( string nome)
        {
            Nome = nome;
        }

        public string Nome { get; private set; }
    }
}