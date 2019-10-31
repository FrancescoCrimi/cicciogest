﻿using Castle.Core.Logging;
using CiccioGest.Domain.Documenti;
using System.Collections.Generic;
using System.Globalization;

namespace CiccioGest.Infrastructure.Persistence.Nhb.Repository
{
    class FatturaRepository : DomainRepository<Fattura>, IFatturaRepository
    {
        public FatturaRepository(ILogger logger, UnitOfWorkNhb unitOfWork)
            : base(unitOfWork)
        {
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " (uow:" + unitOfWork.GetHashCode().ToString(CultureInfo.InvariantCulture) + " ) Created");
        }

        public IEnumerable<FatturaReadOnly> GetAll()
        //public IList<FatturaReadOnly> GetAll()
        {
            List<FatturaReadOnly> list = new List<FatturaReadOnly>();
            //IList qr = da.ISession.CreateQuery("select fat.Id, fat.Nome, fat.Totale from Fattura fat").List();
            IList<Fattura> fatture = unitOfWork.ISession.CreateCriteria<Fattura>().List<Fattura>();
            foreach (Fattura item in fatture)
            {
                list.Add(new FatturaReadOnly(item.Id, item.Nome, item.Totale));
            }
            return list;
        }
    }
}