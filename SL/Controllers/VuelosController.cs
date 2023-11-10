using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    [RoutePrefix("api/vuelos")]
    public class VuelosController : ApiController
    {
        [Route("")]
        [HttpPost]
        public IHttpActionResult GetAll(ML.Vuelos vuelos)
        {
            ML.Result result = BL.Vuelos.GetAll(vuelos.FechaInicio, vuelos.FechaSalida);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("Add")]
        [HttpPost]
        public IHttpActionResult Reservacion(string NumeroVuelo, string Nombre)
        {
            ML.Result result = BL.Reservacion.Add(NumeroVuelo, Nombre);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
    }
}
