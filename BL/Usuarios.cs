using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuarios
    {
        public static ML.Result GetByUsuario(string Usuario, string Password)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AeroMexicoEntities1 contex = new DL.AeroMexicoEntities1())
                {
                    var query = contex.GetByUsuario(Usuario).FirstOrDefault();
                    if (query != null)
                    {
                        ML.Usuarios usuarios = new ML.Usuarios();
                        usuarios.Usuario = query.Usuario;
                        usuarios.Password = query.Password;
                        result.Object = usuarios;
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
