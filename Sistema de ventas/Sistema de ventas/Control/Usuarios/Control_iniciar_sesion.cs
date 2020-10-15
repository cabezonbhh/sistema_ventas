using Sistema_de_ventas.Business;
using Sistema_de_ventas.Data.DataTransferObject;
using Sistema_de_ventas.Data.Mapper.Usuarios;
using Sistema_de_ventas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_ventas.Control.Usuarios
{
    public class Control_iniciar_sesion
    {
        private Service_Sesion service;
        private Mapper_DTO_Usuario map;
        public Control_iniciar_sesion()
        {
            service = new Service_Sesion();
            map = new Mapper_DTO_Usuario();
        }

        public DTO_Usuario iniciar_sesion(string usuario, string contraseña)
        {
            Usuario user = service.iniciar_sesion(usuario, contraseña);
            if(user != null)
            {
                return map.getUsuarioDTO(user);
            }
            else
            {
                return null;
            }
        }
    }
}
