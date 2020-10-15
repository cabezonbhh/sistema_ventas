using Sistema_de_ventas.Business;
using Sistema_de_ventas.Data.DataAccessObjetc.Usuarios;
using Sistema_de_ventas.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_ventas.Services
{
    public class Service_Sesion
    {
        private IDAO_Sesion dao;

        public Service_Sesion()
        {
            dao = new DAO_Sesion();
        }

        public Usuario iniciar_sesion(string usuario, string contraseña)
        {
            return dao.iniciar_sesion(usuario,contraseña);
        }
    }
}
