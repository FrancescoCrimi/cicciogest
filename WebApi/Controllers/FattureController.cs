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
    public class FattureController : ApiController
    {
        private IFatturaService service;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public FattureController(IFatturaService service)
        {
            this.service = service;
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
        public Fattura SaveFattura([FromBody]Fattura fattura)
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
        }
    }
}
