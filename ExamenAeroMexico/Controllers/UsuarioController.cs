using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamenAeroMexico.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Usuario, string Password)
        {
            
            ML.Result result = BL.Usuarios.GetByUsuario(Usuario, Password);
            if (result.Correct)
            {
               ML.Usuarios usuarioIngresado = (ML.Usuarios)result.Object;
               
                if(Usuario == usuarioIngresado.Usuario && Password == usuarioIngresado.Password)
                {
                    result.ErrorMessage = "Autorice";
                }
                else
                {
                    result.ErrorMessage = "No Autorice";

                }
              
            }
            return View(result.ErrorMessage);
        }
    }
}