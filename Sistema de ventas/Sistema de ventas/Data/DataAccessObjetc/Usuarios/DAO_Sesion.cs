using Sistema_de_ventas.Business;
using Sistema_de_ventas.Connection;
using Sistema_de_ventas.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_ventas.Data.DataAccessObjetc.Usuarios
{
    public class DAO_Sesion : IDAO_Sesion
    {
        Encryptor encryptor = Encryptor.GetEncryptor();
        DBHelper helper = DBHelper.getDBHelper();

        public Usuario iniciar_sesion(string usuario, string contraseña)
        {
            DAO_Usuario dao = new DAO_Usuario();
            string sp = "SP_Iniciar_sesion";

            SqlParameter[] parametros = new SqlParameter[2];
            var param1 = new SqlParameter("@n_usuario", usuario);
            param1.SqlDbType = SqlDbType.VarChar;
            parametros[0] = param1;
            Usuario user = null;

            var param2 = new SqlParameter("@password", encryptor.cifrar(contraseña));
            param1.SqlDbType = SqlDbType.VarChar;
            parametros[1] = param2;

            DataTable tabla = helper.consultarStoredProcedureConParametros(sp, parametros);
            if(tabla.Rows.Count==1)
            {
               
                foreach (DataRow fila in tabla.Rows)
                {
                     user = dao.getUsuario(Convert.ToInt32(fila[0].ToString()));
                }
                return user;
            }

            return null;
        }
    }
}
