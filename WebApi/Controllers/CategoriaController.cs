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
    public class CategoriaController : ApiController
    {
        private ICiccioService service;

        public CategoriaController(ICiccioService service)
        {
            this.service = service;
        }

        // GET: api/Categoria
        [HttpGet]
        public IEnumerable<Categoria> GetCategorie()
        {
            return service.GetCategorie();
        }

        // POST: api/Categoria
        [HttpPost]
        public Categoria SaveCategoria([FromBody]Categoria value)
        {
           return service.SaveCategoria(value);
        }

        // DELETE: api/Categoria/5
        [HttpDelete]
        public void DeleteCategoria(Guid id)
        {
        }
    }
}
