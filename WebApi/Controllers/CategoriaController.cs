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
        public IEnumerable<Categoria> Get()
        {
            return service.GetCategorie();
        }

        //// GET: api/Categoria/5
        //public Categoria Get(Guid id)
        //{
            
        //}

        // POST: api/Categoria
        public void Post([FromBody]Categoria value)
        {
            service.SaveCategoria(value);
        }

        // PUT: api/Categoria/5
        public void Put(int id, [FromBody]Categoria value)
        {
            service.SaveCategoria(value);
        }

        // DELETE: api/Categoria/5
        public void Delete(Guid id)
        {
        }
    }
}
