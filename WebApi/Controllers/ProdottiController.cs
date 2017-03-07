using Ciccio1.Application;
using Ciccio1.Domain;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ciccio1.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class ProdottiController : ApiController
    {
        private IProdottoService service;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public ProdottiController(IProdottoService service)
        {
            this.service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("api/Prodotti")]
        [SwaggerOperation("GetProdotti")]
        [SwaggerResponse(200, type: typeof(List<Prodotto>))]
        public IEnumerable<Prodotto> GetAll()
        {
            return service.GetProdotti();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("api/Prodotti/{id}")]
        [SwaggerOperation("GetProdotto")]
        [SwaggerResponse(200, type: typeof(Prodotto))]
        public Prodotto GetById(int id)
        {
            return service.GetProdotto(id);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <response code="200">OK</response>
        [HttpPost]
        [Route("api/Prodotti")]
        [SwaggerOperation("SaveProdotto")]
        [SwaggerResponse(200, type: typeof(Prodotto))]
        public Prodotto Save([FromBody]Prodotto value)
        {
            return service.SaveProdotto(value);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">No Content</response>
        [HttpDelete]
        [Route("api/Prodotti/{id}")]
        [SwaggerOperation("DeleteProdotto")]
        public void Delete(Guid id)
        {
        }
    }
}
