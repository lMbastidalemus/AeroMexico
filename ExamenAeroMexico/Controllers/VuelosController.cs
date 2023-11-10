using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ExamenAeroMexico.Controllers
{
    public class VuelosController : Controller
    {
        // GET: Vuelos
        public ActionResult GetAll()
        {
          
            return View();
        }

        [HttpPost]
        public ActionResult VuelosV(ML.Vuelos vuelos)
        {

            using (var client = new HttpClient())
            {
                ML.Result resultVuelos = BL.Vuelos.GetAll(vuelos.FechaInicio, vuelos.FechaSalida);
                vuelos = new ML.Vuelos();
                vuelos.Vueloss = resultVuelos.Objects;


                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);

                var responseTask = client.GetAsync("");
                responseTask.Wait();

                var resultServicio = responseTask.Result;

                if (resultServicio.IsSuccessStatusCode)
                {
                    var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Vuelos resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Vuelos>(resultItem.ToString());
                        vuelos.Vueloss.Add(resultItemList);
                    }
                }
            }

            return View(vuelos);

        }

        public ActionResult Reservacion()
        {

            ML.Vuelos vuelos = new ML.Vuelos();
            ML.Result result = BL.Vuelos.GetAllR();
            vuelos.Vueloss = result.Objects;
            vuelos.Pasajero = new ML.Pasajeros();
            ML.Result resultPasajero = BL.Pasajeross.GetAll();
            vuelos.Pasajero.Pasajeross = resultPasajero.Objects;
            return View(vuelos);
        }

        [HttpPost]
        public ActionResult Reservacion(string NumeroVuelo, string Nombre)
        {
            //ML.Result result = BL.Reservacion.Add(NumeroVuelo, Nombre);
            //if (result.Correct)
            //{
            //    ViewBag.Mensaje = "Add";
            //}
            //else
            //{
            //    ViewBag.Mensaje = "Error";
            //}
            //return PartialView("Modal");

            //using (var client = new HttpClient())
            //{


            //    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);
            //    var postTask = client.PostAsJsonAsync<ML.Vuelos>("", NumeroVuelo, Nombre);

            //    postTask.Wait();
            //    var result = postTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {
            //        ViewBag.Mensaje = "Agregado correctamente";
            //        return View("Modal");
            //    }
            //    else
            //    {
            //        ViewBag.Mensaje = "Error al agregar";
            //        return View("Modal");
            //    }
            //}
            return View();
        }



       
    }
}