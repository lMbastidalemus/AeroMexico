using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        [Route("{Usuario}/{Password}")]
        [HttpGet]
        public IHttpActionResult Login(string Usuario, string Password)
        {
            ML.Result result = BL.Usuarios.GetByUsuario(Usuario, Password);
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
