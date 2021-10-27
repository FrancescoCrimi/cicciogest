using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Common;
using CiccioSoft.Collections.Generic;
using System;
using System.Collections.Generic;

namespace CiccioGest.Domain.Magazino
{
    public class Articolo : DomainEntity, IEquatable<Articolo>
    {
        private string nome;
        private int prezzo;
        private Fornitore fornitore;
        private string descrizione;

        public Articolo(int id, string nome, int prezzo)
            : this(nome, prezzo)
        {
            Id = id;
        }
        public Articolo(string nome, int prezzo)
            : this()
        {
            this.nome = nome;
            this.prezzo = prezzo;
        }
        public Articolo()
        {
            Categorie = new CiccioSet<Categoria>();
        }

        public virtual string Nome
        {
            get { return nome; }
            set
            {
                if (value != nome)
                {
                    nome = value;
                    NotifyPropertyChanged(nameof(Nome));
                }
            }
        }

        public virtual int Prezzo
        {
            get { return prezzo; }
            set
            {
                if (value != prezzo)
                {
                    prezzo = value;
                    NotifyPropertyChanged(nameof(Prezzo));
                }
            }
        }

        public virtual string Descrizione
        {
            get => descrizione;
            set
            {
                if (value != descrizione)
                {
                    descrizione = value;
                    NotifyPropertyChanged(nameof(Descrizione));
                }
            }
        }

        public virtual ISet<Categoria> Categorie { get; protected set; }

        public virtual Fornitore Fornitore
        {
            get => fornitore;
            set
            {
                if (value != fornitore)
                {
                    fornitore = value;
                    NotifyPropertyChanged(nameof(Fornitore));
                }
            }
        }


        public virtual void AddCategoria(Categoria categoria)
        {
            Categorie.Add(categoria);
        }

        public virtual void RemoveCategoria(Categoria categoria)
        {
            Categorie.Remove(categoria);
        }




        public override bool Equals(object obj)
        {
            return Equals(obj as Articolo);
        }

        public virtual bool Equals(Articolo other)
        {
            return other != null &&
                   Id == other.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
    }
}
