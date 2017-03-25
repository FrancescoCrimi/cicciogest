using CiccioGest.Application;
using CiccioGest.Domain.Model;
using CiccioGest.Domain.ReadOnlyModel;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CiccioGest.Interface.WebApi.Controllers
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
        /// Ritorna lista prodotti
        /// </summary>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("api/Prodotti")]
        [SwaggerOperation("GetProdotti")]
        [SwaggerResponse(200, type: typeof(List<ProdottoReadOnly>))]
        public IEnumerable<ProdottoReadOnly> GetProdotti()
        {
            return service.GetProdotti();
        }


        /// <summary>
        /// Ritorna prodotto per id
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("api/Prodotti/{id}")]
        [SwaggerOperation("GetProdotto")]
        [SwaggerResponse(200, type: typeof(Prodotto))]
        public Prodotto GetProdotto(int id)
        {
            return service.GetProdotto(id);
        }



        /// <summary>
        /// Salva prodotto
        /// </summary>
        /// <param name="prodotto"></param>
        /// <response code="200">OK</response>
        [HttpPost]
        [Route("api/Prodotti")]
        [SwaggerOperation("SaveProdotto")]
        [SwaggerResponse(200, type: typeof(Prodotto))]
        public Prodotto SaveProdotto([FromBody]Prodotto prodotto)
        {
            return service.SaveProdotto(prodotto);
        }


        /// <summary>
        /// Cancella prodotto per id
        /// </summary>
        /// <param name="id">IdProdotto</param>
        /// <response code="204">No Content</response>
        [HttpDelete]
        [Route("api/Prodotti/{id}")]
        [SwaggerOperation("DeleteProdotto")]
        public void DeleteProdotto(int id)
        {
            service.DeleteProdotto(id);
        }
    }
}
