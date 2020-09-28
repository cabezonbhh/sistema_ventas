using Sistema_de_ventas.Business;
using Sistema_de_ventas.Data.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_ventas.Data.Mapper.Usuarios
{
    class Mapper_DTO_Usuario
    {
        public Usuario getUsuario(DTO_Usuario dto)
        {
            Usuario usuario = new Usuario();
            usuario.Idusuario = dto.Idusuario;
            usuario.Nombre = dto.Nombre;
            usuario.Apellido = dto.Apellido;
            usuario.Nombre_usuario = dto.Nombre_usuario;
            usuario.Password = dto.Password;
            usuario.Email = dto.Email;
            usuario.IdRol = dto.IdRol;
            usuario.Legajo = dto.Legajo;

            return usuario;
        }

        public DTO_Usuario getUsuarioDTO(Usuario usuario)
        {
            DTO_Usuario dto = new DTO_Usuario();
            dto.Idusuario = usuario.Idusuario;
            dto.Nombre = usuario.Nombre;
            dto.Apellido = usuario.Apellido;
            dto.Nombre_usuario = usuario.Nombre_usuario;
            dto.Password = usuario.Password;
            dto.Email = usuario.Email;
            dto.IdRol = usuario.IdRol;
            dto.Legajo = usuario.Legajo;
            return dto;
        }

    }
}
