using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using EL;
using System.Threading.Tasks;
using System.Data;
using SQLHelper;

namespace DAL
{
    public class AlertaDAL
    {
        public List<AlertaEL> ListarAlertas(string ale_perfil, string ale_perfil2)
        {
            SqlParameter[] arParams = new SqlParameter[2];

            arParams[0] = new SqlParameter("@ale_perfil", SqlDbType.VarChar, 6);
            arParams[0].Value = ale_perfil;

            arParams[1] = new SqlParameter("@ale_perfil2", SqlDbType.VarChar, 6);
            arParams[1].Value = ale_perfil2;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Alertas_Listar",arParams);

            List<AlertaEL> lstItem = new List<AlertaEL>();
            lstItem = Util.ConvertDataTable<AlertaEL>(dt);

            return lstItem;
        }

        public List<AlertaEL> ActualizarAlertas(string ale_perfil)
        {
            SqlParameter[] arParams = new SqlParameter[1];

            arParams[0] = new SqlParameter("@ale_perfil", SqlDbType.VarChar, 6);
            arParams[0].Value = ale_perfil;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Alertas_Estado", arParams);

            List<AlertaEL> lstItem = new List<AlertaEL>();
            lstItem = Util.ConvertDataTable<AlertaEL>(dt);

            return lstItem;
        }


    }
}
