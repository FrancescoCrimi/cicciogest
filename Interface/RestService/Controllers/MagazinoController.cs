using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
//using CiccioGest.Domain.Model;
//using CiccioGest.Domain.ReadOnlyModel;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CiccioGest.Domain.ClientiFornitori;

namespace CiccioGest.Interface.RestService
{
    public class ProdottiController : ApiController, IMagazinoService
    {
        private IMagazinoService service;

        public ProdottiController(IMagazinoService service)
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
        /// Ritorna categoria per id
        /// </summary>
        /// <param name="id">IdCategoria</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Categorie/{id}")]
        [SwaggerOperation("GetCategoria")]
        public Categoria GetCategoria(int id)
        {
            return service.GetCategoria(id);
        }


        /// <summary>
        /// Crea nuova o aggiorna Categoria
        /// </summary>
        /// <param name="value"></param>
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
        public void DeleteCategoria(int id)
        {
            service.DeleteCategoria(id);
        }


        public Fornitore GetFornitore(int id)
        {
            throw new NotImplementedException();
        }
    }
}
