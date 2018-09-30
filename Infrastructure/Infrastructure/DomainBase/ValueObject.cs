using DddTest.Infrastructure.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CiccioGest.Infrastructure.DomainBase
{
    [Serializable]
    [DataContract(Namespace = "http://gesttest.it")]
    public abstract class ValueObject<T> : IEquatable<T>, INotifyPropertyChanged where T : ValueObject<T>
    {
        private int id;
        [DataMember]
        public virtual int Id { get { return id; } protected set { id = value; } }

        public override int GetHashCode()
        {
            IEnumerable<object> equObj = GetEqualityComponents();
            return new HashCodeBuilder(17, 37)
                .Append(equObj.ToArray())
                .ToHashCode();
        }

        public override bool Equals(object obj)
        {
            T that = obj as T;
            return this.Equals(that);
        }

        public virtual bool Equals(T other)
        {
            if (other == null) { return false; }
            if (other == this) { return true; }
            return new EqualsBuilder()
                .Append(GetEqualityComponents().ToArray(), other.GetEqualityComponents().ToArray())
                .IsEquals();
        }


        public virtual event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected abstract IEnumerable<object> GetEqualityComponents();
    }
}
