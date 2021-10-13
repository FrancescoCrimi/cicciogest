using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace CiccioGest.Infrastructure.DomainBase
{
    [Serializable]
    public abstract class ValueObject<TId> : INotifyPropertyChanged
    {
        private TId id;
        public virtual TId Id { get { return id; } protected set { id = value; } }

        public virtual event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
