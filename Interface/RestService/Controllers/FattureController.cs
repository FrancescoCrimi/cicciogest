using CiccioGest.Application;
using CiccioGest.Domain;
using CiccioGest.Domain.Documenti;
//using CiccioGest.Domain.Model;
//using CiccioGest.Domain.ReadOnlyModel;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CiccioGest.Interface.RestService
{
    public class FattureController : ApiController
    {
        private IFatturaService service;

        public FattureController(IFatturaService service)
        {
            this.service = service;
        }


        /// <summary>
        /// Ritorna lista fatture
        /// </summary>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("api/Fatture")]
        [SwaggerOperation("GetFatture")]
        [SwaggerResponse(200, type: typeof(List<Fattura>))]
        public IEnumerable<FatturaReadOnly> GetFatture()
        {
            return service.GetFatture();
        }


        /// <summary>
        /// Ritorna Fattura per id
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
        /// Salva nuova o aggiorna fattura
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
