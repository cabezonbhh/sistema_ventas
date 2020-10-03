using Sistema_de_ventas.Data.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_ventas.Business
{
    public class Sesion
    {
       
        private static Sesion instance; // variable que almacena una instancia de esta misma clase para utilizar el patron singleton
        private DTO_Usuario logueado;
        //e.Encrypt(aca va la cadena, e.AppPwdUnique, int.Parse("256"))

        private Sesion(DTO_Usuario login) // constructor privado que va a ser llamado por el metodo getDBHelper(). Se utiliza para el patron singleton
        {
            logueado = login;
        }

        public static Sesion getSesion(DTO_Usuario login)//metodo que devuelve la instancia unica.
        {
            if(instance != null)
            {
                return instance;
            }
            else
            {
                instance = new Sesion(login);
                return instance;
            }
        }

        public static Sesion getSesion()//metodo que devuelve la instancia unica.
        {
            return instance;
        }

        public int getIdLogueado()
        {
            return logueado.Idusuario;
        }

        public int getIdRolLogueado()
        {
            return logueado.IdRol;
        }

        public string getNombreUsuarioLogueado()
        {
            return logueado.Nombre_usuario;
        }
    }
}
