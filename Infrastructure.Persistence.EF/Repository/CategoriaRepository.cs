﻿using CiccioGest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.EF.Repository
{
    class CategoriaRepository : EntityRepository<Categoria, int>, ICategoriaRepository
    {
    }
}
