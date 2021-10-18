using System;

namespace CiccioGest.Domain.ClientiFornitori
{
    public class Stato
    {
        public Stato( string nome)
        {
            Nome = nome;
        }

        public string Nome { get; private set; }
    }
}