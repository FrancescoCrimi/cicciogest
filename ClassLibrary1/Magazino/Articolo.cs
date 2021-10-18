using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace CiccioGest.Domain.Magazino
{
    [Serializable]
    public class Articolo : DomainEntity, IEquatable<Articolo>
    {
        [NonSerialized]
        private string nome;
        private int prezzo;
        private Categoria categoria;
        private Fornitore fornitore;

        public Articolo() { }
        public Articolo(string nome, int prezzo)
        {
            this.nome = nome;
            this.prezzo = prezzo;
        }
        public Articolo(int id, string nome, int prezzo)
            : this(nome, prezzo)
        {
            Id = id;
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

        public virtual BindingList<Categoria> Categorie { get; protected set; }

        public virtual Categoria Categoria
        {
            get { return categoria; }
            set
            {
                if (value != categoria)
                {
                    categoria = value;
                    NomeCategoria = categoria.Nome;
                    NotifyPropertyChanged(nameof(NomeCategoria));
                }
            }
        }

        public virtual string NomeCategoria { get; protected set; }

        public virtual Fornitore Fornitore
        {
            get => fornitore;
            set => fornitore = value;
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
