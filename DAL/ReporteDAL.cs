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
    public class ReporteDAL
    {
        public DataTable ReporteSeguimiento(string contenedor, string placa, int empresa, string fchIni, string fchFin, string emp)
        {
            SqlParameter[] arParams = new SqlParameter[6];
            arParams[0] = new SqlParameter("@CONTENEDOR", SqlDbType.VarChar, 20);
            arParams[0].Value = contenedor;
            arParams[1] = new SqlParameter("@PLACA", SqlDbType.VarChar, 10);
            arParams[1].Value = placa;
            arParams[2] = new SqlParameter("@EMPRESA", SqlDbType.Int);
            arParams[2].Value = empresa;
            arParams[3] = new SqlParameter("@FECINI", SqlDbType.VarChar, 10);
            arParams[3].Value = fchIni;
            arParams[4] = new SqlParameter("@FECFIN", SqlDbType.VarChar, 10);
            arParams[4].Value = fchFin;
            arParams[5] = new SqlParameter("@EMP", SqlDbType.VarChar, 50);
            arParams[5].Value = emp;
            return SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_Reportes", arParams);
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
