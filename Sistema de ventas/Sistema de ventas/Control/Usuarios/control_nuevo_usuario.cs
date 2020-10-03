using Sistema_de_ventas.Business;
using Sistema_de_ventas.Business.Usuarios;
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
    public class Control_nuevo_usuario
    {
        private Mapper_DTO_Usuario mapper;
        private Service_Usuario service;

        public Control_nuevo_usuario()
        {
            mapper = new Mapper_DTO_Usuario();
            service = new Service_Usuario();
        }
        public bool registrar_nuevo_usuario(DTO_Usuario dto)
        {
            if (Sesion.getSesion().getIdRolLogueado() < 3 && dto.IdRol >= Sesion.getSesion().getIdRolLogueado())
                return service.registrar_nuevo_usuario(mapper.getUsuario(dto));
            else
                return false;
        }

        public IList<Rol> obtener_roles()
        {
            IList<Rol> roles = service.get_roles();
            foreach(Rol rol in roles)
            {
                if (rol.IdRol < Sesion.getSesion().getIdRolLogueado())
                    roles.Remove(rol);
            }
            return roles;
        }
    }
}
