using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pasajeross
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AeroMexicoEntities2 context = new DL.AeroMexicoEntities2())
                {
                    var query = context.GetAll();
                    if (query != null)
                    {
                        result.Objects = new List<object>().ToList();
                        foreach (var obj in query)
                        {
                            ML.Pasajeros pasajeros = new ML.Pasajeros();
                            pasajeros.IdPasajero = obj.IdPasajero;
                            pasajeros.Nombre = obj.Nombre;
                            result.Objects.Add(pasajeros);
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

        public static ML.Result Add(ML.Pasajeros pasajeros)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AeroMexicoEntities2 context = new DL.AeroMexicoEntities2())
                {
                    var query = context.AddPasajero(pasajeros.Nombre, pasajeros.ApellidoPaterno, pasajeros.ApellidoMaterno);
                    if (query >0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
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
