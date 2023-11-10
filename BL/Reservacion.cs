using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class Reservacion
    {
        public static ML.Result Add(string NumeroVuelo, string Nombre)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AeroMexicoEntities2 context = new DL.AeroMexicoEntities2())
                {
                    var query = context.ReservacionN(NumeroVuelo, Nombre);
                    if (query > 0)
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
