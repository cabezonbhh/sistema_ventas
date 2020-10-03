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
    public class Control_obtener_usuarios
    {
        Service_Usuario service;
        Mapper_DTO_Usuario map;
        IList<DTO_Usuario> lista;

        public Control_obtener_usuarios()
        {
            service = new Service_Usuario();
            map = new Mapper_DTO_Usuario();
        }

        public IList<DTO_Usuario> getUsuarios()
        {
            IList<Usuario> usuarios = service.get_usuarios();
            this.lista = new List<DTO_Usuario>();
            foreach(Usuario usuario in usuarios)
            {
                lista.Add(map.getUsuarioDTO(usuario));
            }
            return lista;
        }

        public DTO_Usuario getDtoPorID(int id)
        {
            DTO_Usuario dto_usuario = null;
            if(lista != null)
            {
                foreach (DTO_Usuario dto in lista)
                {
                    if (dto.Idusuario == id)
                        dto_usuario = dto;
                }
            }
            return dto_usuario;
        }
    }
}
