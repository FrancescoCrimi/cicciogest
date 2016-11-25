using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DddTest.Infrastructure.DomainBase
{
    public interface IValueObjectRepository<TValueObject> where TValueObject : ValueObject<TValueObject>
    {
        IList<TValueObject> GetAll();
        TValueObject Get(Guid id);
        void Save(TValueObject valueObject);
        void Delete(TValueObject valueObject);
    }
}
