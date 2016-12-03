using Ciccio1.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ciccio1.Domain;
using Swashbuckle.Swagger.Annotations;

namespace Ciccio1.WebApi.Controllers
{
    public class CiccioServiceController : ApiController
    {
        private ICiccioService service;
        public CiccioServiceController(ICiccioService service)
        {
            this.service = service;
        }


        /// <summary>
        /// Ritorna tutte le categorie
        /// </summary>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("api/Categorie")]
        [SwaggerOperation("GetCategorie")]
        [SwaggerResponse(200, type: typeof(List<Categoria>))]
        public IEnumerable<Categoria> GetCategorie()
        {
            return service.GetCategorie();
        }

        /// <summary>
        /// Ritorna tutte le categorie
        /// </summary>
        /// <param name="id">IdCategoria</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("api/Categorie/{id}")]
        [SwaggerOperation("GetCategoria")]
        [SwaggerResponse(200, type: typeof(Categoria))]
        public Categoria GetCategoria(int id)
        {
            return service.GetCategoria(id);
        }

        /// <summary>
        /// Crea nuova o aggiorna Categoria
        /// </summary>
        /// <param name="categoria"></param>
        /// <response code="200">OK</response>
        [HttpPost]
        [Route("api/Categorie")]
        [SwaggerOperation("SaveCategoria")]
        [SwaggerResponse(200, type: typeof(Categoria))]
        public Categoria SaveCategoria(Categoria categoria)
        {
            return service.SaveCategoria(categoria);
        }

        /// <summary>
        /// Cancella Categoria
        /// </summary>
        /// <param name="id">IdCategoria</param>
        /// <response code="204">No Content</response>
        [HttpDelete]
        [Route("api/Categorie/{id}")]
        [SwaggerOperation("DeleteCategoria")]
        public void DeleteCategoria(Guid id)
        {
            throw new NotImplementedException();
            //service.DeleteCategoria()
        }


        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("api/Fatture")]
        [SwaggerOperation("GetFatture")]
        [SwaggerResponse(200, type: typeof(List<Fattura>))]
        public IEnumerable<Fattura> GetFatture()
        {
            return service.GetFatture();
        }

        /// <summary>
        /// Ritorna Fattura per Guid
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("api/Fatture/{id}")]
        [SwaggerOperation("GetFattura")]
        [SwaggerResponse(200, type: typeof(Fattura))]
        public Fattura GetFattura(int id)
        {
            return service.GetFattura(id);
        }

        /// <summary>
        /// Salva nuova o aggiorna Fattura
        /// </summary>
        /// <param name="fattura"></param>
        /// <response code="200">OK</response>
        [HttpPost]
        [Route("api/Fatture")]
        [SwaggerOperation("SaveFattura")]
        [SwaggerResponse(200, type: typeof(Fattura))]
        public Fattura SaveFattura(Fattura fattura)
        {
            return service.SaveFattura(fattura);
        }

        /// <summary>
        /// Cancella Fattura
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">No Content</response>
        [HttpDelete]
        [Route("api/Fatture/{id}")]
        [SwaggerOperation("DeleteFattura")]
        public void DeleteFattura(Guid id)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("api/Prodotti")]
        [SwaggerOperation("GetProdotti")]
        [SwaggerResponse(200, type: typeof(List<Prodotto>))]
        public IEnumerable<Prodotto> GetProdotti()
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
        public Prodotto GetProdotto(int id)
        {
            return service.GetProdotto(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prodotto">Prodotto</param>
        /// <response code="200">OK</response>
        [HttpPost]
        [Route("api/Prodotti")]
        [SwaggerOperation("SaveProdotto")]
        [SwaggerResponse(200, type: typeof(Prodotto))]
        public Prodotto SaveProdotto(Prodotto prodotto)
        {
            return service.SaveProdotto(prodotto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">IdProdotto</param>
        /// <response code="204">No Content</response>
        [HttpDelete]
        [Route("api/Prodotti/{id}")]
        [SwaggerOperation("DeleteProdotto")]
        public void DeleteProdotto(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
