using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_ventas.Business
{
    public class Usuario
    {
        public int Idusuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Nombre_usuario { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int IdRol { get; set; }
        public string Legajo { get; set; }

        public Usuario()
        {
            this.Idusuario = 0;
            this.Nombre = "Sin dato";
            this.Apellido = "Sin dato";
            this.Nombre_usuario = "Sin dato";
            this.Password = "Sin dato";
            this.Email = "Sin dato";
            this.IdRol = 0;
            this.Legajo = "Sin dato";
        }

        public Usuario(int idusuario, string nombre, string apellido, string nombre_usuario, string password, string email, int idRol, string legajo)
        {
            this.Idusuario = idusuario;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nombre_usuario = nombre_usuario;
            this.Password = password;
            this.Email = email;
            this.IdRol = idRol;
            this.Legajo = legajo;
        }

        public bool validarNombreUsuario(string usuario)
        {
            return this.Nombre_usuario.Equals(usuario,StringComparison.InvariantCultureIgnoreCase);
        }
        public bool validarLegajo(string legajo)
        {
            return this.Legajo.Equals(legajo, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
