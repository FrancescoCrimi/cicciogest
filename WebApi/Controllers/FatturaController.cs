﻿using Ciccio1.Application;
using Ciccio1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ciccio1.WebApi.Controllers
{
    public class FatturaController : ApiController
    {
        private ICiccioService service;

        public FatturaController(ICiccioService service)
        {
            this.service = service;
        }

        // GET: api/Fattura
        public IEnumerable<Fattura> GetFatture()
        {
            return service.GetFatture();
        }

        // GET: api/Fattura/5
        [HttpGet]
        public Fattura GetFattura(Guid id)
        {
            return service.GetFattura(id);
        }

        // POST: api/Fattura
        [HttpPost]
        public void SaveFattura([FromBody]Fattura value)
        {
            service.SaveFattura(value);
        }

        // PUT: api/Fattura/5
        public void Put(int id, [FromBody]Fattura value)
        {
            service.SaveFattura(value);
        }

        // DELETE: api/Fattura/5
        public void DeleteFattura(Guid id)
        {
            
        }

    }
}
