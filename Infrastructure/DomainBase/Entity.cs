using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Ciccio1.Infrastructure.DomainBase
{
    [Serializable]
    [DataContract(Namespace = "http://gesttest.it")]
    public abstract class Entity<T> : IEquatable<Entity<T>>, INotifyPropertyChanged
    {
        [DataMember]
        public virtual int Id { get; protected set; }

        public abstract  bool IsTransient();

        public virtual event PropertyChangedEventHandler PropertyChanged;

        public virtual bool Equals(Entity<T> other)
        {
            if (object.ReferenceEquals(this, other)) return true;
            if (object.ReferenceEquals(null, other)) return false;
            return this.Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Entity<T>);
        }

        public override int GetHashCode()
        {
            return (this.GetType().GetHashCode() * 907) + this.Id.GetHashCode();
        }

        public override string ToString()
        {
            return this.GetType().Name + " [Id=" + Id.ToString() + "]";
        }

        protected void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
