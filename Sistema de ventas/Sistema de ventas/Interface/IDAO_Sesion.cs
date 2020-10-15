using Sistema_de_ventas.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_ventas.Interface
{
    interface IDAO_Sesion
    {
        Usuario iniciar_sesion(string usuario, string contraseña);
    }
}
