using Sistema_de_ventas.Business;
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
        bool modificarUsuario(Usuario usuario);
        bool eliminarUsuario(int id);
        IList<Usuario> getTodosUsuarios(Usuario usuario);

    }
}
