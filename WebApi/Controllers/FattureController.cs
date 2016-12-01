using Ciccio1.Application;
using Ciccio1.Domain;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

//namespace Ciccio1.WebApi.Controllers
//{
//    public class FattureController : ApiController
//    {
//        private ICiccioService service;

//        public FattureController(ICiccioService service)
//        {
//            this.service = service;
//        }



//        /// <summary>
//        /// 
//        /// </summary>
//        /// <response code="200">OK</response>
//        [HttpGet]
//        [Route("api/Fatture")]
//        [SwaggerOperation("GetFatture")]
//        [SwaggerResponse(200, type: typeof(List<Fattura>))]
//        public IEnumerable<Fattura> GetAll()
//        {
//            return service.GetFatture();
//        }


//        /// <summary>
//        /// Ritorna Fattura per Guid
//        /// </summary>
//        /// <param name="id"></param>
//        /// <response code="200">OK</response>
//        [HttpGet]
//        [Route("api/Fatture/{id}")]
//        [SwaggerOperation("GetFattura")]
//        [SwaggerResponse(200, type: typeof(Fattura))]
//        public Fattura GetById(Guid id)
//        {
//            return service.GetFattura(id);
//        }



//        /// <summary>
//        /// Salva nuova o aggiorna Fattura
//        /// </summary>
//        /// <param name="value"></param>
//        /// <response code="200">OK</response>
//        [HttpPost]
//        [Route("api/Fatture")]
//        [SwaggerOperation("SaveFattura")]
//        [SwaggerResponse(200, type: typeof(Fattura))]
//        public Fattura Save([FromBody]Fattura value)
//        {
//            return service.SaveFattura(value);
//        }


//        /// <summary>
//        /// Cancella Fattura
//        /// </summary>
//        /// <param name="id"></param>
//        /// <response code="204">No Content</response>
//        [HttpDelete]
//        [Route("api/Fatture/{id}")]
//        [SwaggerOperation("DeleteFattura")]
//        public void Delete(Guid id)
//        {
//        }

//    }
//}
