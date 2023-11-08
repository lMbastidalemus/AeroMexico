using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    [RoutePrefix("api/pasajeros")]
    public class PasajerosController : ApiController
    {
        [Route("")]
        [HttpPost]
        public IHttpActionResult Add(ML.Pasajeros pasajeros)
        {
            ML.Result result = BL.Pasajeross.Add(pasajeros);
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
