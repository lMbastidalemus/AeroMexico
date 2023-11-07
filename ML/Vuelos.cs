using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Vuelos
    {
        public string NumeroVuelo { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaSalida { get; set; }
        public ML.Pasajeros Pasajero { get; set; }
        public  List<object> Vueloss { get; set; }
    }
}
