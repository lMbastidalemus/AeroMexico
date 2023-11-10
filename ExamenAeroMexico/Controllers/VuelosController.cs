using System;
using System.Collections.Generic;
using System.Linq;
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
            
            ML.Result resultVuelos = BL.Vuelos.GetAll(vuelos.FechaInicio, vuelos.FechaSalida);
            vuelos = new ML.Vuelos();
            vuelos.Vueloss = resultVuelos.Objects;
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
            ML.Result result = BL.Reservacion.Add(NumeroVuelo, Nombre);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Add";
            }
            else
            {
                ViewBag.Mensaje = "Error";
            }
            return PartialView("Modal");
        }

       
    }
}