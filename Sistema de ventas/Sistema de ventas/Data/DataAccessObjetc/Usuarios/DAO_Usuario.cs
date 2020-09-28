using Sistema_de_ventas.Business;
using Sistema_de_ventas.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_ventas.Data.DataAccessObjetc.Usuarios
{
    public class DAO_Usuario : IDAO_Usuario<Usuario>
    {
        public bool eliminarUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Usuario> getTodosUsuarios(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public bool modificarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public bool registrarNuevoUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
