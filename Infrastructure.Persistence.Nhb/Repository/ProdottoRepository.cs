﻿using Ciccio1.Domain;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciccio1.Infrastructure.Persistence.Nhb.Repository
{
    class ProdottoRepository : DomainRepository<Prodotto>, IProdottoRepository
    {
        public ProdottoRepository(DataAccess da)
            : base(da) { }
    }
}
