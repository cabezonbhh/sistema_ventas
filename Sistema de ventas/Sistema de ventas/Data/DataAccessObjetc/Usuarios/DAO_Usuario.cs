using Sistema_de_ventas.Business;
using Sistema_de_ventas.Business.Usuarios;
using Sistema_de_ventas.Connection;
using Sistema_de_ventas.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_ventas.Data.DataAccessObjetc.Usuarios
{
    public class DAO_Usuario : IDAO_Usuario<Usuario>
    {
        DBHelper helper = DBHelper.getDBHelper();//Helper = se encarga de la comunicacion con la BD.
        private Encryptor encryptor = Encryptor.GetEncryptor();//Encryptor = Se encarga de encriptar y desencriptar las contraseñas u otras cadenas. 

        public bool eliminarUsuario(int id)
        {
            throw new NotImplementedException();
        }

        // public IList<Rol> getRoles()
        //     Metodo para traer todos los roles desde la BD.
        //
        // Parametros:
        //      - No lleva parametros.
        //
        // Devuelve:
        //      Una lista con todos los roles. En caso de no haber roles, devuelve una lista vacia.
        //
        // Excepciones:
        //       No tiene.
        public IList<Rol> getRoles()
        {
            DataTable tabla = helper.consultarStoredProcedure("SP_Obtener_todos_roles");

            IList<Rol> lista = new List<Rol>();
            if (tabla != null)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    lista.Add(map_roles(fila));
                }
            }
            return lista;
        }


        public IList<Usuario> getUsuarios()
        {
            IList<Usuario> lista = new List<Usuario>();
            DataTable tabla = helper.consultarStoredProcedure("SP_Obtener_todos_usuarios");
            if (tabla != null)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    lista.Add(this.map_usuario(fila));
                }
            }
            return lista;
        }

        public bool modificarUsuario(Usuario usuario, bool control)
        {
            string sp = "SP_Modificar_usuario";
            SqlParameter[] parametros = new SqlParameter[8];

            var param1 = new SqlParameter("@nombre", usuario.Nombre);
            param1.SqlDbType = SqlDbType.VarChar;
            parametros[0] = param1;

            var param2 = new SqlParameter("@apellido", usuario.Apellido);
            param1.SqlDbType = SqlDbType.VarChar;
            parametros[1] = param2;

            var param3 = new SqlParameter("@n_usuario", usuario.Nombre_usuario);
            param1.SqlDbType = SqlDbType.VarChar;
            parametros[2] = param3;

            var param4 = new SqlParameter("@pass", encryptor.cifrar(usuario.Password));
            param1.SqlDbType = SqlDbType.VarChar;
            parametros[3] = param4;

            var param5 = new SqlParameter("@email", usuario.Email);
            param1.SqlDbType = SqlDbType.VarChar;
            parametros[4] = param5;

            var param6 = new SqlParameter("@idRol", usuario.IdRol);
            param1.SqlDbType = SqlDbType.Int;
            parametros[5] = param6;

            var param7 = new SqlParameter("@legajo", usuario.Legajo);
            param1.SqlDbType = SqlDbType.VarChar;
            parametros[6] = param7;


            var param8 = new SqlParameter("@id", usuario.Idusuario);
            param1.SqlDbType = SqlDbType.Int;
            parametros[7] = param8;


            return helper.ejecutarStoredProcedureConParametros(sp, parametros) == 1;
        }

        public bool registrarNuevoUsuario(Usuario usuario)
        {
            string sp = "SP_Nuevo_usuario";
            SqlParameter[] parametros = new SqlParameter[7];

            var param1 = new SqlParameter("@nombre", usuario.Nombre);
            param1.SqlDbType = SqlDbType.VarChar;
            parametros[0] = param1;

            var param2 = new SqlParameter("@apellido", usuario.Apellido);
            param1.SqlDbType = SqlDbType.VarChar;
            parametros[1] = param2;

            var param3 = new SqlParameter("@n_usuario", usuario.Nombre_usuario);
            param1.SqlDbType = SqlDbType.VarChar;
            parametros[2] = param3;

            var param4 = new SqlParameter("@pass", encryptor.cifrar(usuario.Password));
            param1.SqlDbType = SqlDbType.VarChar;
            parametros[3] = param4;

            var param5 = new SqlParameter("@email", usuario.Email);
            param1.SqlDbType = SqlDbType.VarChar;
            parametros[4] = param5;

            var param6 = new SqlParameter("@idRol", usuario.IdRol);
            param1.SqlDbType = SqlDbType.Int;
            parametros[5] = param6;

            var param7 = new SqlParameter("@legajo", usuario.Legajo);
            param1.SqlDbType = SqlDbType.VarChar;
            parametros[6] = param7;

            return helper.ejecutarStoredProcedureConParametros(sp,parametros) == 1;
        }

        private Rol map_roles(DataRow fila)
        {
            Rol rol = new Rol();
            rol.IdRol = Convert.ToInt32(fila[0].ToString());
            rol.Nombre = fila[1].ToString();
            return rol;
        }

        private Usuario map_usuario(DataRow fila)
        {
            Usuario usuario = new Usuario();
            Rol rol = new Rol();
            usuario.Idusuario = Convert.ToInt32(fila[0].ToString());
            usuario.Nombre = fila[1].ToString();
            usuario.Apellido = fila[2].ToString();
            usuario.Nombre_usuario = fila[3].ToString();
            usuario.Password =fila[4].ToString();
            usuario.Email = fila[5].ToString();
            usuario.IdRol = Convert.ToInt32(fila[6].ToString());
            usuario.Legajo = fila[8].ToString();
            rol.IdRol = Convert.ToInt32(fila[9].ToString());
            rol.Nombre = fila[10].ToString();
            usuario.rol = rol;
            return usuario;
        }
    }
}
