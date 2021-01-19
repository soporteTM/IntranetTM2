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
    public class TarifaDAL
    {
        public List<TarifaEL> ListarTarifa()
        {
            DataTable dt;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Consulta_Tarifa");

            List<TarifaEL> lstItem = new List<TarifaEL>();
            lstItem = Util.ConvertDataTable<TarifaEL>(dt);

            return lstItem;
        }

        public List<TransaccionEL> RegistrarTarifa(TarifaEL oTarifa)
        {

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@id_cliente", SqlDbType.VarChar, 6);
            arParams[0].Value = oTarifa.id_cliente;

            arParams[1] = new SqlParameter("@precio_tarifa_igv", SqlDbType.Decimal);
            arParams[1].Value = oTarifa.precio_tarifa_igv;

            arParams[2] = new SqlParameter("@precio_tarifa_no_igv", SqlDbType.Decimal);
            arParams[2].Value = oTarifa.precio_tarifa_no_igv;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Registro_Tarifa", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }


    }
}
