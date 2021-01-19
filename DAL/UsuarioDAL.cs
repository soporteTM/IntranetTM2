using EL;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuarioDAL
    {
        public List<UsuarioEL> TEST_Listar_Todo_Usuarios()
        {
            DataTable tabla = SqlServerHelper.ReadTable(SqlServerHelper.cnxSeguridad, CommandType.StoredProcedure, "SEG_Listar_Usuarios");
            
            List<UsuarioEL> lista = new List<UsuarioEL>();
            lista = Util.ConvertDataTable<UsuarioEL>(tabla);

            return lista;
        }

        public List<UsuarioEL> TEST_Filtrar_Usuario(string nom_user)
        {
            SqlParameter[] arParam = new SqlParameter[1];

            arParam[0] = new SqlParameter("@nom_user", SqlDbType.VarChar, 50);
            arParam[0].Value = nom_user;

            DataTable tabla = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TEST_Listar_Filtro", arParam);

            List<UsuarioEL> lista = new List<UsuarioEL>();
            lista = Util.ConvertDataTable<UsuarioEL>(tabla);

            return lista;
        }

        public List<UsuarioEL> TEST_Listar_Filtro(string nom_usuario, string nom_user, string perfil, int id_empleado)
        {
            SqlParameter[] arParam = new SqlParameter[4];

            arParam[0] = new SqlParameter("@nom_usuario", SqlDbType.VarChar, 50);
            arParam[0].Value = nom_usuario;

            arParam[1] = new SqlParameter("@nom_user", SqlDbType.VarChar, 50);
            arParam[1].Value = nom_user;

            arParam[2] = new SqlParameter("@perfil", SqlDbType.VarChar, 50);
            arParam[2].Value = perfil;

            arParam[3] = new SqlParameter("@id_empleado", SqlDbType.VarChar, 50);
            arParam[3].Value = id_empleado;

            DataTable tabla = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TEST_Agregar", arParam);

            List<UsuarioEL> lista = new List<UsuarioEL>();
            lista = Util.ConvertDataTable<UsuarioEL>(tabla);

            return lista;
        }

        public List<UsuarioEL> TEST_Eliminar(int id_usuario)
        {
            SqlParameter[] arParam = new SqlParameter[1];

            arParam[0] = new SqlParameter("@id_usuario", SqlDbType.VarChar, 50);
            arParam[0].Value = id_usuario;

            DataTable tabla = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TEST_Eliminar", arParam);

            List<UsuarioEL> lista = new List<UsuarioEL>();
            lista = Util.ConvertDataTable<UsuarioEL>(tabla);

            return lista;
        }

        public List<UsuarioEL> TEST_Editar(int id_usuario)
        {
            SqlParameter[] arParam = new SqlParameter[1];

            arParam[0] = new SqlParameter("@id_usuario", SqlDbType.VarChar, 50);
            arParam[0].Value = id_usuario;
            
            DataTable tabla = SqlServerHelper.ReadTable(SqlServerHelper.cnxSeguridad, CommandType.StoredProcedure, "SEG_Editar_Usuario", arParam);

            List<UsuarioEL> lista = new List<UsuarioEL>();
            lista = Util.ConvertDataTable<UsuarioEL>(tabla);

            return lista;
        }

        public List<UsuarioEL> ValidarUsuario(string user, string pass)
        {
            SqlParameter[] arParams = new SqlParameter[2];

            arParams[0] = new SqlParameter("@usuario", SqlDbType.VarChar,50);
            arParams[0].Value = user;

            arParams[1] = new SqlParameter("@password", SqlDbType.VarChar,50);
            arParams[1].Value = pass;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxSeguridad, CommandType.StoredProcedure, "TM_Validar_Usuario", arParams);

            List<UsuarioEL> lstItem = new List<UsuarioEL>();
            lstItem = Util.ConvertDataTable<UsuarioEL>(dt);

            return lstItem;
        }
        

        public List<UsuarioEL> ActualizarContraseña(string user, string pass,string newpass)
        {
            SqlParameter[] arParams = new SqlParameter[3];

            arParams[0] = new SqlParameter("@usuario", SqlDbType.VarChar, 50);
            arParams[0].Value = user;

            arParams[1] = new SqlParameter("@password", SqlDbType.VarChar, 50);
            arParams[1].Value = pass;

            arParams[2] = new SqlParameter("@newPassword", SqlDbType.VarChar, 50);
            arParams[2].Value = newpass;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxSeguridad, CommandType.StoredProcedure, "SEG_Actualizar_Contraseña", arParams);

            List<UsuarioEL> lstItem = new List<UsuarioEL>();
            lstItem = Util.ConvertDataTable<UsuarioEL>(dt);

            return lstItem;
        }

        public List<UsuarioEL> ActualizarJefatura(int jefatura, int cod_id)
        {
            SqlParameter[] arParams = new SqlParameter[2];

            arParams[0] = new SqlParameter("@cod_jefatura", SqlDbType.Int);
            arParams[0].Value = jefatura;

            arParams[1] = new SqlParameter("@cod_id", SqlDbType.Int);
            arParams[1].Value = cod_id;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Actualizar_Jefatura", arParams);

            List<UsuarioEL> lstItem = new List<UsuarioEL>();
            lstItem = Util.ConvertDataTable<UsuarioEL>(dt);

            return lstItem;
        }
    }
}
