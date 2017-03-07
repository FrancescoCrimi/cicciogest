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
    public class CategorieController : ApiController
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
        public IEnumerable<Categoria> GetAll()
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
        public Categoria Save([FromBody]Categoria value)
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
        public void Delete(Guid id)
        {
        }
    }
}
