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
    public class EstadisticaOPDAL
    {
        public List<EstadisticasServiciosOP> ReporteServicios(EstadisticaOPEL estadisticasOP)
        {
            SqlParameter[] arParams = new SqlParameter[2];

            arParams[0] = new SqlParameter("@fchInicio", SqlDbType.Date);
            arParams[0].Value = estadisticasOP.fchIni;

            arParams[1] = new SqlParameter("@fchFin", SqlDbType.Date);
            arParams[1].Value = estadisticasOP.fchFin;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OPS_EST_Servicios2", arParams);

            List<EstadisticasServiciosOP> lstItem = new List<EstadisticasServiciosOP>();
            lstItem = Util.ConvertDataTable<EstadisticasServiciosOP>(dt);

            return lstItem;
        }

        public List<EstadisticasTercerosOP> ReporteTerceros(EstadisticaOPEL estadisticasOP)
        {
            SqlParameter[] arParams = new SqlParameter[2];

            arParams[0] = new SqlParameter("@fchInicio", SqlDbType.Date);
            arParams[0].Value = estadisticasOP.fchIni;

            arParams[1] = new SqlParameter("@fchFin", SqlDbType.Date);
            arParams[1].Value = estadisticasOP.fchFin;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OPS_EST_PropioTercero_Servicios2", arParams);

            List<EstadisticasTercerosOP> lstItem = new List<EstadisticasTercerosOP>();
            lstItem = Util.ConvertDataTable<EstadisticasTercerosOP>(dt);

            return lstItem;
        }
    }
}
