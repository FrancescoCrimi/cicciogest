using CiccioGest.Application;
using CiccioGest.Domain;
using CiccioGest.Domain.Model;
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
    public class CategorieController : ApiController, ICategoriaService
    {
        private ICategoriaService service;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public CategorieController(ICategoriaService service)
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
        /// Crea nuova o aggiorna Categoria
        /// </summary>
        /// <param name="value"></param>
        /// <response code="200">OK</response>
        [HttpPost]
        [Route("api/Categorie")]
        [SwaggerOperation("SaveCategoria")]
        [SwaggerResponse(200, type: typeof(Categoria))]
        public Categoria SaveCategoria([FromBody]Categoria value)
        {
            return service.SaveCategoria(value);
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

   
    }
}
