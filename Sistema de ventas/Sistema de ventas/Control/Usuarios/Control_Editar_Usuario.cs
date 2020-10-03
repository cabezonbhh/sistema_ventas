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
    public class Control_Editar_Usuario
    {
        private Service_Usuario service;
        private Mapper_DTO_Usuario map;
        private DTO_Usuario seleccionado;
        public Control_Editar_Usuario()
        {
            service = new Service_Usuario();
            map = new Mapper_DTO_Usuario();
        }
        public IList<Rol> obtener_roles()
        {
            IList<Rol> roles = service.get_roles();
            foreach (Rol rol in roles)
            {
                if (rol.IdRol < Sesion.getSesion().getIdRolLogueado())
                    roles.Remove(rol);
            }
            return roles;
        }
        public DTO_Usuario usuarioPorID(int id)
        {
            IList<Usuario> lista = service.get_usuarios();
            if(lista != null && lista.Count>0)
            {
                foreach(Usuario usuario in lista)
                {
                    if(usuario.Idusuario == id)
                    {
                        seleccionado = map.getUsuarioDTO(usuario);
                    }
                }
                return seleccionado;
            }
            else
            {
                return seleccionado;
            }
        }

        public string getContraseñaDesencriptada()
        {
            string contraseña = seleccionado.Password; 
            Connection.Encryptor encriptador = Connection.Encryptor.GetEncryptor();
            if (seleccionado.Idusuario == Sesion.getSesion().getIdLogueado())
            {
                contraseña = encriptador.descifrar(seleccionado.Password);
            }       
            return contraseña;
        }

        public bool tengoPermisoDeVer()
        {
            return seleccionado.Idusuario == Sesion.getSesion().getIdLogueado();
        }

        public bool tengoPermiso()
        {
            return Sesion.getSesion().getIdRolLogueado() < 3 ;
        }

    }
}
