using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ExamenAeroMexico.Controllers
{
    public class PasajerosController : Controller
    {
        // GET: Pasajeros
        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Form(ML.Pasajeros pasajeros)
        {
            //ML.Result result = BL.Pasajeross.Add(pasajeros);
            //if (result.Correct)
            //{
            //    ViewBag.Mensaje = "Agregado correctamente";
            //    return View("Modal");
            //}
            //else
            //{
            //    ViewBag.Mensaje = "Error al agregar";
            //    return View("Modal");
            //}
            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);
                var postTask = client.PostAsJsonAsync<ML.Pasajeros>("pasajeros", pasajeros);

                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Mensaje = "Agregado correctamente";
                    return View("Modal");
                }
                else
                {
                    ViewBag.Mensaje = "Error al agregar";
                    return View("Modal");
                }
            }

        }
    }
}