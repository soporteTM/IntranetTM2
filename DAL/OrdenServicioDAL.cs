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
    public class OrdenServicioDAL
    {
        public List<TransaccionEL> RegistrarServicio(OrdenServicioEL oServicio)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@id_orden", SqlDbType.Int);
            arParams[0].Value = oServicio.id_orden;

            arParams[1] = new SqlParameter("@cod_servicio", SqlDbType.VarChar,6);
            arParams[1].Value = oServicio.cod_servicio;

            arParams[2] = new SqlParameter("@costo", SqlDbType.Decimal);
            arParams[2].Value = oServicio.costo;

            arParams[3] = new SqlParameter("@obs", SqlDbType.VarChar,100);
            arParams[3].Value = oServicio.obs;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Registrar_Servicio", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<OrdenServicioEL> ListarServicioOT(int id_orden)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];

            arParams[0] = new SqlParameter("@id_orden", SqlDbType.Int);
            arParams[0].Value = id_orden;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Servicio_Consultar",arParams);

            List<OrdenServicioEL> lstItem = new List<OrdenServicioEL>();
            lstItem = Util.ConvertDataTable<OrdenServicioEL>(dt);

            return lstItem;
        }
    }
}
