using Sistema_de_ventas.Business;
using Sistema_de_ventas.Business.Usuarios;
using Sistema_de_ventas.Connection;
using Sistema_de_ventas.Data.DataAccessObjetc.Usuarios;
using Sistema_de_ventas.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_ventas.Services
{
    public class Service_Usuario
    {
        private IDAO_Usuario<Usuario> dao;


        public Service_Usuario()
        {
            dao = new DAO_Usuario();
        }

        public bool registrar_nuevo_usuario(Usuario usuario)
        {
            return dao.registrarNuevoUsuario(usuario);
        }

        public IList<Rol> get_roles()
        {
            IList<Rol> roles = dao.getRoles();
            return roles;
        }
        public IList<Usuario> get_usuarios()
        {
            return dao.getUsuarios();
        }

    }
}
