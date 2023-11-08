using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Vuelos
    {
        public static ML.Result GetAll(ML.Vuelos vuelos)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AeroMexicoEntities2 context = new DL.AeroMexicoEntities2())
                {
                    var query = context.GetAllVuelos(vuelos.FechaInicio, vuelos.FechaSalida);
                    if(query != null)
                    {
                        result.Objects = new List<object>().ToList();
                        foreach(var obj in query)
                        {
                            ML.Vuelos vuelo = new ML.Vuelos();
                            vuelo.NumeroVuelo = obj.NumeroVuelo;
                            vuelo.Origen = obj.Origen;
                            vuelo.Destino = obj.Destino;
                            vuelo.FechaSalida = obj.FechaSalida;
                            result.Objects.Add(vuelo);
                        }
                        result.Correct = true;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
            }
            return result;
        }
    }
}
