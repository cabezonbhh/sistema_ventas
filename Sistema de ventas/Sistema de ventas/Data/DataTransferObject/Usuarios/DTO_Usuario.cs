using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_ventas.Data.DataTransferObject
{
    public class DTO_Usuario
    {
        public int Idusuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Nombre_usuario { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int IdRol { get; set; }
        public string Legajo { get; set; }
        public string Rol { get; set; }
    }
}
