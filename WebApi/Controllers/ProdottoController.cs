using Ciccio1.Application;
using Ciccio1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ciccio1.WebApi.Controllers
{
    public class ProdottoController : ApiController
    {
        private ICiccioService service;

        public ProdottoController(ICiccioService service)
        {
            this.service = service;
        }

        // GET: api/Prodotto
        [HttpGet]
        public IEnumerable<Prodotto> GetProdotti()
        {
            return service.GetProdotti();
        }

        // GET: api/Prodotto/5
        [HttpGet]
        public Prodotto GetProdotto(Guid id)
        {
            return service.GetProdotto(id);
        }

        // POST: api/Prodotto
        [HttpPost]
        public void SaveProdotto([FromBody]Prodotto value)
        {
            service.SaveProdotto(value);
        }

        // PUT: api/Prodotto/5
        public void Put(int id, [FromBody]Prodotto value)
        {
        }

        // DELETE: api/Prodotto/5
        [HttpDelete]
        public void DeleteProdotto(Guid id)
        {
        }
    }
}
