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

        public ActionResult Vuelos(ML.Vuelos vuelos)
        {
            return View(vuelos);

        }

       
    }
}