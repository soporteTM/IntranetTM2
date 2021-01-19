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
    public class FactElectronicaDAL
    {
        public List<FactElectronicaEL> Consultar(string Tipo, DateTime FchInicio, DateTime FchFin, string Pref, string Num, int DocEntry, string Estado, string EstadoLegal )
        {
            SqlParameter[] arParam = new SqlParameter[8];

            arParam[0] = new SqlParameter("@FCH_INICIO", SqlDbType.DateTime);
            arParam[0].Value = FchInicio;
            arParam[1] = new SqlParameter("@FCH_FIN", SqlDbType.DateTime);
            arParam[1].Value = FchFin;
            arParam[2] = new SqlParameter("@PREF", SqlDbType.VarChar, 20);
            arParam[2].Value = Pref;
            arParam[3] = new SqlParameter("@NUM", SqlDbType.VarChar, 20);
            arParam[3].Value = Num;
            arParam[4] = new SqlParameter("@DOCENTRY", SqlDbType.Int);
            arParam[4].Value = DocEntry;
            arParam[5] = new SqlParameter("@ESTADO", SqlDbType.VarChar, 50);
            arParam[5].Value = Estado;
            arParam[6] = new SqlParameter("@ESTADO_LEGAL", SqlDbType.VarChar, 50);
            arParam[6].Value = EstadoLegal;
            arParam[7] = new SqlParameter("@TIPO", SqlDbType.VarChar, 10);
            arParam[7].Value = Tipo;


            DataTable tabla = SqlServerHelper.ReadTable(SqlServerHelper.CnxFepe, CommandType.StoredProcedure, "FE_Proceso_Consultar", arParam);
            
            List<FactElectronicaEL> lista = new List<FactElectronicaEL>();
            lista = Util.ConvertDataTable<FactElectronicaEL>(tabla);

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
            
            DataTable tabla = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TEST_Editar", arParam);

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

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Actualizar_Contraseña", arParams);

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
