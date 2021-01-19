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
    public class EstadisticaDAL
    {
        //public List<EstadisticaEL> ReporteTotal(string operacion,string puerto,string finalizado)
        //{
        //    SqlParameter[] arParams = new SqlParameter[3];

        //    arParams[0] = new SqlParameter("@operacion", SqlDbType.VarChar, 3);
        //    arParams[0].Value = operacion;

        //    arParams[1] = new SqlParameter("@puerto", SqlDbType.VarChar,3);
        //    arParams[1].Value = puerto ;

        //    arParams[2] = new SqlParameter("@finalizado", SqlDbType.VarChar, 1);
        //    arParams[2].Value = finalizado;

        //    //arParams[1] = new SqlParameter("@nro_placa", SqlDbType.VarChar, 10);
        //    //arParams[1].Value = nro_placa;

        //    DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_op, CommandType.StoredProcedure, "SP_EST_Operativo",arParams);

        //    List<EstadisticaEL> lstItem = new List<EstadisticaEL>();
        //    lstItem = Util.ConvertDataTable<EstadisticaEL>(dt);

        //    return lstItem;
        //}

        //public List<EtdPuertoEL> ReportePuerto()
        //{

        //    DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_op, CommandType.StoredProcedure, "SP_EST_Operativo_Puerto");

        //    List<EtdPuertoEL> lstItem = new List<EtdPuertoEL>();
        //    lstItem = Util.ConvertDataTable<EtdPuertoEL>(dt);

        //    return lstItem;
        //}

        //public List<EtdGeneralEL> ReporteGeneral()
        //{

        //    DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_op, CommandType.StoredProcedure, "SP_EST_Operativo_General");

        //    List<EtdGeneralEL> lstItem = new List<EtdGeneralEL>();
        //    lstItem = Util.ConvertDataTable<EtdGeneralEL>(dt);

        //    return lstItem;
        //}
    }
}
