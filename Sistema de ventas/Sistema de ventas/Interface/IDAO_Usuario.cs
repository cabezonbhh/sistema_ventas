using Sistema_de_ventas.Business;
using Sistema_de_ventas.Business.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_ventas.Interface
{
    interface IDAO_Usuario <Usuario>
    {
        bool registrarNuevoUsuario(Usuario usuario);
        bool modificarUsuario(Usuario usuario, bool control);
        bool eliminarUsuario(int id);
        IList<Rol> getRoles();
        IList<Usuario> getUsuarios();

    }
}
