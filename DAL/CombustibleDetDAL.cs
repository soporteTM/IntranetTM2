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
    public class CombustibleDetDAL
    {
        public List<TransaccionEL> Registar_Detalle(CombustibleDetEL oDet)
        {

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[14];
            arParams[0] = new SqlParameter("@id_cabecera", SqlDbType.Int);
            arParams[0].Value = oDet.id_cabecera;

            arParams[1] = new SqlParameter("@nro_placa", SqlDbType.VarChar, 50);
            arParams[1].Value = oDet.nro_placa;

            arParams[2] = new SqlParameter("@nom_cliente", SqlDbType.VarChar, 200);
            arParams[2].Value = oDet.nom_cliente;

            arParams[3] = new SqlParameter("@c_costo", SqlDbType.VarChar, 50);
            arParams[3].Value = oDet.c_costo;
            
            arParams[4] = new SqlParameter("@cod_eess", SqlDbType.VarChar, 50);
            arParams[4].Value = oDet.cod_eess;

            arParams[5] = new SqlParameter("@nom_eess", SqlDbType.VarChar, 50);
            arParams[5].Value = oDet.nom_eess;

            arParams[6] = new SqlParameter("@fch_documento", SqlDbType.VarChar, 50);
            arParams[6].Value = oDet.fch_documento;

            arParams[7] = new SqlParameter("@num_documento", SqlDbType.VarChar, 50);
            arParams[7].Value = oDet.num_documento;

            arParams[8] = new SqlParameter("@cantidad", SqlDbType.Decimal);
            arParams[8].Value = oDet.cantidad;

            arParams[9] = new SqlParameter("@precio_sin_igv", SqlDbType.Decimal);
            arParams[9].Value = oDet.precio_sin_igv;

            arParams[10] = new SqlParameter("@precio_con_igv", SqlDbType.Decimal);
            arParams[10].Value = oDet.precio_con_igv;

            arParams[11] = new SqlParameter("@monto_sin_igv", SqlDbType.Decimal);
            arParams[11].Value = oDet.monto_sin_igv;

            arParams[12] = new SqlParameter("@monto_con_igv", SqlDbType.Decimal);
            arParams[12].Value = oDet.monto_con_igv;

            arParams[13] = new SqlParameter("@Kilometraje", SqlDbType.VarChar,100);
            arParams[13].Value = oDet.Kilometraje;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Insertar_Combustible_Detalle", arParams);
            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<CombustibleDetEL> Listar_Detalle(int id_cabecera)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id_cabecera", SqlDbType.Int);
            arParams[0].Value = id_cabecera;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Listar_Combustible", arParams);
            List<CombustibleDetEL> lstItem = new List<CombustibleDetEL>();
            lstItem = Util.ConvertDataTable<CombustibleDetEL>(dt);

            return lstItem;
        }
    }
}
