// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Anagrafica;
using CiccioGest.Domain.Common;
using CiccioSoft.Collections.Generic;
using System;
using System.Collections.Generic;

namespace CiccioGest.Domain.Documenti
{
    public class Fattura : DomainEntity, IEquatable<Fattura>
    {
        //private string nome;
        private IList<Dettaglio>? _dettagli;
        private Cliente? _cliente;

        // usato da nhibernate
        protected Fattura()
        {
            //dettagli = new CiccioList<Dettaglio>();
        }

        public Fattura(int id, Cliente cliente)
            : this(cliente)
        {
            this.Id = id;
        }

        public Fattura(Cliente cliente)
        {
            Cliente = cliente;
            _dettagli = new CiccioList<Dettaglio>();
        }


        public virtual Cliente? Cliente
        {
            get => _cliente;
            protected set => _cliente = value;
        }

        public virtual string? Nome => Cliente?.NomeCompleto;

        public virtual IList<Dettaglio>? Dettagli
        {
            get => _dettagli;
            protected set
            {
                if (value != _dettagli)
                {
                    _dettagli = value;
                    NotifyPropertyChanged(nameof(Dettagli));
                }
            }
        }

        public virtual int Totale { get; protected set; }


        public virtual void AddDettaglio(Dettaglio dettaglio)
        {
            if (_dettagli != null)
            {
                if (!_dettagli.Contains(dettaglio))
                {
                    _dettagli.Add(dettaglio);
                    CalcolaTotale();
                }
                else
                {
                    Dettaglio d = _dettagli[_dettagli.IndexOf(dettaglio)];
                    d.Quantita += dettaglio.Quantita;
                    CalcolaTotale();
                }
            }
        }

        public virtual void RemoveDettaglio(Dettaglio dettaglio)
        {
            if (_dettagli != null)
            {
                if (_dettagli.Contains(dettaglio))
                {
                    _dettagli.Remove(dettaglio);
                    CalcolaTotale();
                }
            }
        }

        public virtual void AddDettagli(ISet<Dettaglio> dettagli)
        {
            foreach (Dettaglio dettaglio in dettagli)
                AddDettaglio(dettaglio);
        }


        private void CalcolaTotale()
        {
            Totale = 0;
            if (_dettagli != null)
            {
                if (_dettagli.Count > 0)
                {
                    foreach (Dettaglio prodItem in _dettagli)
                    {
                        Totale += prodItem.Totale;
                    }
                }
            }
            NotifyPropertyChanged(nameof(Totale));
        }


        public override bool Equals(object? obj)
        {
            return Equals(obj as Fattura);
        }

        public virtual bool Equals(Fattura? other)
        {
            return other != null &&
                   Id == other.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
