using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

            //ML.Result result = BL.Usuarios.GetByUsuario(Usuario, Password);
            //if (result.Correct)
            //{
            //    ML.Usuarios usuarioIngresado = (ML.Usuarios)result.Object;

            //    if (Usuario == usuarioIngresado.Usuario && Password == usuarioIngresado.Password)
            //    {
            //        ViewBag.Mensaje = "Autorice";
            //        return PartialView("Modal");
            //    }


            //}
            //else
            //{
            //    ViewBag.Mensaje = "No Autorice";

            //}
            //return PartialView("Modal");
            ML.Result result = new ML.Result();
            string urlAPI = System.Configuration.ConfigurationManager.AppSettings["WebApi"];
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(urlAPI);
                var responseTask = client.GetAsync("usuario/" + Usuario + Password);
                responseTask.Wait();
                var resultAPI = responseTask.Result;

                if (resultAPI.IsSuccessStatusCode)
                {

                    var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();
                    ML.Usuarios resultItemList = new ML.Usuarios();
                    resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Usuarios>(readTask.Result.Object.ToString());
                    result.Object = resultItemList;

                    ViewBag.Mensaje = "Autorice";
                    return PartialView("Modal");

                }
                else
                {
                    ViewBag.Mensaje = "No Autorice";
                    return PartialView("Modal");

                }

            }
        }
    }
}